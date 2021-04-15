using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
       
    }
}
