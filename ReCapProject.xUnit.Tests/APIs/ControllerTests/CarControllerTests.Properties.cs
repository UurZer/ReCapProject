using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace ReCapProject.xUnit.Tests.APIs.ControllerTests
{
    public partial class CarControllerTests
    {
        public IDataResult<List<Car>> GetTestCars()
        {
            var sessions = new List<Car>();
            sessions.Add(new Car() {
                BrandId = 4,
                ColorId = 3,
                ModelYear = "2022",
                DailyPrice = 450,
                Description = "DİLERSENİZ PEŞİN DİLERSENİZ %30 PEŞİNAT İLE 48 AYA KADAR KENDİ BÜNYEMİZDE VE ANLAŞMALI FİNANS KURULUŞLARI İLE VADELİ BİR ŞEKİLDE BU ARACA  SAHİP OLABİLİRSİNİZ.",
                CarName = "i8",
                Status = true
            });
            sessions.Add(new Car() {
                BrandId = 4,
                ColorId = 3,
                ModelYear = "2020",
                DailyPrice = 450,
                Description = "DİLERSENİZ PEŞİN DİLERSENİZ %30 PEŞİNAT İLE 48 AYA KADAR KENDİ BÜNYEMİZDE VE ANLAŞMALI FİNANS KURULUŞLARI İLE VADELİ BİR ŞEKİLDE BU ARACA  SAHİP OLABİLİRSİNİZ.",
                CarName = "M5",
                Status = true
            });
            return new SuccessDataResult<List<Car>>(sessions);
        }
        public IDataResult<Car> GetTestCar()
        {
            return new SuccessDataResult<Car>(new Car() {
                BrandId = 4,
                ColorId = 3,
                ModelYear = "2022",
                DailyPrice = 450,
                Description = "DİLERSENİZ PEŞİN DİLERSENİZ %30 PEŞİNAT İLE 48 AYA KADAR KENDİ BÜNYEMİZDE VE ANLAŞMALI FİNANS KURULUŞLARI İLE VADELİ BİR ŞEKİLDE BU ARACA  SAHİP OLABİLİRSİNİZ.",
                CarName = "i8",
                Status = true
            });
        }
    }
}
