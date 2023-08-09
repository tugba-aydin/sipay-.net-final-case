using AutoMapper;
using BLL.Models.Requests.Apartment;
using BLL.Models.Responses.Apartment;
using BLL.Services.Abstract;
using BLL.Validators.Apartment;
using DAL.Entities;
using DAL.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class ApartmentService : IApartmentService
    {
        private readonly IRepository<Apartment> repository;
        private readonly IMapper mapper;
        public ApartmentService(IRepository<Apartment> _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;

        }
        public void AddApartment(CreateApartmentRequest apartmentRequest)
        {
            if (apartmentRequest != null)
            {
                CreateApartmentRequestValidator validations=new CreateApartmentRequestValidator();
                validations.ValidateAndThrow(apartmentRequest);
                var apartment = mapper.Map<Apartment>(apartmentRequest);
                apartment.Id = Guid.NewGuid().ToString();
                apartment.CreatedAt = DateTime.UtcNow;
                apartment.UpdatedAt = DateTime.UtcNow;
                repository.Add(apartment);

            }
        }

        public void DeleteApartment(string id)
        {
            if (id != null)
            {
                repository.Delete(id);
            }
        }

        public List<ApartmentResponse> GetAllApartments()
        {
            var apartments= repository.GetAll();
            return mapper.Map<List<ApartmentResponse>>(apartments);
        }

        public ApartmentResponse GetApartmentDetail(string id)
        {
            if (id != null)
            {
                var apartment = repository.GetById(id);
                return mapper.Map <ApartmentResponse> (apartment);
            }
            else return null;
        }

        public void UpdateApartment(UpdateApartmentRequest updateApartment)
        {
            if (updateApartment != null)
            {
                UpdateApartmentRequestValidator validations = new UpdateApartmentRequestValidator();
                validations.ValidateAndThrow(updateApartment);
                var model = mapper.Map<Apartment>(updateApartment);
                model.UpdatedAt = DateTime.UtcNow;
                repository.Update(model);
            }
        }
    }
}
