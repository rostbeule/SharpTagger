using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TagLib; // keine Möglichkeit gefunden ID3v1-Tags zu bearbeiten
using ID3TagLib; // Kann sowohl ID3v1 als auch ID3v2 (löst TagLib in Zukunft komplett ab)

namespace Tagger
{
    public partial class FileBrowser : Form
    {
        // klassenweit gültig
        private int selectedObject;
        private string pathToFolder;
        private string selectedFormat;

        private MainWindow MainWindow;
        private Config Config = new Config();
        private List<Memory> History = new List<Memory>();
        private List<FileObject> Collection = new List<FileObject>();

        // Initialisieren
        public FileBrowser(MainWindow caller, string pathToFolder)
        {
            MainWindow = caller;
            InitializeComponent();
            // zu behandelndes File-Format zuweisen (temp Lösung)
            selectedFormat = MainWindow.selectedFormat;
            // Konfiguration initialisieren
            Config.Initialize();
            // Pfad an klassenweite Variable übergeben
            this.pathToFolder = pathToFolder;
        }

        #region Allgemein

        // Formular laden
        private void FileBrowser_Load(object sender, EventArgs e)
        {
            // ListViews initialisieren
            InitializeListViewFileBrowser();
            InitializeListViewMetaData();
            // Lese Metadaten von Dateien (redundant)
            GetMetaDataFromFiles();
            // Ausgabe
            ShowData_FileBrowser();
            // Ersten Eintrag selektieren
            PreSelection(selectedObject);
            // Tabulatoren anpassen
            SelectTabPages();
            // Spaltenbreite einstellen -> schlechte performance
            AdaptColumnsWidth(LsvFileBrowser);
            AdaptColumnsWidth(LsvMetaData);
        }

        // Einstellungen der ListView zur Datei-Auswahl
        public void InitializeListViewFileBrowser()
        {
            // Eigenschaften
            LsvFileBrowser.View = View.Details;
            LsvFileBrowser.FullRowSelect = true;
            LsvFileBrowser.AllowColumnReorder = true;
            LsvFileBrowser.CheckBoxes = false;
            LsvFileBrowser.MultiSelect = false;

            // Spalten
            LsvFileBrowser.Columns.Add(string.Empty);           // Index (versteckt)

            if (Convert.ToBoolean(Config.Disc) || Convert.ToBoolean(Config.DiscCount))
                LsvFileBrowser.Columns.Add("CD", 20, HorizontalAlignment.Center);
            if (Convert.ToBoolean(Config.Track))
                LsvFileBrowser.Columns.Add("Nr.", 20, HorizontalAlignment.Right);
            if (Convert.ToBoolean(Config.Title))
                LsvFileBrowser.Columns.Add("Titel");
            if (Convert.ToBoolean(Config.Album))
                LsvFileBrowser.Columns.Add("Album");
            if (Convert.ToBoolean(Config.Year))
                LsvFileBrowser.Columns.Add("Jahr");
            if (Convert.ToBoolean(Config.Artists))
                LsvFileBrowser.Columns.Add("Artist(en)");
            if (Convert.ToBoolean(Config.AlbumArtists))
                LsvFileBrowser.Columns.Add("Album-Artist(en)");
            if (Convert.ToBoolean(Config.Composers))
                LsvFileBrowser.Columns.Add("Komponist(en)");
            if (Convert.ToBoolean(Config.Genres))
                LsvFileBrowser.Columns.Add("Genre(s)");
            if (Convert.ToBoolean(Config.AmazonId))
                LsvFileBrowser.Columns.Add("Amazon ID", 20, HorizontalAlignment.Right);
            if (Convert.ToBoolean(Config.Cover))
                LsvFileBrowser.Columns.Add("Cover", 20, HorizontalAlignment.Center);
            if (Convert.ToBoolean(Config.Comment))
                LsvFileBrowser.Columns.Add("Kommentar");

            if (Convert.ToBoolean(Config.PathToFile))               // Pfad immer an letzter Stelle
                LsvFileBrowser.Columns.Add("Datei-Pfad");
        }

        // Einstellungen der ListView zur Darstellung für Metadaten
        public void InitializeListViewMetaData()
        {
            // Eigenschaften
            LsvMetaData.View = View.Details;
            LsvMetaData.FullRowSelect = true;
            LsvMetaData.AllowColumnReorder = false;
            LsvMetaData.CheckBoxes = false;
            LsvMetaData.MultiSelect = false;
            LsvMetaData.GridLines = true;

            // Spalten
            LsvMetaData.Columns.Add("Eigenschaft");
            LsvMetaData.Columns.Add("Wert");
        }

        /// <summary>
        /// Automatisches Anpassen der Spaltenbreite (Performance optimiert).
        /// Vergleicht Zeichenlänge aller Spalten-Header und zugehöriger Einträge.
        /// Passt dann entsprechend die Spaltenbreite an.
        /// </summary>
        /// <param name="Caller"></param>
        private void AdaptColumnsWidth(ListView Caller)
        {
            // Array erzeugen
            bool[] entryIsMaster = new bool[Caller.Columns.Count];

            // Array füllen
            try
            {
                for (int i = 0; i < Caller.Columns.Count; i++)
                {
                    bool entryWins = false;

                    for (int j = 0; j < Caller.Items.Count; j++)
                        if ((Caller.Items[j].SubItems[i].Text).Length > (Caller.Columns[i].Text).Length)
                        {
                            entryWins = true;
                            break;
                        }

                    if (entryWins)
                        entryIsMaster[i] = true;
                    else
                        entryIsMaster[i] = false;
                }
            }
            catch
            {
                MessageBox.Show("Fehler beim Überprüfen der Zeichenlänge", "FileBrowser: AdaptColumnsWidth");
                return;
            }

            // Spalten entsprechend Array anpassen
            int index = 0;

            foreach (bool entryWins in entryIsMaster)
            {
                if (entryWins)
                    Caller.AutoResizeColumn(index, ColumnHeaderAutoResizeStyle.ColumnContent);
                else
                    Caller.AutoResizeColumn(index, ColumnHeaderAutoResizeStyle.HeaderSize);

                index++;
            }

            // verstecke Indizes in LsvDataBrowser
            if (Caller.Items[0].SubItems[0].Text == "0")
                Caller.Columns[0].Width = 0;
        }

        // Schreibe alle Mp3 Metadaten in ObjektContainer, diese in 'Collection'
        public void GetMetaDataFromFiles()
        {
            // Lösche alte Einträge aus Liste
            Collection.Clear();

            // Index für erzeugte Objekte
            int index = 0;

            // alle Audio-Dateien des Ordners auswählen
            foreach (string pathToFile in Directory.GetFiles(pathToFolder, selectedFormat))
            {
                bool firstEntry = true;

                // Erzeuge Metadaten-Container vom Typ FileObject
                FileObject TagContainer = new FileObject(index);

                // Lese Metadaten aus und übergebe Eigenschaften an Objekt
                ID3File file = new ID3File(pathToFile);
                ID3v1Tag id3v1 = file.ID3v1Tag;
                TagLib.File id3v2 = TagLib.File.Create(pathToFile);

                try
                {
                    // Pfadangabe 
                    TagContainer.Path = pathToFile;

                    // File-Name
                    TagContainer.FileName = TagContainer.Path;

                    // Nummer
                    TagContainer.Id3v1_Track = id3v1.TrackNumber;
                    TagContainer.id3v2_Track = string.Format("{0:d2}", id3v2.Tag.Track);

                    // Titel
                    TagContainer.Id3v1_Title = id3v1.Title;
                    TagContainer.id3v2_Title = id3v2.Tag.Title;

                    // Album
                    TagContainer.Id3v1_Album = id3v1.Album;
                    TagContainer.id3v2_Album = id3v2.Tag.Album;

                    // Jahr
                    TagContainer.Id3v1_Year = id3v1.Year;
                    TagContainer.id3v2_Year = id3v2.Tag.Year.ToString();

                    // Amazon ID
                    TagContainer.id3v2_AmazonId = id3v2.Tag.AmazonId;

                    // Kommentar
                    TagContainer.id3v1_Comment = id3v1.Comment;
                    TagContainer.id3v2_Comment = id3v2.Tag.Comment;

                    // CD-Nummer
                    TagContainer.id3v2_Disc = Convert.ToString(id3v2.Tag.Disc);

                    // Anzahl CDs
                    TagContainer.id3v2_DiscCount = Convert.ToString(id3v2.Tag.DiscCount);

                    // Artist(en)
                    TagContainer.Id3v1_Artist = id3v1.Artist;

                    foreach (string artist in id3v2.Tag.Artists)
                    {
                        if (firstEntry)
                        {
                            TagContainer.id3v2_Artists = artist;
                            firstEntry = false;
                        }
                        else
                            TagContainer.id3v2_Artists += ", " + artist;
                    }
                    firstEntry = true;

                    // AlbumArtist(en)
                    foreach (string albumArtist in id3v2.Tag.AlbumArtists)
                    {
                        if (firstEntry)
                        {
                            TagContainer.id3v2_AlbumArtists = albumArtist;
                            firstEntry = false;
                        }
                        else
                            TagContainer.id3v2_AlbumArtists += ", " + albumArtist;
                    }
                    firstEntry = true;

                    // Genre(s)
                    TagContainer.id3v1_Genre = Convert.ToString(id3v1.Genre);

                    foreach (string genre in id3v2.Tag.Genres)
                    {
                        if (firstEntry)
                        {
                            TagContainer.id3v2_Genres = genre;
                            firstEntry = false;
                        }
                        else
                            TagContainer.id3v2_Genres += ", " + genre;
                    }
                    firstEntry = true;

                    // Komponist(en)
                    foreach (string composer in id3v2.Tag.Composers)
                    {
                        if (firstEntry)
                        {
                            TagContainer.id3v2_Composers = composer;
                            firstEntry = false;
                        }
                        else
                            TagContainer.id3v2_Composers += ", " + composer;
                    }
                    firstEntry = true;

                    // Cover enthalten?
                    if (id3v2.Tag.Pictures.Length > 0)
                        TagContainer.id3v2_Cover = "Ja";
                    else if (id3v2.Tag.Pictures.Length == 0)
                        TagContainer.id3v2_Cover = "Nein";
                    else
                        TagContainer.id3v2_Cover = "N/A";
                }
                catch
                {
                    MessageBox.Show("Fehler beim einlesen der Metadaten der Datei:\n" + pathToFile,
                                    "FileBrowser: GetMetaDataFromFiles",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Füge Objekt der Liste hinzu
                Collection.Add(TagContainer);

                // Index hochzählen
                index++;
            }
        }

        // ListView mit >>gewünschten<< (Optionen/Eigenschaften) Daten aus 'Collection' füllen
        private void ShowData_FileBrowser()
        {
            foreach (FileObject Data in Collection)
            {
                ListViewItem entry = new ListViewItem(Convert.ToString(Data.Index), 0); // -> Index
                if (Convert.ToBoolean(Config.Disc) && !(Convert.ToBoolean(Config.DiscCount)))
                    entry.SubItems.Add(Data.id3v2_Disc);
                if (Convert.ToBoolean(Config.Disc) && Convert.ToBoolean(Config.DiscCount))
                    entry.SubItems.Add(Data.id3v2_Disc + " / " + Data.id3v2_DiscCount);
                if (!(Convert.ToBoolean(Config.Disc)) && Convert.ToBoolean(Config.DiscCount))
                    entry.SubItems.Add("? / " + Data.id3v2_DiscCount);
                if (Convert.ToBoolean(Config.Track))
                    entry.SubItems.Add(Data.id3v2_Track);
                if (Convert.ToBoolean(Config.Title))
                    entry.SubItems.Add(Data.id3v2_Title);
                if (Convert.ToBoolean(Config.Album))
                    entry.SubItems.Add(Data.id3v2_Album);
                if (Convert.ToBoolean(Config.Year))
                    entry.SubItems.Add(Data.id3v2_Year);
                if (Convert.ToBoolean(Config.Artists))
                    entry.SubItems.Add(Data.id3v2_Artists);
                if (Convert.ToBoolean(Config.AlbumArtists))
                    entry.SubItems.Add(Data.id3v2_AlbumArtists);
                if (Convert.ToBoolean(Config.Composers))
                    entry.SubItems.Add(Data.id3v2_Composers);
                if (Convert.ToBoolean(Config.Genres))
                    entry.SubItems.Add(Data.id3v2_Genres);
                if (Convert.ToBoolean(Config.AmazonId))
                    entry.SubItems.Add(Data.id3v2_AmazonId);
                if (Convert.ToBoolean(Config.Cover))
                    entry.SubItems.Add(Data.id3v2_Cover);
                if (Convert.ToBoolean(Config.Comment))
                    entry.SubItems.Add(Data.id3v2_Comment);
                if (Convert.ToBoolean(Config.PathToFile)) // -> Pfadangabe
                    entry.SubItems.Add(Data.Path);
                LsvFileBrowser.Items.Add(entry);
            }
        }

        // Sortiere angewählte Spalte aufsteigen
        public void ListItemSorter(object sender, ColumnClickEventArgs e)
        {
            ListView list = (ListView)sender;

            int total = list.Items.Count;
            list.BeginUpdate();

            ListViewItem[] items = new ListViewItem[total];

            for (int i = 0; i < total; i++)
            {
                int count = list.Items.Count;
                int minIdx = 0;

                for (int j = 1; j < count; j++)
                    if (list.Items[j].SubItems[e.Column].Text.CompareTo(list.Items[minIdx].SubItems[e.Column].Text) < 0)
                        minIdx = j;

                items[i] = list.Items[minIdx];
                list.Items.RemoveAt(minIdx);
            }

            list.Items.AddRange(items);
            list.EndUpdate();
        }

        // Zeige Tabulatoren entsprechend zu behandelndem Datei-Format (aktuell nur MP3 möglich)
        private void SelectTabPages()
        {
            if (selectedFormat == "*.mp3")
            {
                TabConFileBrowser.TabPages.Remove(TabPage3);
            }
            else if (selectedFormat == "*.mp4")
            {
                TabConFileBrowser.TabPages.Remove(TabId3v2);
                TabConFileBrowser.TabPages.Remove(TabId3v1);
            }
        }

        // Wähle automatisch ersten Listeneintrag aus
        private void PreSelection(int selectedObject)
        {
            // selectedObject hat Startwert 0
            LsvFileBrowser.Items[selectedObject].Focused = true;
            LsvFileBrowser.Items[selectedObject].Selected = true;
            ShowData_Id3v2Tags();
        }

        // Wähle manuell Listeneintrag aus
        private void LsvFileBrowser_Click(object sender, EventArgs e)
        {
            // Hole Index von ausgewähltem Listeneintrag
            selectedObject = Convert.ToInt32(LsvFileBrowser.SelectedItems[0].Text);

            if (TabConFileBrowser.SelectedTab == TabId3v2)
            {
                LsvMetaData.Items.Clear();
                ShowData_Id3v2Tags();
            }

            if (TabConFileBrowser.SelectedTab == TabId3v1)
            {
                Show_Id3v1Tags(selectedObject);
            }

            if (TabConFileBrowser.SelectedTab == TabDesigner)
            {
                ShowFileName();
            }
        }

        // Anzeige aktualisieren(vorherige Auswahl gemerkt)
        private void Update_FileBrowser()
        {
            LsvFileBrowser.Items.Clear();
            ShowData_FileBrowser();

            LsvFileBrowser.Items[selectedObject].Focused = true;
            LsvFileBrowser.Items[selectedObject].Selected = true;

            LsvMetaData.Items.Clear();
            ShowData_Id3v2Tags();

            AdaptColumnsWidth(LsvFileBrowser);
            AdaptColumnsWidth(LsvMetaData);
        }

        // Schalte Steuerelemente über 'Delete All'
        private void ChkDeleteAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDeleteAll.Checked)
            {
                CmdSave_v1Tags.Enabled = true;
                CmdSave_v1Tags.Text = "&Anwenden";
                CmdSave_v2Tags.Text = "&Anwenden";
            }
            else
            {
                CmdSave_v1Tags.Text = "&Speichern";
                CmdSave_v2Tags.Text = "&Speichern";
            }
        }

        // Steuerung der Tabulatoren
        private void TabConFileBrowser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabConFileBrowser.SelectedTab == TabId3v2)
            {
                // Steuerelemente einblenden
                ChkDeleteAll.Show();
                PanDeleteAll.Show();

                // Steuerelemente deaktivieren
                ChkDeleteAll.Checked = false;
            }

            if (TabConFileBrowser.SelectedTab == TabId3v1)
            {
                // Ansicht aktualisieren
                Show_Id3v1Tags(selectedObject);

                // Steuerelemente einblenden
                ChkDeleteAll.Show();
                PanDeleteAll.Show();

                // Steuerelemente deaktivieren
                ChkDeleteAll.Checked = false;
            }

            if (TabConFileBrowser.SelectedTab == TabDesigner)
            {
                if (!ChkYesNo_Designer.Checked)
                {
                    // Steuerelemente ausblenden                    
                    LblPathToFolder_Designer.Hide();
                    CmdAddString_Designer.Hide();
                    ChkCopyToAll_Designer.Hide();
                    CmdAddTag_Designer.Hide();
                    CmdDelete_Designer.Hide();
                    CmdCancel_Designer.Hide();
                    ChkDeleteAll.Hide();
                    PanDeleteAll.Hide();

                    // Ausgabe selektierten Files
                    ShowFileName();

                    // Voreinstellungen
                    ChkCopyToAll_Designer.Checked = true;
                    LblPathToFolder_Designer.Text = "Ordner: " + pathToFolder + "\\";

                    // Informations-Panel initialisieren
                    PanInfo_Designer.Location = new Point(6, 30);
                    PanInfo_Designer.Size = new Size(683, 90);

                    LblPanInfo_Desiger.Location = new Point(3, 5);
                    LblPanInfo_Desiger.Size = new Size(677, 90);

                    LblPanInfo_Desiger.Text = "Mit dem File-Name Designer können Sie auf einfach Weise den Dateinamen " +
                                              "des selektierten Elements aus den verfügbaren Tag-Informationen generieren. " +
                                              "Außerdem können Sie dieses Benennungs-Schema auf alle Dateien im aktuellen " +
                                              "Ordner übernehmen. Wenn unter Optionen/Einstellungen das Kontrollkästchen " +
                                              "für Wiederherstellungspunkt aktiviert ist, werden Ihre Dateien mit der " +
                                              "ursprünglichen Benennung im dort angegebenen Ordner bis zum nächsten " +
                                              "Programm-Start gespeichert.";
                }
            }
        }

        #endregion

        #region Album Cover

        // Lade Cover des ausgewählten Eintrags
        private bool GetPicture(string pathToFile)
        {
            // Anzeige zurücksetzen
            PictureBox.Image = null;

            // Auswahl Datei
            var file = TagLib.File.Create(pathToFile);

            // Größe an PictureBox anpassen
            int xSize = PictureBox.Width;
            int ySize = PictureBox.Height;

            // Ausgabe, wenn Cover vorhanden
            if (file.Tag.Pictures.Length >= 1)
            {
                // Mehrere Bilder möglich, hier nur Cover -> [0]
                // vermutlich Schnittstelle zum byteweise auslesen
                TagLib.IPicture pic = file.Tag.Pictures[0];

                using (MemoryStream ms = new MemoryStream(pic.Data.Data))
                {
                    // Instanziiere Vorschaubild
                    Image currentImage = Image.FromStream(ms);
                    // Lade Vorschaubild in PictureBox                        
                    PictureBox.Image = currentImage.GetThumbnailImage(xSize, ySize, null, System.IntPtr.Zero);
                }

                // Setze Steuerelemente
                CmdLoadPic.Hide();
                CmdLoadPic.Enabled = true;
                CmdDelPic.Hide();
                CmdDelPic.Enabled = true;
                CmdCopyPic.Hide();
                CmdCopyPic.Enabled = true;
                LblCoverInfo.Text = "Wähle Cover";

                return true;
            }

            // Ausgabe, wenn kein Bild vorhanden
            else
            {
                // Setze Steuerelemente
                CmdLoadPic.Show();
                CmdLoadPic.Enabled = true;
                CmdDelPic.Show();
                CmdDelPic.Enabled = false;
                CmdCopyPic.Show();
                CmdCopyPic.Enabled = false;
                LblCoverInfo.Text = "enthält kein Cover";

                return false;
            }
        }

        // Aktionsabfrage
        private void PictureBox_Click(object sender, EventArgs e)
        {
            // wenn Steuerelemente ausgeblendet
            if (LblCoverInfo.Text == "Wähle Cover")
                if (GetPicture(Collection[selectedObject].Path))
                {
                    CmdLoadPic.Show();
                    CmdLoadPic.Enabled = true;
                    CmdDelPic.Show();
                    CmdDelPic.Enabled = true;
                    CmdCopyPic.Show();
                    CmdCopyPic.Enabled = true;
                    LblCoverInfo.Text = "Optionen";
                }
                else
                    return;

            // wenn Steuerelemente eingeblendet
            else if (LblCoverInfo.Text == "Optionen")
            {
                CmdLoadPic.Hide();
                CmdLoadPic.Enabled = true;
                CmdDelPic.Hide();
                CmdDelPic.Enabled = true;
                CmdCopyPic.Hide();
                CmdCopyPic.Enabled = true;
                LblCoverInfo.Text = "Wähle Cover";
            }

            else
                return;
        }

        // Füge Cover hinzu
        private void CmdLoadPic_Click(object sender, EventArgs e)
        {
            // Auswahl der Datei
            var file = TagLib.File.Create(Collection[selectedObject].Path);

            // Öffne Standarddialog zum Öffnen
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Multiselect = false,
                InitialDirectory = "desktop",
                Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif",
                Title = "Datei zum Öffnen auswählen"
            };

            // Übergebe Bild
            if (ofd.ShowDialog() == DialogResult.OK)
                file.Tag.Pictures = new Picture[] { new Picture(ofd.FileName) };

            // Picture-Tag speichern
            file.Save();

            // Aktualisieren
            Collection[selectedObject].id3v2_Cover = "Ja";
            GetPicture(Collection[selectedObject].Path);
            LsvFileBrowser.Items.Clear();
            ShowData_FileBrowser();
        }

        // Entferne Cover
        private void CmdDelPic_Click(object sender, EventArgs e)
        {
            // Auswahl der Datei
            var file = TagLib.File.Create(Collection[selectedObject].Path);

            // Schreibe Bild-Tag als leeres Array
            file.Tag.Pictures = new TagLib.IPicture[0];

            // Picture-Tag speichern
            file.Save();

            // Aktualisieren
            Collection[selectedObject].id3v2_Cover = "Nein";
            GetPicture(Collection[selectedObject].Path);
            LsvFileBrowser.Items.Clear();
            ShowData_FileBrowser();
        }

        // Übergebe Cover an alle Listeneinträge
        private void CmdCopyPic_Click(object sender, EventArgs e)
        {
            // Auswahl der selektierten Datei
            var parent = TagLib.File.Create(Collection[selectedObject].Path);

            // Speichere aktuelles Vorschaubild als Byte-Array
            byte[] bin = (byte[])(parent.Tag.Pictures[0].Data.Data);

            // Füge jedem Listeneintrag Vorschaubild hinzu
            foreach (FileObject fo in Collection)
            {
                var file = TagLib.File.Create(fo.Path);

                // Instanziiere Vorschaubild
                TagLib.Picture pic = new TagLib.Picture
                {
                    Type = TagLib.PictureType.FrontCover,
                    MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg,
                    Description = "Cover"
                };

                // Schreibe byteweise Vorschaubild in Datei
                using (MemoryStream ms = new MemoryStream(bin))
                {
                    pic.Data = TagLib.ByteVector.FromStream(ms);
                    file.Tag.Pictures = new TagLib.IPicture[1] { pic };
                    file.Save();
                }

                // FileObjects aktualisieren
                fo.id3v2_Cover = "Ja";

                // Ausgabe aktualisieren
                LsvFileBrowser.Items.Clear();
                ShowData_FileBrowser();
            }
        }

        #endregion        
        
        #region Designer        

        int index = 0;
        int posX = 6, lengthCbx = 120, lengthTxt = 40;
        int posY = 70, heigthCbx = 24, heigthTxt = 24;

        List<string> PartsOfName = new List<string>();
        List<string> ResetName = new List<string>();

        // Abfrage: Designer verwenden?
        private void ChkYesNo_Designer_CheckedChanged(object sender, EventArgs e)
        {
            if (!ChkYesNo_Designer.Checked)
            {
                LblInfo_Designer.Hide();
                PanInfo_Designer.Show();
                CmdAddTag_Designer.Hide();
                CmdDelete_Designer.Hide();
                CmdCancel_Designer.Hide();
                CmdAddString_Designer.Hide();
                ChkCopyToAll_Designer.Hide();
                LblPathToFolder_Designer.Hide();
                TxtFileName_Designer.ReadOnly = false;
            }
            else
            {
                PanInfo_Designer.Hide();
                CmdAddTag_Designer.Show();
                CmdDelete_Designer.Show();
                CmdCancel_Designer.Show();
                CmdAddString_Designer.Show();
                ChkCopyToAll_Designer.Show();
                LblPathToFolder_Designer.Show();
                TxtFileName_Designer.ReadOnly = true;

                if (!ChkCopyToAll_Designer.Checked)
                    LblInfo_Designer.Show();
            }
        }

        // Anzeige (File-Name) aktualisieren
        private void ShowFileName()
        {
            if (PartsOfName.Count == 0)
            {
                CmdDelete_Designer.Enabled = false;
                ChkCopyToAll_Designer.Enabled = true;
                CmdCancel_Designer.Enabled = false;

                // Zeigt aktuellen Dateinamen
                // Alte Einträge löschen
                ResetName.Clear();
                // Setze Startwert
                ResetName.Add(Collection[selectedObject].FileName);
                // Ausgabe (Reihenfolge wichtig, da Event ausgelöst wird)
                TxtFileName_Designer.Text = Collection[selectedObject].FileName;
            }
            else
            {
                // Zeige generierten Dateinamen
                TxtFileName_Designer.Text = GenerateFileName(selectedObject);
            }
        }

        // Manuelles Ändern des Dateinamens
        private void TxtFileName_Designer_TextChanged(object sender, EventArgs e)
        {
            if (TxtFileName_Designer.Enabled)
            {
                // Dateiendung aus gewähltem File-Format
                string[] split = selectedFormat.Split('*');

                // Eingelesener Dateiname könnte mehrere '.' enthalten
                string[] entered = TxtFileName_Designer.Text.Split('.');

                // Dateinamen zusammenstellen
                string enteredName = string.Empty;
                bool firstVisit = true;

                for (int i = 0; i < (entered.Length - 1); i++)
                {
                    if (firstVisit)
                    {
                        enteredName = entered[i];
                        firstVisit = false;
                    }
                    else
                        enteredName += "." + entered[i];
                }

                // Prüfe Änderung der File-Format-Angabe
                if ("." + entered[entered.Length - 1] != split[1])
                {
                    MessageBox.Show("Dateiendung kann nicht geändert werden");

                    // Eingabe zurücksetzen -> Ausgabe 
                    TxtFileName_Designer.Text = ResetName[ResetName.Count - 1];
                }
                else
                {
                    // File-Format hizufügen -> Ausgabe
                    TxtFileName_Designer.Text = enteredName + split[1];
                }

                // Neuen Wert speichern
                ResetName.Add(TxtFileName_Designer.Text);

                // Prüfe geänderten Wert
                if (TxtFileName_Designer.Text != Collection[selectedObject].FileName)
                    CmdSave_Designer.Enabled = true;
                else
                    CmdSave_Designer.Enabled = false;
            }
        }

        // Generiere Dateinamen
        private string GenerateFileName(int selectedObject)
        {
            string fileName = string.Empty;
            bool firstVisit = true;
            string[] fileType = selectedFormat.Split('*');

            // Unterscheidung ob Tag oder String
            foreach (string tagType in PartsOfName)
            {
                // Erzeuge Array über Split an '?'
                string[] noTag = tagType.Split('?');

                // Schreibe Tag, wenn Feld 0 des Arrays nicht 'naTag' enthält
                if (noTag[0] != "noTag")
                {
                    if (firstVisit)
                    {
                        fileName = Collection[selectedObject].GetTagValue(tagType);
                        firstVisit = false;
                    }
                    else
                    {
                        fileName += Collection[selectedObject].GetTagValue(tagType);
                    }
                }
                // Schreibe String, wenn Feld 0 des Arrays 'naTag' enthält
                else
                {
                    if (firstVisit)
                    {
                        fileName = noTag[1];
                        firstVisit = false;
                    }
                    else
                    {
                        fileName += noTag[1];
                    }
                }
            }

            // File-Name bereinigen und zusammensetzen
            string name = AdjustPath(fileName) + fileType[fileType.Length - 1];

            return name;
        }

        // Prüfen, welche Tags in allen Dateien vorhanden sind
        private List<string> GetAvailableTagTypes()
        {
            // Alle Felder in Array auf wahr setzen
            bool[] avail = new bool[12];
            for (int i = 0; i < avail.Length; i++) avail[i] = true;

            if (ChkCopyToAll_Designer.Checked)
            {
                // Wertabfrage aller Listeneinträge (Files)
                // Wenn kein Wert vorhanden, wird entspechender Tag nicht mit einbezogen (false)
                foreach (FileObject fo in Collection)
                {
                    if (String.IsNullOrEmpty(fo.GetTagValue("Artists"))) avail[0] = false;
                    if (String.IsNullOrEmpty(fo.GetTagValue("AlbumArtists"))) avail[1] = false;
                    if (String.IsNullOrEmpty(fo.GetTagValue("Album"))) avail[2] = false;
                    if (String.IsNullOrEmpty(fo.GetTagValue("Year"))) avail[3] = false;
                    if (String.IsNullOrEmpty(fo.GetTagValue("Track"))) avail[4] = false;
                    if (String.IsNullOrEmpty(fo.GetTagValue("Title"))) avail[5] = false;
                    if (String.IsNullOrEmpty(fo.GetTagValue("Genres"))) avail[6] = false;
                    if (String.IsNullOrEmpty(fo.GetTagValue("Disc")) ||
                                             fo.GetTagValue("Disc") == "0") avail[7] = false;
                    if (String.IsNullOrEmpty(fo.GetTagValue("DiscCount")) ||
                                             fo.GetTagValue("DiscCount") == "0") avail[8] = false;
                    if (String.IsNullOrEmpty(fo.GetTagValue("Composers"))) avail[9] = false;
                    if (String.IsNullOrEmpty(fo.GetTagValue("AmazonId"))) avail[10] = false;
                    if (String.IsNullOrEmpty(fo.GetTagValue("Comment"))) avail[11] = false;
                }
            }
            else
            {
                // Wertabfrage des selektierten Listeneintrags wird geprüft
                if (String.IsNullOrEmpty(Collection[selectedObject].GetTagValue("Artists"))) avail[0] = false;
                if (String.IsNullOrEmpty(Collection[selectedObject].GetTagValue("AlbumArtists"))) avail[1] = false;
                if (String.IsNullOrEmpty(Collection[selectedObject].GetTagValue("Album"))) avail[2] = false;
                if (String.IsNullOrEmpty(Collection[selectedObject].GetTagValue("Year"))) avail[3] = false;
                if (String.IsNullOrEmpty(Collection[selectedObject].GetTagValue("Track"))) avail[4] = false;
                if (String.IsNullOrEmpty(Collection[selectedObject].GetTagValue("Title"))) avail[5] = false;
                if (String.IsNullOrEmpty(Collection[selectedObject].GetTagValue("Genres"))) avail[6] = false;
                if (String.IsNullOrEmpty(Collection[selectedObject].GetTagValue("Disc")) ||
                                         Collection[selectedObject].GetTagValue("Disc") == "0") avail[7] = false;
                if (String.IsNullOrEmpty(Collection[selectedObject].GetTagValue("DiscCount")) ||
                                         Collection[selectedObject].GetTagValue("DiscCount") == "0") avail[8] = false;
                if (String.IsNullOrEmpty(Collection[selectedObject].GetTagValue("Composers"))) avail[9] = false;
                if (String.IsNullOrEmpty(Collection[selectedObject].GetTagValue("AmazonId"))) avail[10] = false;
                if (String.IsNullOrEmpty(Collection[selectedObject].GetTagValue("Comment"))) avail[11] = false;
            }

            // generische Liste mit allen verfügbaren Tags
            List<string> Tags = new List<string>();

            if (avail[0]) Tags.Add("Artist(en)");
            if (avail[1]) Tags.Add("Album-Artist(en)");
            if (avail[2]) Tags.Add("Album");
            if (avail[3]) Tags.Add("Jahr");
            if (avail[4]) Tags.Add("Titel-Nummer");
            if (avail[5]) Tags.Add("Titel");
            if (avail[6]) Tags.Add("Genre(s)");
            if (avail[7]) Tags.Add("CD-Nummer");
            if (avail[8]) Tags.Add("Anzahl CDs");
            if (avail[9]) Tags.Add("Komponist(en)");
            if (avail[10]) Tags.Add("Amazon ID");
            if (avail[11]) Tags.Add("Kommentar");

            return Tags;
        }

        // Füge Auswahl-Box hinzu
        private void CmdAddTag_Designer_Click(object sender, EventArgs e)
        {
            if (posX <= 567)
            {
                string name = "cbxTag" + index;

                // ComboBox initialisieren
                ComboBox CbxTag = new ComboBox();
                CbxTag.Name = name;
                CbxTag.TabIndex = index;
                CbxTag.Size = new Size(lengthCbx, heigthCbx);
                CbxTag.Location = new Point(posX, posY);
                PanFileName_Designer.Controls.Add(CbxTag);

                // Einfüge-Schaltflächen deaktivieren bis Wert selektiert
                CmdAddString_Designer.Enabled = false;
                CmdAddTag_Designer.Enabled = false;
                CmdDelete_Designer.Enabled = false;
                CmdCancel_Designer.Enabled = false;
                CmdSave_Designer.Enabled = false;

                // Bei Einzelbearbeitung ListView_FileBrowser deaktivieren
                if (!ChkCopyToAll_Designer.Checked)
                {
                    LsvFileBrowser.Enabled = false;
                    ChkCopyToAll_Designer.Enabled = false;
                }
                else
                    ChkCopyToAll_Designer.Enabled = false;

                // ComboBox füllen
                foreach (string s in GetAvailableTagTypes())
                    CbxTag.Items.Add(s);

                // Assoziiere die Event-Handling-Methode mit dem SelectedIndexChanged-Event
                CbxTag.SelectedIndexChanged += new EventHandler(CbxTag_SelectedIndexChanged);

                // hochzählen
                posX += lengthCbx;
                index++;
            }
            else
                MessageBox.Show("maximale Anzahl erreicht");
        }

        // Wert des selektierten Tags in generische Liste schreiben
        private void CbxTag_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Frage Tag-Typ der Selektion ab
            ComboBox CbxTag = (ComboBox)sender;
            string tagType = (string)CbxTag.SelectedItem;

            // Füge Tag-Typ der Liste hinzu
            PartsOfName.Add(tagType);

            // Vorschau aktualisieren
            ShowFileName();

            // Einfüge-Schaltflächen aktivieren
            CmdAddString_Designer.Enabled = true;
            CmdAddTag_Designer.Enabled = true;
            CmdDelete_Designer.Enabled = true;
            CmdCancel_Designer.Enabled = true;
            CmdSave_Designer.Enabled = true;

            // ComboBox deaktivieren
            CbxTag.Enabled = false;
        }

        // Füge Text-Box hinzu
        private void CmdAddString_Designer_Click(object sender, EventArgs e)
        {
            if (posX <= 644)
            {
                string name = "txtSign" + index;

                // TextBox initialisieren
                System.Windows.Forms.TextBox TxtSign = new System.Windows.Forms.TextBox();
                TxtSign.Name = name;
                TxtSign.TabIndex = index;
                TxtSign.Size = new Size(lengthTxt, heigthTxt);
                TxtSign.Location = new Point(posX, posY + 1);
                TxtSign.TextAlign = HorizontalAlignment.Center;
                PanFileName_Designer.Controls.Add(TxtSign);

                // Einfüge-Schaltflächen deaktivieren bis Wert selektiert
                CmdAddString_Designer.Enabled = false;
                CmdAddTag_Designer.Enabled = false;
                CmdDelete_Designer.Enabled = false;
                CmdCancel_Designer.Enabled = false;
                CmdSave_Designer.Enabled = false;

                // Bei Einzelbearbeitung ListView_FileBrowser deaktivieren
                if (!ChkCopyToAll_Designer.Checked)
                {
                    LsvFileBrowser.Enabled = false;
                    ChkCopyToAll_Designer.Enabled = false;
                }
                else
                    ChkCopyToAll_Designer.Enabled = false;

                // Text-Box fokusieren
                TxtSign.Focus();

                // Assoziiere die Event-Handling-Methode mit dem KeyDown-Event
                TxtSign.KeyDown += new KeyEventHandler(TxtSign_KeyDown);

                // hochzählen
                posX += lengthTxt;
                index++;
            }
            else
                MessageBox.Show("maximale Anzahl erreicht");
        }

        // Prüfe Zulässigkeit der eingegebenen Zeichen(kette)
        private bool UseableString(string sign)
        {
            if (sign != AdjustPath(sign))
                return false;
            else
                return true;
        }

        // Schreibe Wert der Text-Box in generische Liste wenn mit Enter bestätigt
        private void TxtSign_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                // Frage Wert der TextBox ab
                System.Windows.Forms.TextBox TxtSign = (System.Windows.Forms.TextBox)sender;
                string sign = (string)TxtSign.Text;

                if (sign.Length > 0)
                {
                    if (UseableString(sign))
                    {
                        // Schreibe Erkennungsmerkmal und Sonderzeichen in Liste
                        PartsOfName.Add("noTag?" + sign);

                        // Einfüge-Schaltflächen aktivieren
                        CmdAddString_Designer.Enabled = true;
                        CmdAddTag_Designer.Enabled = true;
                        CmdDelete_Designer.Enabled = true;
                        CmdCancel_Designer.Enabled = true;
                        CmdSave_Designer.Enabled = true;

                        // Vorschau aktualisieren
                        ShowFileName();

                        // TextBox deaktivieren
                        TxtSign.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(@"Sonderzeichen: [\\/:*? "" <>|] werden in Dateinamen nicht unterstützt",
                                         "Unzulässige Zeicheneingabe", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        DeleteLastPart();

                        // Einfüge-Schaltflächen aktivieren
                        CmdAddString_Designer.Enabled = true;
                        CmdAddTag_Designer.Enabled = true;
                        CmdDelete_Designer.Enabled = true;
                        CmdCancel_Designer.Enabled = true;
                        CmdSave_Designer.Enabled = true;

                        // Ansicht aktualisieren
                        ShowFileName();
                    }
                }
            }
        }

        // Event-Handler um letztes, angefügtes Steuerelement zu löschen
        private void CmdDelete_Designer_Click(object sender, EventArgs e)
        {
            // Letztes Steuerelement löschen
            DeleteLastPart();

            // Letztes Namens-Feld löschen
            PartsOfName.RemoveAt(index);

            // Ansicht aktualisieren
            ShowFileName();
        }

        // Letztes Steuerelement löschen und Anfügekoordinate entsprechend reduzieren
        private void DeleteLastPart()
        {
            index--;

            // Letztes Steuerelement entfernen
            foreach (Control item in PanFileName_Designer.Controls)
            {
                if (item.Name == "cbxTag" + index)
                {
                    PanFileName_Designer.Controls.Remove(item);
                    posX -= lengthCbx;
                    break;
                }

                else if (item.Name == "txtSign" + index)
                {
                    PanFileName_Designer.Controls.Remove(item);
                    posX -= lengthTxt;
                    break;
                }
            }
        }

        // Hinweis schalten
        private void ChkCopyToAll_Designer_CheckedChanged(object sender, EventArgs e)
        {
            if (!ChkCopyToAll_Designer.Checked)
                LblInfo_Designer.Show();
            else
                LblInfo_Designer.Hide();
        }

        // Änderungen verwerfen
        private void CmdCancel_Designer_Click(object sender, EventArgs e)
        {
            if (!ChkCopyToAll_Designer.Checked)
            {
                LsvFileBrowser.Enabled = true;
                ChkCopyToAll_Designer.Enabled = true;
            }
            else
                ChkCopyToAll_Designer.Enabled = true;

            index--;

            // Alle Steuerelemente entfernen
            do
            {
                foreach (Control item in PanFileName_Designer.Controls)
                {
                    if (item.Name == "cbxTag" + index)
                    {
                        PanFileName_Designer.Controls.Remove(item);
                        PartsOfName.RemoveAt(index);
                        posX -= lengthCbx;
                        index--;
                    }

                    else if (item.Name == "txtSign" + index)
                    {
                        PanFileName_Designer.Controls.Remove(item);
                        PartsOfName.RemoveAt(index);
                        posX -= lengthTxt;
                        index--;
                    }
                }

            } while (index > -1);

            index++;

            // Ansicht aktualisieren
            ShowFileName();
        }

        // Änderungen übernehmen
        private void CmdSave_Designer_Click(object sender, EventArgs e)
        {
            // Bei Verzicht auf File-Name Designer
            if (!ChkYesNo_Designer.Checked)
            {
                UpdateFileName(selectedObject, TxtFileName_Designer.Text);

                CmdSave_Designer.Enabled = false;
            }
            else
            {
                // Aktion bei Einfachauswahl
                if (!ChkCopyToAll_Designer.Checked)
                {
                    UpdateFileName(selectedObject, GenerateFileName(selectedObject));

                    LsvFileBrowser.Enabled = true;
                    ChkCopyToAll_Designer.Enabled = true;
                }

                // Aktion bei Mehrfachauswahl (mind. ein Unterscheidungskriterium)
                else
                {
                    bool allNamesUnique = true;

                    // Prüfung der Dateinamen auf Eindeutigkeit
                    for (int i = 0; i < Collection.Count; i++)
                    {
                        string testName = GenerateFileName(i);
                        FileObject testObject = Collection[i];

                        for (int j = 0; j < Collection.Count; j++)
                        {
                            if (testObject != Collection[j])
                            {
                                if (testName == GenerateFileName(j))
                                {
                                    allNamesUnique = false;
                                }

                            }

                        }

                    }

                    if (allNamesUnique)
                    {
                        // Sicherung und Umbenennen aller Dateien im Ordner
                        for (int i = 0; i < Collection.Count; i++)
                        {
                            UpdateFileName(i, GenerateFileName(i));
                        }

                        ChkCopyToAll_Designer.Enabled = true;
                    }

                    else
                        MessageBox.Show("Datei-Benennungsschema muss mindestens ein Unterscheidungskriterium aufweisen");
                }
            }

            // FileBrowser aktualisieren
            Update_FileBrowser();
        }

        // Aktualisiere Dateinamen
        private void UpdateFileName(int selectedObject, string newName)
        {
            if (Convert.ToBoolean(Config.ChkBackup))
            {
                if (!Collection[selectedObject].BackupDone)
                {
                    // Abbruchbedingung - liefert true oder false - wenn Backup nicht möglich
                    if (CreateBackup(pathToFolder, Config.PathToBackup, Collection[selectedObject].FileName))
                        Collection[selectedObject].BackupDone = true;
                    else
                        return;
                }
            }

            RenameFile(Collection[selectedObject].Path, newName);

            Collection[selectedObject].Path = pathToFolder + "\\" + newName;
            Collection[selectedObject].FileName = newName;
        }

        // Erzeuge Backup
        private bool CreateBackup(string sourceDir, string backupDir, string fileName)
        {
            try
            {
                // Löst Exception aus, wenn nicht möglich
                DirectoryInfo di = new DirectoryInfo(Config.PathToBackup);
                di.GetDirectories();

                try
                {
                    // Wenn File bereits existiert wird es nicht überschrieben
                    System.IO.File.Copy(Path.Combine(sourceDir, fileName), Path.Combine(backupDir, fileName));
                    return true;
                }

                // Exception, wenn File bereits existiert
                catch (IOException)
                {
                    MessageBox.Show("Das Backup-Verzeichnis enthält bereits eine Datei\n" +
                                    "mit der Bezeichnung: " + fileName +
                                    "\n\nVorgang wird abgebrochen.",
                                    "Fehler beim Erzeugen des Backups", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Catch exception if directory couldn't be found
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Das angegebene Backup-Verzeichnis konnte nicht gefunden werden.\n" +
                                "Bitte überprüfen Sie Ihre Angabe unter Optionen/Einstellungen.\n\n" +
                                "Vorgang wird abgebrochen.",
                                "Fehler beim Erzeugen des Backups", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Überprüfe Einstellungen
                Options Options = new Options(this);
                Options.StartPosition = FormStartPosition.CenterParent;
                Options.ShowDialog(this);

                // Nach schließen des Unterdialogs
                TxtFileName_Designer.Text = Collection[selectedObject].FileName;
                Config.Initialize();

                return false;
            }
        }

        // Dateinamen ändern
        private static void RenameFile(string path, string newName)
        {
            try
            {
                // Rename File
                try
                {
                    var fileInfo = new FileInfo(path);
                    System.IO.File.Move(path, fileInfo.Directory + "\\" + newName);
                }

                // Catch exception if the file was already copied.
                catch (IOException copyError)
                {
                    MessageBox.Show(copyError.Message);
                }
            }

            // Catch exception if directory couldn't be found
            catch (DirectoryNotFoundException dirNotFound)
            {
                MessageBox.Show(dirNotFound.Message);
            }
        }

        // Methode entfernt alle Zeichen die in Dateinamen nicht erlaubt sind.
        private string AdjustPath(string Input)
        {
            return System.Text.RegularExpressions.Regex.Replace(Input, @"[\\/:*?""<>|]", string.Empty);
        }

        #endregion

        #region ID3v2-Tags

        // Lese >>alle<< Metadaten für ausgewähltes Element(merke Index)
        private void ShowData_Id3v2Tags()
        {
            // Zeige Album-Cover der Auswahl
            GetPicture(Collection[selectedObject].Path);

            // Zeige Metadaten
            ListViewItem entry;
            entry = LsvMetaData.Items.Add("Artist(en)");
            entry.SubItems.Add(Collection[selectedObject].id3v2_Artists);
            entry = LsvMetaData.Items.Add("Album-Artist(en)");
            entry.SubItems.Add(Collection[selectedObject].id3v2_AlbumArtists);
            entry = LsvMetaData.Items.Add("Album");
            entry.SubItems.Add(Collection[selectedObject].id3v2_Album);
            entry = LsvMetaData.Items.Add("Jahr");
            entry.SubItems.Add(Collection[selectedObject].id3v2_Year);
            entry = LsvMetaData.Items.Add("Titel-Nummer");
            entry.SubItems.Add(Collection[selectedObject].id3v2_Track);
            entry = LsvMetaData.Items.Add("Titel");
            entry.SubItems.Add(Collection[selectedObject].id3v2_Title);
            entry = LsvMetaData.Items.Add("Genre(s)");
            entry.SubItems.Add(Collection[selectedObject].id3v2_Genres);
            entry = LsvMetaData.Items.Add("CD-Nummer");
            entry.SubItems.Add(Collection[selectedObject].id3v2_Disc);
            entry = LsvMetaData.Items.Add("Anzahl CDs");
            entry.SubItems.Add(Collection[selectedObject].id3v2_DiscCount);
            entry = LsvMetaData.Items.Add("Komponist(en)");
            entry.SubItems.Add(Collection[selectedObject].id3v2_Composers);
            entry = LsvMetaData.Items.Add("Amazon ID");
            entry.SubItems.Add(Collection[selectedObject].id3v2_AmazonId);
            entry = LsvMetaData.Items.Add("Kommentar");
            entry.SubItems.Add(Collection[selectedObject].id3v2_Comment);
        }

        // Editiere selektierte(n) Eintrag / Einträge (Aufruf Unterdialog Editor)
        private void LsvMetaData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Informationen des selektierten Tags
            string tagType = LsvMetaData.SelectedItems[0].Text;
            string tagValue = LsvMetaData.SelectedItems[0].SubItems[1].Text;

            // Öffne Unterdialog zum Bearbeiten des Tags
            Editor Editor = new Editor(this, tagType, tagValue);
            Editor.StartPosition = FormStartPosition.CenterParent;
            Editor.ShowDialog(this);

            // Speichere vorherigen Zusatand und übernehme Änderungen
            if (tagValue != Editor.tagValue || Editor.copyToAll == true)
            {

                // wenn mehrere Einträge bearbeitet wurden
                if (Editor.copyToAll)
                {
                    string[] tagValues = new string[Collection.Count];

                    // Erfasse aller Objekte vorherigen Wert des zu bearbeitenden Tags
                    for (int i = 0; i < Collection.Count; i++)
                        tagValues[i] = Collection[i].GetTagValue(tagType);

                    // Speichere Zustand vor Änderung
                    Memory Command = new Memory(selectedObject, tagType, tagValues, Editor.copyToAll);
                    History.Add(Command);

                    // Schreibe neue Werte
                    foreach (FileObject fo in Collection)
                        fo.ChangeTagValue(tagType, Editor.tagValue);
                }

                // wenn einzelner Eintrag bearbeitet wurde
                else
                {
                    // Speichere Zustand vor Änderung
                    Memory Command = new Memory(selectedObject, tagType, tagValue, Editor.copyToAll);
                    History.Add(Command);

                    // Schreibe neue Werte
                    Collection[selectedObject].ChangeTagValue(tagType, Editor.tagValue);
                }

                // Ansicht aktualisieren
                Update_FileBrowser();
            }
        }

        // Methodik um Änderung zurückzusetzen
        private void ChangesResetting()
        {
            // Änderungen der letzten Aktion
            int lastAction = History.Count - 1;
            int editedTrack = History[lastAction].EditedTrack;
            string editedTagType = History[lastAction].EditedTagType;
            string originalTagValue = History[lastAction].OriginalTagValue;
            bool copiedToAll = History[lastAction].CopiedToAll;
            string[] originalTagValues = History[lastAction].OriginalTagValues;

            // Übernehme Änderungen
            if (copiedToAll)
                for (int i = 0; i < Collection.Count; i++)
                    Collection[i].ChangeTagValue(editedTagType, originalTagValues[i]);

            else
                Collection[editedTrack].ChangeTagValue(editedTagType, originalTagValue);

            // Lösche letzte Aktion
            History.RemoveAt(lastAction);
        }

        // Letzte Änderung(en) schrittweise zurücksetzen
        private void CmdUndoStepwise_Click(object sender, EventArgs e)
        {
            if (History.Count > 0)
                ChangesResetting();

            Update_FileBrowser();
        }

        // Alle Änderungen rückgängig
        private void CmdUndoAll_Page1_Click(object sender, EventArgs e)
        {
            if (History.Count > 0)
            {
                if (MessageBox.Show("Wirklich alle Änderungen zurücksetzen?", "Aktion nicht rückgängig",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    for (int i = History.Count - 1; i >= 0; i--)
                    {
                        ChangesResetting();
                    }

                    Update_FileBrowser();
                }
                else
                    return;
            }
        }

        // Änderungen übernehmen
        private void CmdWrite_Page1_Click(object sender, EventArgs e)
        {
            // alle Tags entfernen (wird nicht gespeichert)
            if (ChkDeleteAll.Checked == true)
            {
                if (MessageBox.Show("Wirklich alle Einträge entfernen?", "Aktion nicht rückgängig",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    foreach (FileObject fo in Collection)
                        fo.ClearTags();

                    ChkDeleteAll.Checked = false;

                    Update_FileBrowser();
                }
                else
                {
                    ChkDeleteAll.Checked = false;
                    return;
                }
            }

            // alle Tags (aller Files) speichern
            else
            {
                try
                {
                    try
                    {
                        foreach (FileObject fo in Collection)
                        {
                            // Datei-Bezug über Pfadangabe in FileObject herstellen
                            TagLib.File file = TagLib.File.Create(fo.Path);

                            // Tag-Strings mit Mehrfachangabe in Array wandeln
                            string[] albArtsArr = fo.id3v2_AlbumArtists.Split(';', ',');
                            string[] compsArr = fo.id3v2_Composers.Split(';', ',');
                            string[] artistsArr = fo.id3v2_Artists.Split(';', ',');
                            string[] genresArr = fo.id3v2_Genres.Split(';', ',');

                            // Werte entsprechend konvertieren und zuweisen
                            file.Tag.DiscCount = Convert.ToUInt16(fo.id3v2_DiscCount);
                            file.Tag.Track = Convert.ToUInt16(fo.id3v2_Track);
                            file.Tag.Year = Convert.ToUInt16(fo.id3v2_Year);
                            file.Tag.Disc = Convert.ToUInt16(fo.id3v2_Disc);
                            file.Tag.AlbumArtists = albArtsArr;
                            file.Tag.AmazonId = fo.id3v2_AmazonId;
                            file.Tag.Artists = artistsArr;
                            file.Tag.Comment = fo.id3v2_Comment;
                            file.Tag.Composers = compsArr;
                            file.Tag.Genres = genresArr;
                            file.Tag.Title = fo.id3v2_Title;
                            file.Tag.Album = fo.id3v2_Album;

                            // Datei speichern
                            file.Save();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Fehler beim Schreiben der Tags");
                    }
                }
                catch (DirectoryNotFoundException dirNotFound)
                {
                    MessageBox.Show(dirNotFound.Message);
                }
            }
        }

        #endregion

        #region ID3v1-Tags (noch in Arbeit...)

        // Anzeige aktualisieren
        private void Show_Id3v1Tags(int selectedOject)
        {
            TxtArtist_v1Tag.Text = Collection[selectedObject].Id3v1_Artist;
            TxtAlbum_v1Tag.Text = Collection[selectedObject].Id3v1_Album;
            TxtYear_v1Tag.Text = Collection[selectedObject].Id3v1_Year;
            TxtTrack_v1Tag.Text = Collection[selectedObject].Id3v1_Track;
            TxtTitle_v1Tag.Text = Collection[selectedObject].Id3v1_Title;
            // TxtGenre_v1Tag.Text = Collection[selectedObject].id3v1_Genre; // todo
            // TxtComment_v1Tag.Text = Collection[selectedObject].id3v1_Comment; // todo

            // Steuerelemente deaktivieren
            CmdSave_v1Tags.Enabled = false;
            CmdUndoAll_v1Tags.Enabled = false;
        }

        // Steuerelemente aktivieren
        private void Tags_TextChanged(object sender, EventArgs e)
        {
            CmdSave_v1Tags.Enabled = true;
            CmdUndoAll_v1Tags.Enabled = true;
        }

        // ID3v2 Einträge übernehmen
        private void CmdCopyAll_id3v2Tags(object sender, EventArgs e)
        {
            TxtArtist_v1Tag.Text = Collection[selectedObject].id3v2_Artists;
            TxtAlbum_v1Tag.Text = Collection[selectedObject].id3v2_Album;
            TxtYear_v1Tag.Text = Collection[selectedObject].id3v2_Year;
            TxtTrack_v1Tag.Text = Collection[selectedObject].id3v2_Track;
            TxtTitle_v1Tag.Text = Collection[selectedObject].id3v2_Title;
            TxtGenre_v1Tag.Text = Collection[selectedObject].id3v2_Genres;
            TxtComment_v1Tag.Text = Collection[selectedObject].id3v2_Comment;
        }

        // Änderungen verwerfen
        private void CmdUndoAll_v1Tags_Click(object sender, EventArgs e)
        {
            Show_Id3v1Tags(selectedObject);
        }

        // Speichere ID3v1 Tags
        private void CmdSave_v1Tags_Click(object sender, EventArgs e)
        {
            if (ChkDeleteAll.Checked)
            {
                TxtArtist_v1Tag.Text = string.Empty;
                TxtAlbum_v1Tag.Text = string.Empty;
                TxtYear_v1Tag.Text = string.Empty;
                TxtTrack_v1Tag.Text = string.Empty;
                TxtTitle_v1Tag.Text = string.Empty;
                TxtGenre_v1Tag.Text = string.Empty;
                TxtComment_v1Tag.Text = string.Empty;

                ChkDeleteAll.Checked = false;
                CmdSave_v1Tags.Text = "Speichern";
            }
            else
            {
                ID3File file = new ID3File(Collection[selectedObject].Path);
                ID3v1Tag id3v1 = file.ID3v1Tag;

                // Reihenfolge wichtig, da Werte beim Übergeben an FileObject
                // an die maximal mögliche Zeichenlänge angepasst werden.
                // Anschließend wird der gekürzte String in der Anzeige dargestellt.
                // Dies ist notwendig, da bei ID3v1 fest vorgegebene Byte-Größe
                // der jeweiligen Information. Da mit der Einführung von Genres die
                // maximal zulässige Anzahl Bytes (128) nicht überschritten wird,
                // wurde der Kommentar gekürzt. Problematik noch nicht implementiert.

                // Schreibe neue Werte in selektiertes FileObject
                Collection[selectedObject].Id3v1_Artist = TxtArtist_v1Tag.Text;
                Collection[selectedObject].Id3v1_Album = TxtAlbum_v1Tag.Text;
                Collection[selectedObject].Id3v1_Year = TxtYear_v1Tag.Text;
                Collection[selectedObject].Id3v1_Track = TxtTrack_v1Tag.Text;
                Collection[selectedObject].Id3v1_Title = TxtTitle_v1Tag.Text;
                // Collection[selectedObject].Id3v1_Genre = TxtGenre_v1Tag.Text; // todo
                // Collection[selectedObject].Id3v1_Comment = TxtComment_v1Tag.Text; // todo

                // Übergeben Werte aus FileObject an Tags der Datei
                id3v1.Artist = Collection[selectedObject].Id3v1_Artist;
                id3v1.Album = Collection[selectedObject].Id3v1_Album;
                id3v1.Year = Collection[selectedObject].Id3v1_Year;
                id3v1.TrackNumber = Collection[selectedObject].Id3v1_Track;
                id3v1.Title = Collection[selectedObject].Id3v1_Title;
                // id3v1.Genre = Collection[selectedObject].Id3v1_Genre; // todo
                // id3v1.Comment = Collection[selectedObject].Id3v1_Comment; // todo

                // Tags in ausgewählte Datei schreiben
                file.Save(Collection[selectedObject].Path);

                // Anzeige aktualisieren
                // Update_FileBrowser(); // Stellt aktuell keine relevante Einträge dar // todo
                Show_Id3v1Tags(selectedObject);
            }
        }

        #endregion        
    }
}
