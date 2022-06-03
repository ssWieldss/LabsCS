using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Lab._5CS
{
       
    class Program
    {

        static void Main(string[] args)
        {
            //1 пункт задания

            Person p = new Person("Егор", "Смирнов", new DateTime(2002, 8, 13));
            Student s = new Student(p, Education.Bachelor, 124);

            var mCopy = s.DeepCopy();
            Console.WriteLine(mCopy.ToString());

            //2 пункт задания

            Console.WriteLine("Введите имя файла для загрузки ");
            string filename = Console.ReadLine();

            Student student2 = new Student();

            if (File.Exists(filename))
            {
                if (student2.Load(filename))
                    Console.WriteLine("Загрузка объекта завершена");
                else
                    Console.WriteLine("Ошибка загрузки файла");
            }
            else
                Console.WriteLine("Файла с таким именем не существует");
     
            Console.WriteLine("Этот файл будет использоваться для хранения данных");

            // 3 пункт задания

            Console.WriteLine(student2);

            // 4 пункт задания

            Console.Write("Введите имя файла для сохранения ");
            string filename2 = Console.ReadLine();
            Console.WriteLine();

            Student student3 = new Student();
            while (!student3.AddFromConsole())
            {
                Console.WriteLine("\n\nДобавление студента: \n");
            }

            student3.Save(filename2);
            Console.WriteLine("Объект");
            Console.WriteLine(student3);

            // 5 пункт задания

            if (Student.Load(filename2, ref student3))
                Console.WriteLine("Чтениe объекта из файла успешно");

            //6 пункт задания 

            Console.WriteLine(student3.ToString());
        }
    }
}

