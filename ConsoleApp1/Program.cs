using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EFramework;
using DataAccess.Concrete.NewFolder;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            //ColorTest();
            //BrandDal();
            
        }

        private static void BrandDal()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void ColorTest()
        {
            ColorManager colormanager = new ColorManager(new EfColorDal());
            foreach (var color in colormanager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName+"/"+car.ColorName+"/"+car.DailyPrice+"/"+car.ModelYear);
            }
        }
    }
}
