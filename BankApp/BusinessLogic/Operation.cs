namespace BankApp.BusinessLogic
{
    public abstract class Operation
    {
        public Employee Creator { get; private set; }

        public Account Account { get; private set; }
        
        public Operation(Employee creator, Account account)
        {
            Creator = creator;
            Account = account;
        }

        public abstract void Apply();
    }
}
