using System;
using WpfChallenge.Domain.Entities;
using WpfChallenge.Domain.Interfaces.Base;

namespace WpfChallenge.Domain.Interfaces
{
    public interface ICustomerRepository: IBaseRepository<Customer,Guid>
    {

    }
}
