using FBARefundProject.AmazonModels;
using MarketplaceWebService;
using MarketplaceWebService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FBARefundProject.AmazonMWS
{
    public class ReportsMWS
    {
        String accessKeyId = "AKIAI66FSTIFSFUU44SQ";
        String secretAccessKey = "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";
        const string sellerId = "AM9XZDGJ7SL26";
        const string marketplaceId = "ATVPDKIKX0DER";
        const string applicationName = "FBARefund";
        const string applicationVersion = "1.00";


        string _reportsPath = Path.Combine(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory)), "SettlementReports");

        const string mwsAuthToken = "amzn.mws.caba08d9-9c69-5cb8-1821-352b84b06d34";
        MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();

        public ReportsMWS()
        {
            config.ServiceURL = "https://mws.amazonservices.com";
            if (!Directory.Exists(_reportsPath)) {
                Directory.CreateDirectory(_reportsPath);
            }
        }

        public List<SettlementReportDataItem> GetSettlementReports(string reportType, string sellerId)
        {
            try
            {
                MarketplaceWebServiceClient service = new MarketplaceWebServiceClient(accessKeyId, secretAccessKey, applicationName, applicationVersion, config);

                GetReportListRequest reportListRequest = new GetReportListRequest();
                reportListRequest.Merchant = sellerId;
                reportListRequest.MWSAuthToken = mwsAuthToken;
                //reportListRequest.ReportRequestIdList = lstRequestID;
                reportListRequest.ReportTypeList = new TypeList();
                reportListRequest.ReportTypeList.Type = new List<string>() { reportType };
                var reportList = service.GetReportList(reportListRequest);

                GetReportListResult reportListResult = reportList.GetReportListResult;

                //TODO - Implement GetReportsListByNextToken
                if (reportListResult.ReportInfo.Count > 0) {
                    for (int i = 0; i < reportListResult.ReportInfo.Count; i++)
                    {
                        GetReportRequest reportRequest = new GetReportRequest();
                        reportRequest.Merchant = sellerId;
                        reportRequest.MWSAuthToken = mwsAuthToken;
                        reportRequest.ReportId = reportListResult.ReportInfo[i].ReportId;
                        string path = Path.Combine(_reportsPath,reportListResult.ReportInfo[i].ReportId + ".xml");
                        reportRequest.Report = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        var report = service.GetReport(reportRequest);
                    }
                }

                

                //if (myListzz.Count > 0)
                //{
                //    while (myListzz[0].ReportProcessingStatus.ToString() != "_DONE_")
                //    {
                //        Console.WriteLine("Waiting for Report");
                //        //Thread.Sleep(61000);
                //        reportRequestListResponse =
                //        service.GetReportRequestList(reportRequestListRequest);
                //        reportRequestListResult =
                //        reportRequestListResponse.GetReportRequestListResult;
                //        myListzz = reportRequestListResult.ReportRequestInfo;
                //    }


                //    if (myListzz[0].GeneratedReportId != null)
                //    {
                //        GetReportRequest reportRequest = new GetReportRequest();
                //        reportRequest.Merchant = sellerId;

                //        String source = "C:\\myreport.txt";
                //        reportRequest.ReportId = myListzz[0].GeneratedReportId;
                //        // reportRequest.Report = File.Open(source, FileMode.Create,  FileAccess.ReadWrite);
                //        service.GetReport(reportRequest);
                //    }
                //}
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return null;
        }

        public void GetReports(string reportType)
        {
            try
            {
                MarketplaceWebServiceClient service = new MarketplaceWebServiceClient(accessKeyId,secretAccessKey,applicationName,applicationVersion,config);

                RequestReportRequest reportRequestRequest = new RequestReportRequest();
                reportRequestRequest.Merchant = sellerId;
                reportRequestRequest.MWSAuthToken = mwsAuthToken;
                reportRequestRequest.MarketplaceIdList = new IdList();
                reportRequestRequest.MarketplaceIdList.Id.Add("ATVPDKIKX0DER");
                reportRequestRequest.ReportType = "_GET_FLAT_FILE_OFFAMAZONPAYMENTS_SANDBOX_SETTLEMENT_DATA_";
                
                // you can change ReportType here:
                //http://docs.developer.amazonservices.com/en_IN/reports/Reports_ReportType.html


                RequestReportResponse requestResponse = service.RequestReport(reportRequestRequest);
                IdList lstRequestID = new IdList();
                lstRequestID.Id.Add(requestResponse.RequestReportResult.ReportRequestInfo.ReportRequestId);

                GetReportRequestListRequest reportRequestListRequest = new GetReportRequestListRequest();
                reportRequestListRequest.Merchant = sellerId;
                reportRequestListRequest.ReportRequestIdList = lstRequestID;
                reportRequestListRequest.MWSAuthToken = mwsAuthToken;

                List<ReportRequestInfo> myListzz = new List<ReportRequestInfo>();

                GetReportRequestListResponse reportRequestListResponse = new GetReportRequestListResponse();
                reportRequestListResponse = service.GetReportRequestList(reportRequestListRequest);
                GetReportRequestListResult reportRequestListResult = new GetReportRequestListResult();
                reportRequestListResult = reportRequestListResponse.GetReportRequestListResult;
                myListzz = reportRequestListResult.ReportRequestInfo;

                if (myListzz.Count > 0)
                {
                    while (myListzz[0].ReportProcessingStatus.ToString() != "_DONE_")
                    {
                        Console.WriteLine("Waiting for Report");
                        Thread.Sleep(60000);
                        reportRequestListResponse =
                        service.GetReportRequestList(reportRequestListRequest);
                        reportRequestListResult =
                        reportRequestListResponse.GetReportRequestListResult;
                        myListzz = reportRequestListResult.ReportRequestInfo;
                    }
                }





                    //if (myListzz[0].GeneratedReportId == null) {
                    //    GetReportListRequest reportListRequest = new GetReportListRequest();
                    //    reportListRequest.Merchant = sellerId;
                    //    reportListRequest.MWSAuthToken = mwsAuthToken;
                    //    reportListRequest.ReportRequestIdList = lstRequestID;
                    //    reportListRequest.ReportTypeList = new TypeList();
                    //    reportListRequest.ReportTypeList.Type = new List<string>() { "_GET_MERCHANT_LISTINGS_ALL_DATA_" };
                    //    var reportList = service.GetReportList(reportListRequest);

                    //    if (myListzz.Count > 0)
                    //    {
                    //        GetReportRequest reportRequest = new GetReportRequest();
                    //        reportRequest.Merchant = sellerId;
                    //        reportRequest.MWSAuthToken = mwsAuthToken;
                    //        reportRequest.ReportId = myListzz[0].GeneratedReportId;

                    //        var report = service.GetReport(reportRequest);
                    //    }
                    //}




                    //if (myListzz.Count > 0)
                    //{
                    //    while (myListzz[0].ReportProcessingStatus.ToString() != "_DONE_")
                    //    {
                    //        Console.WriteLine("Waiting for Report");
                    //        //Thread.Sleep(61000);
                    //        reportRequestListResponse =
                    //        service.GetReportRequestList(reportRequestListRequest);
                    //        reportRequestListResult =
                    //        reportRequestListResponse.GetReportRequestListResult;
                    //        myListzz = reportRequestListResult.ReportRequestInfo;
                    //    }


                    //    if (myListzz[0].GeneratedReportId != null)
                    //    {
                    //        GetReportRequest reportRequest = new GetReportRequest();
                    //        reportRequest.Merchant = sellerId;

                    //        String source = "C:\\myreport.txt";
                    //        reportRequest.ReportId = myListzz[0].GeneratedReportId;
                    //        // reportRequest.Report = File.Open(source, FileMode.Create,  FileAccess.ReadWrite);
                    //        service.GetReport(reportRequest);
                    //    }
                    //}
                }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
