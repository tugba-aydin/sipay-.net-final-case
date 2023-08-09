using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Requests.Apartment
{
    public class CreateApartmentRequest
    {
        public string Block { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
        public string FloorLocation { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
