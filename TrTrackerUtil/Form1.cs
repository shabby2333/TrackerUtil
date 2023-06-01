using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transmission.API.RPC;
using Transmission.API.RPC.Entity;

namespace QbTrackerUtil
{
    public partial class Form1 : Form
    {

        private Client _client = null;
        private bool _login = false;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPassword.Text))
                _client = new Client(tbQbUrl.Text, "PARAM_SESSION_ID", tbUsername.Text, tbPassword.Text);
            else
                _client = new Client(tbQbUrl.Text);
            try
            {
                var sessionInfo = _client.GetSessionInformation();
                await Console.Out.WriteLineAsync($"{await _client.PortTestAsync()}");

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

            var torrentList = await _client.TorrentGetAsync(TorrentFields.ALL_FIELDS);


            var successCount = 0;
            var failCount = 0;
            foreach (var torrent in torrentList.Torrents)
            {
                var trackerList = torrent.Trackers;
                foreach (var tracker in trackerList)
                {
                    if (tracker.announce.Contains("hdtime.org"))
                    {
                        try
                        {
                            //await _client.EditTrackerAsync(torrent.Hash, tracker.Url, new Uri($"https://tracker.hdtime.org/announce.php?passkey={passkey}"));
                            _client.TorrentSet(new Transmission.API.RPC.Arguments.TorrentSettings
                            {
                                IDs = new object[] { torrent.ID },
                                TrackerRemove = new int[] { tracker.ID }
                            });

                            _client.TorrentSet(new Transmission.API.RPC.Arguments.TorrentSettings
                            {
                                IDs = new object[] { torrent.ID },
                                TrackerAdd = new string[] { $"https://tracker.hdtime.org/announce.php?passkey={passkey}" }
                            });

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
        }
    }
}
