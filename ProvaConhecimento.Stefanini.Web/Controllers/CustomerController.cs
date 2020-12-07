using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvaConhecimento.Stefanini.Web.Models;
using ProvaConhecimento.Stefanini.Web.ViewModel;

namespace ProvaConhecimento.Stefanini.Web.Controllers
{
    public class CustomerController : Controller
    {
        private DBEntities _db = new DBEntities();
        // GET: Customer
        public ActionResult Index()
        {
            var customerViewModel = new CustomerViewModel();
            int? idUser = Convert.ToInt32(System.Web.HttpContext.Current.Session["idUser"]);

            User user = _db.Users.Where(u => u.IdUser == idUser).FirstOrDefault();

            if (user != null)
            {
                customerViewModel.User = user;

                if (user.Role == "Administrador")
                {
                    var data = _db.Customers.ToList();
                    customerViewModel.Customers = data;

                    CarregarDropDownListFiltro(customerViewModel);

                }
                else
                {
                    var data = _db.Customers.Where(c => c.IdUser == idUser).ToList();
                    customerViewModel.Customers = data;
                }

                return View(customerViewModel);
            }

            return View();
        }

        [HttpPost]
        public ActionResult SearchCustomer(CustomerFilter customerFilter)
        {

            var customerViewModel = new CustomerViewModel();

            int? idUser = Convert.ToInt32(System.Web.HttpContext.Current.Session["idUser"]);
            User user = _db.Users.Where(u => u.IdUser == idUser).FirstOrDefault();
            customerViewModel.User = user;

            CarregarDropDownListFiltro(customerViewModel);

            var result = _db.Customers.AsQueryable();

            if (customerFilter != null)
            {
                if (!string.IsNullOrEmpty(customerFilter.Name))
                    result = result.Where(x => x.Name.Contains(customerFilter.Name));
                if (customerFilter.IdGender != 0)
                    result = result.Where(x => x.IdGender == customerFilter.IdGender);
                if (customerFilter.IdRegion != 0)
                    result = result.Where(x => x.IdRegion == customerFilter.IdRegion);
                if (customerFilter.IdCity != 0)
                    result = result.Where(x => x.IdCity == customerFilter.IdCity);
                if (customerFilter.IdClassification != 0)
                    result = result.Where(x => x.IdClassification == customerFilter.IdClassification);
                if (customerFilter.IdUser != 0)
                    result = result.Where(x => x.IdUser == customerFilter.IdUser);
                if (customerFilter.LastPurchase != null && customerFilter.PurchaseUntil != null)
                    result = result.Where(x => x.LastPurchase >= customerFilter.LastPurchase && x.LastPurchase <= customerFilter.PurchaseUntil);
                else if (customerFilter.PurchaseUntil != null)
                    result = result.Where(x => x.LastPurchase <= customerFilter.PurchaseUntil);
                else if (customerFilter.LastPurchase != null)
                    result = result.Where(x => x.LastPurchase == customerFilter.LastPurchase);
            }

            customerViewModel.Customers = result.ToList();
            return View("Index", customerViewModel);
        }

        private void CarregarDropDownListFiltro(CustomerViewModel customerViewModel)
        {
            var customerFilter = customerViewModel.CustomerFilter = new CustomerFilter();

            customerFilter.Genders = new List<SelectListItem>();
            customerFilter.Genders.Add(new SelectListItem { Text = "", Value = "" });

            foreach (var gender in _db.Genders.ToList())
            {
                customerFilter.Genders.Add(new SelectListItem { Text = gender.Description, Value = gender.IdGender.ToString() });
            }

            customerFilter.Cities = new List<SelectListItem>();
            customerFilter.Cities.Add(new SelectListItem { Text = "", Value = "" });

            foreach (var city in _db.Cities.ToList())
            {
                customerFilter.Cities.Add(new SelectListItem { Text = city.Name, Value = city.IdCity.ToString() });
            }

            customerFilter.Regions = new List<SelectListItem>();
            customerFilter.Regions.Add(new SelectListItem { Text = "", Value = "" });

            foreach (var region in _db.Regions.ToList())
            {
                customerFilter.Regions.Add(new SelectListItem { Text = region.Name, Value = region.IdRegion.ToString() });
            }

            customerFilter.Classifications = new List<SelectListItem>();
            customerFilter.Classifications.Add(new SelectListItem { Text = "", Value = "" });

            foreach (var classification in _db.Classifications.ToList())
            {
                customerFilter.Classifications.Add(new SelectListItem { Text = classification.Name, Value = classification.IdClassification.ToString() });
            }

            customerFilter.Users = new List<SelectListItem>();
            customerFilter.Users.Add(new SelectListItem { Text = "", Value = "" });

            foreach (var user in _db.Users.Where(u => u.Role != "Administrador").ToList())
            {
                customerFilter.Users.Add(new SelectListItem { Text = user.FullName, Value = user.IdUser.ToString() });
            }

        }

    }
}