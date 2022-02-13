using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Interface;
using Store.BL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoreRep rep;
        private readonly IMapper mapper;

        public StoresController(IStoreRep rep,IMapper mapper)
        {
            this.rep = rep;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = rep.Get();

            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StoreVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    rep.Create(dpt);
                    return RedirectToAction("Index", "Department");
                }

                return View(dpt);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(dpt);
            }


        }

        public IActionResult Edit(int id)
        {
            var data = rep.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(StoreVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    rep.Update(dpt);
                    return RedirectToAction("Index", "Department");
                }

                return View(dpt);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(dpt);
            }
        }


        public IActionResult Delete(int id)
        {
            var data = rep.GetById(id);
            //if(data == null)
            //{

            //}
            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                rep.Delete(id);
                return RedirectToAction("Index", "Department");
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();
            }
        }
    }
}
