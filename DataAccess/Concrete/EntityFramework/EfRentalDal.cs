using Core.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RantaCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RantaCarContext contex = new RantaCarContext())
            {
                var result = from rental in contex.Rentals
                             join customer in contex.Customers on rental.CustomerId equals customer.id
                             join user in contex.Users on customer.UserId equals user.Id
                             join car in contex.Cars on rental.CarId equals car.Id
                             join brand in contex.Brands on car.BrandId equals brand.Id
                             select new RentalDetailDto
                             {
                                 Id = rental.Id,
                                 CustomerName = user.FirstName + " " +user.LastName,
                                 CarName = brand.BrandName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 DailyPrice=car.DailyPrice,
                                 TotalPrice= Convert.ToDecimal(rental.ReturnDate.Value.Day - rental.RentDate.Day) * car.DailyPrice

                             };
                return result.ToList();
            }
        }
    }
}
