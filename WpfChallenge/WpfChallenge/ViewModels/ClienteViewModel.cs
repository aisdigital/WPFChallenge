using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfChallenge.Validation;

namespace WpfChallenge.ViewModels
{
    public class ClienteViewModel : PropertyValidateModel, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Insira um email valido")]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string UF { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public int? Numero { get; set; }

        public bool IsValid()
        {
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(this, context, results, true);
        }

    }
}
