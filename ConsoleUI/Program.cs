using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussines.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());


            //GetById(carManager);

            //Delete(carManager);

            GetAll(carManager);

            //Add(carManager);


            Console.ReadLine();
        }

        private static void GetById(CarManager carManager)
        {
            List<Car> a = carManager.GetById(2);

            foreach (var item in a)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.BrandId);
                Console.WriteLine(item.ColorId);
                Console.WriteLine(item.Description);
                Console.WriteLine(item.ModelYear);
                Console.WriteLine(item.DailyPrice);
            }
        }

        private static void Add(CarManager carManager)
        {
            carManager.Add(new Car
            {
                Id = 5,
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 500,
                Description = "Renault",
                ModelYear = 2018
            });
        }

        private static void GetAll(CarManager carManager)
        {
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.BrandId);
                Console.WriteLine(item.ColorId);
                Console.WriteLine(item.Description);
                Console.WriteLine(item.ModelYear);
                Console.WriteLine(item.DailyPrice);
            }
        }

        private static void Delete(CarManager carManager)
        {
            carManager.Delete(new Car
            {
                Id = 2,
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 200,
                Description = "Renault",
                ModelYear = 2018
            });
        }
    }
}
