using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab._2CS
{
    class Student: Person , IDateAndCopy
    {
        private Education education;
        private int group;
        private ArrayList Exam;
        private ArrayList Test;

        public Student()
        {
            name = "name";
            surname = "surname";
            birthday = new DateTime(2000, 1, 1);
            education = Education.Bachelor;
            group = 24;
            Exam = new ArrayList();
            Test = new ArrayList();
        }

        public Student(string _name, string _surname, DateTime _birthday, Education _education, int _group)
        {
            name = _name;
            surname = _surname;
            birthday = _birthday;
            education = _education;
            group = _group;
            Exam = new ArrayList();
            Test = new ArrayList();
        }

        public Education getseteducation
        {
            get
            {
                return education;
            }
            set
            {
                education = value;
            }
        }

        public Person Person
        {
            get => new Person(name, surname, birthday);

            set
            {
                name = value.Name;
                surname = value.Surname;
                birthday = value.Birthday;
            }
        }

        public double Get_middle
        {
            get
            {
                int count = 0;
                double middle = 0;

                foreach (Exam item in Exam)
                {
                    middle += item.mark;
                }

                if (count != 0)
                    middle = middle / count;

                return middle;
            }
        }

        public bool this[Education e]
        {
            get
            {
                return education == e;
            }
        }

        public ArrayList _Exam
        {
            get => Exam;
            set
            {
                Exam = value;
            }
        }

        public void Add_Exams(params Exam[] exams)
        {
            if (Exam == null) 
                Exam = new ArrayList();
            Exam.AddRange(exams);
        }

        public void Add_Test(params Test[] tests)
        {
            if (Test == null)
                Test = new ArrayList();
            Test.AddRange(tests);
        }

        public virtual string ToString()
        {
            string Text = "----------------------------------------------------\n";
            Text += name + " " + surname + " " + birthday + "\n";

            foreach (var Exam in Exam)
            {
                Exam a = Exam as Exam;
                Text += a.ToString() + "\n";
            }

            Text += "Passed Exams:\n";

            foreach (var test in Test)
            {
                Test p = test as Test;
                Text += p.ToString() + "\n";
            }
            Text += education + group;

            return Text;

        }

        public virtual string ToShortString()
        {
            return name + " " + surname + " " + birthday + " " + education + " " + group + " " + Get_middle;
        }

        public virtual object DeepCopy()
        {
            Student s = new Student(name, surname, birthday, education, group);

            foreach (Exam e in this.Exam)
            {
                s.Exam.Add(e.DeepCopy());
            }

            foreach (Test test in this.Test)
            {
                s.Test.Add(test);
            }

            return s;
        }

        public DateTime Date { get; set; }

        public int Group
        {
            get { return group; }
            set
            {
                
                    if ((value > 100) && (value < 599))
                        group = value;
                    else
                        throw new ArgumentOutOfRangeException("Введите значение в диапазоне от 101 до 599!");
               
               
            }
        }

        public IEnumerable Get_Results()
        {
            foreach (var exam in Exam)
                yield return exam;

            foreach (var test in Test)
                yield return test;
        }

        public IEnumerable Exams_Above(int min)
        {
            foreach (var exam in Exam)
            {
                Exam ex = exam as Exam;

                if (ex.mark > min)
                    yield return exam;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(Exam, Test);
        }

        public IEnumerable Passed_Exams_And_Tests()
        {
            foreach (var item in this.Exam)
            {
                if ((item as Exam).mark > 2)
                    yield return item;
            }

            foreach (var item in this.Test)
            {
                if ((item as Test).pass == true)
                    yield return item;
            }
        }

        public IEnumerable Done_Test_In_Exam()
            {
            foreach (var test in this.Test)
            {
               if ((test as Test).pass == true)
                 foreach (var exam in this.Exams_Above(2))
                 {
                   if ((test as Test).name_subject == (exam as Exam).subject)
                    yield return test;
                 }
}
        }

    }
}
