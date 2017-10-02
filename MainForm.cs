using NativeWifi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlashAir {
    public partial class MainForm:Form {

        Settings settings;
        public long[] mega = new long[8000000];

        public MainForm() {
            InitializeComponent();

            for(int c = 0; c<mega.Length; c++) {
                mega[c]= 9223372036854775807;
                }


            settings = new Settings();

            tb_sync_path.Text = settings["sync_path"];
            tb_sync_path.TextChanged += SyncPath;
            btn_exam.Click += BrowseSyncPath;

            tb_root_dir.Text = settings["root_dir"];
            tb_root_dir.TextChanged += RootDir;

            cb_auto_sync.Checked = bool.Parse(settings["sync_auto"]);
            cb_auto_sync.CheckedChanged += AutoSync;

            tb_sync_time.Text = settings["sync_time"];
            tb_sync_time.TextChanged += SyncTime;

            tb_card_ssid.Text = settings["card_ssid"];
            tb_card_ssid.TextChanged += CardSsid;

            btn_open.Click += OpenSyncPath;

            mi_config_card.Click += ConfigCard;
            mi_about.Click += OpenAbout;
            }

        #region settings load

        private void SyncPath(object sender, EventArgs e) {
            settings["sync_path"] = tb_sync_path.Text;
            }

        private void RootDir(object sender, EventArgs e) {
            settings["root_dir"] = tb_root_dir.Text;
            }

        private void SyncTime(object sender, EventArgs e) {
            settings["sync_time"] = tb_sync_time.Text;
            }

        private void CardSsid(object sender, EventArgs e) {
            settings["card_ssid"] = tb_card_ssid.Text;
            }

        private void AutoSync(object sender, EventArgs e) {
            settings["sync_auto"] = cb_auto_sync.Checked.ToString().ToLower();
            }

        #endregion

        private void BrowseSyncPath(object sender, EventArgs e) {
            FolderBrowserDialog bd = new FolderBrowserDialog();
            bd.ShowDialog();
            if(bd.SelectedPath != null && bd.SelectedPath != "") {
                tb_sync_path.Text = bd.SelectedPath;
                }
            }

        private void OpenSyncPath(object sender, EventArgs e) {
            if(Directory.Exists(settings["sync_path"]) == false) {
                Directory.CreateDirectory(settings["sync_path"]);
                }
            System.Diagnostics.Process.Start(settings["sync_path"]);
            }

        private void ConfigCard(object sender, EventArgs e) {
            System.Windows.MessageBox.Show("Esta característica todavía no está disponible.");
            }

        private void OpenAbout(object sender, EventArgs e) {
            new AboutBox().Show();
            }

        }
    }
