using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab._4CS
{
    class JournalEntry
    {
        public string CollectionName { get; set; }
        public Action EventStatus { get; set; }
        public string ChangedPropertyName { get; set; }
        public string StrElementKey { get; set; }

        public JournalEntry(string name, Action status, string propname, string strkey)
        {
            CollectionName = name;
            EventStatus = status;
            ChangedPropertyName = propname;
            StrElementKey = strkey;
        }
        public override string ToString()
        {
            return $"Collection name: {CollectionName}\n" +
                   $"Event status: {EventStatus}\n" +
                   $"Property caused elements changing: {ChangedPropertyName}\n" +
                   $"Changed element key: {StrElementKey}\n";
        }
    }
}
