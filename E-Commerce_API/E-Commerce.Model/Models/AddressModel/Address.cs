﻿using E_Commerce.Model.Models.UserModel;


namespace E_Commerce.Model.Models.AddressModel
{
    public class Address
    {
        public int AddressId { get; }
        public string ResidentialAddress { get; private set; }=string.Empty;   
        public int CityId { get; private set; }
        public City? City { get; set; }
        public int StateId { get; private set; }
        public State? State { get; set; }
        public int CountryId { get; private set; }
        public Country? Country { get; set; }
        public int UserId { get; private set; } 
        public User? User { get; set; }
        public bool IsDeleted { get; private set; }
        public bool IsDefault { get; private set; }

        public Address(string residentialAddress,int cityId,int stateId,int countryId,int userId,bool isDeleted,bool isDefault)
        {
            ResidentialAddress = residentialAddress;
            CityId = cityId;
            StateId = stateId;
            CountryId = countryId;
            UserId = userId;
            IsDeleted = isDeleted;
            IsDefault = isDefault;
        }

        public void UpdateAddress(string residentialAddress, int cityId, int stateId, int countryId,int userId)
        {
            ResidentialAddress=residentialAddress;
            CityId = cityId;
            StateId = stateId;
            CountryId = countryId;
            UserId = userId;
        }

        public void UpdateIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }

        public void UpdateIsDefault(bool isDefault)
        {
            IsDefault = isDefault;
        }

    }
}
