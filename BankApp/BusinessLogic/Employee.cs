namespace BankApp.BusinessLogic
{
    public class Employee : Person
    {
        public bool IsSingIn { get; private set; }

        public string Password { get; private set; }

        public OperationTypes AllowedOperationTypes { get; private set; }

        public void SingIn()
        {
            IsSingIn = true;
        }

        public void SingOut()
        {
            IsSingIn = false;
        }

        public Employee(int number, string name, string password,
                OperationTypes allowedOperationTypes)
            : base(number, name)
        {
            IsSingIn = false;

            Password = password;
            AllowedOperationTypes = allowedOperationTypes;
        }

        public void CreateOperation(OperationTypes operationType, decimal deltaMoney)
        {
            // проверить доступ сотрудника

            // создать операцию

            // применить операцию
        }
    }
}
