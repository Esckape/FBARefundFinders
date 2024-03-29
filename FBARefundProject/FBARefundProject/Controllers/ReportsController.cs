﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBARefundProject.AmazonMWS;
using FBARefundProject.Models.Reports;
using Microsoft.AspNetCore.Mvc;

namespace FBARefundProject.Controllers
{
    public class ReportsController : Controller
    {
        public ActionResult Index(int SellerId)
        {

            ReportsMWS mwsReports = new ReportsMWS();
            mwsReports.GetSettlementReports(Reports.SettlementReports.XMLSettlementReport, "AM9XZDGJ7SL26");


            ReportsViewModel model = new ReportsViewModel();
            //TODO Get from Amazon
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

            model.ReportsGridItems.Add(new ReportsGridItem()
            {
                Actual = "",
                AmazonStatus = AmazonStatuses.Closed,
                CaseId = 123456,
                CaseStatus = CaseStatuses.Success,
                Details = "Test details",
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
