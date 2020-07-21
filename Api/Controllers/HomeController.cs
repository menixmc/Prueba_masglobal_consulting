using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Capa_datos;
using Capa_negocio;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Api.Controllers
{
    public class HomeController : ApiController
    {
        readonly Negocio Cnegocio = new Negocio();

        [Route("Api/getempleados/")]
        public IHttpActionResult GetEmpleados()
        {
            List<Modelo> Model = Cnegocio.GetInformacion(null);
            if (Model.Count > 0)
            {
                foreach (var item in Model)
                {
                    item.annualSalary = Cnegocio.Calcularsalarioanual(item);
                }
            }
            return Ok(Model);
        }


        [Route("Api/getempleados/{id}")]
        public IHttpActionResult GetEmpleados(int? id)
        {
            List<Modelo> Model = Cnegocio.GetInformacion(id);
            if (Model.Count > 0)
            {
                foreach (var item in Model)
                {
                    item.annualSalary = Cnegocio.Calcularsalarioanual(item);
                }
            }
            return Ok(Model);
        }


    }
}
