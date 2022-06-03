using System;
using System.Collections.Generic;
using System.Text;

namespace Lab._5CS
{
    [Serializable]
    class Exam: IDateAndCopy, IComparable, IComparer<Exam>
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

        public Exam() : this("Математика", 0, new DateTime(2000, 1, 1))
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


        public int CompareTo(object obj)
        {
                if (obj == null) return 1;

                Exam exam = obj as Exam;
                if (exam != null)
                    return this.subject.CompareTo(exam.subject);
                else
                    throw new ArgumentException("Объект не является Экзаменом");
        }

        public int Compare(Exam x, Exam y)
        {
            if (x.mark == y.mark)
                return 0;
            if (x.mark < y.mark)
                return -1;
            if (x.mark > y.mark)
                return 1;
            else throw new ArgumentException("Неверные данные!");
        }

    }
}

