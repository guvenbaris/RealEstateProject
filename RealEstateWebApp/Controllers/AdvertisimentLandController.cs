using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateWebApp.DataAccess;
using RealEstateWebApp.Models;

namespace RealEstateWebApp.Controllers
{
    public class AdvertisimentLandController : Controller
    {
        private readonly AdvertisementLandDal _advertisementLandDal =
            new AdvertisementLandDal(new LandDal(new AddressDal()), new UserDal(new AddressDal()));

        // GET: AdvertisimentLand
        public ActionResult Index()
        {
            List<AdvertisimentLand> advertisimentLands = _advertisementLandDal.GetAll();

            return View(advertisimentLands);
        }

    }
}
