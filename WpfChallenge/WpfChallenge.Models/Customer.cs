using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfChallenge.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [MaxLength(100)]
        [StringLength(100)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(80)]
        [StringLength(80)]
        public string Email { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [MaxLength(80)]
        [StringLength(80)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateDeleted { get; set; }
    }
}
