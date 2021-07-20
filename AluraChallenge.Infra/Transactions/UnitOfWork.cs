namespace AluraChallenge.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AluraChallengeContext _context;

        public UnitOfWork(AluraChallengeContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
