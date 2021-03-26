using System;
using System.Collections.Generic;

namespace HomeWork9
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Добрый день");

            List<Student> students = new List<Student>();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Вы хотите\nсоздать-1\nредактировать-2\nудалить-3\nпросмотреть-4");
                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:

                        Console.WriteLine("Имя");
                        string name = Console.ReadLine();
                        Console.WriteLine("Фамилия");
                        string surname = Console.ReadLine();

                        new Student()
                        {
                            Name = name,
                            Surname = surname,
                        };


                        break;
                    case 2:


                        break;
                    case 3:
                        
                        break;
                    case 4:
                        foreach (var s in students)
                        {
                            Console.WriteLine(s);
                        };

                        break;
                }

            }
                        
        }
    }
}
