using System;
using System.Collections.Generic;

namespace HomeWork9
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Добрый день");

            Console.WriteLine("Имя");
            string name = Console.ReadLine();
            Console.WriteLine("Фамилия");
            string surname = Console.ReadLine();

            new Student()
            {
                Name = name,
                Surname = surname,
            };

            Console.WriteLine(StudentsGroup.Students);


        }
    }
}
