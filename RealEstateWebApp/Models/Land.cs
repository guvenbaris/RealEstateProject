using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealEstateWebApp.ModelBase;

namespace RealEstateWebApp.Models
{
    public class Land : IRealEstate
    {
        public int LandId { get; set; }
        public SellType SellType { get; set; }
        public int Square { get; set; }
        public Address Address { get; set; }
        public int BlockNumber { get; set; }
        public int ParselNumber { get; set; }
        public int SquarePrice { get; set; }
        public int ZoningStatus { get; set; }

        public virtual int SellTypeId
        {
            get => (int)this.SellType;
            set => SellType = (SellType)value;
        }

    }
}