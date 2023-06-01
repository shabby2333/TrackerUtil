using QBittorrent.Client;
using System;
using System.Windows.Forms;

namespace QbTrackerUtil
{
    public partial class Form1 : Form
    {

        private QBittorrentClient _client = null;
        private bool _login = false;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            _client = new QBittorrentClient(new Uri(tbQbUrl.Text));
            try
            {
                await _client.LoginAsync(tbUsername.Text, tbPassword.Text);
                _login = true;

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
                    _login = false;
                    btnReplace.Enabled = false;
                    MessageBox.Show(ex.Message);
                }));
            }

        }

        private async void btnReplace_Click(object sender, EventArgs e)
        {
            var passkey = tbPasskey.Text;

            var torrentList = await _client.GetTorrentListAsync();
            Invoke(new Action(() =>
            {
                tbLog.AppendText($"请求种子列表成功，共{torrentList.Count}个种子\n");
            }));
            var successCount = 0;
            var failCount = 0;
            foreach (var torrent in torrentList)
            {
                var trackerList = await _client.GetTorrentTrackersAsync(torrent.Hash);
                foreach (var tracker in trackerList)
                {
                    if (tracker.Url.IsAbsoluteUri && tracker.Url.Host.Contains("hdtime.org"))
                    {
                        try
                        {
                            await _client.EditTrackerAsync(torrent.Hash, tracker.Url, new Uri($"https://tracker.hdtime.org/announce.php?passkey={passkey}"));

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
    }
}
