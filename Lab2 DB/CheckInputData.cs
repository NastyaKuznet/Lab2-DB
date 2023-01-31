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
        public static void InputErrorRightCountColumns(string[] date, int count, string nameFile)
        {
            if (date.Length != count)
                OutputErrorCountColumns(nameFile);
        }
        private static void OutputErrorType(string nameError)
        {
            Console.WriteLine($"Ошибка типа данных в столбце {nameError}.");
            Environment.Exit(0);
        }
        private static void InputErrorInt(string num, string nameColumn)
        {
            if (!int.TryParse(num, out int number))
                OutputErrorType(nameColumn);
        }
        private static void InputErrorDateTime(string num, string nameColumn)
        {
            if (!DateTime.TryParse(num, out DateTime dateTime))
                OutputErrorType(nameColumn);
        }
        public static void CheckInputBook(string[] data)
        {
            InputErrorInt(data[0], "Id книги");
            InputErrorInt(data[3], "Год публикации");
            InputErrorInt(data[4], "Номер шкафа");
            InputErrorInt(data[5], "Номер полки");
        }

        public static void CheckInputReader(string[] data)
        {
            InputErrorInt(data[0], "Id читателя");
            InputErrorInt(data[2], "Номер читательского билета");
        }
        public static void CheckInputRiderBooks(string[] data)
        {
            InputErrorInt(data[0], "Id читателя");
            InputErrorInt(data[1], "Id книги");
            InputErrorDateTime(data[2], "Дата взятия книги");
            InputErrorDateTime(data[3], "Дата возврата книги");
        }
    }
}
