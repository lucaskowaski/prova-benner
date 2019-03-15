using Microondas.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Microondas.Controllers
{
    public class ProgramaController : Controller
    {
        JavaScriptSerializer _serialize = new JavaScriptSerializer();
        // GET: Programa
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProgramaViewModel programa)
        {
            if (ModelState.IsValid)
            {
                List<ProgramaViewModel> programas = new List<ProgramaViewModel>();
                programas.Add(programa);
                Session["programas"] = _serialize.Serialize(programas);
                return RedirectToAction("Index", "Microondas");
            }
            else
            {
                return View();
            }
        }
    }
}