using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealEstateWebApp.ModelBase;

namespace RealEstateWebApp.Models
{
    public class Commercial : IRealEstate
    {
        public SellType SellType { get; set; }
        public double Square { get; set; }
        public int AddressId { get; set; }
        public short Age { get; set; }
        public Address Address { get; set; }
        public short FloorNumber { get; set; }
        public short Heating { get; set; }
        public bool Balcony { get; set; }
        public bool Funished { get; set; }
        public short ResidentialType { get; set; }
        public short BuildingType { get; set; }

        public virtual int SellTypeId
        {
            get => (int)this.SellType;
            set => SellType = (SellType)value;
        }

    }
}