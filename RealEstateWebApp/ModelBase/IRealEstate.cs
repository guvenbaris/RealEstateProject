using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateWebApp.Models;

namespace RealEstateWebApp.ModelBase
{
    public enum SellType
    {
        ForSale,
        ForRent
    }
    public interface IRealEstate
    {
        int RealEstateId { get; set; }
        SellType SellType { get; set; }
        double Square { get; set; }
        Address Address { get; set; }

    }
}
