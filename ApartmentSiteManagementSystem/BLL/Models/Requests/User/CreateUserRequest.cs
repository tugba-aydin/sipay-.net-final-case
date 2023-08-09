﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Requests.User
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string ApartmentId { get; set; }
    }
}
