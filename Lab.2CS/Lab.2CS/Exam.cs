using System;
using System.Collections.Generic;
using System.Text;

namespace Lab._2CS
{
    class Exam: IDateAndCopy
    {
        public string subject { get; set; }

        public int mark { get; set; }

        public DateTime examtime { get; set; }

        public Exam(string subjectValue, int markValue, DateTime examValue)
        {
            subject = subjectValue;
            mark = markValue;
            examtime = examValue;
        }

        public Exam() : this("Математика", 5, new DateTime(2000, 1, 1))
        { }

        public override string ToString()
        {
            return subject + " " + mark + " " + examtime.ToShortDateString();
        }
        public object DeepCopy()
        {
            return new Exam { subject = this.subject, mark = this.mark, examtime = this.examtime };
        }
        public DateTime Date { get; set; }

    }
}

