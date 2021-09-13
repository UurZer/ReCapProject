using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussines.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;
using Xunit;

namespace ReCapProject.xUnit.Tests.APIs.ControllerTests
{
    public partial class CarControllerTests//Unit Test
    {
        [Fact]
        public void Controller_Returns_WithAListOfCar()
        {
            // Arrange
            var mockService = new Mock<ICarService>();

            mockService.Setup(repo => repo.GetAll())
                .Returns(GetTestCars());
            
            var controller = new CarsController(mockService.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            var OkResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SuccessDataResult<List<Car>>>(OkResult.Value).Data;
            var idea = returnValue.FirstOrDefault();
            
            Assert.Equal(2, returnValue.Count);
            Assert.Equal("i8", idea.CarName);
        }


        [Fact]
        public void Create_ReturnsBadRequest_GivenInvalidCar()
        {
            // Arrange & Act
            var mockService = new Mock<ICarService>();

            var controller = new CarsController(mockService.Object);
            
            mockService.Setup(repo => repo.Add(null))
               .Returns(new ErrorResult());
            
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = controller.Add(car: null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public void Create_ReturnsOkResult_GivenInvalidCar()
        {
            // Arrange & Act
            var testCar = GetTestCar().Data;

            var mockService = new Mock<ICarService>();
            
            var controller = new CarsController(mockService.Object);
            
            mockService.Setup(repo => repo.Add(testCar))
               .Returns(new SuccessResult());

            // Act
            var result = controller.Add(testCar);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
