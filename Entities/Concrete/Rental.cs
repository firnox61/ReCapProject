using Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Rental:IEntity
    {//Arabanın kiralanma bilgisini tutan tablo oluşturunuz. Rentals-->Id, CarId, CustomerId, RentDate(Kiralama Tarihi),
     //ReturnDate(Teslim Tarihi). Araba teslim edilmemişse ReturnDate null'dır.
      
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime?  ReturnDate { get; set; }
    }
}
