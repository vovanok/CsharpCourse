using Common;
using System;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество колес: ");
            uint countWheels;
            if (!Utils.TryEnterNumberFromConsole(out countWheels))
            {
                HandleIncorrectEnter();
                return;
            }

            Console.Write("Введите количество дверей: ");
            uint countDoors;
            if (!Utils.TryEnterNumberFromConsole(out countDoors))
            {
                HandleIncorrectEnter();
                return;
            }

            Car car = new Car((int)countDoors, (int)countWheels, "Запорожец");

            foreach (Detail detail in car.Details)
            {
                IMovable rotatableDetail = detail as IMovable;
                if (rotatableDetail != null)
                {
                    rotatableDetail.Move();
                }
            }

            Console.Write("Введите номер двери: ");
            uint doorNumber;
            if (!Utils.TryEnterNumberFromConsole(out doorNumber))
            {
                HandleIncorrectEnter();
                return;
            }

            foreach (Detail detail in car.Details)
            {
                Door door = detail as Door;
                if (door != null && door.Number == doorNumber)
                {
                    door.Open();
                    break;
                }
            }

            Console.Read();
        }

        private static void HandleIncorrectEnter()
        {
            Console.WriteLine("Некорректный ввод");
            Console.Read();
        }
    }
}
