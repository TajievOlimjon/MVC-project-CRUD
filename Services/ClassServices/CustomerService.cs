using Domain.Entities;
using Persistence.Data;
using Services.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ClassServices
{
    public  class CustomerService:ICustomerService
    {
        private readonly DataContext context;

        public CustomerService(DataContext context)
        {
            this.context = context;
        }
       public  List<Customer> GetCustomers()
        {
            var list = context.Customers.ToList();
            return list;
        }
       public  Customer GetCustomerById(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) return new Customer();
            return customer;
        }
       public  int Insert(Customer customer)
        {
            context.Customers.Add(customer);
            return context.SaveChanges();
        }
       public  int Update(Customer customer)
        {
            var c = context.Customers.Find(customer.Id);
            if (c == null) return 0;
            c.FirstName = customer.FirstName;
            c.LastName = customer.LastName;
            c.Email = customer.Email;
            c.Birthday = customer.Birthday;
            c.Address = customer.Address;
            c.PhoneNumber = customer.PhoneNumber;
            return context.SaveChanges();
        }
       public  int Delete(int id)
        {
            var customer = context.Customers.Find(id);
            if (customer == null) return 0;
            context.Customers.Remove(customer);
            return context.SaveChanges();
        }

    }
}
