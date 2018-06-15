using System;
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

        /// <summary>
        /// Deletes the old image (if any) and replaces with new, else just saves the new image
        /// </summary>
        /// <param name="oldImageName">sql to fetch a string of the existing image path</param>
        /// <param name="imgType">Used in prefixing img name. E.g. GeoTree, Acc, Pkg...</param>
        /// <param name="itemId">Parent records primary key</param>
        /// <param name="UploadedFile">HttpPostedFileBase</param>
        /// <returns></returns>
        protected string SaveImage(string oldUploadName, string imgType, int itemId, System.Web.HttpPostedFileBase UploadedFile)
        {
            string fn = "";
            if (UploadedFile != null)
            {
                //First remove the old img (if exists)
                if (oldUploadName?.Length > 0) System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath("/Uploads"), oldUploadName));

                //Save the new file
                fn = UploadedFile.FileName.Substring(UploadedFile.FileName.LastIndexOf('\\') + 1);
                //fn = String.Concat(imgType, "_", itemId.ToString(), "_", fn);
                string SavePath = System.IO.Path.Combine(Server.MapPath("~/Uploads"), fn);
                UploadedFile.SaveAs(SavePath);
            }
            return (fn.Length > 0) ? fn : oldUploadName;
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