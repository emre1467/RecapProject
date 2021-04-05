using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomersService
    {
        ICustomersDal _customersDal;
        public CustomerManager(ICustomersDal customersDal)
        {
            _customersDal = customersDal;
        }

        public IResult Add(Customers customers)
        {
            _customersDal.Add(customers);
            return new SuccessResult("başarılı");
        }

        public IResult Delete(Customers customers)
        {
            _customersDal.Delete(customers);
            return new SuccessResult("başarılı");
        }

        public IDataResult<List<Customers>> GetAll()
        {
            return new SuccessDataResult<List<Customers>>(_customersDal.GetAll(), "başarılı");
        }

        public IResult Update(Customers customers)
        {
            _customersDal.Update(customers);
            return new SuccessResult("başarılı");
        }
    }
}
