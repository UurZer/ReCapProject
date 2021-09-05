using System.ComponentModel.DataAnnotations;
using Bussines.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tynamix.ObjectFiller;
using Xunit;

namespace ReCapProject.CarTests.Acceptance.Tests
{
    public class CarApiTests
    {
        private Car CreateRandomCar() =>
            new Filler<Car>().Create();

        //[ExpectedException(typeof(ValidationException))]
        [Fact]
        private void ShouldAddCar()
        {
            var mockObject = new Mock<EfCarDal>() { CallBase = true }.Object;
            CarManager carManager = new CarManager(mockObject);

            Car randomCar = CreateRandomCar();
            randomCar.BrandId = 2;
            randomCar.ColorId = 2;
            Car inputCar = randomCar;

            mockObject.Add(inputCar);

            var expectedCar = mockObject.Get(p=>p.Id == inputCar.Id);

            inputCar.Should().BeEquivalentTo(expectedCar);

            mockObject.Delete(expectedCar);

        }

        [Fact]
        private void GetCar()
        {
            var mockObject = new Mock<EfCarDal>() { CallBase = true }.Object;
            CarManager carManager = new CarManager(mockObject);
            
            //var randomCar = new Car{
            //        BrandId = 4,
            //        ColorId = 3,
            //        ModelYear = "2020",
            //        DailyPrice = 450,
            //        Description = "DİLERSENİZ PEŞİN DİLERSENİZ %30 PEŞİNAT İLE 48 AYA KADAR KENDİ BÜNYEMİZDE VE ANLAŞMALI FİNANS KURULUŞLARI İLE VADELİ BİR ŞEKİLDE BU ARACA  SAHİP OLABİLİRSİNİZ.",
            //        CarName = "i8",
            //        Status = true
            //};

            //Car inputCar = randomCar;
            //Car expectedCar = inputCar;
            //Car actualCar = carManager.Add(randomCar).Data;

            var actualCar = mockObject.GetAll(p=>p.Status== true).Count;

            actualCar.Should().Be(8);

            //mockObject.Setup(m => m.Delete(inputCar));
        }
    }
}
