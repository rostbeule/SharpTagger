namespace Tagger
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabCtrlOptions = new System.Windows.Forms.TabControl();
            this.TabPageOptions1 = new System.Windows.Forms.TabPage();
            this.ChkBackup = new System.Windows.Forms.CheckBox();
            this.CmdBrowsePathToBackup = new System.Windows.Forms.Button();
            this.LblPathToBackup = new System.Windows.Forms.Label();
            this.TxtPathToBackup = new System.Windows.Forms.TextBox();
            this.CmdSaveOptionsPage1 = new System.Windows.Forms.Button();
            this.CmdBrowsePathToLib = new System.Windows.Forms.Button();
            this.LblPathToLib = new System.Windows.Forms.Label();
            this.TxtPathToLib = new System.Windows.Forms.TextBox();
            this.CmdCloseOptionsPage1 = new System.Windows.Forms.Button();
            this.TabPageOptions2 = new System.Windows.Forms.TabPage();
            this.LblPathToFile = new System.Windows.Forms.Label();
            this.ChkPathToFile = new System.Windows.Forms.CheckBox();
            this.GrpOptionsMetadata = new System.Windows.Forms.GroupBox();
            this.ChkDiscCount = new System.Windows.Forms.CheckBox();
            this.ChkDisc = new System.Windows.Forms.CheckBox();
            this.ChkComment = new System.Windows.Forms.CheckBox();
            this.ChkAmazonId = new System.Windows.Forms.CheckBox();
            this.ChkComposers = new System.Windows.Forms.CheckBox();
            this.ChkCover = new System.Windows.Forms.CheckBox();
            this.ChkGenres = new System.Windows.Forms.CheckBox();
            this.ChkYear = new System.Windows.Forms.CheckBox();
            this.ChkTrack = new System.Windows.Forms.CheckBox();
            this.ChkTitle = new System.Windows.Forms.CheckBox();
            this.ChkAlbum = new System.Windows.Forms.CheckBox();
            this.ChkAlbumArtists = new System.Windows.Forms.CheckBox();
            this.ChkArtists = new System.Windows.Forms.CheckBox();
            this.CmdSaveOptionsPage2 = new System.Windows.Forms.Button();
            this.CmdCloseOptionsPage2 = new System.Windows.Forms.Button();
            this.TabPageOptions3 = new System.Windows.Forms.TabPage();
            this.CmdSaveOptionsPage3 = new System.Windows.Forms.Button();
            this.CmdCloseOptionsPage3 = new System.Windows.Forms.Button();
            this.TabCtrlOptions.SuspendLayout();
            this.TabPageOptions1.SuspendLayout();
            this.TabPageOptions2.SuspendLayout();
            this.GrpOptionsMetadata.SuspendLayout();
            this.TabPageOptions3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabCtrlOptions
            // 
            this.TabCtrlOptions.Controls.Add(this.TabPageOptions1);
            this.TabCtrlOptions.Controls.Add(this.TabPageOptions2);
            this.TabCtrlOptions.Controls.Add(this.TabPageOptions3);
            this.TabCtrlOptions.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabCtrlOptions.Location = new System.Drawing.Point(12, 12);
            this.TabCtrlOptions.Name = "TabCtrlOptions";
            this.TabCtrlOptions.SelectedIndex = 0;
            this.TabCtrlOptions.Size = new System.Drawing.Size(626, 346);
            this.TabCtrlOptions.TabIndex = 0;
            // 
            // TabPageOptions1
            // 
            this.TabPageOptions1.Controls.Add(this.ChkBackup);
            this.TabPageOptions1.Controls.Add(this.CmdBrowsePathToBackup);
            this.TabPageOptions1.Controls.Add(this.LblPathToBackup);
            this.TabPageOptions1.Controls.Add(this.TxtPathToBackup);
            this.TabPageOptions1.Controls.Add(this.CmdSaveOptionsPage1);
            this.TabPageOptions1.Controls.Add(this.CmdBrowsePathToLib);
            this.TabPageOptions1.Controls.Add(this.LblPathToLib);
            this.TabPageOptions1.Controls.Add(this.TxtPathToLib);
            this.TabPageOptions1.Controls.Add(this.CmdCloseOptionsPage1);
            this.TabPageOptions1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPageOptions1.Location = new System.Drawing.Point(4, 29);
            this.TabPageOptions1.Name = "TabPageOptions1";
            this.TabPageOptions1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageOptions1.Size = new System.Drawing.Size(618, 313);
            this.TabPageOptions1.TabIndex = 0;
            this.TabPageOptions1.Text = "Allgemein";
            this.TabPageOptions1.UseVisualStyleBackColor = true;
            // 
            // ChkBackup
            // 
            this.ChkBackup.AutoSize = true;
            this.ChkBackup.Location = new System.Drawing.Point(158, 94);
            this.ChkBackup.Name = "ChkBackup";
            this.ChkBackup.Size = new System.Drawing.Size(369, 23);
            this.ChkBackup.TabIndex = 3;
            this.ChkBackup.Text = "&Erstellt beim Schreiben Wiederherstellungspunkt";
            this.ChkBackup.UseVisualStyleBackColor = true;
            this.ChkBackup.CheckedChanged += new System.EventHandler(this.ChkBackup_CheckedChanged);
            // 
            // CmdBrowsePathToBackup
            // 
            this.CmdBrowsePathToBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CmdBrowsePathToBackup.Image = global::Tagger.Properties.Resources.folder;
            this.CmdBrowsePathToBackup.Location = new System.Drawing.Point(532, 123);
            this.CmdBrowsePathToBackup.Name = "CmdBrowsePathToBackup";
            this.CmdBrowsePathToBackup.Size = new System.Drawing.Size(26, 26);
            this.CmdBrowsePathToBackup.TabIndex = 5;
            this.CmdBrowsePathToBackup.UseVisualStyleBackColor = true;
            this.CmdBrowsePathToBackup.Click += new System.EventHandler(this.CmdBrowsePath_Click);
            // 
            // LblPathToBackup
            // 
            this.LblPathToBackup.AutoSize = true;
            this.LblPathToBackup.Location = new System.Drawing.Point(74, 126);
            this.LblPathToBackup.Name = "LblPathToBackup";
            this.LblPathToBackup.Size = new System.Drawing.Size(59, 19);
            this.LblPathToBackup.TabIndex = 7;
            this.LblPathToBackup.Text = "B&ackup";
            // 
            // TxtPathToBackup
            // 
            this.TxtPathToBackup.BackColor = System.Drawing.SystemColors.Window;
            this.TxtPathToBackup.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TxtPathToBackup.Location = new System.Drawing.Point(158, 123);
            this.TxtPathToBackup.Name = "TxtPathToBackup";
            this.TxtPathToBackup.Size = new System.Drawing.Size(370, 27);
            this.TxtPathToBackup.TabIndex = 4;
            this.TxtPathToBackup.TextChanged += new System.EventHandler(this.PathSelection_TextChanged);
            // 
            // CmdSaveOptionsPage1
            // 
            this.CmdSaveOptionsPage1.Enabled = false;
            this.CmdSaveOptionsPage1.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSaveOptionsPage1.Location = new System.Drawing.Point(390, 276);
            this.CmdSaveOptionsPage1.Name = "CmdSaveOptionsPage1";
            this.CmdSaveOptionsPage1.Size = new System.Drawing.Size(108, 31);
            this.CmdSaveOptionsPage1.TabIndex = 6;
            this.CmdSaveOptionsPage1.Text = "&Speichern";
            this.CmdSaveOptionsPage1.UseVisualStyleBackColor = true;
            this.CmdSaveOptionsPage1.Click += new System.EventHandler(this.CmdSaveOptionsPage1_Click);
            // 
            // CmdBrowsePathToLib
            // 
            this.CmdBrowsePathToLib.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CmdBrowsePathToLib.Image = global::Tagger.Properties.Resources.folder;
            this.CmdBrowsePathToLib.Location = new System.Drawing.Point(532, 48);
            this.CmdBrowsePathToLib.Name = "CmdBrowsePathToLib";
            this.CmdBrowsePathToLib.Size = new System.Drawing.Size(26, 26);
            this.CmdBrowsePathToLib.TabIndex = 2;
            this.CmdBrowsePathToLib.UseVisualStyleBackColor = true;
            this.CmdBrowsePathToLib.Click += new System.EventHandler(this.CmdBrowsePath_Click);
            // 
            // LblPathToLib
            // 
            this.LblPathToLib.AutoSize = true;
            this.LblPathToLib.Location = new System.Drawing.Point(74, 51);
            this.LblPathToLib.Name = "LblPathToLib";
            this.LblPathToLib.Size = new System.Drawing.Size(78, 19);
            this.LblPathToLib.TabIndex = 2;
            this.LblPathToLib.Text = "&Bibliothek";
            // 
            // TxtPathToLib
            // 
            this.TxtPathToLib.BackColor = System.Drawing.SystemColors.Window;
            this.TxtPathToLib.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TxtPathToLib.Location = new System.Drawing.Point(158, 48);
            this.TxtPathToLib.Name = "TxtPathToLib";
            this.TxtPathToLib.Size = new System.Drawing.Size(370, 27);
            this.TxtPathToLib.TabIndex = 1;
            this.TxtPathToLib.TextChanged += new System.EventHandler(this.PathSelection_TextChanged);
            // 
            // CmdCloseOptionsPage1
            // 
            this.CmdCloseOptionsPage1.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCloseOptionsPage1.Location = new System.Drawing.Point(504, 276);
            this.CmdCloseOptionsPage1.Name = "CmdCloseOptionsPage1";
            this.CmdCloseOptionsPage1.Size = new System.Drawing.Size(108, 31);
            this.CmdCloseOptionsPage1.TabIndex = 7;
            this.CmdCloseOptionsPage1.Text = "Sch&ließen";
            this.CmdCloseOptionsPage1.UseVisualStyleBackColor = true;
            this.CmdCloseOptionsPage1.Click += new System.EventHandler(this.CmdCloseOptions_Click);
            // 
            // TabPageOptions2
            // 
            this.TabPageOptions2.Controls.Add(this.LblPathToFile);
            this.TabPageOptions2.Controls.Add(this.ChkPathToFile);
            this.TabPageOptions2.Controls.Add(this.GrpOptionsMetadata);
            this.TabPageOptions2.Controls.Add(this.CmdSaveOptionsPage2);
            this.TabPageOptions2.Controls.Add(this.CmdCloseOptionsPage2);
            this.TabPageOptions2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPageOptions2.Location = new System.Drawing.Point(4, 29);
            this.TabPageOptions2.Name = "TabPageOptions2";
            this.TabPageOptions2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageOptions2.Size = new System.Drawing.Size(618, 313);
            this.TabPageOptions2.TabIndex = 1;
            this.TabPageOptions2.Text = "Tag Style";
            this.TabPageOptions2.UseVisualStyleBackColor = true;
            // 
            // LblPathToFile
            // 
            this.LblPathToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPathToFile.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LblPathToFile.Location = new System.Drawing.Point(31, 274);
            this.LblPathToFile.Name = "LblPathToFile";
            this.LblPathToFile.Size = new System.Drawing.Size(262, 31);
            this.LblPathToFile.TabIndex = 8;
            this.LblPathToFile.Text = "* nur Ausgabe-Information - wird automatisch gesetzt,    wenn keine Tag-Info ausg" +
    "ewählt wurde";
            // 
            // ChkPathToFile
            // 
            this.ChkPathToFile.AutoSize = true;
            this.ChkPathToFile.Location = new System.Drawing.Point(33, 248);
            this.ChkPathToFile.Name = "ChkPathToFile";
            this.ChkPathToFile.Size = new System.Drawing.Size(211, 24);
            this.ChkPathToFile.TabIndex = 7;
            this.ChkPathToFile.Text = "Pfadangabe einbeziehen*";
            this.ChkPathToFile.UseVisualStyleBackColor = true;
            this.ChkPathToFile.CheckedChanged += new System.EventHandler(this.MetadataSelection_CheckChanged);
            // 
            // GrpOptionsMetadata
            // 
            this.GrpOptionsMetadata.Controls.Add(this.ChkDiscCount);
            this.GrpOptionsMetadata.Controls.Add(this.ChkDisc);
            this.GrpOptionsMetadata.Controls.Add(this.ChkComment);
            this.GrpOptionsMetadata.Controls.Add(this.ChkAmazonId);
            this.GrpOptionsMetadata.Controls.Add(this.ChkComposers);
            this.GrpOptionsMetadata.Controls.Add(this.ChkCover);
            this.GrpOptionsMetadata.Controls.Add(this.ChkGenres);
            this.GrpOptionsMetadata.Controls.Add(this.ChkYear);
            this.GrpOptionsMetadata.Controls.Add(this.ChkTrack);
            this.GrpOptionsMetadata.Controls.Add(this.ChkTitle);
            this.GrpOptionsMetadata.Controls.Add(this.ChkAlbum);
            this.GrpOptionsMetadata.Controls.Add(this.ChkAlbumArtists);
            this.GrpOptionsMetadata.Controls.Add(this.ChkArtists);
            this.GrpOptionsMetadata.Location = new System.Drawing.Point(22, 16);
            this.GrpOptionsMetadata.Name = "GrpOptionsMetadata";
            this.GrpOptionsMetadata.Size = new System.Drawing.Size(571, 223);
            this.GrpOptionsMetadata.TabIndex = 1;
            this.GrpOptionsMetadata.TabStop = false;
            this.GrpOptionsMetadata.Text = "Metadaten";
            // 
            // ChkDiscCount
            // 
            this.ChkDiscCount.AutoSize = true;
            this.ChkDiscCount.Location = new System.Drawing.Point(370, 36);
            this.ChkDiscCount.Name = "ChkDiscCount";
            this.ChkDiscCount.Size = new System.Drawing.Size(112, 24);
            this.ChkDiscCount.TabIndex = 12;
            this.ChkDiscCount.Text = "Anzahl CDs";
            this.ChkDiscCount.UseVisualStyleBackColor = true;
            this.ChkDiscCount.CheckedChanged += new System.EventHandler(this.MetadataSelection_CheckChanged);
            // 
            // ChkDisc
            // 
            this.ChkDisc.AutoSize = true;
            this.ChkDisc.Location = new System.Drawing.Point(211, 186);
            this.ChkDisc.Name = "ChkDisc";
            this.ChkDisc.Size = new System.Drawing.Size(116, 24);
            this.ChkDisc.TabIndex = 11;
            this.ChkDisc.Text = "CD-Nummer";
            this.ChkDisc.UseVisualStyleBackColor = true;
            this.ChkDisc.CheckedChanged += new System.EventHandler(this.MetadataSelection_CheckChanged);
            // 
            // ChkComment
            // 
            this.ChkComment.AutoSize = true;
            this.ChkComment.Location = new System.Drawing.Point(211, 126);
            this.ChkComment.Name = "ChkComment";
            this.ChkComment.Size = new System.Drawing.Size(119, 24);
            this.ChkComment.TabIndex = 10;
            this.ChkComment.Text = "Kommentare";
            this.ChkComment.UseVisualStyleBackColor = true;
            this.ChkComment.CheckedChanged += new System.EventHandler(this.MetadataSelection_CheckChanged);
            // 
            // ChkAmazonId
            // 
            this.ChkAmazonId.AutoSize = true;
            this.ChkAmazonId.Location = new System.Drawing.Point(211, 96);
            this.ChkAmazonId.Name = "ChkAmazonId";
            this.ChkAmazonId.Size = new System.Drawing.Size(105, 24);
            this.ChkAmazonId.TabIndex = 9;
            this.ChkAmazonId.Text = "Amazon Id";
            this.ChkAmazonId.UseVisualStyleBackColor = true;
            this.ChkAmazonId.CheckedChanged += new System.EventHandler(this.MetadataSelection_CheckChanged);
            // 
            // ChkComposers
            // 
            this.ChkComposers.AutoSize = true;
            this.ChkComposers.Location = new System.Drawing.Point(211, 156);
            this.ChkComposers.Name = "ChkComposers";
            this.ChkComposers.Size = new System.Drawing.Size(121, 24);
            this.ChkComposers.TabIndex = 8;
            this.ChkComposers.Text = "Komponisten";
            this.ChkComposers.UseVisualStyleBackColor = true;
            this.ChkComposers.CheckedChanged += new System.EventHandler(this.MetadataSelection_CheckChanged);
            // 
            // ChkCover
            // 
            this.ChkCover.AutoSize = true;
            this.ChkCover.Location = new System.Drawing.Point(211, 66);
            this.ChkCover.Name = "ChkCover";
            this.ChkCover.Size = new System.Drawing.Size(119, 24);
            this.ChkCover.TabIndex = 7;
            this.ChkCover.Text = "Album-Cover";
            this.ChkCover.UseVisualStyleBackColor = true;
            this.ChkCover.CheckedChanged += new System.EventHandler(this.MetadataSelection_CheckChanged);
            // 
            // ChkGenres
            // 
            this.ChkGenres.AutoSize = true;
            this.ChkGenres.Location = new System.Drawing.Point(211, 36);
            this.ChkGenres.Name = "ChkGenres";
            this.ChkGenres.Size = new System.Drawing.Size(73, 24);
            this.ChkGenres.TabIndex = 6;
            this.ChkGenres.Text = "Genre";
            this.ChkGenres.UseVisualStyleBackColor = true;
            this.ChkGenres.CheckedChanged += new System.EventHandler(this.MetadataSelection_CheckChanged);
            // 
            // ChkYear
            // 
            this.ChkYear.AutoSize = true;
            this.ChkYear.Location = new System.Drawing.Point(11, 186);
            this.ChkYear.Name = "ChkYear";
            this.ChkYear.Size = new System.Drawing.Size(161, 24);
            this.ChkYear.TabIndex = 5;
            this.ChkYear.Text = "Erscheinungs-Jahr";
            this.ChkYear.UseVisualStyleBackColor = true;
            this.ChkYear.CheckedChanged += new System.EventHandler(this.MetadataSelection_CheckChanged);
            // 
            // ChkTrack
            // 
            this.ChkTrack.AutoSize = true;
            this.ChkTrack.Location = new System.Drawing.Point(11, 156);
            this.ChkTrack.Name = "ChkTrack";
            this.ChkTrack.Size = new System.Drawing.Size(122, 24);
            this.ChkTrack.TabIndex = 4;
            this.ChkTrack.Text = "Titel-Nummer";
            this.ChkTrack.UseVisualStyleBackColor = true;
            this.ChkTrack.CheckedChanged += new System.EventHandler(this.MetadataSelection_CheckChanged);
            // 
            // ChkTitle
            // 
            this.ChkTitle.AutoSize = true;
            this.ChkTitle.Location = new System.Drawing.Point(11, 126);
            this.ChkTitle.Name = "ChkTitle";
            this.ChkTitle.Size = new System.Drawing.Size(57, 24);
            this.ChkTitle.TabIndex = 3;
            this.ChkTitle.Text = "Titel";
            this.ChkTitle.UseVisualStyleBackColor = true;
            this.ChkTitle.CheckedChanged += new System.EventHandler(this.MetadataSelection_CheckChanged);
            // 
            // ChkAlbum
            // 
            this.ChkAlbum.AutoSize = true;
            this.ChkAlbum.Location = new System.Drawing.Point(11, 96);
            this.ChkAlbum.Name = "ChkAlbum";
            this.ChkAlbum.Size = new System.Drawing.Size(73, 24);
            this.ChkAlbum.TabIndex = 2;
            this.ChkAlbum.Text = "Album";
            this.ChkAlbum.UseVisualStyleBackColor = true;
            this.ChkAlbum.CheckedChanged += new System.EventHandler(this.MetadataSelection_CheckChanged);
            // 
            // ChkAlbumArtists
            // 
            this.ChkAlbumArtists.AutoSize = true;
            this.ChkAlbumArtists.Location = new System.Drawing.Point(11, 66);
            this.ChkAlbumArtists.Name = "ChkAlbumArtists";
            this.ChkAlbumArtists.Size = new System.Drawing.Size(167, 24);
            this.ChkAlbumArtists.TabIndex = 1;
            this.ChkAlbumArtists.Text = "Album-Interpret(en)";
            this.ChkAlbumArtists.UseVisualStyleBackColor = true;
            this.ChkAlbumArtists.CheckedChanged += new System.EventHandler(this.MetadataSelection_CheckChanged);
            // 
            // ChkArtists
            // 
            this.ChkArtists.AutoSize = true;
            this.ChkArtists.Location = new System.Drawing.Point(11, 36);
            this.ChkArtists.Name = "ChkArtists";
            this.ChkArtists.Size = new System.Drawing.Size(117, 24);
            this.ChkArtists.TabIndex = 0;
            this.ChkArtists.Text = "Interpret(en)";
            this.ChkArtists.UseVisualStyleBackColor = true;
            this.ChkArtists.CheckedChanged += new System.EventHandler(this.MetadataSelection_CheckChanged);
            // 
            // CmdSaveOptionsPage2
            // 
            this.CmdSaveOptionsPage2.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSaveOptionsPage2.Location = new System.Drawing.Point(390, 276);
            this.CmdSaveOptionsPage2.Name = "CmdSaveOptionsPage2";
            this.CmdSaveOptionsPage2.Size = new System.Drawing.Size(108, 31);
            this.CmdSaveOptionsPage2.TabIndex = 6;
            this.CmdSaveOptionsPage2.Text = "Speichern";
            this.CmdSaveOptionsPage2.UseVisualStyleBackColor = true;
            this.CmdSaveOptionsPage2.Click += new System.EventHandler(this.CmdSaveOptionsPage2_Click);
            // 
            // CmdCloseOptionsPage2
            // 
            this.CmdCloseOptionsPage2.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCloseOptionsPage2.Location = new System.Drawing.Point(504, 276);
            this.CmdCloseOptionsPage2.Name = "CmdCloseOptionsPage2";
            this.CmdCloseOptionsPage2.Size = new System.Drawing.Size(108, 31);
            this.CmdCloseOptionsPage2.TabIndex = 1;
            this.CmdCloseOptionsPage2.Text = "Schließen";
            this.CmdCloseOptionsPage2.UseVisualStyleBackColor = true;
            this.CmdCloseOptionsPage2.Click += new System.EventHandler(this.CmdCloseOptions_Click);
            // 
            // TabPageOptions3
            // 
            this.TabPageOptions3.Controls.Add(this.CmdSaveOptionsPage3);
            this.TabPageOptions3.Controls.Add(this.CmdCloseOptionsPage3);
            this.TabPageOptions3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPageOptions3.Location = new System.Drawing.Point(4, 29);
            this.TabPageOptions3.Name = "TabPageOptions3";
            this.TabPageOptions3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageOptions3.Size = new System.Drawing.Size(618, 313);
            this.TabPageOptions3.TabIndex = 2;
            this.TabPageOptions3.Text = "DataBase";
            this.TabPageOptions3.UseVisualStyleBackColor = true;
            // 
            // CmdSaveOptionsPage3
            // 
            this.CmdSaveOptionsPage3.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSaveOptionsPage3.Location = new System.Drawing.Point(390, 276);
            this.CmdSaveOptionsPage3.Name = "CmdSaveOptionsPage3";
            this.CmdSaveOptionsPage3.Size = new System.Drawing.Size(108, 31);
            this.CmdSaveOptionsPage3.TabIndex = 6;
            this.CmdSaveOptionsPage3.Text = "Speichern";
            this.CmdSaveOptionsPage3.UseVisualStyleBackColor = true;
            // 
            // CmdCloseOptionsPage3
            // 
            this.CmdCloseOptionsPage3.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCloseOptionsPage3.Location = new System.Drawing.Point(504, 276);
            this.CmdCloseOptionsPage3.Name = "CmdCloseOptionsPage3";
            this.CmdCloseOptionsPage3.Size = new System.Drawing.Size(108, 31);
            this.CmdCloseOptionsPage3.TabIndex = 2;
            this.CmdCloseOptionsPage3.Text = "Schließen";
            this.CmdCloseOptionsPage3.UseVisualStyleBackColor = true;
            this.CmdCloseOptionsPage3.Click += new System.EventHandler(this.CmdCloseOptions_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(650, 370);
            this.Controls.Add(this.TabCtrlOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Options";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.TabCtrlOptions.ResumeLayout(false);
            this.TabPageOptions1.ResumeLayout(false);
            this.TabPageOptions1.PerformLayout();
            this.TabPageOptions2.ResumeLayout(false);
            this.TabPageOptions2.PerformLayout();
            this.GrpOptionsMetadata.ResumeLayout(false);
            this.GrpOptionsMetadata.PerformLayout();
            this.TabPageOptions3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabCtrlOptions;
        private System.Windows.Forms.TabPage TabPageOptions1;
        private System.Windows.Forms.TabPage TabPageOptions2;
        private System.Windows.Forms.Button CmdCloseOptionsPage1;
        private System.Windows.Forms.Button CmdCloseOptionsPage2;
        private System.Windows.Forms.TabPage TabPageOptions3;
        private System.Windows.Forms.Button CmdCloseOptionsPage3;
        private System.Windows.Forms.Label LblPathToLib;
        private System.Windows.Forms.TextBox TxtPathToLib;
        private System.Windows.Forms.Button CmdBrowsePathToLib;
        private System.Windows.Forms.Button CmdSaveOptionsPage1;
        private System.Windows.Forms.Button CmdSaveOptionsPage2;
        private System.Windows.Forms.Button CmdSaveOptionsPage3;
        private System.Windows.Forms.GroupBox GrpOptionsMetadata;
        private System.Windows.Forms.CheckBox ChkGenres;
        private System.Windows.Forms.CheckBox ChkYear;
        private System.Windows.Forms.CheckBox ChkTrack;
        private System.Windows.Forms.CheckBox ChkTitle;
        private System.Windows.Forms.CheckBox ChkAlbum;
        private System.Windows.Forms.CheckBox ChkAlbumArtists;
        private System.Windows.Forms.CheckBox ChkArtists;
        private System.Windows.Forms.Button CmdBrowsePathToBackup;
        private System.Windows.Forms.Label LblPathToBackup;
        private System.Windows.Forms.TextBox TxtPathToBackup;
        private System.Windows.Forms.CheckBox ChkBackup;
        private System.Windows.Forms.Label LblPathToFile;
        private System.Windows.Forms.CheckBox ChkPathToFile;
        private System.Windows.Forms.CheckBox ChkCover;
        private System.Windows.Forms.CheckBox ChkComposers;
        private System.Windows.Forms.CheckBox ChkComment;
        private System.Windows.Forms.CheckBox ChkAmazonId;
        private System.Windows.Forms.CheckBox ChkDisc;
        private System.Windows.Forms.CheckBox ChkDiscCount;
    }
}