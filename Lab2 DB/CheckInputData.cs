using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_DB
{
    public static class CheckInputData
    {
        private static void OutputErrorCountColumns(string nameFile)
        {
            Console.WriteLine($"Ошибка количества столбцов в файле {nameFile}.");
            Environment.Exit(0);
        }
        public static void IsRightCountColumns(string[] date, int count, string nameFile)
        {
            if (date.Length != count)
                OutputErrorCountColumns(nameFile);
        }
        private static void OutputErrorType(string nameError)
        {
            Console.WriteLine($"Ошибка типа данных в столбце {nameError}.");
            Environment.Exit(0);
        }
        private static void IsInt(string num, string nameColumn)
        {
            if (!int.TryParse(num, out int number))
                OutputErrorType(nameColumn);
        }
        private static void IsDateTime(string num, string nameColumn)
        {
            if (!DateTime.TryParse(num, out DateTime dateTime))
                OutputErrorType(nameColumn);
        }
        public static void IsRightBook(string[] data)
        {
            IsInt(data[0], "Id книги");
            IsInt(data[3], "Год публикации");
            IsInt(data[4], "Номер шкафа");
            IsInt(data[5], "Номер полки");
        }

        public static void IsRightReader(string[] data)
        {
            IsInt(data[0], "Id читателя");
            IsInt(data[2], "Номер читательского билета");
        }
        public static void IsRightRiderBooks(string[] data)
        {
            IsInt(data[0], "Id читателя");
            IsInt(data[1], "Id книги");
            IsDateTime(data[2], "Дата взятия книги");
            IsDateTime(data[3], "Дата возврата книги");
        }
    }
}
