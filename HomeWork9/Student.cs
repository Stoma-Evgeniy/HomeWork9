using System.Collections.Generic;
using static HomeWork9.DataStorage;

namespace HomeWork9
{
        
        public class Student : Person, IMarkRecipient
        {
            public string ID { get; set; }
                               
            public Group Group { get; set; }

            private List<int> marks = new List<int>();
            public List<int> Marks 
            { 
            get { return marks; } 
            }

        

        public void AddMark(int mark)
        {
            if (mark < 0 || mark > 10)
                throw new WrongMarkException ($"Оценка {mark} должна быть от 0 до 10"); ;
            Marks.Add(mark);
        }
    }

    public interface IMarkRecipient
    {
        void AddMark(int mark);
    }
}

    
