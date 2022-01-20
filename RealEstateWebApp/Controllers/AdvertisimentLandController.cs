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
        private AdvertisementLandDal _advertisementLandDal =
            new AdvertisementLandDal(new LandDal(new AddressDal()), new UserDal(new AddressDal()));

        // GET: AdvertisimentLand
        public ActionResult Index()
        {
            List<AdvertisimentLand> advertisimentLands =  _advertisementLandDal.GetAll();

            return View(advertisimentLands);
        }

        // GET: AdvertisimentLand/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdvertisimentLand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvertisimentLand/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdvertisimentLand/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdvertisimentLand/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdvertisimentLand/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdvertisimentLand/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
