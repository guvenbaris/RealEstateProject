using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateWebApp.DataAccess;
using RealEstateWebApp.Models;

namespace RealEstateWebApp.Controllers
{
    public class AdvertisementResidentialController : Controller
    {


        private readonly AdvirtisementResidentialDal _advirtisementResidentialDal =
            new AdvirtisementResidentialDal(new ResidentialDal(new AddressDal()), new UserDal(new AddressDal()));


        // GET: AdvertisementResidential
        public ActionResult Index()
        {

            List<AdvertisimentResedential> advertisimentResedentials = _advirtisementResidentialDal.GetAll();
            return View(advertisimentResedentials);
        }
    }
}