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

            return targetEmployee != null;
        }

        public void CreateClient(string name)
        {
            Clients.Add(new Client(Clients.Count, name));
        }

        public Employee GetEmployeeByOperation(OperationTypes operationType)
        {
            throw new NotImplementedException();
        }

        public Bank()
        {
            Employees = new List<Employee>();
            Clients = new List<Client>();
            Accounts = new List<Account>();
        }
    }
}
