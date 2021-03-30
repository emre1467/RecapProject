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
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Car c = new Car() {BrandId=3,Id=6,ColorId=4,DailyPrice=322,ModelYear=2000,Description="mercedes" };
            Car d = new Car() { BrandId = 4, Id = 7, ColorId = 4, DailyPrice = 200, ModelYear = 2007, Description = "tofas" };
            //carManager.Add(d);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear);
            }
            

        }
    }
}
