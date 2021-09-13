using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bussines.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tynamix.ObjectFiller;
using WebAPI.Controllers;
using Xunit;

namespace ReCapProject.CarTests.Acceptance.Tests
{
    public class CarApiTests//Acceptance
    {
        private readonly EfCarDal mockObject;

        public CarApiTests()
        {
            this.mockObject = new Mock<EfCarDal>() { CallBase = true }.Object;
        }
        private Car CreateRandomCar() =>
           new Filler<Car>().Create();

        [Fact]
        private void AddCarShouldReallyAddThenDeleteIt()
        {
            //given
            Car randomCar = CreateRandomCar();
            randomCar.BrandId = 2;
            randomCar.ColorId = 2;
            Car inputCar = randomCar;

            //when
            mockObject.Add(inputCar);

            var expectedCar = mockObject.Get(p => p.Id == inputCar.Id);

            //then
            inputCar.Should().BeEquivalentTo(expectedCar);
            //Thread.Sleep(4000);
            mockObject.Delete(expectedCar);

        }

        [Fact]
        private void GetCarsShouldBeNotNull()
        {

            var actualCar = mockObject.GetAll();

            var expected = actualCar.FirstOrDefault();
            Assert.Equal("2020", expected.ModelYear);
        }
    }
}
