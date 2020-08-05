using FBARefund.Models.Reports;
using System;
using System.Web.Mvc;

namespace FBARefund.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index(int SellerId)
        {
            ReportsViewModel model = new ReportsViewModel();
            //TODO Get from DB
            model.SellerId = "ABS2322A";
            model.ReportsGridItems.Add(new ReportsGridItem()
            {
                Actual = "",
                AmazonStatus = AmazonStatuses.Open,
                CaseId = 213123132,
                CaseStatus = CaseStatuses.Success,
                Details = "Units damaged in warehouse were never reimbursed",
                Price = 400,
                Quantity = 2,
                FilledOn = DateTime.Now
            });
            
            return View(model);
        }

        public ActionResult AmazonApi()
        {
           
            return View();
        }
    }
}