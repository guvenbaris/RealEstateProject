using RealEstateWebApp.ModelBase;

namespace RealEstateWebApp.Models
{

    public enum HeatingType
    {
        NaturalGas,
        AirCondition,
        Stove,
        CentralHeating
    }
    public enum ResidentialType
    {
        Flat,
        Residence,
        Villa,
        FarmHouse
    }
    public class Residential : IRealEstate
    {
        public int RealEstateId { get; set; }
        public SellType SellType { get; set; }
        public double Square { get; set; }
        public short Age { get; set; }
        public byte FloorNumber { get; set; }
        public HeatingType Heating { get; set; }
        public bool Balcony { get; set; }
        public bool Furnished { get; set; }
        public ResidentialType ResidentialType { get; set; }
        public Address Address { get ; set; }
    }
}