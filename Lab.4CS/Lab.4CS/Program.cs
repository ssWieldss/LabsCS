using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab._4CS
{
       

        delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    class Program
    {

        static void Main(string[] args)
        {
            //1 пункт задания

            KeySelector<String> selector1 = studentcol1 => studentcol1.GetHashCode().ToString();
            StudentCollection<string> stCollection1 = new StudentCollection<string>(selector1);
            stCollection1.CollectionName = "Student Collection 1";

            KeySelector<String> selector2 = studentcol2 => studentcol2.GetHashCode().ToString();
            StudentCollection<string> stCollection2 = new StudentCollection<string>(selector2);
            stCollection2.CollectionName = "Student Collection 2";

            //2 пункт задания

            Student student1 = new Student("Егор", "Смирнов", new DateTime(2002, 8, 13), Education.Bachelor, 124);
            Student student2 = new Student("Геннадий", "Смирнов", new DateTime(2004, 8, 13), Education.SecondEducation, 130);
            Student student3 = new Student("Галина", "Смирнов", new DateTime(2006, 8, 13), Education.Bachelor, 140);

            Journal journal = new Journal();
            stCollection1.StudentsChanged += journal.CollectionEventContoller;
            stCollection2.StudentsChanged += journal.CollectionEventContoller;

            // 3 пункт задания
            stCollection1.AddStudents(student1);
            stCollection2.AddStudents(student2, student3);

            student1.getseteducation = Education.Specialist;
            student3.Group = 122;

            stCollection1.Remove(student1);
            stCollection2.Remove(student2);

            // 4 пункт задания
            student2.Group = 166;

            Console.WriteLine("\n\nChanges:\n");
            Console.WriteLine(journal);

        }
    }
}

