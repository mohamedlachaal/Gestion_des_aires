using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marhaba.Controllers
{
    public class SeDeconnecterController : Controller
    {
        public IActionResult Index()
        {
            
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Passager");
       
            
        }
    }
}
