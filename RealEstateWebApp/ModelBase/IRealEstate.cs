using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateWebApp.Models;

namespace RealEstateWebApp.ModelBase
{
    public interface IRealEstate
    {
        SellType SellType { get; set; }
        double Square { get; set; }
        Address Address { get; set; }

    }
}
