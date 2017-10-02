using NativeWifi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlashAir {
    class Program {

        static MainForm window;
        static System.Windows.Forms.NotifyIcon icon;

        static Thread SyncThread;
        static System.Threading.Timer timer;

        static Settings settings;

        static WlanClient wlan_client;
        static WlanClient.WlanInterface wlan_intr;


        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();

            OpenMainWindow();

            settings = new Settings();
            wlan_client = new WlanClient();

            wlan_intr = wlan_client.Interfaces[0];
            wlan_intr.WlanNotification += WlanNotification;

            ContextMenuStrip menu = new System.Windows.Forms.ContextMenuStrip();
            menu.Items.Add("Abrir control...", null, OpenWindow);
            menu.Items.Add("Salir", null, CloseProgram);

            icon = new NotifyIcon();
            icon.Icon = window.Icon;
            icon.Text = "FlashAir Control se ejecuta en segundo plano.";
            icon.ContextMenuStrip = menu;
            icon.MouseDoubleClick += IconClick;
            icon.Visible = true;

            StartSyncAuto();
            NetworkChange.NetworkAvailabilityChanged += NetChange;

            Application.Run();
            }

        #region UI

        static void OpenMainWindow() {
            window = new MainForm();
            window.mi_start_sync.Click += BtnStartSync;
            window.mi_stop_sync.Click += BtnStopSync;
            window.mi_commands.DropDownOpened += MenuUpdate;
            window.cb_auto_sync.Click += SyncAutoChange;
            window.Closed += WindowClose;
            window.Show();
            }

        private static void OpenWindow(object sender, EventArgs e) {
            OpenMainWindow();
            }

        private static void WindowClose(object sender, EventArgs e) {

            window = null;
            icon.ShowBalloonTip(2000, "FlashAir Control", "El sincronizador se ejecuta en segundo plano.", System.Windows.Forms.ToolTipIcon.Info);
            }

        private static void NetChange(object sender, NetworkAvailabilityEventArgs e) {
            if(e.IsAvailable) {
                try {
                    WebClient wc = new WebClient();
                    string ssid = wc.DownloadString("http://flashair/command.cgi?op=104");
                    if(bool.Parse(settings["sync_auto"])) {
                        StartSyncAuto();
                        icon.ShowBalloonTip(2000, "La SD " + ssid + " fue detectada",
                        "Iniciando sincronización.", System.Windows.Forms.ToolTipIcon.Info);
                        } else {
                        icon.ShowBalloonTip(10000, "La SD " + ssid + " fue detectada",
                          "No se copiarán datos de la SD, la sincronización automática está desactivada.",
                          System.Windows.Forms.ToolTipIcon.Warning);
                        }
                    } catch(WebException) {

                    }
                } else {
                if(wlan_intr.InterfaceState == Wlan.WlanInterfaceState.Disconnected
                  || GetSsidString(wlan_intr.CurrentConnection.wlanAssociationAttributes.dot11Ssid) != settings["card_ssid"]) {
                    wlan_intr.Scan();
                    }
                }
            }

        public static void WlanNotification(Wlan.WlanNotificationData notifyData) {

            switch((Wlan.WlanNotificationCodeAcm) notifyData.NotificationCode) {

                case Wlan.WlanNotificationCodeAcm.ScanComplete:
                    foreach(Wlan.WlanAvailableNetwork net in wlan_intr.GetAvailableNetworkList(Wlan.WlanGetAvailableNetworkFlags.IncludeAllAdhocProfiles)) {
                        if(GetSsidString(net.dot11Ssid) == settings["card_ssid"]) {
                            wlan_client.Interfaces[0].Connect(Wlan.WlanConnectionMode.Auto, Wlan.Dot11BssType.Any, net.dot11Ssid, Wlan.WlanConnectionFlags.HiddenNetwork);
                            break;
                            }
                        }
                    break;
                }
            }

        private static void IconClick(object sender, EventArgs e) {
            OpenMainWindow();
            }

        private static void SyncAutoChange(object sender, EventArgs e) {
            CheckBox cb = sender as CheckBox;
            if(cb.Checked == true) {
                settings["sync_auto"] = "true";
                StartSyncAuto();
                } else {
                settings["sync_auto"] = "false";
                }
            }

        private static void MenuUpdate(object sender, EventArgs e) {
            ToolStripMenuItem container = (ToolStripMenuItem) sender;
            ToolStripMenuItem start = (ToolStripMenuItem) container.DropDownItems[0];
            ToolStripMenuItem stop = (ToolStripMenuItem) container.DropDownItems[0];

            if(settings["sync_auto"] == "true") {
                start.Enabled = false;
                stop.Enabled = false;
                } else if(isSync()) {
                start.Enabled = false;
                stop.Enabled = true;
                } else {
                start.Enabled = true;
                stop.Enabled = false;
                }
            }

        private static void BtnStartSync(object sender, EventArgs e) {
            if(Controller.Available()) {
                StartSync();
                } else {
                MessageBox.Show("No se pudo establecer conexión con la SD, comprueba que está conectada.", "SD No Conectada",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        private static void BtnStopSync(object sender, EventArgs e) {
            StopSync();
            }

        #endregion

        #region Sync

        /**<summary>Starts the timer that makes the sicronization</summary> */
        static void StartSyncAuto() {
            if(timer == null && bool.Parse(settings["sync_auto"])) {
                timer = new System.Threading.Timer(SyncAuto, null, 0, int.Parse(settings["sync_time"]));
                }
            }

        /**<summary>Callback for StartSyncAuto() timer</summary>*/
        private static void SyncAuto(object state) {
            if(bool.Parse(settings["sync_auto"])) {
                if(isSync() == false) {
                    if(Controller.Available()) {
                        StartSync();
                        } else if(wlan_intr.InterfaceState == Wlan.WlanInterfaceState.Disconnected
                          || GetSsidString(wlan_intr.CurrentConnection.wlanAssociationAttributes.dot11Ssid) != settings["card_ssid"]) {
                        wlan_intr.Scan();
                        }
                    }
                } else {
                timer.Dispose();
                timer = null;
                }
            }


        /**<summary>Starts the syncrhoization</summary>*/
        public static void StartSync() {
            SyncThread = new Thread(new ThreadStart(SyncThreadAction));
            SyncThread.Start();
            }

        /**<summary>Stops the syncrhoization</summary>*/
        public static void StopSync() {
            SyncThread.Abort();
            SyncThread = null;
            }

        /**<summary>Makes the actual syncrhoization</summary>*/
        public static void SyncThreadAction() {
            Controller ct = new Controller();
            ct.Sincronize();
            }

        /**<summary>Determines if the sync is ongoing</summary>*/
        public static bool isSync() {
            if(SyncThread == null
              || SyncThread.ThreadState == ThreadState.Stopped
              || SyncThread.ThreadState == ThreadState.Suspended
              || SyncThread.ThreadState == ThreadState.Unstarted) {
                return false;
                }
            return true;
            }

        #endregion

        public static string GetSsidString(Wlan.Dot11Ssid org) {
            return Encoding.ASCII.GetString(org.SSID, 0, (int) org.SSIDLength);
            }

        private static void CloseProgram(object sender, EventArgs e) {
            if(isSync())
                StopSync();
            Application.Exit();
            }



        }
    }