using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RantaCarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (var context = new RantaCarContext())
            {

                //join customer in contex.Customers on rental.CustomerId equals customer.id
                //join user in contex.Users on customer.UserId equals user.Id
                var result = from customer in context.Customers
                             join user in context.Users on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 id = customer.id,
                                 CompanyName = customer.CompanyName,
                                 CustomerName = user.FirstName + " " + user.LastName
                             };
                return result.ToList();

            }
        }
    }
}
