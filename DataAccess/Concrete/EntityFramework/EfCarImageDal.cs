using System;
using System.Collections.Generic;
using System.Text;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RantaCarContext>, ICarImageDal
    {
        public List<CarImagesDetailDto> getCarDetail(int carId)
        {
            using (RantaCarContext context = new RantaCarContext())
            {
                var result = from c in context.CarImages
                             join b in context.Cars
                             on c.CarId equals b.Id
                             join cl in context.Colors
                             on b.ColorId equals cl.Id
                             join br in context.Brands
                             on b.BrandId equals br.Id
                             where b.Id==carId && c.Default==true
                             select new CarImagesDetailDto { Id = c.Id,
                                                             BrandName = br.BrandName,
                                                             ColorName = cl.ColorName, 
                                                             DailyPrice = b.DailyPrice, 
                                                             Description = b.Description, 
                                                             ModelYear = b.ModelYear, 
                                                             CarName = b.CarName, 
                                                             Status = b.Status ,
                                                             ImagePath=c.ImagePath};

                return result.ToList();
               
            }
        }
    }
}
