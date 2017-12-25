namespace Tagger
{
    partial class Editor
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
            this.TxtNewEntry = new System.Windows.Forms.TextBox();
            this.CmdEditorReturn = new System.Windows.Forms.Button();
            this.CmdEditorSave = new System.Windows.Forms.Button();
            this.LstTags = new System.Windows.Forms.ListBox();
            this.CmdDelete = new System.Windows.Forms.Button();
            this.LblNewEntry = new System.Windows.Forms.Label();
            this.CmdAdd = new System.Windows.Forms.Button();
            this.LblEntries = new System.Windows.Forms.Label();
            this.ChkCopyToAll = new System.Windows.Forms.CheckBox();
            this.PanBckGrnd_Editor = new System.Windows.Forms.Panel();
            this.LblTagType = new System.Windows.Forms.Label();
            this.PanBckGrnd_Editor.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtNewEntry
            // 
            this.TxtNewEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNewEntry.Location = new System.Drawing.Point(12, 44);
            this.TxtNewEntry.Name = "TxtNewEntry";
            this.TxtNewEntry.Size = new System.Drawing.Size(331, 26);
            this.TxtNewEntry.TabIndex = 0;
            this.TxtNewEntry.TextChanged += new System.EventHandler(this.TxtEditor_TextChanged);
            // 
            // CmdEditorReturn
            // 
            this.CmdEditorReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdEditorReturn.Location = new System.Drawing.Point(351, 191);
            this.CmdEditorReturn.Name = "CmdEditorReturn";
            this.CmdEditorReturn.Size = new System.Drawing.Size(101, 30);
            this.CmdEditorReturn.TabIndex = 6;
            this.CmdEditorReturn.Text = "&Abbruch";
            this.CmdEditorReturn.UseVisualStyleBackColor = true;
            this.CmdEditorReturn.Click += new System.EventHandler(this.CmdEditorReturn_Click);
            // 
            // CmdEditorSave
            // 
            this.CmdEditorSave.AutoSize = true;
            this.CmdEditorSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdEditorSave.Location = new System.Drawing.Point(231, 191);
            this.CmdEditorSave.Name = "CmdEditorSave";
            this.CmdEditorSave.Size = new System.Drawing.Size(112, 30);
            this.CmdEditorSave.TabIndex = 5;
            this.CmdEditorSave.Text = "Ü&bernehmen";
            this.CmdEditorSave.UseVisualStyleBackColor = true;
            this.CmdEditorSave.Click += new System.EventHandler(this.CmdEditorSave_Click);
            // 
            // LstTags
            // 
            this.LstTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstTags.ForeColor = System.Drawing.Color.Black;
            this.LstTags.FormattingEnabled = true;
            this.LstTags.ItemHeight = 20;
            this.LstTags.Location = new System.Drawing.Point(12, 93);
            this.LstTags.Name = "LstTags";
            this.LstTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LstTags.Size = new System.Drawing.Size(331, 84);
            this.LstTags.TabIndex = 2;
            this.LstTags.SelectedIndexChanged += new System.EventHandler(this.LstTags_SelectedIndexChanged);
            // 
            // CmdDelete
            // 
            this.CmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDelete.Location = new System.Drawing.Point(349, 93);
            this.CmdDelete.Name = "CmdDelete";
            this.CmdDelete.Size = new System.Drawing.Size(101, 30);
            this.CmdDelete.TabIndex = 3;
            this.CmdDelete.Text = "&Entfernen";
            this.CmdDelete.UseVisualStyleBackColor = true;
            this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
            // 
            // LblNewEntry
            // 
            this.LblNewEntry.AutoSize = true;
            this.LblNewEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNewEntry.Location = new System.Drawing.Point(9, 28);
            this.LblNewEntry.Name = "LblNewEntry";
            this.LblNewEntry.Size = new System.Drawing.Size(83, 13);
            this.LblNewEntry.TabIndex = 7;
            this.LblNewEntry.Text = "Mögliche Aktion";
            // 
            // CmdAdd
            // 
            this.CmdAdd.AutoSize = true;
            this.CmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAdd.Location = new System.Drawing.Point(349, 42);
            this.CmdAdd.Name = "CmdAdd";
            this.CmdAdd.Size = new System.Drawing.Size(101, 30);
            this.CmdAdd.TabIndex = 1;
            this.CmdAdd.Text = "&Hinzufügen";
            this.CmdAdd.UseVisualStyleBackColor = true;
            this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
            // 
            // LblEntries
            // 
            this.LblEntries.AutoSize = true;
            this.LblEntries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEntries.Location = new System.Drawing.Point(9, 77);
            this.LblEntries.Name = "LblEntries";
            this.LblEntries.Size = new System.Drawing.Size(87, 13);
            this.LblEntries.TabIndex = 8;
            this.LblEntries.Text = "Aktuelle Einträge";
            // 
            // ChkCopyToAll
            // 
            this.ChkCopyToAll.AutoSize = true;
            this.ChkCopyToAll.Location = new System.Drawing.Point(36, 197);
            this.ChkCopyToAll.Name = "ChkCopyToAll";
            this.ChkCopyToAll.Size = new System.Drawing.Size(162, 17);
            this.ChkCopyToAll.TabIndex = 4;
            this.ChkCopyToAll.Text = "Für alle &Dateien übernehmen";
            this.ChkCopyToAll.UseVisualStyleBackColor = true;
            this.ChkCopyToAll.CheckedChanged += new System.EventHandler(this.ChkCopyToAll_CheckedChanged);
            // 
            // PanBckGrnd_Editor
            // 
            this.PanBckGrnd_Editor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanBckGrnd_Editor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanBckGrnd_Editor.Controls.Add(this.LblTagType);
            this.PanBckGrnd_Editor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.PanBckGrnd_Editor.Location = new System.Drawing.Point(0, 0);
            this.PanBckGrnd_Editor.Name = "PanBckGrnd_Editor";
            this.PanBckGrnd_Editor.Size = new System.Drawing.Size(464, 233);
            this.PanBckGrnd_Editor.TabIndex = 9;
            // 
            // LblTagType
            // 
            this.LblTagType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTagType.Location = new System.Drawing.Point(3, 1);
            this.LblTagType.Name = "LblTagType";
            this.LblTagType.Size = new System.Drawing.Size(456, 23);
            this.LblTagType.TabIndex = 0;
            this.LblTagType.Text = "zu bearbeitender Tag";
            this.LblTagType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(464, 233);
            this.Controls.Add(this.ChkCopyToAll);
            this.Controls.Add(this.LblEntries);
            this.Controls.Add(this.CmdAdd);
            this.Controls.Add(this.LblNewEntry);
            this.Controls.Add(this.CmdDelete);
            this.Controls.Add(this.LstTags);
            this.Controls.Add(this.CmdEditorSave);
            this.Controls.Add(this.CmdEditorReturn);
            this.Controls.Add(this.TxtNewEntry);
            this.Controls.Add(this.PanBckGrnd_Editor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Editor";
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.Editor_Load);
            this.PanBckGrnd_Editor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNewEntry;
        private System.Windows.Forms.Button CmdEditorReturn;
        private System.Windows.Forms.Button CmdEditorSave;
        private System.Windows.Forms.ListBox LstTags;
        private System.Windows.Forms.Button CmdDelete;
        private System.Windows.Forms.Label LblNewEntry;
        private System.Windows.Forms.Button CmdAdd;
        private System.Windows.Forms.Label LblEntries;
        private System.Windows.Forms.CheckBox ChkCopyToAll;
        private System.Windows.Forms.Panel PanBckGrnd_Editor;
        private System.Windows.Forms.Label LblTagType;
    }
}