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
using Entities.DTOs;

namespace Bussines.Abstract
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //[SecuredOperation("car.add")]
        //[ValidationAspect(typeof(CarValidator))]
        //[CacheRemoveAspect("IProductService.Get")]
        //[CacheAspect]
        public IResult Add(Car car)
        {
            if(car==null)
            {
                return new ErrorResult(Messages.Invalidcar);
            }

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
            var result = _carDal.Get(p => p.Id == id);
            if(result!=null)
                return new SuccessDataResult<Car>(result);

            return new ErrorDataResult<Car>(result);
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

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsByBrand(brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsByColor(colorId));
        }
    }
}
