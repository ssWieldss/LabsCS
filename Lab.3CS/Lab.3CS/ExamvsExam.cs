using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab._3CS
{
    class ExamvsExam: IComparer<Exam>
    {
        private Exam examsfirst;
        private Exam examssecond;
        public ExamvsExam(Exam examsfirst, Exam examssecond)
        {
            this.examsfirst = examsfirst;
            this.examssecond = examssecond;
        }
        public ExamvsExam()
        {
            examsfirst = new Exam();
            examssecond = new Exam();
        }
        public int Compare(Exam x, Exam y)
        {
            return x.examtime.CompareTo(y.examtime);
        }
    }
}
