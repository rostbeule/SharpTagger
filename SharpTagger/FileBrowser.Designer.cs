namespace Tagger
{
    partial class FileBrowser
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
            this.LsvFileBrowser = new System.Windows.Forms.ListView();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.TabConFileBrowser = new System.Windows.Forms.TabControl();
            this.TabId3v2 = new System.Windows.Forms.TabPage();
            this.PanButtons_Page1 = new System.Windows.Forms.Panel();
            this.LblLastAction_Page1 = new System.Windows.Forms.Label();
            this.LblAllActions_Page1 = new System.Windows.Forms.Label();
            this.CmdSave_v2Tags = new System.Windows.Forms.Button();
            this.CmdUndoAll_v2Tags = new System.Windows.Forms.Button();
            this.CmdUndoLast_v2Tags = new System.Windows.Forms.Button();
            this.LsvMetaData = new System.Windows.Forms.ListView();
            this.TabId3v1 = new System.Windows.Forms.TabPage();
            this.TxtTrack_v1Tag = new System.Windows.Forms.TextBox();
            this.PanBckGrndBtn_ID3v1 = new System.Windows.Forms.Panel();
            this.LblCopyData_ID3v1 = new System.Windows.Forms.Label();
            this.LblAllChanges_ID3v1 = new System.Windows.Forms.Label();
            this.CmdSave_v1Tags = new System.Windows.Forms.Button();
            this.CmdUndoAll_v1Tags = new System.Windows.Forms.Button();
            this.CmdCopyAll_v1Tags = new System.Windows.Forms.Button();
            this.TxtGenre_v1Tag = new System.Windows.Forms.TextBox();
            this.TxtComment_v1Tag = new System.Windows.Forms.TextBox();
            this.LblComment_v1Tag = new System.Windows.Forms.Label();
            this.TxtTitle_v1Tag = new System.Windows.Forms.TextBox();
            this.TxtYear_v1Tag = new System.Windows.Forms.TextBox();
            this.TxtAlbum_v1Tag = new System.Windows.Forms.TextBox();
            this.LblGenre_v1Tag = new System.Windows.Forms.Label();
            this.LblTrackTitle_v1Tag = new System.Windows.Forms.Label();
            this.LblYear_v1Tag = new System.Windows.Forms.Label();
            this.LblAlbum_v1Tag = new System.Windows.Forms.Label();
            this.LblArtist_v1Tag = new System.Windows.Forms.Label();
            this.TxtArtist_v1Tag = new System.Windows.Forms.TextBox();
            this.PanBckGrndData_ID3v1 = new System.Windows.Forms.Panel();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.TabDesigner = new System.Windows.Forms.TabPage();
            this.PanFileName_Designer = new System.Windows.Forms.Panel();
            this.LblInfo_Designer = new System.Windows.Forms.Label();
            this.CmdCancel_Designer = new System.Windows.Forms.Button();
            this.LblPathToFolder_Designer = new System.Windows.Forms.Label();
            this.CmdDelete_Designer = new System.Windows.Forms.Button();
            this.CmdAddString_Designer = new System.Windows.Forms.Button();
            this.ChkCopyToAll_Designer = new System.Windows.Forms.CheckBox();
            this.CmdAddTag_Designer = new System.Windows.Forms.Button();
            this.PanInfo_Designer = new System.Windows.Forms.Panel();
            this.LblPanInfo_Desiger = new System.Windows.Forms.Label();
            this.ChkYesNo_Designer = new System.Windows.Forms.CheckBox();
            this.PanBckGrndFile_Designer = new System.Windows.Forms.Panel();
            this.TxtFileName_Designer = new System.Windows.Forms.TextBox();
            this.CmdSave_Designer = new System.Windows.Forms.Button();
            this.ChkDeleteAll = new System.Windows.Forms.CheckBox();
            this.PanDeleteAll = new System.Windows.Forms.Panel();
            this.LblCoverInfo = new System.Windows.Forms.Label();
            this.PanCover = new System.Windows.Forms.Panel();
            this.CmdCopyPic = new System.Windows.Forms.Button();
            this.CmdDelPic = new System.Windows.Forms.Button();
            this.CmdLoadPic = new System.Windows.Forms.Button();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.TabConFileBrowser.SuspendLayout();
            this.TabId3v2.SuspendLayout();
            this.PanButtons_Page1.SuspendLayout();
            this.TabId3v1.SuspendLayout();
            this.PanBckGrndBtn_ID3v1.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.TabDesigner.SuspendLayout();
            this.PanFileName_Designer.SuspendLayout();
            this.PanInfo_Designer.SuspendLayout();
            this.PanBckGrndFile_Designer.SuspendLayout();
            this.PanDeleteAll.SuspendLayout();
            this.PanCover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LsvFileBrowser
            // 
            this.LsvFileBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LsvFileBrowser.Location = new System.Drawing.Point(12, 12);
            this.LsvFileBrowser.MultiSelect = false;
            this.LsvFileBrowser.Name = "LsvFileBrowser";
            this.LsvFileBrowser.Size = new System.Drawing.Size(920, 236);
            this.LsvFileBrowser.TabIndex = 0;
            this.LsvFileBrowser.UseCompatibleStateImageBehavior = false;
            this.LsvFileBrowser.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListItemSorter);
            this.LsvFileBrowser.Click += new System.EventHandler(this.LsvFileBrowser_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Location = new System.Drawing.Point(0, 479);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(944, 22);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // TabConFileBrowser
            // 
            this.TabConFileBrowser.Controls.Add(this.TabId3v2);
            this.TabConFileBrowser.Controls.Add(this.TabId3v1);
            this.TabConFileBrowser.Controls.Add(this.TabPage3);
            this.TabConFileBrowser.Controls.Add(this.TabDesigner);
            this.TabConFileBrowser.Location = new System.Drawing.Point(229, 265);
            this.TabConFileBrowser.Name = "TabConFileBrowser";
            this.TabConFileBrowser.SelectedIndex = 0;
            this.TabConFileBrowser.Size = new System.Drawing.Size(703, 200);
            this.TabConFileBrowser.TabIndex = 4;
            this.TabConFileBrowser.SelectedIndexChanged += new System.EventHandler(this.TabConFileBrowser_SelectedIndexChanged);
            // 
            // TabId3v2
            // 
            this.TabId3v2.Controls.Add(this.PanButtons_Page1);
            this.TabId3v2.Controls.Add(this.LsvMetaData);
            this.TabId3v2.Location = new System.Drawing.Point(4, 22);
            this.TabId3v2.Name = "TabId3v2";
            this.TabId3v2.Padding = new System.Windows.Forms.Padding(3);
            this.TabId3v2.Size = new System.Drawing.Size(695, 174);
            this.TabId3v2.TabIndex = 0;
            this.TabId3v2.Text = "ID3v2 TAG";
            this.TabId3v2.UseVisualStyleBackColor = true;
            // 
            // PanButtons_Page1
            // 
            this.PanButtons_Page1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PanButtons_Page1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanButtons_Page1.Controls.Add(this.LblLastAction_Page1);
            this.PanButtons_Page1.Controls.Add(this.LblAllActions_Page1);
            this.PanButtons_Page1.Controls.Add(this.CmdSave_v2Tags);
            this.PanButtons_Page1.Controls.Add(this.CmdUndoAll_v2Tags);
            this.PanButtons_Page1.Controls.Add(this.CmdUndoLast_v2Tags);
            this.PanButtons_Page1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanButtons_Page1.Location = new System.Drawing.Point(499, 0);
            this.PanButtons_Page1.Name = "PanButtons_Page1";
            this.PanButtons_Page1.Size = new System.Drawing.Size(196, 174);
            this.PanButtons_Page1.TabIndex = 19;
            // 
            // LblLastAction_Page1
            // 
            this.LblLastAction_Page1.AutoSize = true;
            this.LblLastAction_Page1.Location = new System.Drawing.Point(57, 23);
            this.LblLastAction_Page1.Name = "LblLastAction_Page1";
            this.LblLastAction_Page1.Size = new System.Drawing.Size(79, 16);
            this.LblLastAction_Page1.TabIndex = 14;
            this.LblLastAction_Page1.Text = "letzte Aktion";
            // 
            // LblAllActions_Page1
            // 
            this.LblAllActions_Page1.AutoSize = true;
            this.LblAllActions_Page1.Location = new System.Drawing.Point(44, 78);
            this.LblAllActions_Page1.Name = "LblAllActions_Page1";
            this.LblAllActions_Page1.Size = new System.Drawing.Size(106, 16);
            this.LblAllActions_Page1.TabIndex = 17;
            this.LblAllActions_Page1.Text = "alle Änderungen";
            // 
            // CmdSave_v2Tags
            // 
            this.CmdSave_v2Tags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSave_v2Tags.Location = new System.Drawing.Point(39, 130);
            this.CmdSave_v2Tags.Name = "CmdSave_v2Tags";
            this.CmdSave_v2Tags.Size = new System.Drawing.Size(116, 30);
            this.CmdSave_v2Tags.TabIndex = 16;
            this.CmdSave_v2Tags.Text = "&Speichern";
            this.CmdSave_v2Tags.UseVisualStyleBackColor = true;
            this.CmdSave_v2Tags.Click += new System.EventHandler(this.CmdWrite_Page1_Click);
            // 
            // CmdUndoAll_v2Tags
            // 
            this.CmdUndoAll_v2Tags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUndoAll_v2Tags.Location = new System.Drawing.Point(39, 94);
            this.CmdUndoAll_v2Tags.Name = "CmdUndoAll_v2Tags";
            this.CmdUndoAll_v2Tags.Size = new System.Drawing.Size(116, 30);
            this.CmdUndoAll_v2Tags.TabIndex = 15;
            this.CmdUndoAll_v2Tags.Text = "&Zurücksetzen";
            this.CmdUndoAll_v2Tags.UseVisualStyleBackColor = true;
            this.CmdUndoAll_v2Tags.Click += new System.EventHandler(this.CmdUndoAll_Page1_Click);
            // 
            // CmdUndoLast_v2Tags
            // 
            this.CmdUndoLast_v2Tags.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmdUndoLast_v2Tags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUndoLast_v2Tags.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdUndoLast_v2Tags.Location = new System.Drawing.Point(39, 39);
            this.CmdUndoLast_v2Tags.Name = "CmdUndoLast_v2Tags";
            this.CmdUndoLast_v2Tags.Size = new System.Drawing.Size(116, 30);
            this.CmdUndoLast_v2Tags.TabIndex = 13;
            this.CmdUndoLast_v2Tags.Text = "&Rückgängig";
            this.CmdUndoLast_v2Tags.UseVisualStyleBackColor = true;
            this.CmdUndoLast_v2Tags.Click += new System.EventHandler(this.CmdUndoStepwise_Click);
            // 
            // LsvMetaData
            // 
            this.LsvMetaData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LsvMetaData.Location = new System.Drawing.Point(0, 0);
            this.LsvMetaData.Name = "LsvMetaData";
            this.LsvMetaData.Size = new System.Drawing.Size(500, 174);
            this.LsvMetaData.TabIndex = 12;
            this.LsvMetaData.UseCompatibleStateImageBehavior = false;
            this.LsvMetaData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LsvMetaData_MouseDoubleClick);
            // 
            // TabId3v1
            // 
            this.TabId3v1.Controls.Add(this.TxtTrack_v1Tag);
            this.TabId3v1.Controls.Add(this.PanBckGrndBtn_ID3v1);
            this.TabId3v1.Controls.Add(this.TxtGenre_v1Tag);
            this.TabId3v1.Controls.Add(this.TxtComment_v1Tag);
            this.TabId3v1.Controls.Add(this.LblComment_v1Tag);
            this.TabId3v1.Controls.Add(this.TxtTitle_v1Tag);
            this.TabId3v1.Controls.Add(this.TxtYear_v1Tag);
            this.TabId3v1.Controls.Add(this.TxtAlbum_v1Tag);
            this.TabId3v1.Controls.Add(this.LblGenre_v1Tag);
            this.TabId3v1.Controls.Add(this.LblTrackTitle_v1Tag);
            this.TabId3v1.Controls.Add(this.LblYear_v1Tag);
            this.TabId3v1.Controls.Add(this.LblAlbum_v1Tag);
            this.TabId3v1.Controls.Add(this.LblArtist_v1Tag);
            this.TabId3v1.Controls.Add(this.TxtArtist_v1Tag);
            this.TabId3v1.Controls.Add(this.PanBckGrndData_ID3v1);
            this.TabId3v1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabId3v1.Location = new System.Drawing.Point(4, 22);
            this.TabId3v1.Name = "TabId3v1";
            this.TabId3v1.Padding = new System.Windows.Forms.Padding(3);
            this.TabId3v1.Size = new System.Drawing.Size(695, 174);
            this.TabId3v1.TabIndex = 1;
            this.TabId3v1.Text = "ID3v1 TAG";
            this.TabId3v1.UseVisualStyleBackColor = true;
            // 
            // TxtTrack_v1Tag
            // 
            this.TxtTrack_v1Tag.Location = new System.Drawing.Point(123, 90);
            this.TxtTrack_v1Tag.Name = "TxtTrack_v1Tag";
            this.TxtTrack_v1Tag.Size = new System.Drawing.Size(33, 22);
            this.TxtTrack_v1Tag.TabIndex = 4;
            this.TxtTrack_v1Tag.TextChanged += new System.EventHandler(this.Tags_TextChanged);
            // 
            // PanBckGrndBtn_ID3v1
            // 
            this.PanBckGrndBtn_ID3v1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PanBckGrndBtn_ID3v1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanBckGrndBtn_ID3v1.Controls.Add(this.LblCopyData_ID3v1);
            this.PanBckGrndBtn_ID3v1.Controls.Add(this.LblAllChanges_ID3v1);
            this.PanBckGrndBtn_ID3v1.Controls.Add(this.CmdSave_v1Tags);
            this.PanBckGrndBtn_ID3v1.Controls.Add(this.CmdUndoAll_v1Tags);
            this.PanBckGrndBtn_ID3v1.Controls.Add(this.CmdCopyAll_v1Tags);
            this.PanBckGrndBtn_ID3v1.Location = new System.Drawing.Point(499, 0);
            this.PanBckGrndBtn_ID3v1.Name = "PanBckGrndBtn_ID3v1";
            this.PanBckGrndBtn_ID3v1.Size = new System.Drawing.Size(196, 174);
            this.PanBckGrndBtn_ID3v1.TabIndex = 24;
            // 
            // LblCopyData_ID3v1
            // 
            this.LblCopyData_ID3v1.AutoSize = true;
            this.LblCopyData_ID3v1.Location = new System.Drawing.Point(44, 23);
            this.LblCopyData_ID3v1.Name = "LblCopyData_ID3v1";
            this.LblCopyData_ID3v1.Size = new System.Drawing.Size(106, 16);
            this.LblCopyData_ID3v1.TabIndex = 14;
            this.LblCopyData_ID3v1.Text = "Daten von ID3v2";
            // 
            // LblAllChanges_ID3v1
            // 
            this.LblAllChanges_ID3v1.AutoSize = true;
            this.LblAllChanges_ID3v1.Location = new System.Drawing.Point(44, 78);
            this.LblAllChanges_ID3v1.Name = "LblAllChanges_ID3v1";
            this.LblAllChanges_ID3v1.Size = new System.Drawing.Size(106, 16);
            this.LblAllChanges_ID3v1.TabIndex = 17;
            this.LblAllChanges_ID3v1.Text = "alle Änderungen";
            // 
            // CmdSave_v1Tags
            // 
            this.CmdSave_v1Tags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSave_v1Tags.Location = new System.Drawing.Point(39, 130);
            this.CmdSave_v1Tags.Name = "CmdSave_v1Tags";
            this.CmdSave_v1Tags.Size = new System.Drawing.Size(116, 30);
            this.CmdSave_v1Tags.TabIndex = 11;
            this.CmdSave_v1Tags.Text = "&Speichern";
            this.CmdSave_v1Tags.UseVisualStyleBackColor = true;
            this.CmdSave_v1Tags.Click += new System.EventHandler(this.CmdSave_v1Tags_Click);
            // 
            // CmdUndoAll_v1Tags
            // 
            this.CmdUndoAll_v1Tags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUndoAll_v1Tags.Location = new System.Drawing.Point(39, 94);
            this.CmdUndoAll_v1Tags.Name = "CmdUndoAll_v1Tags";
            this.CmdUndoAll_v1Tags.Size = new System.Drawing.Size(116, 30);
            this.CmdUndoAll_v1Tags.TabIndex = 10;
            this.CmdUndoAll_v1Tags.Text = "&Zurücksetzen";
            this.CmdUndoAll_v1Tags.UseVisualStyleBackColor = true;
            this.CmdUndoAll_v1Tags.Click += new System.EventHandler(this.CmdUndoAll_v1Tags_Click);
            // 
            // CmdCopyAll_v1Tags
            // 
            this.CmdCopyAll_v1Tags.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmdCopyAll_v1Tags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCopyAll_v1Tags.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCopyAll_v1Tags.Location = new System.Drawing.Point(39, 39);
            this.CmdCopyAll_v1Tags.Name = "CmdCopyAll_v1Tags";
            this.CmdCopyAll_v1Tags.Size = new System.Drawing.Size(116, 30);
            this.CmdCopyAll_v1Tags.TabIndex = 9;
            this.CmdCopyAll_v1Tags.Text = "Übernehmen";
            this.CmdCopyAll_v1Tags.UseVisualStyleBackColor = true;
            this.CmdCopyAll_v1Tags.Click += new System.EventHandler(this.CmdCopyAll_id3v2Tags);
            // 
            // TxtGenre_v1Tag
            // 
            this.TxtGenre_v1Tag.Location = new System.Drawing.Point(123, 116);
            this.TxtGenre_v1Tag.Name = "TxtGenre_v1Tag";
            this.TxtGenre_v1Tag.Size = new System.Drawing.Size(214, 22);
            this.TxtGenre_v1Tag.TabIndex = 6;
            this.TxtGenre_v1Tag.TextChanged += new System.EventHandler(this.Tags_TextChanged);
            // 
            // TxtComment_v1Tag
            // 
            this.TxtComment_v1Tag.Location = new System.Drawing.Point(123, 142);
            this.TxtComment_v1Tag.Name = "TxtComment_v1Tag";
            this.TxtComment_v1Tag.Size = new System.Drawing.Size(214, 22);
            this.TxtComment_v1Tag.TabIndex = 7;
            this.TxtComment_v1Tag.TextChanged += new System.EventHandler(this.Tags_TextChanged);
            // 
            // LblComment_v1Tag
            // 
            this.LblComment_v1Tag.AutoSize = true;
            this.LblComment_v1Tag.Location = new System.Drawing.Point(20, 145);
            this.LblComment_v1Tag.Name = "LblComment_v1Tag";
            this.LblComment_v1Tag.Size = new System.Drawing.Size(76, 16);
            this.LblComment_v1Tag.TabIndex = 17;
            this.LblComment_v1Tag.Text = "Kommentar";
            // 
            // TxtTitle_v1Tag
            // 
            this.TxtTitle_v1Tag.Location = new System.Drawing.Point(162, 90);
            this.TxtTitle_v1Tag.Name = "TxtTitle_v1Tag";
            this.TxtTitle_v1Tag.Size = new System.Drawing.Size(175, 22);
            this.TxtTitle_v1Tag.TabIndex = 5;
            this.TxtTitle_v1Tag.TextChanged += new System.EventHandler(this.Tags_TextChanged);
            // 
            // TxtYear_v1Tag
            // 
            this.TxtYear_v1Tag.Location = new System.Drawing.Point(123, 64);
            this.TxtYear_v1Tag.Name = "TxtYear_v1Tag";
            this.TxtYear_v1Tag.Size = new System.Drawing.Size(214, 22);
            this.TxtYear_v1Tag.TabIndex = 3;
            this.TxtYear_v1Tag.TextChanged += new System.EventHandler(this.Tags_TextChanged);
            // 
            // TxtAlbum_v1Tag
            // 
            this.TxtAlbum_v1Tag.Location = new System.Drawing.Point(123, 38);
            this.TxtAlbum_v1Tag.Name = "TxtAlbum_v1Tag";
            this.TxtAlbum_v1Tag.Size = new System.Drawing.Size(214, 22);
            this.TxtAlbum_v1Tag.TabIndex = 2;
            this.TxtAlbum_v1Tag.TextChanged += new System.EventHandler(this.Tags_TextChanged);
            // 
            // LblGenre_v1Tag
            // 
            this.LblGenre_v1Tag.AutoSize = true;
            this.LblGenre_v1Tag.Location = new System.Drawing.Point(20, 119);
            this.LblGenre_v1Tag.Name = "LblGenre_v1Tag";
            this.LblGenre_v1Tag.Size = new System.Drawing.Size(45, 16);
            this.LblGenre_v1Tag.TabIndex = 18;
            this.LblGenre_v1Tag.Text = "Genre";
            // 
            // LblTrackTitle_v1Tag
            // 
            this.LblTrackTitle_v1Tag.AutoSize = true;
            this.LblTrackTitle_v1Tag.Location = new System.Drawing.Point(20, 93);
            this.LblTrackTitle_v1Tag.Name = "LblTrackTitle_v1Tag";
            this.LblTrackTitle_v1Tag.Size = new System.Drawing.Size(91, 16);
            this.LblTrackTitle_v1Tag.TabIndex = 16;
            this.LblTrackTitle_v1Tag.Text = "Nummer, Titel";
            // 
            // LblYear_v1Tag
            // 
            this.LblYear_v1Tag.AutoSize = true;
            this.LblYear_v1Tag.Location = new System.Drawing.Point(20, 67);
            this.LblYear_v1Tag.Name = "LblYear_v1Tag";
            this.LblYear_v1Tag.Size = new System.Drawing.Size(34, 16);
            this.LblYear_v1Tag.TabIndex = 15;
            this.LblYear_v1Tag.Text = "Jahr";
            // 
            // LblAlbum_v1Tag
            // 
            this.LblAlbum_v1Tag.AutoSize = true;
            this.LblAlbum_v1Tag.Location = new System.Drawing.Point(20, 41);
            this.LblAlbum_v1Tag.Name = "LblAlbum_v1Tag";
            this.LblAlbum_v1Tag.Size = new System.Drawing.Size(46, 16);
            this.LblAlbum_v1Tag.TabIndex = 14;
            this.LblAlbum_v1Tag.Text = "Album";
            // 
            // LblArtist_v1Tag
            // 
            this.LblArtist_v1Tag.AutoSize = true;
            this.LblArtist_v1Tag.Location = new System.Drawing.Point(20, 15);
            this.LblArtist_v1Tag.Name = "LblArtist_v1Tag";
            this.LblArtist_v1Tag.Size = new System.Drawing.Size(37, 16);
            this.LblArtist_v1Tag.TabIndex = 13;
            this.LblArtist_v1Tag.Text = "Artist";
            // 
            // TxtArtist_v1Tag
            // 
            this.TxtArtist_v1Tag.Location = new System.Drawing.Point(123, 12);
            this.TxtArtist_v1Tag.Name = "TxtArtist_v1Tag";
            this.TxtArtist_v1Tag.Size = new System.Drawing.Size(214, 22);
            this.TxtArtist_v1Tag.TabIndex = 1;
            this.TxtArtist_v1Tag.TextChanged += new System.EventHandler(this.Tags_TextChanged);
            // 
            // PanBckGrndData_ID3v1
            // 
            this.PanBckGrndData_ID3v1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanBckGrndData_ID3v1.Location = new System.Drawing.Point(0, 0);
            this.PanBckGrndData_ID3v1.Name = "PanBckGrndData_ID3v1";
            this.PanBckGrndData_ID3v1.Size = new System.Drawing.Size(500, 174);
            this.PanBckGrndData_ID3v1.TabIndex = 25;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.label1);
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(695, 174);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "iTunes MP4 TAG";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aktuell nicht implementiert";
            // 
            // TabDesigner
            // 
            this.TabDesigner.Controls.Add(this.PanFileName_Designer);
            this.TabDesigner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabDesigner.Location = new System.Drawing.Point(4, 22);
            this.TabDesigner.Name = "TabDesigner";
            this.TabDesigner.Padding = new System.Windows.Forms.Padding(3);
            this.TabDesigner.Size = new System.Drawing.Size(695, 174);
            this.TabDesigner.TabIndex = 3;
            this.TabDesigner.Text = "File-Name Designer";
            this.TabDesigner.UseVisualStyleBackColor = true;
            // 
            // PanFileName_Designer
            // 
            this.PanFileName_Designer.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PanFileName_Designer.Controls.Add(this.LblInfo_Designer);
            this.PanFileName_Designer.Controls.Add(this.CmdCancel_Designer);
            this.PanFileName_Designer.Controls.Add(this.LblPathToFolder_Designer);
            this.PanFileName_Designer.Controls.Add(this.CmdDelete_Designer);
            this.PanFileName_Designer.Controls.Add(this.CmdAddString_Designer);
            this.PanFileName_Designer.Controls.Add(this.ChkCopyToAll_Designer);
            this.PanFileName_Designer.Controls.Add(this.CmdAddTag_Designer);
            this.PanFileName_Designer.Controls.Add(this.PanInfo_Designer);
            this.PanFileName_Designer.Controls.Add(this.ChkYesNo_Designer);
            this.PanFileName_Designer.Controls.Add(this.PanBckGrndFile_Designer);
            this.PanFileName_Designer.Location = new System.Drawing.Point(0, 0);
            this.PanFileName_Designer.Name = "PanFileName_Designer";
            this.PanFileName_Designer.Size = new System.Drawing.Size(695, 174);
            this.PanFileName_Designer.TabIndex = 0;
            // 
            // LblInfo_Designer
            // 
            this.LblInfo_Designer.AutoSize = true;
            this.LblInfo_Designer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.LblInfo_Designer.Location = new System.Drawing.Point(23, 40);
            this.LblInfo_Designer.Name = "LblInfo_Designer";
            this.LblInfo_Designer.Size = new System.Drawing.Size(332, 16);
            this.LblInfo_Designer.TabIndex = 17;
            this.LblInfo_Designer.Text = "während der Bearbeitung ist die Titel-Auswahl gesperrt";
            // 
            // CmdCancel_Designer
            // 
            this.CmdCancel_Designer.AutoSize = true;
            this.CmdCancel_Designer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CmdCancel_Designer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCancel_Designer.Location = new System.Drawing.Point(598, 19);
            this.CmdCancel_Designer.Name = "CmdCancel_Designer";
            this.CmdCancel_Designer.Size = new System.Drawing.Size(78, 26);
            this.CmdCancel_Designer.TabIndex = 16;
            this.CmdCancel_Designer.Text = "&Verwerfen";
            this.CmdCancel_Designer.UseVisualStyleBackColor = true;
            this.CmdCancel_Designer.Click += new System.EventHandler(this.CmdCancel_Designer_Click);
            // 
            // LblPathToFolder_Designer
            // 
            this.LblPathToFolder_Designer.AutoSize = true;
            this.LblPathToFolder_Designer.BackColor = System.Drawing.Color.Transparent;
            this.LblPathToFolder_Designer.Location = new System.Drawing.Point(6, 109);
            this.LblPathToFolder_Designer.Name = "LblPathToFolder_Designer";
            this.LblPathToFolder_Designer.Size = new System.Drawing.Size(171, 16);
            this.LblPathToFolder_Designer.TabIndex = 14;
            this.LblPathToFolder_Designer.Text = "LblPathToFolder_Designer";
            // 
            // CmdDelete_Designer
            // 
            this.CmdDelete_Designer.AutoSize = true;
            this.CmdDelete_Designer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CmdDelete_Designer.Location = new System.Drawing.Point(419, 19);
            this.CmdDelete_Designer.Name = "CmdDelete_Designer";
            this.CmdDelete_Designer.Size = new System.Drawing.Size(32, 26);
            this.CmdDelete_Designer.TabIndex = 13;
            this.CmdDelete_Designer.Text = "&<<";
            this.CmdDelete_Designer.UseVisualStyleBackColor = true;
            this.CmdDelete_Designer.Click += new System.EventHandler(this.CmdDelete_Designer_Click);
            // 
            // CmdAddString_Designer
            // 
            this.CmdAddString_Designer.AutoSize = true;
            this.CmdAddString_Designer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CmdAddString_Designer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAddString_Designer.Location = new System.Drawing.Point(516, 19);
            this.CmdAddString_Designer.Name = "CmdAddString_Designer";
            this.CmdAddString_Designer.Size = new System.Drawing.Size(76, 26);
            this.CmdAddString_Designer.TabIndex = 11;
            this.CmdAddString_Designer.Text = "&Zeichen +";
            this.CmdAddString_Designer.UseVisualStyleBackColor = true;
            this.CmdAddString_Designer.Click += new System.EventHandler(this.CmdAddString_Designer_Click);
            // 
            // ChkCopyToAll_Designer
            // 
            this.ChkCopyToAll_Designer.AutoSize = true;
            this.ChkCopyToAll_Designer.Location = new System.Drawing.Point(6, 23);
            this.ChkCopyToAll_Designer.Name = "ChkCopyToAll_Designer";
            this.ChkCopyToAll_Designer.Size = new System.Drawing.Size(299, 20);
            this.ChkCopyToAll_Designer.TabIndex = 10;
            this.ChkCopyToAll_Designer.Text = "Schema auf &alle Dateien im Ordner anwenden";
            this.ChkCopyToAll_Designer.UseVisualStyleBackColor = true;
            this.ChkCopyToAll_Designer.CheckedChanged += new System.EventHandler(this.ChkCopyToAll_Designer_CheckedChanged);
            // 
            // CmdAddTag_Designer
            // 
            this.CmdAddTag_Designer.AutoSize = true;
            this.CmdAddTag_Designer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CmdAddTag_Designer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAddTag_Designer.Location = new System.Drawing.Point(457, 19);
            this.CmdAddTag_Designer.Name = "CmdAddTag_Designer";
            this.CmdAddTag_Designer.Size = new System.Drawing.Size(53, 26);
            this.CmdAddTag_Designer.TabIndex = 9;
            this.CmdAddTag_Designer.Text = "&Tag +";
            this.CmdAddTag_Designer.UseVisualStyleBackColor = true;
            this.CmdAddTag_Designer.Click += new System.EventHandler(this.CmdAddTag_Designer_Click);
            // 
            // PanInfo_Designer
            // 
            this.PanInfo_Designer.BackColor = System.Drawing.SystemColors.Menu;
            this.PanInfo_Designer.Controls.Add(this.LblPanInfo_Desiger);
            this.PanInfo_Designer.Location = new System.Drawing.Point(262, 6);
            this.PanInfo_Designer.Name = "PanInfo_Designer";
            this.PanInfo_Designer.Size = new System.Drawing.Size(93, 20);
            this.PanInfo_Designer.TabIndex = 8;
            // 
            // LblPanInfo_Desiger
            // 
            this.LblPanInfo_Desiger.Location = new System.Drawing.Point(3, 0);
            this.LblPanInfo_Desiger.Name = "LblPanInfo_Desiger";
            this.LblPanInfo_Desiger.Size = new System.Drawing.Size(87, 20);
            this.LblPanInfo_Desiger.TabIndex = 0;
            this.LblPanInfo_Desiger.Text = "Infotext";
            // 
            // ChkYesNo_Designer
            // 
            this.ChkYesNo_Designer.AutoSize = true;
            this.ChkYesNo_Designer.Location = new System.Drawing.Point(6, 6);
            this.ChkYesNo_Designer.Name = "ChkYesNo_Designer";
            this.ChkYesNo_Designer.Size = new System.Drawing.Size(250, 20);
            this.ChkYesNo_Designer.TabIndex = 1;
            this.ChkYesNo_Designer.Text = "Mit dem &File-Name Designer arbeiten";
            this.ChkYesNo_Designer.UseVisualStyleBackColor = true;
            this.ChkYesNo_Designer.CheckedChanged += new System.EventHandler(this.ChkYesNo_Designer_CheckedChanged);
            // 
            // PanBckGrndFile_Designer
            // 
            this.PanBckGrndFile_Designer.BackColor = System.Drawing.SystemColors.Window;
            this.PanBckGrndFile_Designer.Controls.Add(this.TxtFileName_Designer);
            this.PanBckGrndFile_Designer.Controls.Add(this.CmdSave_Designer);
            this.PanBckGrndFile_Designer.Location = new System.Drawing.Point(6, 128);
            this.PanBckGrndFile_Designer.Name = "PanBckGrndFile_Designer";
            this.PanBckGrndFile_Designer.Size = new System.Drawing.Size(683, 40);
            this.PanBckGrndFile_Designer.TabIndex = 19;
            // 
            // TxtFileName_Designer
            // 
            this.TxtFileName_Designer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtFileName_Designer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFileName_Designer.Location = new System.Drawing.Point(9, 11);
            this.TxtFileName_Designer.Name = "TxtFileName_Designer";
            this.TxtFileName_Designer.Size = new System.Drawing.Size(565, 19);
            this.TxtFileName_Designer.TabIndex = 18;
            this.TxtFileName_Designer.TextChanged += new System.EventHandler(this.TxtFileName_Designer_TextChanged);
            // 
            // CmdSave_Designer
            // 
            this.CmdSave_Designer.AutoSize = true;
            this.CmdSave_Designer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CmdSave_Designer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSave_Designer.Location = new System.Drawing.Point(580, 7);
            this.CmdSave_Designer.Name = "CmdSave_Designer";
            this.CmdSave_Designer.Size = new System.Drawing.Size(96, 26);
            this.CmdSave_Designer.TabIndex = 15;
            this.CmdSave_Designer.Text = "Ü&bernehmen";
            this.CmdSave_Designer.UseVisualStyleBackColor = true;
            this.CmdSave_Designer.Click += new System.EventHandler(this.CmdSave_Designer_Click);
            // 
            // ChkDeleteAll
            // 
            this.ChkDeleteAll.AutoSize = true;
            this.ChkDeleteAll.Location = new System.Drawing.Point(15, 3);
            this.ChkDeleteAll.Name = "ChkDeleteAll";
            this.ChkDeleteAll.Size = new System.Drawing.Size(92, 17);
            this.ChkDeleteAll.TabIndex = 8;
            this.ChkDeleteAll.Text = "Alle Entfernen";
            this.ChkDeleteAll.UseVisualStyleBackColor = true;
            this.ChkDeleteAll.CheckedChanged += new System.EventHandler(this.ChkDeleteAll_CheckedChanged);
            // 
            // PanDeleteAll
            // 
            this.PanDeleteAll.Controls.Add(this.ChkDeleteAll);
            this.PanDeleteAll.Location = new System.Drawing.Point(772, 275);
            this.PanDeleteAll.Name = "PanDeleteAll";
            this.PanDeleteAll.Size = new System.Drawing.Size(116, 22);
            this.PanDeleteAll.TabIndex = 5;
            // 
            // LblCoverInfo
            // 
            this.LblCoverInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCoverInfo.Location = new System.Drawing.Point(3, -1);
            this.LblCoverInfo.Name = "LblCoverInfo";
            this.LblCoverInfo.Size = new System.Drawing.Size(194, 23);
            this.LblCoverInfo.TabIndex = 9;
            this.LblCoverInfo.Text = "LblCoverInfo";
            this.LblCoverInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanCover
            // 
            this.PanCover.BackColor = System.Drawing.SystemColors.Window;
            this.PanCover.Controls.Add(this.CmdCopyPic);
            this.PanCover.Controls.Add(this.LblCoverInfo);
            this.PanCover.Controls.Add(this.CmdDelPic);
            this.PanCover.Controls.Add(this.CmdLoadPic);
            this.PanCover.Controls.Add(this.PictureBox);
            this.PanCover.ForeColor = System.Drawing.SystemColors.WindowText;
            this.PanCover.Location = new System.Drawing.Point(12, 265);
            this.PanCover.Name = "PanCover";
            this.PanCover.Size = new System.Drawing.Size(200, 200);
            this.PanCover.TabIndex = 10;
            // 
            // CmdCopyPic
            // 
            this.CmdCopyPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCopyPic.Location = new System.Drawing.Point(57, 131);
            this.CmdCopyPic.Name = "CmdCopyPic";
            this.CmdCopyPic.Size = new System.Drawing.Size(86, 26);
            this.CmdCopyPic.TabIndex = 13;
            this.CmdCopyPic.Text = "Übertragen";
            this.CmdCopyPic.UseVisualStyleBackColor = true;
            this.CmdCopyPic.Click += new System.EventHandler(this.CmdCopyPic_Click);
            // 
            // CmdDelPic
            // 
            this.CmdDelPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDelPic.Location = new System.Drawing.Point(57, 99);
            this.CmdDelPic.Name = "CmdDelPic";
            this.CmdDelPic.Size = new System.Drawing.Size(86, 26);
            this.CmdDelPic.TabIndex = 12;
            this.CmdDelPic.Text = "Entfernen";
            this.CmdDelPic.UseVisualStyleBackColor = true;
            this.CmdDelPic.Click += new System.EventHandler(this.CmdDelPic_Click);
            // 
            // CmdLoadPic
            // 
            this.CmdLoadPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdLoadPic.Location = new System.Drawing.Point(57, 67);
            this.CmdLoadPic.Name = "CmdLoadPic";
            this.CmdLoadPic.Size = new System.Drawing.Size(86, 26);
            this.CmdLoadPic.TabIndex = 11;
            this.CmdLoadPic.Text = "Laden";
            this.CmdLoadPic.UseVisualStyleBackColor = true;
            this.CmdLoadPic.Click += new System.EventHandler(this.CmdLoadPic_Click);
            // 
            // PictureBox
            // 
            this.PictureBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PictureBox.Location = new System.Drawing.Point(13, 22);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(172, 172);
            this.PictureBox.TabIndex = 14;
            this.PictureBox.TabStop = false;
            this.PictureBox.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // FileBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.PanCover);
            this.Controls.Add(this.PanDeleteAll);
            this.Controls.Add(this.TabConFileBrowser);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.LsvFileBrowser);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileBrowser";
            this.Opacity = 0.9D;
            this.Text = "FileBrowser";
            this.Load += new System.EventHandler(this.FileBrowser_Load);
            this.TabConFileBrowser.ResumeLayout(false);
            this.TabId3v2.ResumeLayout(false);
            this.PanButtons_Page1.ResumeLayout(false);
            this.PanButtons_Page1.PerformLayout();
            this.TabId3v1.ResumeLayout(false);
            this.TabId3v1.PerformLayout();
            this.PanBckGrndBtn_ID3v1.ResumeLayout(false);
            this.PanBckGrndBtn_ID3v1.PerformLayout();
            this.TabPage3.ResumeLayout(false);
            this.TabPage3.PerformLayout();
            this.TabDesigner.ResumeLayout(false);
            this.PanFileName_Designer.ResumeLayout(false);
            this.PanFileName_Designer.PerformLayout();
            this.PanInfo_Designer.ResumeLayout(false);
            this.PanBckGrndFile_Designer.ResumeLayout(false);
            this.PanBckGrndFile_Designer.PerformLayout();
            this.PanDeleteAll.ResumeLayout(false);
            this.PanDeleteAll.PerformLayout();
            this.PanCover.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LsvFileBrowser;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.TabControl TabConFileBrowser;
        private System.Windows.Forms.TabPage TabId3v2;
        private System.Windows.Forms.TabPage TabId3v1;
        private System.Windows.Forms.TabPage TabPage3;
        private System.Windows.Forms.TabPage TabDesigner;
        private System.Windows.Forms.ListView LsvMetaData;
        private System.Windows.Forms.TextBox TxtGenre_v1Tag;
        private System.Windows.Forms.TextBox TxtComment_v1Tag;
        private System.Windows.Forms.TextBox TxtTitle_v1Tag;
        private System.Windows.Forms.TextBox TxtYear_v1Tag;
        private System.Windows.Forms.TextBox TxtAlbum_v1Tag;
        private System.Windows.Forms.Label LblGenre_v1Tag;
        private System.Windows.Forms.Label LblComment_v1Tag;
        private System.Windows.Forms.Label LblTrackTitle_v1Tag;
        private System.Windows.Forms.Label LblYear_v1Tag;
        private System.Windows.Forms.Label LblAlbum_v1Tag;
        private System.Windows.Forms.Label LblArtist_v1Tag;
        private System.Windows.Forms.TextBox TxtArtist_v1Tag;
        private System.Windows.Forms.Label LblAllActions_Page1;
        private System.Windows.Forms.Button CmdSave_v2Tags;
        private System.Windows.Forms.Button CmdUndoAll_v2Tags;
        private System.Windows.Forms.Label LblLastAction_Page1;
        private System.Windows.Forms.Button CmdUndoLast_v2Tags;
        private System.Windows.Forms.Panel PanButtons_Page1;
        private System.Windows.Forms.CheckBox ChkDeleteAll;
        private System.Windows.Forms.Panel PanDeleteAll;
        private System.Windows.Forms.Panel PanBckGrndBtn_ID3v1;
        private System.Windows.Forms.Label LblCopyData_ID3v1;
        private System.Windows.Forms.Label LblAllChanges_ID3v1;
        private System.Windows.Forms.Button CmdSave_v1Tags;
        private System.Windows.Forms.Button CmdUndoAll_v1Tags;
        private System.Windows.Forms.Button CmdCopyAll_v1Tags;
        private System.Windows.Forms.Panel PanFileName_Designer;
        private System.Windows.Forms.Panel PanInfo_Designer;
        private System.Windows.Forms.Label LblPanInfo_Desiger;
        private System.Windows.Forms.CheckBox ChkYesNo_Designer;
        private System.Windows.Forms.Button CmdAddTag_Designer;
        private System.Windows.Forms.CheckBox ChkCopyToAll_Designer;
        private System.Windows.Forms.Button CmdAddString_Designer;
        private System.Windows.Forms.Button CmdDelete_Designer;
        private System.Windows.Forms.Label LblPathToFolder_Designer;
        private System.Windows.Forms.Button CmdCancel_Designer;
        private System.Windows.Forms.Button CmdSave_Designer;
        private System.Windows.Forms.Label LblInfo_Designer;
        private System.Windows.Forms.TextBox TxtFileName_Designer;
        private System.Windows.Forms.Panel PanBckGrndFile_Designer;
        private System.Windows.Forms.Label LblCoverInfo;
        private System.Windows.Forms.Panel PanCover;
        private System.Windows.Forms.Button CmdLoadPic;
        private System.Windows.Forms.Button CmdDelPic;
        private System.Windows.Forms.Button CmdCopyPic;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.TextBox TxtTrack_v1Tag;
        private System.Windows.Forms.Panel PanBckGrndData_ID3v1;
        private System.Windows.Forms.Label label1;
    }
}