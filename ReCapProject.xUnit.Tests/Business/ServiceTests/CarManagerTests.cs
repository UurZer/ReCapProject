using Bussines.Abstract;
using DataAccess.Abstract;
using Moq;
using Xunit;

namespace ReCapProject.xUnit.Tests.Business.ServiceTests
{
    public partial class CarManagerTests
    {
        private readonly CarManager _sut;
        private readonly Mock<ICarDal> _carDalMock = new Mock<ICarDal>();


        public CarManagerTests() =>
            _sut = new CarManager(_carDalMock.Object);

        // AAA(Arrange - Act - Assert ) Or Given Then When
        [Fact]
        public void GetByIdShouldReturnCarWhenCarExists()
        {
            //Arrange
            var carId = CreateRandomInteger();
            var car = CreateRandomCar();
            car.Id = carId;

            _carDalMock.Setup(x => x.Get(i => i.Id == carId)).Returns(car);

            //Act
            var resultCar = _sut.GetById(carId).Data;

            //Assert
            Assert.Equal(resultCar.Id, carId);  // Or  resultCar.Id.Should().Be(carId);
            Assert.Equal(resultCar.CarName, car.CarName);
        }


        [Fact]
        public void GetByIdShouldReturnNothingWhenCarDoesNotExists()
        {
            //Arrange 
            _carDalMock.Setup(x => x.Get(i => i.Id == It.IsAny<int>()))
                .Returns(() => null);

            //Act
            var resultCar = _sut.GetById(It.IsAny<int>());

            //Assert
            Assert.Null(resultCar.Data);
            Assert.False(resultCar.Success);
        }
    }
}
