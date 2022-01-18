using System;
using RealEstateWebApp.Models;
using System.Web.Mvc;
using RealEstateWebApp.ModelBase;


namespace RealEstateWebApp.Controllers
{
    public class AdvertisementResidentialController : Controller
    {
        // GET: AdvertisementResidential
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdvertisementResidential/Details/5
        public ActionResult Details()
        {
            Address address = new Address
            {
                City = "Sakarya",
                Country = "Türkiye"
            };
            Residential house = new Residential
            {
                RealEstateId = 1,
                Square = 160,
                Furnished = false,
                Heating = HeatingType.NaturalGas,
                Address = address
            };


            User user = new User
            {
                Email = "test@test.com",
                FullName = "Haydar haydar"
            };
            AdvertisimentResedential advertisimentResedential = new AdvertisimentResedential
            {

                AdvertisementId = 1,
                Date = new DateTime(2012, 05, 24),
                Title = "Merhaba Dünya",
                Explanation = "Çok güzel bir ev",
                IsActive = true,
                User = user,
                RealEstate = house
            };


            return View(advertisimentResedential);
        }

        // GET: AdvertisementResidential/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvertisementResidential/Create
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

        // GET: AdvertisementResidential/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdvertisementResidential/Edit/5
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

        // GET: AdvertisementResidential/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdvertisementResidential/Delete/5
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
