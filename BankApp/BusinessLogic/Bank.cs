using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.BusinessLogic
{
    public class Bank
    {
        public List<Employee> Employees { get; private set; }

        public List<Client> Clients { get; private set; }

        public List<Account> Accounts { get; private set; }

        public Employee CurrentEmployee { get; private set; }

        public List<Operation> OperationsHistory { get; private set; }

        public Bank()
        {
            Employees = new List<Employee>();
            Clients = new List<Client>();
            Accounts = new List<Account>();
            OperationsHistory = new List<Operation>();
        }

        public Employee CreateEmployee(string name, string password,
            OperationTypes allowedOperationTypes)
        {
            var newEmployee = new Employee(
                Employees.Count, name, password, allowedOperationTypes);
            Employees.Add(newEmployee);
            return newEmployee;
        }

        public bool LoginEmployee(string name, string password)
        {
            if (Employees == null)
                return false;

            Employee targetEmployee = Employees.FirstOrDefault(
                (employee) => employee.Name == name && employee.Password == password);

            CurrentEmployee = targetEmployee;

            return targetEmployee != null;
        }

        public Client CreateClient(string name)
        {
            Client newClient = new Client(Clients.Count, name);
            Clients.Add(newClient);
            return newClient;
        }

        public Account CreateAccount(Client ownerClient)
        {
            if (ownerClient == null)
                return null;

            Account newAccount = new Account(ownerClient, Accounts.Count);
            Accounts.Add(newAccount);
            return newAccount;
        }

        public void PushMoney(Account account, decimal deltaMoney)
        {
            if (account == null)
                return;

            CheckOperationPermission(OperationTypes.PushMoney);

            if (!CurrentEmployee.AllowedOperationTypes.HasFlag(OperationTypes.PushMoney))
            {
                throw new Exception("У текущего сотрудника нет прав на осуществление операции");
            }

            PushMoneyOperation operation =
                new PushMoneyOperation(CurrentEmployee, account, deltaMoney);

            operation.Apply();
            OperationsHistory.Add(operation);
        }

        public void PullMoney(Account account, decimal deltaMoney)
        {
            if (account == null)
                return;

            CheckOperationPermission(OperationTypes.PullMoney);

            PullMoneyOperation operation =
                new PullMoneyOperation(CurrentEmployee, account, deltaMoney);

            operation.Apply();
            OperationsHistory.Add(operation);
        }

        public void AddAccount(Client ownerClient)
        {
            if (ownerClient == null)
                return;

            CheckOperationPermission(OperationTypes.OpenAccount);

            CreateAccount(ownerClient);
        }

        public void DeleteAccount(Account account)
        {
            CheckOperationPermission(OperationTypes.CloseAccount);

            Accounts.Remove(account);
        }

        private void CheckOperationPermission(OperationTypes operationType)
        {
            if (!CurrentEmployee.AllowedOperationTypes.HasFlag(operationType))
            {
                throw new Exception("У текущего сотрудника нет прав на осуществление операции");
            }
        }
    }
}
