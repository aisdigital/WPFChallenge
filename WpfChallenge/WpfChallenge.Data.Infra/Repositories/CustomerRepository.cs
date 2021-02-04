using MySchool.Infra.Data.Repositories.Context;
using System;
using WpfChallenge.Data.Infra.Repositories.Base;
using WpfChallenge.Domain.Entities;
using WpfChallenge.Domain.Interfaces;

namespace WpfChallenge.Data.Infra.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, Guid>, ICustomerRepository
    {
        private readonly WpfChallengeContext _wpfChallengeContext;

        public CustomerRepository(WpfChallengeContext wpfChallengeContext) : base(wpfChallengeContext)
        {
            _wpfChallengeContext = wpfChallengeContext;
        }
    }
}
