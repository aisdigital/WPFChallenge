namespace WpfChallenge.Repositories
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using WpfChallenge.Models;

    public partial class WpfChallengeDB : DbContext
    {
        public WpfChallengeDB()
            : base("name=WpfChallengeDB")
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
