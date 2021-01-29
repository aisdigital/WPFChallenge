using WPFChallenge.Dominio.Clientes;

namespace WPFChallenge.Aplicacao.GestaoDeClientes.Modelos
{
    public class ModeloDeClienteDaLista
    {
        public ModeloDeClienteDaLista()
        {

        }

        public ModeloDeClienteDaLista(Cliente cliente) : this()
        {
            if (cliente == null)
                return;

            this.Id = cliente.Id;
            this.Nome = cliente.Nome;
            this.Email = cliente.Email;
            this.Telefone = cliente.Telefone;
            this.Endereco = cliente.Endereco;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Endereco { get; private set; }
    }
}