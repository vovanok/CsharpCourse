namespace BankApp.BusinessLogic
{
    public class PushMoneyOperation : MoneyOperation
    {
        public PushMoneyOperation(Employee creator, Account account, decimal deltaMoney)
            : base(creator, account, deltaMoney)
        {
        }

        public override void Apply()
        {
            Account.IncreaseMoney(DeltaMoney);
        }
    }
}
