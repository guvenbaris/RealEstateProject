using System;
using System.Text.Json;
using RealEstateWebApp.DataAccess;

namespace TestConsoleApp
{
    class Program
    {
       public static void Main(string[] args)
       {
        AdvertisementLandDal _advertisementLandDal =
           new AdvertisementLandDal(new LandDal(new AddressDal()), new UserDal(new AddressDal()));

        foreach (var advertisiment in _advertisementLandDal.GetAll())
        {
            Console.WriteLine(JsonSerializer.Serialize(advertisiment.Land));
        }
       }
    }
}
