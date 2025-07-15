using System;
using System.Collections.Generic;
using System.Linq;
using BostadStockholm.Core.Entities;
using BostadStockholm.Data;
//test
using BostadStockholm.Data.Interfaces;
using BostadStockholm.Data.Repositories;
using BostadStockholm.Services.Interfaces;
using NHibernate;

namespace BostadStockholm.Services.Implementations
{
    public class ApartmentService : IApartmentService
    {
        private readonly IRepository<Apartment> _apartmentRepository;
        private readonly IRepository<Application> _applicationRepository;
        private readonly ISession _session;

        public ApartmentService(ISession session)
        {
            _session = session;
            _apartmentRepository = new Repository<Apartment>(_session);
            _applicationRepository = new Repository<Application>(_session);
        }

        public Apartment GetApartmentById(Guid id)
        {
            return _apartmentRepository.GetById(id);
        }

        public IList<Apartment> GetAllAvailableApartments()
        {
            return _apartmentRepository.GetAll()
                .Where(a => a.IsAvailable)
                .ToList();
        }

        public void ApplyForApartment(Guid apartmentId, Guid userId)
        {
            var application = new Application
            {
                Id = Guid.NewGuid(),
                ApartmentId = apartmentId,
                UserId = userId,
                ApplicationDate = DateTime.UtcNow,
                Status = "Pending"
            };

            _applicationRepository.Save(application);
        }
    }
}