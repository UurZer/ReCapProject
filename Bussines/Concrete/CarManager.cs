using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Constants;
using Bussines.BusinessAspects;
using Bussines.Concrete;
using Bussines.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Bussines.Abstract
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        [CacheAspect]
        public IResult Add(Car car)
        {
            BusinessRules.Run(CheckCarNameIsSame(car.CarName));

            _carDal.Add(car);
            return new SuccessResult(Messages.DataAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DataDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p=> p.Id == id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.DataUpdated);
        }


        public IResult CheckCarNameIsSame(string carName)
        {
            var result = _carDal.GetAll(p => p.CarName == carName).Any();
            if (result)
                return new ErrorResult(Messages.CarNameAlreadyExists);
            return new SuccessResult();
        }
    }
}
