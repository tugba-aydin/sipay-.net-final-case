using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public bool HasVehicle { get; set; }
        public string? Plate { get; set; }
        public string? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
    }
}
