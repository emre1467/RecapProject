using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _branddal;
        public BrandManager(IBrandDal brandDal)
        {
            _branddal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _branddal.Add(brand);
            return new SuccessResult("başarılı");
        }

        public IResult Delete(Brand brand)
        {
            _branddal.Delete(brand);
            return new SuccessResult("başarılı");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>( _branddal.GetAll(),"başarılı");
        }

        public IResult Update(Brand brand)
        {
            _branddal.Update(brand);
            return new SuccessResult("başarılı");
        }
    }
}
