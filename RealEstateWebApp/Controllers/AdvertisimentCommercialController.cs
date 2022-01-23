using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateWebApp.DataAccess;
using RealEstateWebApp.Models;

namespace RealEstateWebApp.Controllers
{
    public class AdvertisimentCommercialController : Controller
    {
        private AdvertisementCommercialDal _advertisementCommercialDal =
            new AdvertisementCommercialDal(new UserDal(new AddressDal()), new CommercialDal(new AddressDal()));

        // GET: AdvertisimentCommercial
        public ActionResult Index()
        {

            List<AdvertisimentCommercial> advertisiments = _advertisementCommercialDal.GetAll();
            return View(advertisiments);
        }
    }
}