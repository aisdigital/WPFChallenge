using System.Data;
using WpfChallenge.Models;

namespace WpfChallenge.Repository
{
    public interface IClienteRepository
    {
        DataTable Get();

        DataTable Get(int Id);

        DataTable Post(Cliente cliente);

        DataTable Put(Cliente cliente);

        bool Delete(int Id);
    }
}
