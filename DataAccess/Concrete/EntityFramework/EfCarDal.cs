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
    public class EfCarDal : EfEntityRepositoryBase<Car, RantaCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RantaCarContext context = new RantaCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             select new CarDetailDto {Id = c.Id, BrandName = b.BrandName, ColorName = cl.ColorName, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear ,CarName=c.CarName, Status=c.Status};

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

        public List<CarDetailDto> GetCarsByBrand(int brandId)
        {
            using (RantaCarContext context = new RantaCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             where b.Id ==brandId
                             select new CarDetailDto { Id = c.Id, BrandName = b.BrandName, ColorName = cl.ColorName, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear, CarName = c.CarName, Status = c.Status };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsByColor(int colorId)
        {
            using (RantaCarContext context = new RantaCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             where cl.Id == colorId
                             select new CarDetailDto { Id = c.Id, BrandName = b.BrandName, ColorName = cl.ColorName, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear, CarName = c.CarName, Status = c.Status };

                return result.ToList();
            }
        }
    }
}
