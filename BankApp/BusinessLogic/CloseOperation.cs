namespace BankApp.BusinessLogic
{
    public class CloseOperation : Operation
    {
        public CloseOperation(Employee creator, Account account)
            : base(creator, account)
        {
        }

        public override void Apply()
        {
            Account.Close();
        }
    }
}
