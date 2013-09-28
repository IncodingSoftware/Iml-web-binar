namespace IML.Controllers
{
    #region << Using >>

    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Incoding.Extensions;
    using Incoding.MvcContrib;

    #endregion

    public class ReferenceController : Controller
    {

        [HttpGet]
        public ActionResult FetchCountry()
        {
            return IncodingResult.Success(GetCountries());
        }

        [HttpGet]
        public ActionResult FetchCity(string country)
        {
            Dictionary<string, List<KeyValueVm>> cities = GetCities();
            return IncodingResult.Success(cities.GetOrDefault(country, cities.Values.SelectMany(r => r).ToList()));
        }

        static List<KeyValueVm> GetCountries()
        {
            return new List<KeyValueVm>
                       {
                               new KeyValueVm("Russian"),
                               new KeyValueVm("Ukraine")
                       };
        }

        static Dictionary<string, List<KeyValueVm>> GetCities()
        {
            return new Dictionary<string, List<KeyValueVm>>
                       {
                               {
                                       "Russian", new List<KeyValueVm>
                                                      {
                                                              new KeyValueVm("Rostov"),
                                                              new KeyValueVm("Taganrog")
                                                      }
                               },
                               {
                                       "Ukraine", new List<KeyValueVm>
                                                      {
                                                              new KeyValueVm("Dnepropetrovsk"),
                                                              new KeyValueVm("Kiev")
                                                      }
                               }
                       };
        }
    }
}