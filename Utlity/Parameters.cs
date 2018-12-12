using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utlity
{
    public static class Parameters
    {
        public static string parameter = "JsonValue";
        public static string SyncParameter = "jsonSyncDeleteDetails";

        public static class CommonParameters
        {
            public static string SiteID = "SiteID";
            public static string INSiteTankID = "INSiteTankID";
            public static string SubCompartmentID = "SubCompartmentID";
            public static string ProdContID = "ProdCont";
            public static string ShipToVesselID = "ShipToVesselID";
            public static string CarrierID = "CarrierID";
            public static string VehicleID = "VehicleID";
            public static string MarineLocID = "MarineLocID";
            public static string MarineRegionID = "MarineRegionID";

            public static string INSiteTankVolumeID = "INSiteTankVolumeID";
            public static string ReadingDateTime = "ReadingDateTime";

            public static string SysTrxNo = "SysTrxNo";
            public static string OrderNo = "OrderNo";
            public static string DocNo = "DocNo";
            public static string CompanyID = "CompanyID";
            public static string CustomerID = "CustomerID";

            public static string StatusCode = "StatusCode";
            public static string LastModifiedUser = "LastModifiedUser";

            public static string OrderStatusID = "OrderStatusID";          

            public static string RetryCount = "RetryCount";

            public static string ID = "ID";
            public static string TableName = "TableName";
            public static string OrderDetails = "jsonOrderDetails";
            public static string DocType = "DOCTYPE";
            public static string UserID = "UserID";

            public static string ProductAPIID = "ProductAPIID";
            public static string CompartmentID = "CompartmentID";
            public static string UOMID = "UOMID";




        }
        public static class INSiteBillingItem
        {
            public static string SiteID = "SiteID";
            public static string BillingItemID = "BillingItemID";
        }

        public static class INSiteProdCont
        {
            public static string SiteID = "SiteID";
            public static string ProdContID = "ProdContID";
        }

        public static class PersonPhone
        {
            public static string PhoneID = "PhoneID";
            public static string PersonID = "PersonID";
        }

        public static class Substitutes
        {
            public static string ProdContID = "ProdContID";
            public static string SubProdContID = "SubProdContID";
        }

        public static class TankChartDetail
        {
            public static string TankChartID = "TankChartID";
            public static string Depth = "Depth";
            public static string DepthFeet = "DepthFeet";
            public static string DepthFraction = "DepthFraction";
        }

        public static class OrderAttachment
        {
            public static string AttachmentID = "AttachmentID";
            public static string FileExt = "FileExt";
            public static string FileDescr = "FileDescr";
            public static string FilePath = "FilePath";
            public static string FileName = "FileName";


        }


    }

}
