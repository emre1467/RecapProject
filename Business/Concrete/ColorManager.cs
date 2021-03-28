using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colordal)
        {
            _colorDal = colordal;
        }
        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }
    }
}
