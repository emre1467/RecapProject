using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IColorService _colorService;
        public CarManager(ICarDal carDal,IColorService colorService)
        {
            _carDal = carDal; // Kullanıcı hangi yöntem ile çalışmak istediğini girer(new EfCarDal())
            _colorService =colorService;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result= BusinessRules.Run(CheckIfCarCountOfColorCorrect(car.ColorId));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
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
        private IResult CheckIfCarCountOfColorCorrect(int colorid)
        {
            var result = _carDal.GetAll(c=>c.ColorId==colorid).Count;
            if (result > 15)
            {
                return new ErrorResult(Messages.CarCauntOfColorError);
            }
            return new SuccessResult();
        }
        //private IResult CheckIfColorLimitExceded()
        //{
        //    var result = _colorService.GetAll();
        //    if (result.Data.Count > 15)
        //    {
        //        return new ErrorResult(Messages.ColorLimitExceded);
        //    }
        //}
        
    }
}
