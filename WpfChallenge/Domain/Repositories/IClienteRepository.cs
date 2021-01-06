using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IClienteRepository
    {
        void Cadastrar(Cliente cliente);
        bool Atualizar(Cliente cliente);
        IEnumerable<Cliente> Listar();
        bool Excluir(Guid id);
        Cliente Get(Guid id);
    }
}
