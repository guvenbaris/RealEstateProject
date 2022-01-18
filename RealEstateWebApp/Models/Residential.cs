using RealEstateWebApp.ModelBase;

namespace RealEstateWebApp.Models
{

    // Yerleşim
    public class Residential : IRealEstate
    {
        public int ResidentialId { get; set; }
        public double Square { get; set; }
        public short Age { get; set; }
        public short FloorNumber { get; set; }
        public bool Balcony { get; set; }
        public bool Furnished { get; set; }
        public Address Address { get; set; }
        public HeatingType HeatingType { get; set; }
        public SellType SellType { get; set; }
        public ResidentialType ResidentialType { get; set; }

        public virtual int HeatingTypeId
        {
            get => (int)this.HeatingType;
            set => HeatingType = (HeatingType)value;
        }
        public virtual int SellTypeId
        {
            get => (int)this.SellType;
            set => SellType = (SellType)value;
        }

        public virtual int ResidentialTypeId
        {
            get => (int) this.ResidentialType;
            set => ResidentialType = (ResidentialType) value;
        }
    }
}