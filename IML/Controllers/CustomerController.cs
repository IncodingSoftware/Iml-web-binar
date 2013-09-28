namespace IML.Controllers
{
    #region << Using >>

    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Incoding.CQRS;
    using Incoding.MvcContrib;

    #endregion

    public class CustomerController : IncControllerBase
    {
        public CustomerController(IDispatcher dispatcher)
                : base(dispatcher) { }

        [HttpGet]
        public ActionResult Details(FetchCustomerQuery query)
        {
            var customerVm = GetCustomers(query).FirstOrDefault();            
            return IncView(customerVm);
        }


        [HttpGet]
        public ActionResult Fetch(FetchCustomerQuery query)
        {
            IEnumerable<CustomerVm> customerVms = GetCustomers(query);            
            return IncodingResult.Success(customerVms);
        }

        #region Factory constructors

        public static IEnumerable<CustomerVm> GetCustomers(FetchCustomerQuery query)
        {
            var customers = new List<CustomerVm>
                                {
                                        new CustomerVm { Name = "Vlad", Country = "Russian", City = "Rostov", IsPublic = true },
                                        new CustomerVm { Name = "Vladislav", Country = "Russian", City = "Taganrog" },
                                        new CustomerVm { Name = "Artur", Country = "Russian", City = "Taganrog" },
                                        new CustomerVm { Name = "Igor", Country = "Ukraine", City = "Kiev", IsPublic = true },
                                        new CustomerVm { Name = "Dima", Country = "Ukraine", City = "Dnepropetrovsk" },
                                        new CustomerVm { Name = "Alex", Country = "Ukraine", City = "Dnepropetrovsk" }
                                };

            var filter = customers
                    .Where(r => string.IsNullOrWhiteSpace(query.Name) || r.Name.Contains(query.Name))
                    .Where(r => string.IsNullOrWhiteSpace(query.Country) || r.Country == query.Country)
                    .Where(r => string.IsNullOrWhiteSpace(query.City) || r.City == query.City);
            return filter;
        }

        #endregion
    }

    public class FetchCustomerQuery
    {
        #region Properties

        public string Name { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        #endregion
    }

    public class CustomerVm
    {
        #region Properties

        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public bool IsPublic { get; set; }
       

        #endregion
    }
}