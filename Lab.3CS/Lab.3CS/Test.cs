using System;
using System.Collections.Generic;
using System.Text;

namespace Lab._3CS
{
    class Test
    {
        public string name_subject { get; set; }
        public bool pass { get; set; }

        public Test()
        {
            name_subject = "Математика";
            pass = false;
        }
        public Test(string name_subject, bool pass)
        {
            this.name_subject = name_subject;
            this.pass = pass;
        }

        public override string ToString()
        {
            return name_subject + " " + pass;
        }
    }
}
