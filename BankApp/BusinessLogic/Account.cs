using System;

namespace BankApp.BusinessLogic
{
    public class Account
    {
        public decimal Balance { get; private set; }

        public bool IsOpen { get; private set; }

        public Client OwnerClient { get; private set; }

        public int Number { get; private set; }

        public DateTime CreationDateTime { get; private set; }

        public Account(Client ownerClient, int number)
        {
            Balance = 0;
            Open();
            OwnerClient = ownerClient;
            Number = number;
            CreationDateTime = DateTime.Now;
        }

        public void Open()
        {
            IsOpen = true;
        }

        public void Close()
        {
            IsOpen = false;
        }

        public void DecreaseMoney(decimal value)
        {
            if (Balance < value)
                throw new Exception("Не достаточно средств.");

            Balance -= value;
        }

        public void IncreaseMoney(decimal value)
        {
            Balance += value;
        }
    }
}