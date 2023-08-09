using BLL.Models.Requests.Apartment;
using BLL.Models.Responses.Apartment;
using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IApartmentService
    {
        List<ApartmentResponse> GetAllApartments();
        ApartmentResponse GetApartmentDetail(string id);
        void AddApartment(CreateApartmentRequest apartmentRequest);
        void DeleteApartment(string id);
        void UpdateApartment(UpdateApartmentRequest apartmentRequest);
    }
}
