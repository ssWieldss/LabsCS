using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab._3CS
{
        delegate TKey KeySelector<TKey>(Student st);

        delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    class Program
    {

        static void Main(string[] args)
        {

            //1 пункт задания

            Student student = new Student("Егор", "Смирнов", new DateTime(2002, 8, 13), Education.Bachelor, 124);


            student.Add_Exams(new Exam("Физика", 5, new DateTime(2020, 1, 18)));
            student.Add_Exams(new Exam("Математика", 3, new DateTime(2020, 1, 11)));
            student.Add_Exams(new Exam("Электротехника", 4, new DateTime(2021, 1, 11)));
            student.Add_Test(new Test("Физика", true));

            student.Sort_by_Date();
            Console.WriteLine("Сортировка по дате:\n");
            Console.WriteLine(student.ToString());

            Console.WriteLine("---------------------------------");

            student.Sort_by_Subject();
            Console.WriteLine("Сортировка по предмету:\n");
            Console.WriteLine(student.ToString());

            Console.WriteLine("---------------------------------");

            student.Sort_by_Number();
            Console.WriteLine("Сортировка по оценке:\n");
            Console.WriteLine(student.ToString());

            //2 пункт задания

            KeySelector<String> selector = delegate (Student secstudent)
            {
                return secstudent.GetHashCode().ToString();
            };

            StudentCollection<string> studentCollection = new StudentCollection<string>(selector);

            studentCollection.AddDefaults();

            Student student1 = new Student("Егор", "Смирнов", new DateTime(2002, 8, 13), Education.Bachelor, 120);
            Student student2 = new Student("Геннадий", "Смирнов", new DateTime(2004, 8, 13), Education.SecondEducation, 130);
            Student student3 = new Student("Галина", "Смирнова", new DateTime(2006, 8, 13), Education.Bachelor, 140);

            student1.Add_Exams(new Exam("Физика", 5, new DateTime(2020, 1, 18)));
            student1.Add_Exams(new Exam("СРМА", 3, new DateTime(2020, 1, 19)));

            student2.Add_Exams(new Exam("Математика", 3, new DateTime(2020, 1, 11)));
            student3.Add_Exams(new Exam("Электротехника", 4, new DateTime(2021, 1, 11)));

            studentCollection.AddStudents(student1, student2, student3);

            Console.WriteLine("---------------------------------");
            Console.WriteLine(studentCollection.ToString());


            //3 пункт задания

            double max_Middle = studentCollection.Max_Middle;
            Console.WriteLine("Максимальное значние средней оценки в коллекции: " + max_Middle + "\n");

            Console.WriteLine("Соответствия форме обучения: \n");
            foreach (var educ in studentCollection.EducationForm(Education.SecondEducation))
            {
                Console.WriteLine(educ.ToString());
            }

            Console.WriteLine("Группировка студентов по форме обучения:\n");
            foreach (var item in studentCollection.Group_by_Education)
            {
                foreach (var stud in item)
                    Console.WriteLine(stud);
            }

            //4 пункт задания

            GenerateElement<Person, Student> elem = delegate (int j)
            {
                var key = new Person("Егор " + j, "Номер: " + j, new DateTime(2002+j, 8, 13));
                var value = new Student("Егор " + j, "Номер: " + j, new DateTime(2002 + j, 8, 13), (Education)(j % 3 + 1), 101+j);
                return new KeyValuePair<Person, Student>(key, value);
            };

            Console.WriteLine("Введите количество студентов \n");

            string num = Console.ReadLine();
            int c = int.Parse(num);

            var test = new TestCollections<Person, Student>(c, elem);

            Stopwatch sw = new Stopwatch();

            //List

            Console.WriteLine("List: \n");
            sw.Start();
            test.Search_In_TKeyList();
            sw.Stop();
            Console.WriteLine("Время выполнения ListTkey:" + sw.ElapsedMilliseconds + "мсек\n");

            sw.Start();
            test.Search_In_StringList();
            sw.Stop();
            Console.WriteLine("Время выполнения ListString:" + sw.ElapsedMilliseconds + "мсек\n");


            //Dictionary

            Console.WriteLine("Dictionary: \n");
            sw.Start();
            test.Search_In_TKeyDictionary();
            sw.Stop();
            Console.WriteLine("Время выполнения DictionaryTkey:" + sw.ElapsedMilliseconds + "мсек\n");

            sw.Start();
            test.Search_In_StringDictionary();
            sw.Stop();
            Console.WriteLine("Время выполнения DictionaryString:" + sw.ElapsedMilliseconds + "мсек\n");


            Console.WriteLine("Dictionary(value): \n");
            sw.Start();
            test.Search_In_TKeyDictionary_by_Value();
            sw.Stop();
            Console.WriteLine("Время выполнения DictionaryTkey(value):" + sw.ElapsedMilliseconds + "мсек\n");

            sw.Start();
            test.Search_In_StringDictionary_by_Value();
            sw.Stop();
            Console.WriteLine("Время выполнения DictionaryString(value):" + sw.ElapsedMilliseconds + "мсек\n");


        }
    }
}

