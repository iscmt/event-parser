using System;

namespace EventParser.GUI
{
    internal class DataRecord
    {
        public String Level { get; set; }
        public String DateAndTime { get; set; }
        public String Source { get; set; }
        public String EventID { get; set; }
        public String TaskCategory { get; set; }
        public String InformationDump { get; set; }
    }
}