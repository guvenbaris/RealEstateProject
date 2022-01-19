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

            Address address = new Address
            {
                AddressId = 2,
                City = "Sakarya",
                Street = "M.Altınışık",
                Description = "Bu evi sattığım için çok pişmanım",
                Country = "Türkiye",
                Town = "Serdivan"
            };

            User user = new User
            {
                UserId = 3,
                Email = "gvnbrs54@gmail.com",
                FullName = "Güven Barış ÇAKAN",
                Password = "55585558",
                PhoneNumber = "5414202551",
                ProfilePicUrl = "www.google.com",
                Address = address,
            };

            Residential residential = new Residential
            {
                Address = address,
                HeatingType = HeatingType.CentralHeating,
                SellType = SellType.ForSale,
                Age = 10,
                Balcony = true,
                FloorNumber = 2,
                Furnished = false,
                Square = 120,
                ResidentialType = ResidentialType.Villa,
            };

            Land land = new Land
            {
                Address = address,
                SellType = SellType.ForSale,
                Square = 10000,
                BlockNumber = 25,
                LandId = 1,
                ZoningStatus = 10,
                ParselNumber = 2131234214,
                SquarePrice = 20.000f,
            };
            Commercial commercial = new Commercial
            {
                Address = address,
                HeatingType = HeatingType.NaturalGas,
                SellType = SellType.ForSale,
                Age = 10,
                Balcony = true,
                FloorNumber = 2,
                Furnished = false,
                Square = 120,
                ResidentialType = ResidentialType.Villa,
                BuildingType = 1,
            };
            AdvertisimentResedential advertisimentResedential = new AdvertisimentResedential
            {
                User = user,
                Residential = residential,
                AdvertType = AdvertType.Residential,
                BuildingType = 1,
                Explanation = "Merhaba dünya",
                IsActive = true,
                PublishDate = new DateTime(2021, 05, 05),
                Title = "Residans",

            };

            AdvertisimentLand advertisimentLand = new AdvertisimentLand
            {
                User = user,
                Land = land,
                AdvertType = AdvertType.Land,
                Explanation = "Merhaba dünya",
                IsActive = true,
                PublishDate = new DateTime(2021, 05, 05),
                Title = "Deneme",
            };

            AdvertisimentCommercial advertisimentCommercial = new AdvertisimentCommercial
            {
                User = user,
                Commercial = commercial,
                AdvertType = AdvertType.Commercial,
                Explanation = "Merhaba dünya",
                IsActive = true,
                PublishDate = new DateTime(2021, 05, 05),
                Title = "Deneme",
            };

            AddressDal _addressDal = new AddressDal();

            UserDal _userDal = new UserDal(new AddressDal());

            ResidentialDal _residential = new ResidentialDal(new AddressDal());

            LandDal landDal = new LandDal(new AddressDal());

            CommercialDal commercialDal = new CommercialDal(new AddressDal());


            AdvirtisementResidentialDal advirtisementResidentialDal =
                new AdvirtisementResidentialDal(_residential, _userDal);

            AdvertisementLandDal advertisementLandDal = new AdvertisementLandDal(landDal, _userDal);
            advertisementLandDal.Update(advertisimentLand);


            AdvertisementCommercialDal advertisementCommercialDal = new AdvertisementCommercialDal(_userDal, commercialDal);

            //advertisementCommercialDal.Add(advertisimentCommercial);
            //advirtisementResidentialDal.Add(advertisimentResedential);
            //commercialDal.Add(commercial);
            //landDal.Add(land);
            //Console.WriteLine(landDal.GetById(1).SquarePrice);
            //_residential.Add(residential);
            //_addressDal.Add(address);
            //_userDal.Update(user);
        }
    }
}
