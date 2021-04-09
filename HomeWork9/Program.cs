using System;
using System.Collections.Generic;
using System.Linq;
using static HomeWork9.DataStorage;

namespace HomeWork9
{

    public class StudentsPublisher
    {
        public delegate void CreateStudent();
        public event CreateStudent StudentNewCreated;

        public void Process()
        {
            StudentNewCreated();
        }
    }

    public class StudentsSubscriber
    {
        public string Name { get; set; }
        public StudentsSubscriber(string name)
        {
            Name = name;
        }
        public void StudentNewHandler()
        {
            Console.WriteLine("Student was received");
            Console.WriteLine($"Subscriber = {Name}");
        }
    }

    

    partial class Program
    {

        static void Main(string[] args)
        {
            StudentsPublisher studentsPublisher = new StudentsPublisher();
            StudentsSubscriber teacher = new StudentsSubscriber("Учитель1");

            studentsPublisher.StudentNewCreated += teacher.StudentNewHandler;
            studentsPublisher.Process();


            Console.WriteLine("Добрый день");

            
            Student student1 = new Student { ID = "1", Name = "Ivan", Surname = "Ivanov", };
            Student student2 = new Student { ID = "2", Name = "Petr", Surname = "Petrov", };

            DataStorage.Instance.Students.Add(student1);
            DataStorage.Instance.Students.Add(student2);

            
            



            while (true)
            {
                Console.WriteLine("Вы хотите" +
                    "\nсоздать студента-1" +
                    "\nредактировать студента-2" +
                    "\nудалить студента-3" +
                    "\nпросмотреть список студентов-4" +
                    "\nсоздать группу-5" +
                    "\nредактировать группу-6" +
                    "\nудалить группу-7" +
                    "\nпросмотреть список групп-8"+
                    "\nдобавить оценку-9");
                int command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        var newStudent = InputNewStudent();
                        DataStorage.Instance.Students.Add(newStudent);
                        break;
                    case 2:
                        EditStudent();
                        break;
                    case 3: 
                        var removeStudent = RemoveStudent();
                        DataStorage.Instance.Students.Remove(removeStudent);
                        break;
                    case 4:
                        PrintStudents(DataStorage.Instance.Students);
                        break;
                    case 5:
                        var newGroup = InputNewGroup();
                        DataStorage.Instance.Groups.Add(newGroup);
                        break;
                    case 6:
                        EditGroup();
                        break;
                    case 7:
                        RemoveGroup();
                        break;
                    case 8:
                        PrintGroups(DataStorage.Instance.Groups);
                        break;
                    /*case 9:
                        try
                        {
                            student1.AddMark(7);

                        }
                        catch (WrongMarkException exc)
                        {
                            Console.WriteLine(exc);
                        };
                        break;*/
                }

            }

        }

        private static void StudentsPublisher_StudentNewCreated()
        {
            throw new NotImplementedException();
        }

        private static Group InputNewGroup()
        {
            Console.WriteLine("Новая группа");
            var number = Console.ReadLine();
            
            Group group = new Group { Number= number };


            return group;
        }

        private static void EditGroup()
        {
            PrintGroups(DataStorage.Instance.Groups);
            Console.WriteLine("Введите номер группы для изменения");
            var num = Console.ReadLine();
            var editGroup = DataStorage.Instance.Groups.FirstOrDefault(g => g.Number == num);

            
            Console.WriteLine("Введите новую группу");
            var group = Console.ReadLine();

            
            editGroup.Number = num;
            
            PrintStudents(DataStorage.Instance.Students); ;
        }

        private static Group RemoveGroup()
        {
            PrintGroups(DataStorage.Instance.Groups);
            Console.WriteLine("Введите номер группы для изменения");
            var num = Console.ReadLine();
            var removeGroup = DataStorage.Instance.Groups.FirstOrDefault(g => g.Number == num);

            return removeGroup;
        }

        private static void PrintGroups(List<Group> groups)
        {
            foreach(var g in groups)
            {
                Console.WriteLine($"{g.Number}");
            }
        }

        private static Student InputNewStudent()
        {
            Console.WriteLine("ID");
            var id = Console.ReadLine();
            Console.WriteLine("Имя");
            var name = Console.ReadLine();
            Console.WriteLine("Фамилия");
            var surname = Console.ReadLine();

            Student student = new Student {ID=id, Name = name, Surname = surname };


            return student;
        }
        private static void EditStudent()
        {
            PrintStudents(DataStorage.Instance.Students);
            Console.WriteLine("Введите ID студента для изменения");
            var num = Console.ReadLine();
            var editStudent = DataStorage.Instance.Students.FirstOrDefault(s => s.ID == num);

            Console.WriteLine("Введите новое имя");
            var name = Console.ReadLine();

            Console.WriteLine("Введите новую фамилию");
            var surname = Console.ReadLine();

            Console.WriteLine("Введите новую группу");
            var group = Console.ReadLine();
            var newGroup = DataStorage.Instance.Groups.FirstOrDefault(g => g.Number == group);

            editStudent.Name = name;
            editStudent.Surname = surname;
            editStudent.Group = newGroup;

            PrintStudents(DataStorage.Instance.Students);
        }


        private static Student RemoveStudent()
        {
            PrintStudents(DataStorage.Instance.Students);
            Console.WriteLine("Введите ID студента для изменения");
            var num = Console.ReadLine();
            var removeStudent = DataStorage.Instance.Students.FirstOrDefault(s => s.ID == num);

            return removeStudent;
        }

        private static void PrintStudents(List<Student> students)
        {
            foreach (var s in students)
            {
                Console.WriteLine($"{s.ID} {s.Name} {s.Surname} {s.Group?.Number} {s.Marks}");
            };
        }

        
    }
}

    
