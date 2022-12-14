using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_DB
{
    public static class LoadData
    {
        public static Book[] ReadBooks(string nameFile)
        {
            string[] lines = File.ReadAllLines(nameFile);
            Book[] books = new Book[lines.Length];

            for (int i = 0; i < books.Length; i++)
            {
                string[] line = lines[i].Split(';');
                IsRightCountColumns(line, 6, nameFile);
                IsRightBook(line);
                books[i] = new Book(int.Parse(line[0]), line[1], line[2], int.Parse(line[3]), int.Parse(line[4]), int.Parse(line[5]));
            }
            return books;
        }
        public static Reader[] ReadReaders(string nameFileReaders, string nameFileReadersBooks)
        {
            string[] linesReadersBooks = File.ReadAllLines(nameFileReadersBooks);

            string[] linesReaders = File.ReadAllLines(nameFileReaders);
            Reader[] readers = new Reader[linesReaders.Length];

            for (int i = 0; i < readers.Length; i++)
            {
                string[] line = linesReaders[i].Split(';');
                IsRightCountColumns(line, 3, nameFileReaders);
                IsRightReader(line);
                Dictionary<int, DateTime> dateTake = new Dictionary<int, DateTime>();
                Dictionary<int, DateTime> dateReturn = new Dictionary<int, DateTime>();
                for (int j = 0; j < linesReadersBooks.Length; j++)
                {

                    string[] lineDates = linesReadersBooks[j].Split(';');
                    IsRightCountColumns(lineDates, 4, nameFileReadersBooks);
                    if (line[0] == lineDates[0])
                    {
                        IsInt(lineDates[1], "Id книги");
                        int id = int.Parse(lineDates[1]);
                        bool isDateTime1 = DateTime.TryParse(lineDates[2], out DateTime dateTake_);
                        bool isDateTime2 = DateTime.TryParse(lineDates[3], out DateTime dateReturn_);
                        dateTake[id] = dateTake_;
                        dateReturn[id] = dateReturn_;
                    }
                }
                readers[i] = new Reader(int.Parse(line[0]), line[1], int.Parse(line[2]), dateTake, dateReturn);
            }
            return readers;
        }
        private static void OutputErrorCountColumns(string nameFile)
        {
            Console.WriteLine($"Ошибка количества столбцов в файле {nameFile}.");
            Environment.Exit(0);
        }
        private static bool IsRightCountColumns(string[] date, int count, string nameFile)
        {
            if (date.Length != count)
                OutputErrorCountColumns(nameFile);
            return true;
        }
        private static void OutputErrorType(string nameError)
        {
            Console.WriteLine($"Ошибка типа данных в столбце {nameError}.");
            Environment.Exit(0);
        }
        private static bool IsInt(string num, string nameColumn)
        {
            if (!int.TryParse(num, out int number))
                OutputErrorType(nameColumn);
            return true;
        }
        private static bool IsRightBook(string[] data)
        {
            IsInt(data[0], "Id книги");
            IsInt(data[3], "Год публикации");
            IsInt(data[4], "Номер шкафа");
            IsInt(data[5], "Номер полки");
            return true;
        }

        private static bool IsRightReader(string[] data)
        {
            IsInt(data[0], "Id читателя");
            IsInt(data[2], "Номер читательского билета");
            return true;
        }
        private static void IsRightDates(bool isRight)
    }
}
