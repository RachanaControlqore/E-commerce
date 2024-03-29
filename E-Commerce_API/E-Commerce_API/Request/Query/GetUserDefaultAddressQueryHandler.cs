﻿using E_Commerce.Repository.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Request.Query
{
    public class GetUserDefaultAddressQueryHandler : IRequestHandler<GetUserDefaultAddressQuery, AddressDetailsQuery>

    {
        private readonly ECommerceDbContext _context;
        public GetUserDefaultAddressQueryHandler(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<AddressDetailsQuery> Handle(GetUserDefaultAddressQuery request, CancellationToken cancellationToken)
        {
            
            var addressInfo = await _context.Address
            .Where(a => a.UserId == request.UserId && a.IsDefault == true && a.IsDeleted == false)
            .Join(_context.City, a => a.CityId, c => c.CityId, (a, c) => new { a, c })
            .Join(_context.State, ac => ac.a.StateId, s => s.StateId, (ac, s) => new { ac.a, ac.c, s })
            .Join(_context.Country, acs => acs.a.CountryId, co => co.CountryId, (acs, co) => new AddressDetailsQuery
            {
                AddressId = acs.a.AddressId,
                ResidentialAddress = acs.a.ResidentialAddress,
                CityName = acs.c.Name,
                StateName = acs.s.Name,
                CountryName = co.Name
            })
            .FirstOrDefaultAsync(cancellationToken);

            if (addressInfo == null)
            {
                return new AddressDetailsQuery();
            }
            return addressInfo;
        }
    }
}
