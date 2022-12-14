using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_DB
{
    public class Book
    {
        public int Id { get; private set; }
        public string FullNameWriter { get; private set; }
        public string Name { get; private set; }
        public int YearPublication { get; private set; }
        public int NumberWardrobe { get; private set; }
        public int NumberShelf { get; private set; }

        public Book(int id, string fullNameWriter, string name, int yearPublication, int numberWardrobe, int numberShelf)
        {
            Id = id;
            FullNameWriter = fullNameWriter;
            Name = name;
            YearPublication = yearPublication;
            NumberWardrobe = numberWardrobe;
            NumberShelf = numberShelf;
        }
        public override string ToString()
        {
            return $"{Id}. {FullNameWriter} - {Name}. Опубликована {YearPublication} г. Номер шкафа {NumberWardrobe}. Номер полки {NumberShelf}. ";
        }
    }
}
