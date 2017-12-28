using System;
using System.IO;
using System.Windows.Forms;

namespace Tagger
{
    public class FileObject
    {        
        private int index = -1;
        private string fileName;
        private bool backupDone;
        private string path = string.Empty;

        private const int MaxArtistLength = 30;
        private const int MaxAlbumLength = 30;
        private const int MaxTitleLength = 30;
        private const int MaxYearLength = 4;
        private const int MaxTracknumberValue = 255;
        private const int MaxCommentLengthVersion1_0 = 30; // todo
        private const int MaxCommentLengthVersion1_1 = 28; // todo

        private string id3v1_Artist = string.Empty;
        private string id3v1_Album = string.Empty;
        private string id3v1_Track = string.Empty;
        private string id3v1_Title = string.Empty;
        private string id3v1_Year = string.Empty;
        public string id3v1_Genre = string.Empty; // todo -> private
        public string id3v1_Comment = string.Empty; // todo -> private

        public string id3v2_Track = string.Empty;
        public string id3v2_Title = string.Empty;
        public string id3v2_Album = string.Empty;
        public string id3v2_Year = string.Empty;
        public string id3v2_Artists = string.Empty;
        public string id3v2_AlbumArtists = string.Empty;
        public string id3v2_Genres = string.Empty;
        public string id3v2_Cover = string.Empty;
        public string id3v2_AmazonId = string.Empty;
        public string id3v2_Comment = string.Empty;
        public string id3v2_Composers = string.Empty;
        public string id3v2_Disc = string.Empty;
        public string id3v2_DiscCount = string.Empty;


        public FileObject(int index)
        {
            Index = index;
        }

        #region Methoden allgemein

        public int Index
        {
            get { return index; }

            set
            {
                if (index < 0)
                    index = value;
            }
        }

        public string Path
        {
            get { return path; }

            set
            {
                if (path == string.Empty)
                    path = value;

                else if (File.Exists(value))
                    path = value;                
            }
        }

        public bool BackupDone
        {
            get { return backupDone; }

            set
            {
                if (value == true)
                    backupDone = true;
            }
        }

        public string FileName
        {
            get { return fileName; }

            set
            {
                string[] split = value.Split('\\');
                fileName = split[split.Length - 1];
            }
        }

        #endregion

        #region Methoden für ID3v1-Tags

        /// <summary>
        /// Festlegen und Ausgeben des Tags Artist (ID3v1).
        /// Limitierung der Zeichenlänge auf 30 Zeichen.
        /// </summary>
        public string Id3v1_Artist
        {
            get { return id3v1_Artist; }

            set
            {
                id3v1_Artist = Truncate(value, MaxArtistLength);
            }
        }

        /// <summary>
        /// Festlegen und Ausgeben des Tags Album (ID3v1).
        /// Limitierung der Zeichenlänge auf 30 Zeichen.
        /// </summary>
        public string Id3v1_Album
        {
            get { return id3v1_Album; }

            set
            {
                id3v1_Album = Truncate(value, MaxAlbumLength);
            }
        }

        /// <summary>
        /// Festlegen und Ausgeben des Tags Jahr (ID3v1).
        /// Limitierung der Zeichenlänge auf 4 Zeichen.
        /// </summary>
        public string Id3v1_Year
        {
            get { return id3v1_Year; }

            set
            {
                id3v1_Year = Truncate(value, MaxYearLength);
            }
        }

        /// <summary>
        /// Festlegen und Ausgeben der Tags Titel-Nummer (ID3v1).
        /// Limitierung des Eingabewerts von 0 bis 255.
        /// </summary>
        public string Id3v1_Track
        {
            get { return id3v1_Track; }

            set
            {
                if (Convert.ToInt32(value) >= 0 && Convert.ToInt32(value) <= 255)
                    id3v1_Track = value;
                else
                    id3v1_Track = null;
            }
        }

        /// <summary>
        /// Festlegen und Ausgeben des Tags Titel (ID3v1).
        /// Limitierung der Zeichenlänge auf 30 Zeichen.
        /// </summary>
        public string Id3v1_Title
        {
            get { return id3v1_Title; }

            set
            {
                id3v1_Title = Truncate(value, MaxTitleLength);
            }
        }

        /// <summary>
        /// Methode zum Kürzen des zu übergebenden Tag-Strings.
        /// Länge des Strings vom jeweiligen Tag-Typ abhängig.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns>Zeichenlängen limitierter String</returns>
        private string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        #endregion

        #region Methoden für ID3v2-Tags

        /// <summary>
        /// Gibt Wert des angegebenen Tags zurück
        /// </summary>
        /// <param name="tagType"></param>
        /// <returns></returns>
        public string GetTagValue(string tagType)
        {
            switch (tagType)
            {
                case "Artists":
                case "Artist(en)":
                    return id3v2_Artists;

                case "AlbumArtists":
                case "Album-Artist(en)":
                    return id3v2_AlbumArtists;

                case "Album":
                    return id3v2_Album;

                case "Year":
                case "Jahr":
                    return id3v2_Year;

                case "Track":
                case "Titel-Nummer":
                    return id3v2_Track;

                case "Title":
                case "Titel":
                    return id3v2_Title;

                case "Genres":
                case "Genre(s)":
                    return id3v2_Genres;

                case "AmazonId":
                case "Amazon ID":
                    return id3v2_AmazonId;

                case "Comment":
                case "Kommentar":
                    return id3v2_Comment;

                case "Composers":
                case "Komponist(en)":
                    return id3v2_Composers;

                case "Disc":
                case "CD-Nummer":
                    return id3v2_Disc;

                case "DiscCount":
                case "Anzahl CDs":
                    return id3v2_DiscCount;

                default:
                    MessageBox.Show
                    ("Unbekannter Tag-Typ", "FileObject: GetTagValue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "error";
            }
        }


        /// <summary>
        /// weist Wert eines beliebigen Tags automatisch dem Richtigen zu
        /// </summary>
        /// <param name="tagType"></param>
        /// <param name="tagValue"></param>
        public void ChangeTagValue(string tagType, string tagValue)
        {
            switch (tagType)
            {
                case "Artists":
                case "Artist(en)":
                    id3v2_Artists = tagValue;
                    break;

                case "AlbumArtists":
                case "Album-Artist(en)":
                    id3v2_AlbumArtists = tagValue;
                    break;

                case "Album":
                    id3v2_Album = tagValue;
                    break;

                case "Year":
                case "Jahr":
                    id3v2_Year = tagValue;
                    break;

                case "Track":
                case "Titel-Nummer":
                    id3v2_Track = tagValue;
                    break;

                case "Title":
                case "Titel":
                    id3v2_Title = tagValue;
                    break;

                case "Genres":
                case "Genre(s)":
                    id3v2_Genres = tagValue;
                    break;

                case "AmazonId":
                case "Amazon ID":
                    id3v2_AmazonId = tagValue;
                    break;

                case "Comment":
                case "Kommentar":
                    id3v2_Comment = tagValue;
                    break;

                case "Composers":
                case "Komponist(en)":
                    id3v2_Composers = tagValue;
                    break;

                case "Disc":
                case "CD-Nummer":
                    id3v2_Disc = tagValue;
                    break;

                case "DiscCount":
                case "Anzahl CDs":
                    id3v2_DiscCount = tagValue;
                    break;

                default:
                    MessageBox.Show
                    ("Unbekannter Tag-Typ", "FileObject: ChangeTagValue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }


        /// <summary>
        /// Entfernt alle Einträge
        /// </summary>
        public void ClearTags()
        {
            id3v2_Track = string.Empty;
            id3v2_Title = string.Empty;
            id3v2_Album = string.Empty;
            id3v2_Year = string.Empty;
            id3v2_Artists = string.Empty;
            id3v2_AlbumArtists = string.Empty;
            id3v2_Genres = string.Empty;
            id3v2_Cover = string.Empty;
            id3v2_AmazonId = string.Empty;
            id3v2_Comment = string.Empty;
            id3v2_Composers = string.Empty;
            id3v2_Disc = string.Empty;
            id3v2_DiscCount = string.Empty;
        }

        #endregion

        #region Methoden für MP4 - Tags

        // noch nicht implementiert

        #endregion

        #region override ToString()

        public override string ToString()
        {
            return "Location: " + Path + Environment.NewLine +
                   "Track: " + id3v2_Track + Environment.NewLine +
                   "Title: " + id3v2_Title + Environment.NewLine +
                   "Album: " + id3v2_Album + Environment.NewLine +
                   "Year: " + id3v2_Year + Environment.NewLine +
                   "Artist(s): " + id3v2_Artists + Environment.NewLine +
                   "AlbumArtist(s): " + id3v2_AlbumArtists + Environment.NewLine +
                   "Genre(s): " + id3v2_Genres + Environment.NewLine +
                   "AmazonId: " + id3v2_AmazonId + Environment.NewLine +
                   "Comment: " + id3v2_Comment + Environment.NewLine +
                   "Composers: " + id3v2_Composers + Environment.NewLine +
                   "Disc: " + id3v2_Disc + Environment.NewLine +
                   "DiscCount: " + id3v2_DiscCount + Environment.NewLine +
                   "Cover: " + id3v2_Cover;
        }

        #endregion
    }
}
