using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Rentals:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomersId { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
