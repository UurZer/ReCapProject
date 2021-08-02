using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);

        List<CarDetailDto> GetCarsByBrand(int brandId);
        List<CarDetailDto> GetCarsByColor(int colorId);
    }
}
