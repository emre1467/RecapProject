using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Car car)
        {
            if(car.DailyPrice>0 && car.Description.Length > 2)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);

            }
            else
            {
                return new ErrorResult(Messages.CarPriceInvalid);

            }

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("silindi");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"ürünler listelendi");  // EfCarDal sınıfına gidip GetAll metodunu çalıştırır
        }

        

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
             return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), "dto");
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.BrandId == id));// EfCarDal sınıfına gidip id si bizim ıd ile aynı olanları bulur.
            
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.ColorId == id));
        }

        public IResult Update(Car car)
        {
            
            _carDal.Update(car);
            return new SuccessResult("güncellendi");
        }
    }
}
