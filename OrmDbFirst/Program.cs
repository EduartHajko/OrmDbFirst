
using Microsoft.EntityFrameworkCore;
using OrmDbFirst;
using OrmDbFirst.DTOS;
using OrmDbFirst.Models;

Console.WriteLine("Hello, World!");

//using (var context = new EfDbFirstContext())
//{


//    var std = new Customer()
//    {
//        CustomerName = "edi",
//        TsInserted = DateTime.Now,
//        CustomerAddress = "kombinat"

//    };

//    var result = (from a in context.Customers
//                 join b in context.Calls
//                 on a.Id equals b.CustomerId
//                 where a.Id==1
//                 select new CustomerDto
//                 {
//                     CustomerName=a.CustomerName,
//                     CustomerAddress=a.CustomerAddress,
//                     DateCreated=b.StartTime
//                 }).ToList();



//    foreach (var item in result)
//    {
//        Console.WriteLine("  CustomerName   " + item.CustomerName + "  CustomerAddress   " + item.CustomerAddress
//            + "  DateCreated  " + item.DateCreated);
//    }



//    var students = context.Customers
//                  .FromSql($"select * from customer where id = 6")
//                  .ToList();

//    var res=context.Database.ExecuteSqlRaw("delete from customer where id = 6");





//}


CustomerService service = new CustomerService();
var result = service.GetCustomerDtos();
foreach (var item in result)
{
    Console.WriteLine("  CustomerName   " + item.CustomerName + "  CustomerAddress   " + item.CustomerAddress
        + "  DateCreated  " + item.DateCreated);
}

