using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealEstateWebApp.ModelBase;

namespace RealEstateWebApp.Models
{
    public class Commercial : IRealEstate
    {
        public int CommercialId { get; set; }
        public SellType SellType { get; set; }
        public int Square { get; set; }
        public short Age { get; set; }
        public Address Address { get; set; }
        public short FloorNumber { get; set; }
        public bool Balcony { get; set; }
        public bool Furnished { get; set; }
        public ResidentialType ResidentialType { get; set; }
        public HeatingType HeatingType { get; set; }
        public short BuildingType { get; set; }

        public virtual int SellTypeId
        {
            get => (int)this.SellType;
            set => SellType = (SellType)value;
        }
        public virtual int ResidentialTypeId
        {
            get => (int)this.ResidentialType;
            set => ResidentialType = (ResidentialType) value;
        }
        public virtual int HeatingTypeId
        {
            get => (int)this.HeatingType;
            set => HeatingType = (HeatingType)value;
        }
    }

}