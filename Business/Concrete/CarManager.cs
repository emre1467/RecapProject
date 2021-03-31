using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal; // Kullanıcı hangi yöntem ile çalışmak istediğini girer(new EfCarDal())
        }

        public void Add(Car car)
        {
            if(car.DailyPrice>0 && car.Description.Length > 2)
            {
                Console.WriteLine("Arac Eklendi");
                _carDal.Add(car);
            }
            else
                Console.WriteLine("araba eklenmedi");
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();  // EfCarDal sınıfına gidip GetAll metodunu çalıştırır
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);// EfCarDal sınıfına gidip id si bizim ıd ile aynı olanları bulur.
            
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
