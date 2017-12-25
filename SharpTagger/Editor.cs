using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tagger
{
    public partial class Editor : Form
    {
        // namensraumweit verfügbar
        public bool copyToAll;
        public string tagType;
        public string tagValue;

        // klassenweit verfügbar
        private string[] entries;
        private string tagValueEdited;
        private FileBrowser FileBrowser;

        #region Initialisierung

        public Editor(FileBrowser caller, string tagType, string tagValue)
        {
            FileBrowser = caller;

            // Wertübergabe der Aufrufer-Parameter
            this.tagType = tagType;
            this.tagValue = tagValue;
            tagValueEdited = tagValue;

            InitializeComponent();
        }

        #endregion

        #region Formular laden

        private void Editor_Load(object sender, EventArgs e)
        {
            LblTagType.Text = tagType;

            if (MultiSelection(tagType))
            {
                Init_MultiSelection();
                ShowEntries_MultiSelection(tagValue);
            }
            else
                Init_SingleSelection();

            if (CopyToAll(tagType))
                ChkCopyToAll.Show();
            else
                ChkCopyToAll.Hide();

            CmdDelete.Enabled = false;
            CmdEditorSave.Enabled = false;
        }

        #endregion

        #region Möglichkeit der Mehrfacheingabe prüfen (Genres beachten)

        private bool MultiSelection(string tagType)
        {
            if (tagType == "Artist(en)" || tagType == "Album-Artist(en)" || 
                tagType == "Genre(s)"   || tagType == "Komponist(en)")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Vorgabe welche Metadaten auf alle Dateien angewendet werden können

        private bool CopyToAll(string tagType)
        {
            if (tagType == "Artist(en)" || tagType == "Album-Artist(en)" || tagType == "Genre(s)" ||
                tagType == "Album"      || tagType == "Jahr"             || tagType == "Kommentar" || 
                tagType == "CD-Nummer"  || tagType == "Anzahl CDs")
                return true;
            else
                return false;
        }

        #endregion

        #region Mehrfachauswahl

        private void Init_MultiSelection()
        {
            LstTags.Show();
            LstTags.Items.Clear();
            LblNewEntry.Text = "Neuen Eintrag hizufügen";
        }

        // Anzeige Mehrfachauswahl
        private void ShowEntries_MultiSelection(string tagValueEdited)
        {
            LstTags.Items.Clear();
            ActiveControl = TxtNewEntry;
            TxtNewEntry.Text = string.Empty;

            entries = tagValueEdited.Split(';', ',');

            foreach (string entry in entries)
            {
                if (entry != string.Empty)
                {
                    string displayed = entry.Trim(' ');
                    LstTags.Items.Add(displayed);
                }
            }
        }

        // Selektierte Einträge entfernen
        private void CmdDelete_Click(object sender, EventArgs e)
        {
            // Einträge aus Liste entfernen
            for (int x = LstTags.SelectedIndices.Count - 1; x >= 0; x--)
                LstTags.Items.RemoveAt(LstTags.SelectedIndices[x]);

            // Verbleibende Einträge in string 'tagValue' schreiben

            if (LstTags.Items.Count > 0)
            {
                bool firstEntry = true;

                for (int i = 0; i < LstTags.Items.Count; i++)
                {
                    if (firstEntry)
                    {
                        tagValueEdited = Convert.ToString(LstTags.Items[i]);
                        CmdDelete.Enabled = false;
                        firstEntry = false;
                        CheckChanges();
                    }
                    else
                        tagValueEdited += "; " + Convert.ToString(LstTags.Items[i]);
                }
            }
            else
            {
                tagValueEdited = string.Empty;
                CmdDelete.Enabled = false;
                CheckChanges();
            }
        }

        #endregion

        #region Einfachauswahl

        private void Init_SingleSelection()
        {
            CmdAdd.Hide();
            LstTags.Hide();
            CmdDelete.Hide();
            LblEntries.Hide();

            LblNewEntry.Location = new Point(22, 84);
            LblNewEntry.Text = "Eingetragener Wert";

            TxtNewEntry.Location = new Point(25, 100);
            TxtNewEntry.Size = new Size(415, 26);
            TxtNewEntry.Text = tagValueEdited;
        }

        #endregion        

        #region Eintrag hinzufügen

        private void CmdAdd_Click(object sender, EventArgs e)
        {
            if (!(TxtNewEntry.Text == string.Empty))
            {
                if (LstTags.Items.Count == 0)
                    tagValueEdited = TxtNewEntry.Text;
                else
                    tagValueEdited += "; " + TxtNewEntry.Text;

                // string neu einlesen
                ShowEntries_MultiSelection(tagValueEdited);
            }
        }

        #endregion

        #region weitere Steuerelemente

        // Bei Auswahl Entfernen-Taste aktivieren
        private void LstTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmdDelete.Enabled = true;
        }

        // Prüfe Änderungen
        private void CheckChanges()
        {
            if (tagValue != tagValueEdited)
                CmdEditorSave.Enabled = true;
            else
                CmdEditorSave.Enabled = false;
        }

        // Aktiviere Speichern
        private void TxtEditor_TextChanged(object sender, EventArgs e)
        {
            if (MultiSelection(tagType))
                CheckChanges();
            else
            {
                tagValueEdited = TxtNewEntry.Text;
                CheckChanges();
            }
        }

        // Änderungen speichern
        private void CmdEditorSave_Click(object sender, EventArgs e)
        {
            tagValue = tagValueEdited;
            Close();
        }

        // Aktion abbrechen
        private void CmdEditorReturn_Click(object sender, EventArgs e)
        {
            tagValueEdited = tagValue;
            Close();
        }

        // Abfrage der CheckBox
        private void ChkCopyToAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCopyToAll.Checked == true)
            {
                CmdEditorSave.Enabled = true;
                copyToAll = true;
            }
            else
            {
                //CmdEditorSave.Enabled = false;
                copyToAll = false;
                CheckChanges();
            }
        }

        #endregion
    }
}
