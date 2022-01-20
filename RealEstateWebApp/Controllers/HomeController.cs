using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateWebApp.DataAccess;
using RealEstateWebApp.Models;

namespace RealEstateWebApp.Controllers
{
    public class HomeController : Controller
    {
        private AdvertisementLandDal _advertisementLandDal =
            new AdvertisementLandDal(new LandDal(new AddressDal()), new UserDal(new AddressDal()));

        private AdvertisementCommercialDal _advertisementCommercialDal =
            new AdvertisementCommercialDal(new UserDal(new AddressDal()), new CommercialDal(new AddressDal()));

        private AdvirtisementResidentialDal _advirtisementResidentialDal =
            new AdvirtisementResidentialDal(new ResidentialDal(new AddressDal()), new UserDal(new AddressDal()));
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LandPartial()
        {
            List<AdvertisimentLand> residentials = _advertisementLandDal.GetAll();
            return View(residentials);
        }
       
    }
}
