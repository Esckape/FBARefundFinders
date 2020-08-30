using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBARefundProject.AmazonMWS
{
    public static class Reports
    {
        public static class InventoryReports {
            public const string InventoryReport = "_GET_FLAT_FILE_OPEN_LISTINGS_DATA_";
            public const string AllListings = "_GET_MERCHANT_LISTINGS_ALL_DATA_";
        }

        public class SettlementReports {
            public const string XMLSettlementReport = "_GET_V2_SETTLEMENT_REPORT_DATA_XML_";
            public const string FlatFileSettlementReportV2 = "_GET_V2_SETTLEMENT_REPORT_DATA_FLAT_FILE_V2_";
        }
    }
}
