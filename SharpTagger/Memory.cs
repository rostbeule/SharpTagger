namespace Tagger
{
    public class Memory
    {
        public int EditedTrack { get; private set; }
        public string EditedTagType { get; private set; }
        public string OriginalTagValue { get; private set; }
        public bool CopiedToAll { get; private set; }
        public string[] OriginalTagValues { get; private set; }

        /// <summary>
        /// Konstruktor für einzelne Werte, wenn nur Einzelwert möglich
        /// </summary>
        /// <param name="track"></param>
        /// <param name="tagType"></param>
        /// <param name="tagValue"></param>
        /// <param name="copyToAll"></param>
        public Memory(int track, string tagType, string tagValue, bool copyToAll)
        {
            EditedTrack = track;
            EditedTagType = tagType;
            OriginalTagValue = tagValue;
            CopiedToAll = copyToAll;
        }

        /// <summary>
        /// Konstruktor für Werte-Array, wenn Mehrfacheingabe möglich
        /// </summary>
        /// <param name="track"></param>
        /// <param name="tagType"></param>
        /// <param name="tagValues"></param>
        /// <param name="copyToAll"></param>
        public Memory(int track, string tagType, string[] tagValues, bool copyToAll)
        {
            EditedTrack = track;
            EditedTagType = tagType;
            OriginalTagValues = tagValues;
            CopiedToAll = copyToAll;
        }

        public override string ToString()
        {
            return EditedTrack + " " + EditedTagType + " " + OriginalTagValue + " " + CopiedToAll;
        }
    }
}
