using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_DB
{
    public class Reader
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public int NumberReaderTiсket { get; private set; }
        public Dictionary<int, DateTime> DateTake { get; private set; }
        public Dictionary<int, DateTime> DateReturn { get; private set; }
        public Reader(int id, string fullName, int numberReaderTiсket, Dictionary<int, DateTime> dateTake, Dictionary<int, DateTime> dateReturn)
        {
            Id = id;
            FullName = fullName;
            NumberReaderTiсket = numberReaderTiсket;
            DateTake = dateTake;
            DateReturn = dateReturn;
        }
        public override string ToString()
        {
            return $"{Id}. Полное имя читателя {FullName}. Номер читательского билета {NumberReaderTiсket}.";
        }
        public string ToString(Book book)
        {
            if (DateTake.ContainsKey(book.Id))
                return $"{Id}. Полное имя читателя {FullName}. Номер читательского билета {NumberReaderTiсket}.\n" +
                $"Книга {book.Name} взята на чтение {DateTake[book.Id].ToString("d")} и возвращена в библиотеку {DateReturn[book.Id].ToString("d")}.";
            else
                return $"{Id}. Полное имя читателя {FullName}. Номер читательского билета {NumberReaderTiсket}.\n" +
                    $"Данный читатель не брал книгу {Id}. {book.FullNameWriter} - {book.Name}";
        }
        public static string ToString(Reader[] readers, Book book)
        {
            StringBuilder result = new StringBuilder();
            foreach (Reader reader in readers)
            {
                if (reader.DateTake.ContainsKey(book.Id))
                    result.Append($"{reader.Id}. Полное имя читателя {reader.FullName}. Номер читательского билета {reader.NumberReaderTiсket}.\n" +
                    $"Книга {book.Name} взята на чтение {reader.DateTake[book.Id].ToString("d")} и возвращена в библиотеку {reader.DateReturn[book.Id].ToString("d")}.\n");
            }
            return result.ToString();
        }
    }
}
