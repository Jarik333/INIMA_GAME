using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopProject_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProject_1.Controllers
{ 
    public class HomeController : Controller
    {
        bool Admin;
        ApplicationContext db;
        string error;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
           
            return View();
        }
        [HttpGet]
        public IActionResult IndexLogin()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {

           
            return View();
        }
        [HttpPost]
        public IActionResult Registration(string Name, int Password)
        {
            foreach (User user in db.Users)
            {
                if ((user.UserName == Name))
                {
                    ViewData["Message"] = "Такой пользователь уже зарегистрирован";
                    return View(error);
                }



            }
            User User = new User();
            User.UserName = Name;
            User.Password = Password;
            
            db.Users.Add(User);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return RedirectToAction("IndexLogin", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            
            return View();


        }
        [HttpPost]
        public IActionResult Login(string Name, int Password)
        {
            foreach (User user in db.Users)
            {
                if ((user.UserName == Name) && (user.Password == Password))
                {
                    Admin = true;

                    return RedirectToAction("IndexLogin", "Home");
                }
                
                   
                
            }
            ViewData["Message"] = "Неверный пароль";
            Admin = false;
            return View(error);


        }
       
        [HttpGet]
        public IActionResult Buy(int Id)
        {
           
            foreach (Game game in db.Games)
            {
                if (game.GameId == Id)
                {
                    ViewData["GameName"] = game.Name;
                    ViewData["GamePrice"] = game.Price;
                }



            }
            
            return View();


        }
        [HttpPost]
        public IActionResult Buy(string Adress, int Phone)
        {
           
                Order Order = new Order();
                Order.Adress = Adress;
                Order.Phone = Phone;

                db.Order.Add(Order);
                // сохраняем в бд все изменения
                db.SaveChanges();
                ViewData["Message"] = "Заказ оформлен!";
          
           
            return View();
        }
    }

}