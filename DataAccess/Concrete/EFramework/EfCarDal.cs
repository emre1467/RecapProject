using DataAccess.Abstract;
using DataAccess.Concrete.EFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.NewFolder
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext carContext=new CarContext())
            {
                var result = from p in carContext.Table
                             join c in carContext.Colorr
                             on p.ColorId equals c.Id
                             join b in carContext.Brand
                             on p.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 DailyPrice = p.DailyPrice,
                                 ModelYear = p.ModelYear
                             };
                return result.ToList();
            }
        }
    }
}
