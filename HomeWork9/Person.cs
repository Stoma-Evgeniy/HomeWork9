﻿namespace HomeWork9
{
    public class Person
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string FullName {  get { return Surname + " " + Name; } }
    }
}