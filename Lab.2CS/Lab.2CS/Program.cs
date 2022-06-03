using System;
using System.Diagnostics;

namespace Lab._2CS
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 пункт задания

            Person Person1 = new Person();
            Person Person2 = new Person();

            Console.WriteLine("Равенство объектов:");
            Console.WriteLine( Person1.Equals(Person2) );

            Console.WriteLine("Равенство ссылок:");
            Console.WriteLine( ReferenceEquals(Person2, Person1) );

            Console.WriteLine("Значения хеш-кодов:");
            Console.WriteLine(Person1.GetHashCode());
            Console.WriteLine(Person2.GetHashCode());

            //2 пункт задания

            Student student = new Student("Егор", "Смирнов", new DateTime(2002, 8, 13), Education.Bachelor, 124);

           
            student.Add_Exams(new Exam("Физика", 5, new DateTime(2020, 1, 18)));
            student.Add_Exams(new Exam("Математика", 3, new DateTime(2020, 1, 11)));
            student.Add_Test(new Test("Физика", true));

            Console.WriteLine(student.ToString());

            //3 пункт задания

            Console.WriteLine("---------------------------------");
            Console.WriteLine(student.Person.ToString());

            //4 пункт задания

            Student student_clone = (Student)student.DeepCopy();
            student.Name = "Геннадий";
            student.Surname = "Sergeev";

            Console.WriteLine(student.ToString());
            Console.WriteLine(student_clone.ToString());

            //5 пункт задания

            try
            {
                student.Group = 600;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            //6 пункт задания

            Console.WriteLine("-------------------------------6--------------------------");

            foreach (var task in student.Get_Results())

                Console.WriteLine(task.ToString());

            //7 пукнт задания

            Console.WriteLine("------------------------------7---------------------------");

            foreach (var task in student.Exams_Above(3))

                Console.WriteLine(task.ToString());

            //8 пункт задания

            Console.WriteLine("-----------------------------8----------------------------");

            foreach (var exam in student)
            {
                Console.WriteLine((exam as Exam).subject);
            }

            //9 пункт задания

            Console.WriteLine("----------------------------9-----------------------------");

            foreach (var test in student.Passed_Exams_And_Tests())
                Console.WriteLine(test.ToString());

            //10 пункт задания

            Console.WriteLine("----------------------------10----------------------------");

            foreach (var test in student.Done_Test_In_Exam())
                Console.WriteLine(test.ToString());

        }
    }
}

