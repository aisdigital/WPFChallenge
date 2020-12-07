using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WpfChallenge.Models;
using WpfChallenge.Repositories;

namespace WpfChallenge.Services
{
    public class CustomersService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomersService()
        {
            _customerRepository = new CustomerRepository();
        }

        public List<Customer> GetAll()
        {
            try
            {
                var customers = _customerRepository.GetAll().ToList();

                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer Create(Customer customer)
        {
            try
            {
                _customerRepository.Create(customer);

                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _customerRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer FindById(int id)
        {
            try
            {
                var customer = _customerRepository.FindById(id);

                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Customer customer)
        {
            try
            {
                _customerRepository.Update(customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public List<Customer> Search(Expression<Func<Customer, bool>> predicate)
        {
            try
            {
                var customers = _customerRepository.GetAll()
                            .Where(predicate)
                            .ToList();

                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
