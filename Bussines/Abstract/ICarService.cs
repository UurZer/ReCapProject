using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Bussines.Concrete
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IDataResult<Car> GetById(int id);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
