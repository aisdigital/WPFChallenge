using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WpfChallenge.Models;

namespace WpfChallenge.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly WpfChallengeDB _context;

        public CustomerRepository()
        {
            _context = new WpfChallengeDB();
        }

        public CustomerRepository(WpfChallengeDB context)
        {
            _context = context;
        }

        public Customer Create(Customer customer)
        {
            customer.DateCreated = DateTime.Now;
            _context.Customer.Add(customer);

            _context.SaveChanges();

            return customer;
        }

        public void Delete(int id)
        {
            var customer = FindById(id);

            customer.DateDeleted = DateTime.Now;

            _context.SaveChanges();
        }

        public Customer FindById(int id)
        {
            try
            {
                var customer = _context.Customer.SingleOrDefault(x => x.CustomerID == id);

                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Customer> GetAll()
        {
            var customers = _context.Customer.Where(x => x.DateDeleted == null);

            return customers;
        }

        public void Update(Customer customer)
        {
            var entry = _context.Entry(customer);

            entry.State = System.Data.Entity.EntityState.Modified;
            entry.Property("DateCreated").IsModified = false;
            entry.Property("DateDeleted").IsModified = false;

            _context.SaveChanges();
        }

        public IQueryable<Customer> Search(Expression<Func<Customer, bool>> predicate)
        {
            var customers = GetAll()
                    .Where(predicate);

            return customers;
        }
    }
}
