namespace FlashAir {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && ( components != null )) {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mi_commands = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_start_sync = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_stop_sync = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mn_open_output_folder = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_config_card = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_about = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_sync_path = new System.Windows.Forms.TextBox();
            this.tb_root_dir = new System.Windows.Forms.TextBox();
            this.cb_auto_sync = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_sync_time = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_card_ssid = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btn_exam = new System.Windows.Forms.Button();
            this.btn_open = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_commands,
            this.herramientasToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mi_commands
            // 
            this.mi_commands.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_start_sync,
            this.mi_stop_sync,
            this.toolStripSeparator1,
            this.mn_open_output_folder});
            this.mi_commands.Name = "mi_commands";
            this.mi_commands.Size = new System.Drawing.Size(77, 20);
            this.mi_commands.Text = "Comandos";
            // 
            // mi_start_sincro
            // 
            this.mi_start_sync.Name = "mi_start_sincro";
            this.mi_start_sync.Size = new System.Drawing.Size(194, 22);
            this.mi_start_sync.Text = "Sincronizar ahora";
            // 
            // mi_stop_sincro
            // 
            this.mi_stop_sync.Name = "mi_stop_sincro";
            this.mi_stop_sync.Size = new System.Drawing.Size(194, 22);
            this.mi_stop_sync.Text = "Detener sincronizacion";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // mn_open_output_folder
            // 
            this.mn_open_output_folder.Name = "mn_open_output_folder";
            this.mn_open_output_folder.Size = new System.Drawing.Size(194, 22);
            this.mn_open_output_folder.Text = "Abrir carpeta de salida";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_config_card});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // mi_config_card
            // 
            this.mi_config_card.Name = "mi_config_card";
            this.mi_config_card.Size = new System.Drawing.Size(180, 22);
            this.mi_config_card.Text = "Configurar targeta...";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_about});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // mi_about
            // 
            this.mi_about.Name = "mi_about";
            this.mi_about.Size = new System.Drawing.Size(135, 22);
            this.mi_about.Text = "Acerca de...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sincronizar con el directorio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Directorio raiz:";
            // 
            // tb_sync_path
            // 
            this.tb_sync_path.Location = new System.Drawing.Point(15, 54);
            this.tb_sync_path.Name = "tb_sync_path";
            this.tb_sync_path.Size = new System.Drawing.Size(300, 20);
            this.tb_sync_path.TabIndex = 3;
            // 
            // tb_root_dir
            // 
            this.tb_root_dir.Location = new System.Drawing.Point(15, 107);
            this.tb_root_dir.Name = "tb_root_dir";
            this.tb_root_dir.Size = new System.Drawing.Size(200, 20);
            this.tb_root_dir.TabIndex = 4;
            // 
            // cb_auto_sync
            // 
            this.cb_auto_sync.AutoSize = true;
            this.cb_auto_sync.Location = new System.Drawing.Point(13, 147);
            this.cb_auto_sync.Name = "cb_auto_sync";
            this.cb_auto_sync.Size = new System.Drawing.Size(162, 17);
            this.cb_auto_sync.TabIndex = 6;
            this.cb_auto_sync.Text = "Sincronizar automaticamente";
            this.cb_auto_sync.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sincronizar cada:";
            // 
            // tb_sync_time
            // 
            this.tb_sync_time.Location = new System.Drawing.Point(115, 170);
            this.tb_sync_time.Name = "tb_sync_time";
            this.tb_sync_time.Size = new System.Drawing.Size(60, 20);
            this.tb_sync_time.TabIndex = 8;
            this.tb_sync_time.Text = "10000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 173);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "ms";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "SSID de la targeta:";
            // 
            // tb_card_ssid
            // 
            this.tb_card_ssid.Location = new System.Drawing.Point(123, 196);
            this.tb_card_ssid.Name = "tb_card_ssid";
            this.tb_card_ssid.Size = new System.Drawing.Size(100, 20);
            this.tb_card_ssid.TabIndex = 11;
            this.tb_card_ssid.Text = "FlashAir";
            // 
            // btn_exam
            // 
            this.btn_exam.Location = new System.Drawing.Point(321, 52);
            this.btn_exam.Name = "btn_exam";
            this.btn_exam.Size = new System.Drawing.Size(75, 23);
            this.btn_exam.TabIndex = 12;
            this.btn_exam.Text = "Examinar...";
            this.btn_exam.UseVisualStyleBackColor = true;
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(402, 51);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(43, 23);
            this.btn_open.TabIndex = 13;
            this.btn_open.Text = "Abrir";
            this.btn_open.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.btn_exam);
            this.Controls.Add(this.tb_card_ssid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_sync_time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_auto_sync);
            this.Controls.Add(this.tb_root_dir);
            this.Controls.Add(this.tb_sync_path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "FlashAir Control";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource bindingSource1;
        public System.Windows.Forms.TextBox tb_sync_path;
        public System.Windows.Forms.TextBox tb_root_dir;
        public System.Windows.Forms.ToolStripMenuItem mi_commands;
        public System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        public System.Windows.Forms.CheckBox cb_auto_sync;
        public System.Windows.Forms.TextBox tb_sync_time;
        public System.Windows.Forms.TextBox tb_card_ssid;
        public System.Windows.Forms.ToolStripMenuItem mi_start_sync;
        public System.Windows.Forms.ToolStripMenuItem mi_stop_sync;
        public System.Windows.Forms.ToolStripMenuItem mn_open_output_folder;
        public System.Windows.Forms.ToolStripMenuItem mi_config_card;
        public System.Windows.Forms.ToolStripMenuItem mi_about;
        private System.Windows.Forms.Button btn_exam;
        private System.Windows.Forms.Button btn_open;
        }
    }