using System.Collections.Generic;

namespace FBARefundProject.Models.Reports
{
    public class ReportsViewModel
    {
        public ReportsViewModel()
        {
            ReportsGridItems = new List<ReportsGridItem>();
        }
        public string SellerId { get; set; }
        public List<ReportsGridItem> ReportsGridItems { get; set; }
    }
}