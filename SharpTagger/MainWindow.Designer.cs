namespace Tagger
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MnuCmdData = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCmdOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCmdDataAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.nAToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuCmdDataClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCmdOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCmdArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.nAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCmdBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.nAToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuCmdOptionsAdjustments = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCmdMaehhr = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCmdInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.TrvLibrary = new System.Windows.Forms.TreeView();
            this.PanSheep = new System.Windows.Forms.Panel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.statusStrip1.Location = new System.Drawing.Point(0, 655);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1260, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.MenuStrip.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuCmdData,
            this.MnuCmdOptions,
            this.MnuCmdMaehhr});
            this.MenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1260, 28);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // MnuCmdData
            // 
            this.MnuCmdData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuCmdOpen,
            this.MnuCmdDataAdd,
            this.toolStripSeparator1,
            this.MnuCmdDataClose});
            this.MnuCmdData.Name = "MnuCmdData";
            this.MnuCmdData.Size = new System.Drawing.Size(68, 24);
            this.MnuCmdData.Text = "&Datei";
            // 
            // MnuCmdOpen
            // 
            this.MnuCmdOpen.Name = "MnuCmdOpen";
            this.MnuCmdOpen.Size = new System.Drawing.Size(179, 24);
            this.MnuCmdOpen.Text = "Ö&ffnen";
            this.MnuCmdOpen.Click += new System.EventHandler(this.MnuCmdOpen_Click);
            // 
            // MnuCmdDataAdd
            // 
            this.MnuCmdDataAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nAToolStripMenuItem2});
            this.MnuCmdDataAdd.Name = "MnuCmdDataAdd";
            this.MnuCmdDataAdd.Size = new System.Drawing.Size(179, 24);
            this.MnuCmdDataAdd.Text = "&Hinzufügen";
            // 
            // nAToolStripMenuItem2
            // 
            this.nAToolStripMenuItem2.Name = "nAToolStripMenuItem2";
            this.nAToolStripMenuItem2.Size = new System.Drawing.Size(118, 24);
            this.nAToolStripMenuItem2.Text = "(N/A)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // MnuCmdDataClose
            // 
            this.MnuCmdDataClose.Name = "MnuCmdDataClose";
            this.MnuCmdDataClose.Size = new System.Drawing.Size(179, 24);
            this.MnuCmdDataClose.Text = "&Beenden";
            this.MnuCmdDataClose.Click += new System.EventHandler(this.MnuCmdDataClose_Click);
            // 
            // MnuCmdOptions
            // 
            this.MnuCmdOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuCmdArchive,
            this.MnuCmdBackup,
            this.toolStripSeparator2,
            this.MnuCmdOptionsAdjustments});
            this.MnuCmdOptions.Name = "MnuCmdOptions";
            this.MnuCmdOptions.Size = new System.Drawing.Size(103, 24);
            this.MnuCmdOptions.Text = "&Optionen";
            // 
            // MnuCmdArchive
            // 
            this.MnuCmdArchive.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nAToolStripMenuItem});
            this.MnuCmdArchive.Name = "MnuCmdArchive";
            this.MnuCmdArchive.Size = new System.Drawing.Size(242, 24);
            this.MnuCmdArchive.Text = "Archiv verwalten";
            // 
            // nAToolStripMenuItem
            // 
            this.nAToolStripMenuItem.Name = "nAToolStripMenuItem";
            this.nAToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.nAToolStripMenuItem.Text = "(N/A)";
            // 
            // MnuCmdBackup
            // 
            this.MnuCmdBackup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nAToolStripMenuItem1});
            this.MnuCmdBackup.Name = "MnuCmdBackup";
            this.MnuCmdBackup.Size = new System.Drawing.Size(242, 24);
            this.MnuCmdBackup.Text = "Backup verwalten";
            // 
            // nAToolStripMenuItem1
            // 
            this.nAToolStripMenuItem1.Name = "nAToolStripMenuItem1";
            this.nAToolStripMenuItem1.Size = new System.Drawing.Size(118, 24);
            this.nAToolStripMenuItem1.Text = "(N/A)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(239, 6);
            // 
            // MnuCmdOptionsAdjustments
            // 
            this.MnuCmdOptionsAdjustments.BackgroundImage = global::Tagger.Properties.Resources.sheep_with_headphones_640;
            this.MnuCmdOptionsAdjustments.Name = "MnuCmdOptionsAdjustments";
            this.MnuCmdOptionsAdjustments.Size = new System.Drawing.Size(242, 24);
            this.MnuCmdOptionsAdjustments.Text = "&Einstellungen";
            this.MnuCmdOptionsAdjustments.Click += new System.EventHandler(this.MnuCmdOptionsAdjustments_Click);
            // 
            // MnuCmdMaehhr
            // 
            this.MnuCmdMaehhr.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuCmdInfo});
            this.MnuCmdMaehhr.Name = "MnuCmdMaehhr";
            this.MnuCmdMaehhr.Size = new System.Drawing.Size(91, 24);
            this.MnuCmdMaehhr.Text = "&Mähhr..";
            // 
            // MnuCmdInfo
            // 
            this.MnuCmdInfo.Name = "MnuCmdInfo";
            this.MnuCmdInfo.Size = new System.Drawing.Size(159, 24);
            this.MnuCmdInfo.Text = "Info (N/A)";
            // 
            // TrvLibrary
            // 
            this.TrvLibrary.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TrvLibrary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TrvLibrary.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrvLibrary.Location = new System.Drawing.Point(12, 34);
            this.TrvLibrary.Name = "TrvLibrary";
            this.TrvLibrary.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TrvLibrary.ShowLines = false;
            this.TrvLibrary.ShowPlusMinus = false;
            this.TrvLibrary.Size = new System.Drawing.Size(1280, 575);
            this.TrvLibrary.TabIndex = 2;
            this.TrvLibrary.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TrvLibrary_BeforeExpand);
            this.TrvLibrary.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TrvLibrary_NodeMouseDoubleClick);
            // 
            // PanSheep
            // 
            this.PanSheep.BackColor = System.Drawing.Color.Transparent;
            this.PanSheep.BackgroundImage = global::Tagger.Properties.Resources.sheep_with_headphones_640;
            this.PanSheep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PanSheep.Location = new System.Drawing.Point(420, 80);
            this.PanSheep.Name = "PanSheep";
            this.PanSheep.Size = new System.Drawing.Size(700, 515);
            this.PanSheep.TabIndex = 3;
            // 
            // Timer
            // 
            this.Timer.Interval = 2000;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1260, 26);
            this.panel1.TabIndex = 4;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1260, 677);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanSheep);
            this.Controls.Add(this.TrvLibrary);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MenuStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "SharpTagger";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MnuCmdData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MnuCmdDataClose;
        private System.Windows.Forms.ToolStripMenuItem MnuCmdOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MnuCmdOptionsAdjustments;
        private System.Windows.Forms.ToolStripMenuItem MnuCmdMaehhr;
        private System.Windows.Forms.TreeView TrvLibrary;
        private System.Windows.Forms.Panel PanSheep;
        private System.Windows.Forms.ToolStripMenuItem MnuCmdDataAdd;
        private System.Windows.Forms.ToolStripMenuItem MnuCmdArchive;
        private System.Windows.Forms.ToolStripMenuItem MnuCmdBackup;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem MnuCmdOpen;
        private System.Windows.Forms.ToolStripMenuItem nAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nAToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MnuCmdInfo;
        private System.Windows.Forms.ToolStripMenuItem nAToolStripMenuItem2;
    }
}

