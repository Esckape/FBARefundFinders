using System;

namespace FBARefundProject.Models.Reports
{
    public class ReportsGridItem
    {
        public DateTime FilledOn { get; set; }
        public AmazonStatuses AmazonStatus { get; set; }
        public CaseStatuses CaseStatus { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Actual { get; set; }
        public long CaseId { get; set; } //maybe guid?
        public string Details { get; set; }
        public string MoreDetails { get; set; } // is needed?
    }


    public enum AmazonStatuses { 
        Open,
        Pending,
        Closed
    }

    public enum CaseStatuses
    {
        Pending,
        Success,
        Failed,
        Closed
    }
}