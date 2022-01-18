using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealEstateWebApp.ModelBase;


namespace RealEstateWebApp.Models
{
    public class AdvertisimentResedential : IAdvertisement
    {
        public int AdvertisementId { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string Explanation { get; set; }
        public User User { get; set; }
        public Residential RealEstate { get; set; }

    }
}