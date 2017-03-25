using System;

namespace Common
{
    public static class Utils
    {
        public static bool TryEnterNumberFromConsole(out uint number)
        {
            Console.Write("Введите число: ");
            string numberAsString = Console.ReadLine();

            if (!(uint.TryParse(numberAsString, out number)))
            {
                Console.Write("Ввели не число");
                return false;
            }

            return true;
        }
    }
}
