using System;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string enteredString = Console.ReadLine();

            StringHelper sHelper = new StringHelper(enteredString);

            string isPolyndromAnswer = sHelper.IsChangeling() ? "Является" : "Не является";
            Console.WriteLine($"{isPolyndromAnswer} полиндромом");
            Console.WriteLine($"Количество слов: {sHelper.GetCountWords()}");
            Console.WriteLine($"Перевернутая строка: {sHelper.GetInverseString()}");

            Console.Read();
        }
    }
}
