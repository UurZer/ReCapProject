﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Bussines.Concrete
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        List<Car> GetById(int id);
        void Update(Car car);
        void Delete(Car car);
    }
}
