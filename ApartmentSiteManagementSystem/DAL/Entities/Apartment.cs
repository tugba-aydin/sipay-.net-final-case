using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Apartment
    {
        public string Id { get; set; }
        public string Block { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
        public string FloorLocation { get; set; }
        public string ApartmentNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
