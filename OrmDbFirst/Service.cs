using OrmDbFirst.DTOS;
using OrmDbFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmDbFirst
{
    public  class CustomerService
    {
        EfDbFirstContext context = new EfDbFirstContext();
        public IEnumerable<CustomerDto> GetCustomerDtos()
        {

            var result = (from a in context.Customers
                         join b in context.Calls
                         on a.Id equals b.CustomerId

                         select new CustomerDto
                         {
                             CustomerName = a.CustomerName,
                             CustomerAddress = a.CustomerAddress,
                             DateCreated = b.StartTime
                         }).OrderByDescending(a=>a.DateCreated).Skip(3).Take(1).ToList();


            return result;
        }
    }
}
