﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GRB.Models;

namespace GRB.Controllers
{
    [HandleError]
    [Authorize]
    public class EAController : Controller
    {
        protected GoaRehabEntities db;
        public EAController()
        {
            this.db = new GoaRehabEntities();
        }

        // GET: EA
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (DateTime.Now.Date > DateTime.Parse("15 Aug 2017"))
        //    {                
        //        filterContext.Result = new RedirectResult("~/Home/pli");
        //        return;
        //    }
            
        //}

        protected override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                string controller = filterContext.RouteData.Values["controller"].ToString();
                string action = filterContext.RouteData.Values["action"].ToString();
                Exception ex = filterContext.Exception;

                filterContext.Result = new ViewResult {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary(new HandleErrorInfo(ex, controller, action))
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}