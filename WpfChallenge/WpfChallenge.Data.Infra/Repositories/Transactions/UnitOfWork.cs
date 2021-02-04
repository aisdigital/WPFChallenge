using MySchool.Infra.Data.Repositories.Context;

namespace WpfChallenge.Data.Infra.Repositories.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WpfChallengeContext _wpfChallengeContext;

        public UnitOfWork(WpfChallengeContext wpfChallengeContext)
        {
            _wpfChallengeContext = wpfChallengeContext;
        }

        public void SaveChanges()
        {
            _wpfChallengeContext.SaveChanges();
        }
    }
}


