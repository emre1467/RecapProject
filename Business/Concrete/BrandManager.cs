using Business.Abstract;
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
        public List<Brand> GetAll()
        {
            return _branddal.GetAll();
        }
    }
}
