using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class StoreFrontController : Controller
    {
        private IStoreFrontBL _storeFrontBL;
        public StoreFrontController(IStoreFrontBL p_storeFrontBL)
        {
            _storeFrontBL = p_storeFrontBL;

        }

        // GET: StoreFrontController
        public ActionResult Index()
        {
            return View(_storeFrontBL.GetStoreFrontList()
                .Select(store => new StoreFrontVM(store))
                .ToList()
                );
        }

        // GET: StoreFrontController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreFrontController1/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StoreFrontVM frontVM)
        {
        


            if (ModelState.IsValid)
        {
            _storeFrontBL.AddStoreFront(new StoreFront()
        {
            Name = frontVM.Name,
                Address = frontVM.Address,
            });

            return RedirectToAction(nameof(Index));
    }
            return View();
}

        // POST: StoreFrontController1/Create
        // GET: StoreFrontController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreFrontController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreFrontController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreFrontController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
