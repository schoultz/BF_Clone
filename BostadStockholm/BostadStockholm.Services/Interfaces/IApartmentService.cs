using System;
using System.Collections.Generic;
using BostadStockholm.Core.Entities;

namespace BostadStockholm.Services.Interfaces
{
    public interface IApartmentService
    {
        Apartment GetApartmentById(Guid id);
        IList<Apartment> GetAllAvailableApartments();
        void ApplyForApartment(Guid apartmentId, Guid userId);
    }
}