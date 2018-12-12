using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarineDeliveryServiceNew
{
    public static class ApplicationConstants
    {
        public const string Ascend = "Ascend";
        public const string MarineDelivery = "MarineDelivery";

        public const int invoicedOrderStatusID = 1007;
        public enum Database
        {
            Ascend,
            MarineDelivery,
        }

        public static string Success = "success";

        public static class Procs
        {
            public static string GetCompany = "MN_GetCompany";
            public static string UpdateCompany = "MN_UpdateCompany";

            public static string GetLoginUser = "MN_GetLoginUser";
            public static string UpdateLoginUser = "MN_UpdateLoginUser";

            public static string GetSyncDeletedTrx = "MN_GetSyncDeletedTrx";
            public static string UpdateSyncDeleted = "MN_UpdateSyncDeleted";
            public static string UpdateSyncDeletedIsUpdatedFlag = "MN_UpdateSyncDeletedIsUpdatedFlagTest";
            
            public static string GetDeletedINSiteBillingItem = "MN_GetDeletedINSiteBillingItem";
            public static string DeleteINSiteBillingItem = "MN_DeleteINSiteBillingItem";
            public static string UpdateINSiteBillingItemDeletedTrxSyncFlag = "MN_UpdateINSiteBillingItemDeletedTrxSyncFlag";

            public static string GetDeletedINSiteProdCont = "MN_GetDeletedINSiteProdCont";
            public static string DeleteINSiteProdCont = "MN_DeleteINSiteProdCont";
            public static string UpdateINSiteProdContDeletedTrxSyncFlag = "MN_UpdateINSiteProdContDeletedTrxSyncFlag";

            public static string GetDeletedPersonPhone = "MN_GetDeletedPersonPhone";
            public static string DeletePersonPhone = "MN_DeletePersonPhone";
            public static string UpdatePersonPhoneDeletedTrxSyncFlag = "MN_UpdatePersonPhoneDeletedTrxSyncFlag";

            public static string GetDeletedSubstitutes = "MN_GetDeletedSubstitutes";
            public static string DeleteSubstitutes = "MN_DeleteSubstitutes";
            public static string UpdateSubstitutesDeletedTrxSyncFlag = "MN_UpdateSubstitutesDeletedTrxSyncFlag";

            public static string GetDeletedTankChartDetail = "MN_GetDeletedTankChartDetail";
            public static string DeleteTankChartDetail = "MN_DeleteTankChartDetail";
            public static string UpdateTankChartDetailDeletedTrxSyncFlag = "MN_UpdateTankChartDetailDeletedTrxSyncFlag";

            public static string GetDeletedVehicleSubCompartments = "MN_GetDeletedVehicleSubCompartments";
            public static string DeleteVehicleSubCompartments = "MN_DeleteVehicleSubCompartments";
            public static string UpdateVehicleSubCompartmentsDeletedTrxSyncFlag = "MN_UpdateVehicleSubCompartmentsDeletedTrxSyncFlag";

            



        }


       
    }
}
