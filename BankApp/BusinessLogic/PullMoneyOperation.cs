namespace BankApp.BusinessLogic
{
    public class PullMoneyOperation : MoneyOperation
    {
        public PullMoneyOperation(Employee creator, Account account, decimal deltaMoney)
            : base(creator, account, deltaMoney)
        {
        }

        public override void Apply()
        {
            Account.DecreaseMoney(DeltaMoney);
        }
    }
}
