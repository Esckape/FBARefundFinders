using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBARefundProject.AmazonModels
{
    public class SettlementReportDataItem
    {
        //TODO Add all columns from report if needed
        public string SettlementId { get; set; }
        public DateTime SettlementStartDate{ get; set; }
        public DateTime SettlementEndDate { get; set; }
        public DateTime SettlementDepositDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Curency { get; set; }
        public string TransactionType { get; set; }
        public string OrderId { get; set; }
        public string MerchantOrderId { get; set; }
        public string AmountType { get; set; }
        public string AmoutDescription { get; set; }
        public string FulfillmentId { get; set; }
        public int QuantityPurchased { get; set; }
    }
}
