using System.Linq;
using System.Web.Mvc;
using ProvaConhecimento.Stefanini.Web.Models;
using ProvaConhecimento.Stefanini.Web.Utils;

namespace ProvaConhecimento.Stefanini.Web.Controllers
{
    public class HomeController : Controller
    {
        private DBEntities _db = new DBEntities();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = Cryptography.GetMD5(password);
                var user = _db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).FirstOrDefault();

                if (user != null)
                {
                    //add session
                    Session["Role"] = user.Role;
                    Session["Email"] = user.Email;
                    Session["idUser"] = user.IdUser;
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ViewBag.error = @"The email and/or password entered is invalid.Please try again.";                   
                }
            }

            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }        

    }
}
