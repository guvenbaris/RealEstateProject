using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateWebApp.ModelBase;

namespace RealEstateWebApp.Models
{
    public class AdvertisimentLand : IAdvertisement
    {
        public int AdvertisementId { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string Explanation { get; set; }
        public Land Land { get; set; }
        public User User { get; set; }
        public AdvertType AdvertType { get; set; }
        public virtual int AdvertTypeId
        {
            get => (int)this.AdvertType;
            set => AdvertType = (AdvertType)value;
        }

    }
}
