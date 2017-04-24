namespace BankApp.BusinessLogic
{
    public class OpenOperation : Operation
    {
        public OpenOperation(Employee creator, Account account)
            : base(creator, account)
        {
        }

        public override void Apply()
        {
            Account.Open();
        }
    }
}
