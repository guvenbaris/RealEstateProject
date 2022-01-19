using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateWebApp.ModelBase
{
    public enum HeatingType
    {
        NaturalGas = 0,
        AirCondition = 1,
        Stove = 2,
        CentralHeating = 3
    }
    public enum ResidentialType
    {
        Flat = 0,
        Residence = 1,
        Villa = 2,
        FarmHouse = 3
    }
    public enum SellType
    {
        ForSale = 0,
        ForRent = 1
    }

    public enum AdvertType
    {
        Residential = 0,
        Commercial = 1,
        Land = 2,
    }
    public static class EnumBase
    {
        public static T ToEnum<T>(this int value)
        {
            var name = Enum.GetName(typeof(T), value);
            return name.ToEnum<T>();
        }
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }


}