using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Lab._4CS
{
    class StudentEnumerator : IEnumerator
    {
        private List<Exam> Exam;
        private List<Test> Test;
        private int position = -1;

        public StudentEnumerator(List<Exam> Exams, List<Test> Tests)
        {
            this.Exam = Exams;
            this.Test = Tests;
        }

        public bool MoveNext()
        {
            for (int i = position + 1; i < Exam.Count; i++)
            {
                foreach (var test in Test)
                {
                    if ((test as Test).name_subject == ((Exam[i] as Exam).subject))
                    {
                        position = i;
                        return true;
                    }

                }
            }
            return false;
        }

        public object Current
        {
            get
            {
                if (position == -1 || position >= Exam.Count) throw new InvalidOperationException();
                return Exam[position];
            }
        }

        public void Reset()
        {
            position = -1;

        }

    }
}
