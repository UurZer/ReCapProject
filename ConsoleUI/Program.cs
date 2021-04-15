using System;
using Bussines.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                Description = "asdasdad",
                 BrandId=1,
                  ColorId=1
            });
            var result = carManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}
