using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PartyInvites_Asst2_slohja.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "My View Page";
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "good Morning" : "Good Afternoon";
            return View("MyView");
        }
    }
}