using QBittorrent.Client;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transmission.API.RPC;
using Transmission.API.RPC.Entity;

namespace QbTrackerUtil
{
    public partial class Form1 : Form
    {

        private QBittorrentClient _qbClient = null;
        private Client _trClient = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            switch (cbType.SelectedItem)
            {
                case "qBitorrent":
                    qbLogin();
                    break;
                case "transmission":
                    trLogin();
                    break;
                default:
                    break;
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            switch (cbType.SelectedItem)
            {
                case "qBitorrent":
                    qbReplace();
                    break;
                case "transmission":
                    trReplace();
                    break;
                default:
                    break;
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbType.SelectedText)
            {
                case "qBitorrent":
                    tbUrl.Text = "http://localhost:8080";
                    break;
                case "transmission":
                    tbUrl.Text = "http://localhost:9091/transmission/rpc";
                    break;
                default:
                    break;
            }

            btnReplace.Enabled = false;
        }
        private async void qbLogin()
        {
            _qbClient = new QBittorrentClient(new Uri(tbUrl.Text));
            try
            {
                await _qbClient.LoginAsync(tbUsername.Text, tbPassword.Text);

                Invoke(new Action(() =>
                {
                    btnReplace.Enabled = true;
                    tbLog.AppendText("登录成功\n");
                }));
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    btnReplace.Enabled = false;
                    MessageBox.Show(ex.Message);
                }));
            }
        }

        private async void trLogin()
        {

            if (!string.IsNullOrEmpty(tbPassword.Text))
                _trClient = new Client(tbUrl.Text, "PARAM_SESSION_ID", tbUsername.Text, tbPassword.Text);
            else
                _trClient = new Client(tbUrl.Text);
            try
            {
                var sessionInfo = _trClient.GetSessionInformation();
                await Console.Out.WriteLineAsync($"{await _trClient.PortTestAsync()}");


                Invoke(new Action(() =>
                {
                    btnReplace.Enabled = true;
                    tbLog.AppendText("登录成功\n");
                }));
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    btnReplace.Enabled = false;
                    MessageBox.Show(ex.Message);
                }));
            }
        }
        private async void qbReplace()
        {
            var replaceUrl = tbReplaceDomain.Text;
            var targetUrl = tbTargetUrl.Text;

            var torrentList = await _qbClient.GetTorrentListAsync();
            Invoke(new Action(() =>
            {
                tbLog.AppendText($"请求种子列表成功，共{torrentList.Count}个种子\n");
            }));
            var successCount = 0;
            var failCount = 0;
            foreach (var torrent in torrentList)
            {
                var trackerList = await _qbClient.GetTorrentTrackersAsync(torrent.Hash);
                foreach (var tracker in trackerList)
                {
                    if (tracker.Url.IsAbsoluteUri && tracker.Url.Host.Contains(replaceUrl))
                    {
                        try
                        {
                            await _qbClient.EditTrackerAsync(torrent.Hash, tracker.Url, new Uri(targetUrl));

                            successCount++;
                            Invoke(new Action(() =>
                            {
                                tbLog.AppendText($"将[{torrent.Name}]中的tracker[{tracker.Url}]替换成功\n");
                            }));
                        }
                        catch
                        {
                            failCount++;
                            Invoke(new Action(() =>
                            {
                                tbLog.AppendText($"将[{torrent.Name}]中的tracker[{tracker.Url}]替换失败\n");
                            }));
                        }

                    }
                }
            }

            Invoke(new Action(() =>
            {
                tbLog.AppendText($"替换完成,成功{successCount}个，失败{failCount}个\n");
            }));

        }

        private async void trReplace()
        {
            var replaceUrl = tbReplaceDomain.Text;
            var targetUrl = tbTargetUrl.Text;

            await Task.Run(new Action(async () =>
            {
                var torrentList = await _trClient.TorrentGetAsync(new string[] {
                TorrentFields.ID,
                TorrentFields.FILES,
                TorrentFields.NAME,
                TorrentFields.TRACKERS,
                TorrentFields.HASH_STRING
            });


                var successCount = 0;
                var failCount = 0;
                foreach (var torrent in torrentList.Torrents)
                {
                    var trackerList = torrent.Trackers;
                    foreach (var tracker in trackerList)
                    {
                        if (tracker.announce.Contains(replaceUrl))
                        {
                            try
                            {
                                //await _client.EditTrackerAsync(torrent.Hash, tracker.Url, new Uri($"https://tracker.hdtime.org/announce.php?passkey={passkey}"));
                                _trClient.TorrentSet(new Transmission.API.RPC.Arguments.TorrentSettings
                                {
                                    IDs = new object[] { torrent.ID },
                                    TrackerRemove = new int[] { tracker.ID }
                                });

                                _trClient.TorrentSet(new Transmission.API.RPC.Arguments.TorrentSettings
                                {
                                    IDs = new object[] { torrent.ID },
                                    TrackerAdd = new string[] { targetUrl }
                                });

                                successCount++;

                                Invoke(new Action(() =>
                                {
                                    btnReplace.Enabled = true;
                                    tbLog.AppendText($"将[{torrent.Name}]中的tracker[{tracker.announce}]替换成功\n");
                                }));
                            }
                            catch
                            {
                                failCount++;
                                Invoke(new Action(() =>
                                {
                                    tbLog.AppendText($"将[{torrent.Name}]中的tracker[{tracker.announce}]替换失败\n");
                                }));
                            }
                        }
                    }
                }

                Invoke(new Action(() =>
                {
                    tbLog.AppendText($"替换完成,成功{successCount}个，失败{failCount}个\n");
                }));
            }));
        }


    }

}
