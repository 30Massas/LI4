using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WorldWideBasketball.Models;
using WorldWideBasketball.DataAccess;

namespace WorldWideBasketball.Controllers

{
    public class AccountController : Controller
    {

        private LogingInfo model = new LogingInfo(false);
        
        // GET: Account
        [HttpGet]
        public IActionResult Login()
        {
            return View(model);
        }

        public IActionResult Register()
        {

            return View(model);
        }

        public IActionResult Index()
        {
            return View(model);   
        }

        public IActionResult Privacy()
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult Verify(Account account)
        {
            UserDAO user = new UserDAO();

            if (user.isValid(account))
            {
                model.setLogged(true);
                model.setStatus(3);
                return RedirectToAction("Home", "Home", model);
            }
            else
            {
                model.setStatus(5);
                return View("Login", model);
            }
        }
            

        [HttpPost]
        public ActionResult RegisterUser(Account account)
        {
            UserDAO user = new UserDAO();

            switch (user.Insert(account))
            {
                case -1:
                    model.setStatus(-1);
                    return View("Register", model);
                case 1:
                    model.setStatus(1);
                    return View("Login",model);
                case 2:
                    model.setStatus(2);
                    return View("Register", model);
                case 6:
                    model.setStatus(6);
                    return View("Register", model);
                case 7:
                    model.setStatus(7);
                    return View("Register",model);
                case 8:
                    model.setStatus(8);
                    return View("Register", model);
                default:
                    model.setStatus(0);
                    return View("Register", model);
            }

        }
    }
}