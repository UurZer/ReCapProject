using DataAccess.Concrete.EntityFramework;
using Moq;
using Tynamix.ObjectFiller;
using WireMock.Server;
using Entities.Concrete;
using System;
using Xunit;
using Bussines.Concrete;
using DataAccess.Abstract;
using AutoMoq;
using Bussines.Abstract;
using FluentAssertions;

namespace ReCapProject.Acceptance.Tests.APIs.Cars
{
    public class CarApiTests : TestBase
    {
        public Mock<ICarDal> mockObject;
        public CarApiTests()
        {
            AutofacContainer.BeginLifetimeScope();
            mockObject = new Mock<ICarDal>();
        }
        private Car CreateRandomCar() =>
         new Filler<Car>().Create();
    }

    
}
