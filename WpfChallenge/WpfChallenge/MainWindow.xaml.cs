using System.Windows;
using Domain.Handlers;
using Domain.Commands;
using Shared.Commands;
using System.Collections.Generic;
using WpfChallenge.ViewModels;
using System.ComponentModel.DataAnnotations;
using Shared.Notifications;
//using Unity;

namespace WpfChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ClienteHandler _handler;    


        public MainWindow(ClienteHandler handler)
        {            
            _handler = handler;    
            InitializeComponent();
            PopularEstados();
        }   

        private void PopularEstados()
        {
            lstUF.Items.Add("AC");
            lstUF.Items.Add("AL");
            lstUF.Items.Add("AP");
            lstUF.Items.Add("AM");
            lstUF.Items.Add("BA");
            lstUF.Items.Add("CE");
            lstUF.Items.Add("DF");
            lstUF.Items.Add("ES");
            lstUF.Items.Add("GO");
            lstUF.Items.Add("MA");
            lstUF.Items.Add("MT");
            lstUF.Items.Add("MS");
            lstUF.Items.Add("MG");
            lstUF.Items.Add("PA");
            lstUF.Items.Add("PB");
            lstUF.Items.Add("PR");
            lstUF.Items.Add("PE");
            lstUF.Items.Add("PI");
            lstUF.Items.Add("RJ");
            lstUF.Items.Add("RN");
            lstUF.Items.Add("RS");
            lstUF.Items.Add("RO");
            lstUF.Items.Add("RR");
            lstUF.Items.Add("SC");
            lstUF.Items.Add("SP");
            lstUF.Items.Add("SE");
            lstUF.Items.Add("TO");
        }

        private void btnSalvarClick(object sender, RoutedEventArgs e)
        {
            var cliente = (ClienteViewModel)this.DataContext;
            
            if (cliente.IsValid())
            {               
                var command = new CadastrarClienteCommand()
                {
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone,
                    CEP = cliente.CEP,
                    UF = cliente.UF,
                    Bairro = cliente.Bairro,
                    Cidade = cliente.Cidade,
                    Complemento = cliente.Complemento,
                    Logradouro = cliente.Logradouro,
                    Numero = cliente.Numero
                };
                var result = this._handler.Handle(command);

                if (result.Success)
                {
                    this.DataContext = new ClienteViewModel();
                    MessageBox.Show(result.Message);
                }
                else
                {
                    string mensagem = string.Empty;

                    foreach (var item in (IReadOnlyCollection<Notification>)result.Data)
                    {
                        mensagem += item.Message;
                    }
                    MessageBox.Show(mensagem);
                }
            } 
           
        }    

    }
}
