﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            /*
             * When I first edited the Index action method, it returned a string value. 
             * This meant that MVC did nothing except pass the string value as is to the browser.
             * Now that the Index method returns a ViewResult, MVC renders a view and returns 
             * the HTML it produces. I told MVC which view should be used, so it used the 
             * naming convention to find it automatically. The convention is that the view 
             * has the name of the action method and is contained in a folder named after 
             * the controller: /Views/Home/MyView.cshtml.  
             * 
             * I can return other results from action methods besides strings and ViewResult 
             * objects. For example, if I return a RedirectResult, the browser will be 
             * redirected to another URL. If I return an HttpUnauthorizedResult, 
             * I force the user to log in. These objects are collectively known 
             * as action results. The action result system lets you encapsulate 
             * and reuse common responses in actions.
             */
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        /*
         * The RsvpForm action method calls the View method without an argument, 
         * which tells MVC to render the default view associated with the action method, 
         * which is a view with the same name as the action method, in this case RsvpForm.cshtml
        */
        [HttpGet]
        public ViewResult RsvpForm() { return View(); }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);             
            return View("Thanks", guestResponse);
            }
            else
            {
                // there is a validation error              
                return View();
            }
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}