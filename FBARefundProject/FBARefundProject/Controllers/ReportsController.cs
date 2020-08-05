using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBARefundProject.Models.Reports;
using Microsoft.AspNetCore.Mvc;

namespace FBARefundProject.Controllers
{
    public class ReportsController : Controller
    {
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
