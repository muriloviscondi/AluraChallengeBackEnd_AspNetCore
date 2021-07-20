namespace AluraChallenge.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
