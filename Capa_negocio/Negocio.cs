using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Capa_datos;
using Newtonsoft.Json;

namespace Capa_negocio
{
    public class Negocio
    {

        /// <summary>
        /// Metodo usado para realizar la conexion con la api, y obtener sus datos datos.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static dynamic ConsumirApi(string url)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
            myWebRequest.Credentials = CredentialCache.DefaultCredentials;
            myWebRequest.Proxy = null;
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream myStream = myHttpWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);
            string Datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());
            dynamic data = JsonConvert.DeserializeObject(Datos);
            return data;
        }

        /// <summary>
        /// Metodo que retorna un listado de la clase modelo, la cual en este caso es el response de la api
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Modelo> GetInformacion(int? Id)
        {
            List<Modelo> listadoempleados = new List<Modelo>();
            dynamic informacion = ConsumirApi("http://masglobaltestapi.azurewebsites.net/api/Employees");
            listadoempleados = JsonConvert.DeserializeObject<List<Modelo>>(JsonConvert.SerializeObject(informacion));

            if (Id != null)
            {
                listadoempleados = listadoempleados.Where(l => l.id == Id).ToList();
            }

            return listadoempleados;
        }

        /// <summary>
        /// Metodo utilizado para calcular el sario anual de un empleado
        /// </summary>
        /// <param name="empleados"></param>
        /// <returns></returns>
        public decimal Calcularsalarioanual(Modelo empleados)
        {
            decimal salarioanual = 0;
            string tipocontrato = empleados.contractTypeName;

            switch (tipocontrato)
            {
                case "HourlySalaryEmployee":

                    salarioanual = 120 * empleados.hourlySalary * 12;
                        break;
                case "MonthlySalaryEmployee":

                    salarioanual = empleados.monthlySalary * 12;
                    break;
                default:
                    break;
            }

            return salarioanual;
        }


    }
}
