using Marhaba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marhaba.Controllers
{
    public class PassagerController : Controller
    {
        private readonly MyContext _context;

        public PassagerController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/Inscription")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("/Inscription")]
        public IActionResult Create(Passager passager)
        {
            string numbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz!@#$%^&*()-=";
            Random objrandom = new Random();
            string passwordString = "";
            string strrandom = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                int temp = objrandom.Next(0, numbers.Length);
                passwordString = numbers.ToCharArray()[temp].ToString();
                strrandom += passwordString;
            }
            TempData["password"] = strrandom;
           // ViewBag.strongpwd = strrandom;
            passager.Password= strrandom;
            _context.Passagers.Add(passager);
            _context.SaveChanges();

            return RedirectToAction(nameof(Login));
        }
        [Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("/Login")]
        public IActionResult Login(Passager passager)
        {
            if(ModelState.IsValid)
            {
                var passagers = _context.Passagers.Where(p => p.Tel == passager.Tel && p.Password == passager.Password).FirstOrDefault();
                if(passagers!=null)
                {
                    HttpContext.Session.SetInt32("Id", passagers.Id);
                    HttpContext.Session.SetString("Nom", passagers.Nom);
                    HttpContext.Session.SetString("Prenom", passagers.Prenom);
                    
                    return RedirectToAction("Index", "Reservations");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Tel or password");
                }
            }
            
            return View();
        }






    }
}
