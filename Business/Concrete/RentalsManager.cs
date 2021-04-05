using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentalsDal;
        public RentalsManager(IRentalsDal rentalsDal)
        {
            _rentalsDal= rentalsDal;
        }
        public IResult Add(Rentals rentals)
        {
            if (rentals.ReturnDate != null)
            {
                _rentalsDal.Add(rentals);
                return new SuccessResult("başarılı");
            }
            else
                return new ErrorResult("başarısız");

        }

        public IResult Delete(Rentals rentals)
        {
            _rentalsDal.Delete(rentals);
            return new SuccessResult("başarılı");
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalsDal.GetAll(), "başarılı");

        }

        public IResult Update(Rentals rentals)
        {
            _rentalsDal.Update(rentals);
            return new SuccessResult("başarılı");
        }
    }
}
