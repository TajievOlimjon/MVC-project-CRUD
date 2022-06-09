using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfaceServices
{
    public  interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        int Insert(Customer customer);
        int Update(Customer customer);
        int Delete(int id);

    }
}
