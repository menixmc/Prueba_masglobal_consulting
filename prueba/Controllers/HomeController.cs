using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_datos;
using Capa_negocio;

namespace prueba.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Modelo> Model = new List<Modelo>();
            ViewBag.id = "";
            return View(Model);
        }

        [HttpPost]
        public ActionResult Index(int? Id)
        {
            Negocio Cnegocio = new Negocio();
            List<Modelo> Model = Cnegocio.GetInformacion(Id);
            ViewBag.id = Id;
            if (Model.Count > 0)
            {
                foreach (var item in Model)
                {
                    item.annualSalary = Cnegocio.Calcularsalarioanual(item);
                }
            }

            return View(Model);
        }
    }
}