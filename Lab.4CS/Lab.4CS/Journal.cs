using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab._4CS
{
    class Journal
    {
        private List<JournalEntry> journal = new List<JournalEntry>();
        public void CollectionEventContoller(object subject, EventArgs ev)
        {
            var e = (StudentsChangedEventArgs<string>)ev;

            JournalEntry NewEntry = new JournalEntry(e.CollectionName, e.CallEvent, e.PropertyName, e.ChangedKey.ToString());

            journal.Add(NewEntry);
        }


        public override string ToString()
        {
            string result = "";
            foreach (JournalEntry temp in journal)
            {
                result += temp.ToString() + "\n";
            }
            return result;
        }
    }
}
