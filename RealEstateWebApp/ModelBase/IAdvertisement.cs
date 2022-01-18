using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateWebApp.Models;

namespace RealEstateWebApp.ModelBase
{
    public interface IAdvertisement
    {
        DateTime Date { get; set; }
        bool IsActive { get; set; }
        string Title { get; set; }
        string Explanation { get; set; }
        User User { get; set; }
    }
}
