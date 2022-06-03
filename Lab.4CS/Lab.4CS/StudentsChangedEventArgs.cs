using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab._4CS
{
    class StudentsChangedEventArgs<Tkey>: EventArgs
    {
        public string CollectionName { get; set; }
        public Action CallEvent { get; set; }
        public string PropertyName { get; set; }
        public Tkey ChangedKey { get; set; }
        public StudentsChangedEventArgs(string name, Action call, string propname, Tkey changedkey)
        {
            CollectionName = name;
            CallEvent = call;
            PropertyName = propname;
            ChangedKey = changedkey;
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            s.Append($"Changing in collection: {CollectionName}\n");
            s.Append($"Changing status: {CallEvent}");
            s.Append($"Changing in property {PropertyName}");
            s.Append($"Changing element with key {ChangedKey}");

            return s.ToString();
        }
    }
}

