using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Net;


namespace Lab._5CS
{
    [Serializable]
    class Student: Person, IEnumerable
    {
        private Person person;
        private Education education;
        private int group;
        private List<Exam> Exam;
        private List<Test> Test;
        public event PropertyChangedEventHandler PropertyChanged;

        public Student(Person persone, Education _education, int _group)
        {
            person = persone;
            education = _education;
            group = _group;
            Exam = new List<Exam>();
            Test = new List<Test>();
        }

        public Student()
        {
            person = new Person();
            education = Education.Bachelor;
            group = 24;
            Exam = new List<Exam>();
            Test = new List<Test>();
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("set education"));
            }
        }

        public Person Person
        {
            get
            {
                return person;
            }
            set
            {
                person = value;
            }
        }

        public double Get_middle
        {
            get
            {
                int count = -1;
                double middle = 0;

                foreach (Exam item in Exam)
                {
                    middle += item.mark;
                    count++;
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

        public List<Exam> _Exam
        {
            get => Exam;
            set
            {
                Exam = value;
            }
        }
        public List<Test> _Test
        {
            get => Test;
            set
            {
                Test = value;
            }
        }

        public void Add_Exams(params Exam[] exams)
        {
            if (Exam == null)
                Exam.Add(new Exam());
            Exam.AddRange(exams);
        }

        public void Add_Test(params Test[] tests)
        {
            if (Test == null)
                Test.Add(new Test());
            Test.AddRange(tests);
        }

        public override string ToString()
        {
            string Text = null;
            Text += person.ToString() + "\n";

            foreach (var Exam in Exam)
            {
                Exam a = Exam as Exam;
                Text += a.ToString() + "\n";
            }

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
            return Person.ToString() + " " + education + " " + group + " " + Get_middle;
        }

        public DateTime Date { get; set; }

        public int Group
        {
            get { return group; }
            set
            {

                if ((value > 100) && (value < 599))
                {
                    group = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("set group"));
                }
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

        public void Sort_by_Subject()
        {
            Exam.Sort();
        }
        public void Sort_by_Number()
        {
            Exam.Sort(new Exam());
        }
        public void Sort_by_Date()
        {
            Exam.Sort(new ExamvsExam());
        }

        public object DeepCopy()
        {

                try
                {
                    MemoryStream memoryStream = new MemoryStream();
                    BinaryFormatter binaryFormatter = new BinaryFormatter();

                    binaryFormatter.Serialize(memoryStream, this);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    return binaryFormatter.Deserialize(memoryStream);
                }
                catch (Exception e)
                {
                    throw new Exception("Ошибка копирования!");
                }

            }

        public bool Save(string fileName)
        {
            return Save(fileName, this);
        }

        public bool Load(string fileName)
        {
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(fileName, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();

                Student Obj = formatter.Deserialize(fileStream) as Student;


                name = Obj.Name;
                surname = Obj.Surname;
                birthday = Obj.Birthday;
                education = Obj.getseteducation;
                group = Obj.Group;
                Test = Obj._Test;
                Exam = Obj._Exam;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddFromConsole()
        {
            try
            {
                Console.WriteLine("Введите данные экзамена - название, оценка, дата через пробел");
                string exstr = Console.ReadLine();

                string[] exarr = exstr.Split(',', ' ');

                if (exarr.Length != 3)
                {
                    Console.WriteLine("Ошибка ввода. Объект не добавлен!");
                    return false;
                }
                string subject = exarr[0];
                int mark = int.Parse(exarr[1]);
                DateTime date = DateTime.Parse(exarr[2]);


                Exam.Add(new Exam(subject, mark, date));
            }
            catch (FormatException)
            {
                Console.WriteLine("Данные введены неверно! Объект не добавлен!");
                return false;
            }
            return true;
        }
        public static bool Save(string fileName, Student stud)
        {
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(fileStream, stud);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }

        }
        public static bool Load(string fileName, ref Student obj)
        {
            if (obj != null)
                return obj.Load(fileName);
            else
                throw new ArgumentNullException();
        }

        public static bool operator ==(Student obj1, Student obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }
            if (ReferenceEquals(obj1, null))
            {
                return false;
            }
            if (ReferenceEquals(obj2, null))
            {
                return false;
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(Student obj1, Student obj2)
        {
            return !(obj1 == obj2);
        }
    }

}
