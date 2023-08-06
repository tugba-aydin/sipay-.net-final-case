using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Responses.Apartment
{
    public class ApartmentResponse
    {
        public string Id { get; set; }
        public string Block { get; set; }
        public bool State { get; set; }
        public string Type { get; set; }
        public string FloorLocation { get; set; }
        public string ApartmentNumber { get; set; }
        public string? UserId { get; set; }
    }
}
