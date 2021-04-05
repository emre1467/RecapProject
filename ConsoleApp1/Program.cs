using Business.Concrete;
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
            //CarTest();
            //ColorTest();
            //BrandDal();
            //UsersTest();
            //CustomersTest();
            //Rentals rentals1 = new Rentals { Id=5,CarId = 5, CustomersId = 5, RentDate = "2012",ReturnDate= "2018" };
            //RentalsManager rentalsManager = new RentalsManager(new EfRentalsDal());
            //rentalsManager.Add(rentals1);
            
        }

        private static void CustomersTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomersDal());
            foreach (var customers in customerManager.GetAll().Data)
            {
                Console.WriteLine(customers.CompanyName);
            }
        }

        private static void UsersTest()
        {
            UsersManager usersManager = new UsersManager(new EfUsersDal());
            foreach (var users in usersManager.GetAll().Data)
            {
                Console.WriteLine(users.FirstName);
            }
        }

        private static void BrandDal()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void ColorTest()
        {
            ColorManager colormanager = new ColorManager(new EfColorDal());
            foreach (var color in colormanager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.BrandName+"/"+car.ColorName+"/"+car.DailyPrice+"/"+car.ModelYear);
            }
        }
    }
}
