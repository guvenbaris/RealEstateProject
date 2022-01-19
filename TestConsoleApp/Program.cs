using System;
using System.Text.Json.Serialization;
using System.Xml;
using Newtonsoft.Json;
using RealEstateWebApp.DataAccess;
using RealEstateWebApp.ModelBase;
using RealEstateWebApp.Models;
using Formatting = Newtonsoft.Json.Formatting;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            AddressDal _addressDal = new AddressDal();

            Address address = new Address
            {
                AddressId = 2,
                City = "Sakarya",
                Street = "M.Altınışık",
                Description = "Bu evi sattığım için çok pişmanım",
                Country = "Türkiye",
                Town = "Serdivan"
            };


            //UserDal _userDal = new UserDal(new AddressDal(), address);

            User user = new User
            {
                UserId = 1,
                Email = "gvnbrs54@gmail.com",
                FullName = "Güven Barış ÇAKAN",
                Password = "987654321",
                PhoneNumber = "5414202551",
                ProfilePicUrl = "www.google.com",
            };

            Residential residential = new Residential
            {
                ResidentialId = 6,
                Address = address,
                HeatingType = HeatingType.CentralHeating,
                SellType = SellType.ForSale,
                Age = 10,
                Balcony = true,
                FloorNumber = 2,
                Furnished = false,
                Square = 120,
                ResidentialType = ResidentialType.Villa
            };


            AdvirtisementResidentialDal _advirtisementResidentialDal =
                new AdvirtisementResidentialDal(new ResidentialDal(new AddressDal()), new UserDal(new AddressDal()));

            _advirtisementResidentialDal.GetAll();
            //_residentialDal.Update(residential);

            //_residentialDal.Delete(residential);

            //_residentialDal.Add(residential);

            //Update,Delete,Add
            //_addressDal.Add(address);


            ////GetById
            //Console.WriteLine(JsonConvert.SerializeObject(_addressDal.GetById(1),Formatting.Indented));
            //_addressDal.Delete(address);


            // Read Enum
            //int HeatingTypeId = 3;
            //var result =  HeatingTypeId.ToEnum<HeatingType>();
            //Console.WriteLine(result);

        }
    }
}
