using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tagger
{
    public partial class Options : Form
    {
        private MainWindow mainWindow;
        private FileBrowser fileBrowser;

        // Klasse Config instanziieren
        private Config Config = new Config();        

        public Options(MainWindow caller)
        {
            this.mainWindow = caller;
            InitializeComponent();
            // Konfiguration initialisieren
            Config.Initialize();
        }

        public Options(FileBrowser caller)
        {
            this.fileBrowser = caller;
            InitializeComponent();
            // Konfiguration initialisieren
            Config.Initialize();
        }


        // ========== Einstellungen Allgemein ==========

        // Laden der Konfiguration
        private void Options_Load(object sender, EventArgs e)
        {

            // ===== Lade Einstellungen Tabulator 1 =====
            TxtPathToLib.Text = Config.PathToLib;
            TxtPathToBackup.Text = Config.PathToBackup;
            ChkBackup.Checked = Convert.ToBoolean(Config.ChkBackup);

            // Excaption-Handling Pfad-Konfiguration
            PathConfig_CheckExcaption();


            // ===== Lade Einstellungen Tabulator 2 =====
            ChkArtists.Checked = Convert.ToBoolean(Config.Artists);
            ChkAlbumArtists.Checked = Convert.ToBoolean(Config.AlbumArtists);
            ChkAlbum.Checked = Convert.ToBoolean(Config.Album);
            ChkTitle.Checked = Convert.ToBoolean(Config.Title);
            ChkTrack.Checked = Convert.ToBoolean(Config.Track);
            ChkYear.Checked = Convert.ToBoolean(Config.Year);
            ChkGenres.Checked = Convert.ToBoolean(Config.Genres);
            ChkCover.Checked = Convert.ToBoolean(Config.Cover);
            ChkPathToFile.Checked = Convert.ToBoolean(Config.PathToFile);
            ChkAmazonId.Checked = Convert.ToBoolean(Config.AmazonId);
            ChkComment.Checked = Convert.ToBoolean(Config.Comment);
            ChkComposers.Checked = Convert.ToBoolean(Config.Composers);
            ChkDisc.Checked = Convert.ToBoolean(Config.Disc);
            ChkDiscCount.Checked = Convert.ToBoolean(Config.DiscCount);

            // Excaption-Handling Metadaten-Konfiguration
            MetadataConfig_CheckExcaption();


            // ===== Lade Einstellungen Tabulator 3 =====

            // to be continued ...


            // ===== Speicher-Knöpfe deaktivieren =====
            CmdSaveOptionsPage1.Enabled = false;
            CmdSaveOptionsPage2.Enabled = false;
            CmdSaveOptionsPage3.Enabled = false;
        }


        // Beendet Einstellungsdialog
        private void CmdCloseOptions_Click(object sender, EventArgs e)
        {
            Close();
        }


        // ========== Einstellungen zur Laufzeit ==========


        // ========== Einstellungen Tabulator1 ==========

        // Ruft Standarddialog für Ordnerauswahl auf
        private void CmdBrowsePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                RootFolder = Environment.SpecialFolder.Desktop,
                ShowNewFolderButton = false,
                Description = "Verzeichnis auswählen"
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (sender == CmdBrowsePathToLib)
                    TxtPathToLib.Text = fbd.SelectedPath;

                else if (sender == CmdBrowsePathToBackup)
                    TxtPathToBackup.Text = fbd.SelectedPath;
            }
        }

        // Geänderte Pfadangabe aktiviert Speichern-Knopf
        private void PathSelection_TextChanged(object sender, EventArgs e)
        {
            CmdSaveOptionsPage1.Enabled = true;
        }

        // (De)aktiviert Backup-Modus und aktiviert Speichern-Knopf
        private void ChkBackup_CheckedChanged(object sender, EventArgs e)
        {
            PathConfig_CheckExcaption();
            CmdSaveOptionsPage1.Enabled = true;
        }

        // Prüft getroffene Auswahl, setzt ggf. Limitierung
        private void PathConfig_CheckExcaption()
        {
            if (ChkBackup.Checked)
            {
                TxtPathToBackup.ReadOnly = false;
                TxtPathToBackup.Enabled = true;
                CmdBrowsePathToBackup.Enabled = true;
                LblPathToBackup.ForeColor = Color.Black;
            }
            else
            {
                TxtPathToBackup.ReadOnly = true;
                TxtPathToBackup.Enabled = false;
                CmdBrowsePathToBackup.Enabled = false;
                LblPathToBackup.ForeColor = Color.Gray;
            }
        }                

        // Betätigung löst Übernehmen diverser Einstellungen von Tabulator 1 aus
        private void CmdSaveOptionsPage1_Click(object sender, EventArgs e)
        {
            // Schreiben der Konfigurationsänderungen
            Config.Update("ChkBackup", Convert.ToString(Convert.ToBoolean(ChkBackup.CheckState)));
            Config.Update("PathToLib", TxtPathToLib.Text);
            Config.Update("PathToBackup", TxtPathToBackup.Text);
            // Betätigen des Speichernknopf deaktivieren
            CmdSaveOptionsPage1.Enabled = false;
        }


        // ========== Einstellungen Tabulator2 ==========

        // Registriert Änderungen der Auswahl
        private void MetadataSelection_CheckChanged(object sender, EventArgs e)
        {
            MetadataConfig_CheckExcaption();
            CmdSaveOptionsPage2.Enabled = true;
        }

        // Prüft getroffene Auswahl, setzt ggf. Mindestbedingung
        private void MetadataConfig_CheckExcaption()
        {
            if (Convert.ToBoolean(ChkArtists.CheckState) == false &&
                Convert.ToBoolean(ChkAlbumArtists.CheckState) == false &&
                Convert.ToBoolean(ChkAlbum.CheckState) == false &&
                Convert.ToBoolean(ChkTitle.CheckState) == false &&
                Convert.ToBoolean(ChkTrack.CheckState) == false &&
                Convert.ToBoolean(ChkYear.CheckState) == false &&
                Convert.ToBoolean(ChkGenres.CheckState) == false &&
                Convert.ToBoolean(ChkCover.CheckState) == false &&
                Convert.ToBoolean(ChkAmazonId.CheckState) == false &&
                Convert.ToBoolean(ChkComment.CheckState) == false &&
                Convert.ToBoolean(ChkComposers.CheckState) == false &&
                Convert.ToBoolean(ChkDisc.CheckState) == false &&
                Convert.ToBoolean(ChkDiscCount.CheckState) == false &&
                Convert.ToBoolean(ChkPathToFile.CheckState) == false)
            {
                ChkPathToFile.Checked = true;
                ChkPathToFile.Enabled = false;
                LblPathToFile.ForeColor = Color.Red;
            }
            else
            {
                ChkPathToFile.Enabled = true;
                LblPathToFile.ForeColor = DefaultForeColor;
            }
        }

        // Betätigung löst Übernehmen diverser Einstellungen von Tabulator 2 aus
        private void CmdSaveOptionsPage2_Click(object sender, EventArgs e)
        {
            // Schreiben der Konfigurationsänderungen
            Config.Update("Artists", Convert.ToString(Convert.ToBoolean(ChkArtists.CheckState)));
            Config.Update("AlbumArtists", Convert.ToString(Convert.ToBoolean(ChkAlbumArtists.CheckState)));
            Config.Update("Album", Convert.ToString(Convert.ToBoolean(ChkAlbum.CheckState)));
            Config.Update("Title", Convert.ToString(Convert.ToBoolean(ChkTitle.CheckState)));
            Config.Update("Track", Convert.ToString(Convert.ToBoolean(ChkTrack.CheckState)));
            Config.Update("Year", Convert.ToString(Convert.ToBoolean(ChkYear.CheckState)));
            Config.Update("Genre", Convert.ToString(Convert.ToBoolean(ChkGenres.CheckState)));
            Config.Update("Cover", Convert.ToString(Convert.ToBoolean(ChkCover.CheckState)));
            Config.Update("PathToFile", Convert.ToString(Convert.ToBoolean(ChkPathToFile.CheckState)));
            Config.Update("AmazonId", Convert.ToString(Convert.ToBoolean(ChkAmazonId.CheckState)));
            Config.Update("Comment", Convert.ToString(Convert.ToBoolean(ChkComment.CheckState)));
            Config.Update("Composers", Convert.ToString(Convert.ToBoolean(ChkComposers.CheckState)));
            Config.Update("Disc", Convert.ToString(Convert.ToBoolean(ChkDisc.CheckState)));
            Config.Update("DiscCount", Convert.ToString(Convert.ToBoolean(ChkDiscCount.CheckState)));

            // Speichernknopf für Tabulator 2 deaktivieren
            CmdSaveOptionsPage2.Enabled = false;
        }
    }
}
