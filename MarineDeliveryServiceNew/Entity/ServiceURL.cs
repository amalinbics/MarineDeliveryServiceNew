using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class ServiceURL
    {
        /* Client API */
        //public static String GetCompanyURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetCompany?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetINSiteURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetINSite?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetINSiteTankURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetINSiteTank?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetINSiteTankProductURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetINSiteTankProducts?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetInSiteTankSubCompartments = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetInSiteTankSubCompartments?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetINSiteTankProductAPIURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetINSiteTankProductsAPI?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetVehicleURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetVehicles?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetVehicleCompartmentsURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetVehicleCompartments?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetVehicleSubCompartmentsURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetVehicleSubCompartments?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetLoginUserURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetLoginUser?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetDriversURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetDrivers?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetCarrierURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetCarriers?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetARShipToURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetARShipTo?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetPersonURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetPerson?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetPersonPhoneURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetPersonPhone?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetProductsToURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetProducts?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetUOMTypeURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetUOMType?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetUOMURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetUOM?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetMarineLocURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetMarineLoc?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetMarineLocTypeURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetMarineLocType?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetMarineRegionURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetMarineRegion?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetMarineAppSalesPLUButtonsURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetSalesPLUButtons?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetTankChartURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetTankChart?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetTankChartDetailURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetTankChartDetails?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetTankChartKeelURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetTankChartKeel?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetTankChartTrimURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetTankChartTrim?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetShipToVesselURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetShipToVessel?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetINSiteProdContURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetINSiteProdCont?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetSubProdContURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetSubProdCont?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetINSiteBillingItemURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetINSiteBillingItem?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();

        //public static String UpdateOrderDetailsURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateOrderDetails?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateOrderHdrURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateOrderDetailsTest?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateShipmentDetailsURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateShipmentDetails?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateShipmentDetailsReviewURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateShipmentDetailsReview?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateDeliveryDetailsURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateDeliveryDetails?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateDeliveryDetailsReviewURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateDeliveryDetailsReview?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();

        ////Update MarineSyncFlag
        //public static String UpdateSyncFlagARShipTo = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagARShipTo";
        //public static String UpdateSyncFlagCarrier = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagCarrier";
        //public static String UpdateSyncFlagInSite = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagInSite";
        //public static String UpdateSyncFlagINSiteProdCont = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagINSiteProdCont";
        //public static String UpdateSyncFlagSubProdCont = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagSubProdCont";
        //public static String UpdateSyncFlagINSiteBillingItem = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagINSiteBillingItem";
        //public static String UpdateSyncFlagINSiteTank = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagINSiteTank";
        //public static String UpdateSyncFlagInSiteTankSubCompartments = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagInSiteTankSubCompartments";
        //public static String UpdateSyncFlagMarineLoc = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagMarineLoc";
        //public static String UpdateSyncFlagMarineRegion = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagMarineRegion";
        //public static String UpdateSyncFlagPerson = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagPerson1";
        //public static String UpdateSyncFlagPersonPhone = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagPersonPhone";
        //public static String UpdateSyncFlagProduct = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagProduct";
        //public static String UpdateSyncFlagShipToVessel = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagShipToVessel";
        //public static String UpdateSyncFlagTankChart = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagTankChart";
        //public static String UpdateSyncFlagTankChartDetail = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagTankChartDetail";
        //public static String UpdateSyncFlagTankChartKeel = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagTankChartKeel";
        //public static String UpdateSyncFlagTankChartTrim = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagTankChartTrim";
        //public static String UpdateSyncFlagUOM = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagUOM";
        //public static String UpdateSyncFlagVehicle = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagVehicle";
        //public static String UpdateSyncFlagVehicleCompartments = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagVehicleCompartments";
        //public static String UpdateSyncFlagVehicleSubCompartments = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagVehicleSubCompartments";
        //public static String UpdateSyncFlagINSiteTankProductAPI = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagINSiteTankProductAPI";

        ///* Get Order Details API from ASCEND */
        //public static String GetClientOrderHdrURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetClientOrderHdr?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetClientOrderItemURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetClientOrderItem?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetClientOrderItemComponentURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetClientOrderItemComponent?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String GetClientOrderNoteURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetClientOrderNote?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();

        //public static String UpdateLoadStatusURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateLoadStatus";

        //public static String UpdateOrderItemDelete = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_OrderItemDelete";

        ///* MarineDelivery API from CLOUD */

        ///* Update Master data from Client to MarineDelivery */
        //public static String UpdateCompanyURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateCompany?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateINSiteURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateINSite?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateINSiteTankURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateINSiteTank?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateINSiteTankProductsURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateINSiteTankProducts?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateInSiteTankSubCompartmentsURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateInSiteTankSubCompartments?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateVehicleURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateVehicle?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateVehicleCompartmentURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateVehicleCompartment?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateVehicleSubCompartmentURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateVehicleSubCompartment?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateLoginUserURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateLoginUser?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateDriversURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateDrivers?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateCarrierURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateCarrier?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateARShipToURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateARShipTo?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdatePersonURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdatePerson?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdatePersonPhoneURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdatePersonPhone?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateProductsURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateProducts?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateUOMTypeURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateUOMType?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateUOMURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateUOM?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateMarineLocURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateMarineLoc?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateMarineLocTypeURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateMarineLocType?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateMarineRegionURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateMarineRegion?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateMarineAppSalesPLUButtonsURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateMarineAppSalesPLUButtons?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateTankChartURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateTankChart?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateTankChartDetailURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateTankChartDetail?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateTankChartKeelURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateTankChartKeel?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateTankChartTrimURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateTankChartTrim?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateVesselURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateVessel?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateINSiteProdContURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateINSiteProdCont?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateSubProdContURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateSubProdCont?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateINSiteBillingItemURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateINSiteBillingItem?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateDOIURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateDOI?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateINSiteTankProductAPIURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateINSiteTankProductAPI?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();

        ///* Get Order Details API */
        ////  public static String GetOrderHdrURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetOrderHdr?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String GetOrderHdrURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetOrderHdr";
        ////public static String GetOrderItemURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetOrderItem?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        ////public static String GetOrderItemComponentURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetOrderItemComponent?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        ////public static String GetOrderNotesURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetOrderNotesUpdate?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String GetOrderItemURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetOrderItem";
        //public static String GetOrderItemComponentURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetOrderItemComponent";
        //public static String GetOrderNotesURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetOrderNotesUpdate";
        //public static String UpdateOrderRetryCount = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateOrderRetryCount";

        //public static String GetOrderItemCountURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetOrderItemCount";
        //public static String GetClientOrderItemCountURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetOrderItemCount";
        
        //public static String GetDOIURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDOIUpdate?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();

        ///* Get Delivery Ticket*/
        //public static String GetDeliveryTicket = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDeliveryTicketUpdate?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        ///* Update Delivery Ticket */
        //public static String UpdateDeliveryTicket = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateDeliveryTicket?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();

        ///* update Order Details API from client */
        //public static String UpdateClientOrderDetailsURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateClientOrderDetails?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();

        ///* Get Shipment Details API */
        //// public static String GetShipDocURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetShipDoc?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String GetShipDocURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetShipDoc";        
        //public static String GetShipDocItemReadingURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetShipDocItemReading?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String GetShipDocItemReadingDtlURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetShipDocItemReadingDtl?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String GetShipmentDetails = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetShipmentLoad?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String GetShipmentLoadDetails = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetShipmentLoadDetail?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateShipmentRetryCount = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateShipmentRetryCount";

        //public static String GetShipDocItemURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetShipDocItem";
        //public static String GetShipDocItemCompURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetShipDocItemComp";        
        ////public static String GetShipDocItemReadingURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetShipDocItemReading";        
        ////public static String GetShipDocItemReadingDtlURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetShipDocItemReadingDtl";      
        ////public static String GetShipmentDetails = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetShipmentLoad";        
        ////public static String GetShipmentLoadDetails = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetShipmentLoadDetail";

        ///* Get delivery Details API */
        ////public static String GetDeliveryDocURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDeliveryDoc?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String GetDeliveryDocURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDeliveryDoc";
        ////public static String GetDeliveryDocItemURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDeliveryDocItem?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        ////public static String GetDeliveryDocItemCompURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDeliveryDocItemComp?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String GetDeliveryDocItemReadingURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDeliveryDocItemReading?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String GetDeliveryDocItemReadingDtlURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDeliveryDocItemReadingDtl?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String GetDelivery = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDelivery?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String GetDeliveryDetails = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDeliveryDetail?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String GetShipDocItemVessel = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetShipDocItemVessel?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateDeliveryRetryCount = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateDeliveryRetryCount";

        //public static String GetDeliveryDocItemURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDeliveryDocItem";
        //public static String GetDeliveryDocItemCompURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDeliveryDocItemComp";
        ////public static String GetDeliveryDocItemReadingURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDeliveryDocItemReading" ;
        ////public static String GetDeliveryDocItemReadingDtlURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDeliveryDocItemReadingDtl";
        ////public static String GetDelivery = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDelivery";
        ////public static String GetDeliveryDetails = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetDeliveryDetail";
        ////public static String GetShipDocItemVessel = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetShipDocItemVessel";

        ///* Get Order Status History to update  in client */
        //public static String GetOrderStatusHistoryURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetOrderStatusToUpdate";
        //public static String UpdateOrderStatusHistoryNeedUpdateFlagURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateOrderStatusNeedUpdateFlag";


        //public static String UpdateOrderDetailsNeedUpdateFlagURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateOrderDetailsNeedUpdateFlag";
        //public static String UpdateShipmentDetailsNeedUpdateFlagURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateShipmentDetailsNeedUpdateFlag";
        //public static String UpdateShipmentReadingDetailsNeedUpdateFlagURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateShipmentReadingDetailsNeedUpdateFlag";

        //public static String UpdateDeliveryDetailsNeedUpdateFlagURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateDeliveryDetailsNeedUpdateFlag";
        //public static String UpdateDeliveryReadingDetailsNeedUpdateFlagURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateDeliveryReadingDetailsNeedUpdateFlag";
        //public static String UpdateDeliveryDetailsLineUpdateFlagURL = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateShipDocItemLine";

        //public static String UpdateNeedUpdateDOI = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_NeedUpdateFlagDOI";
        //public static String UpdateNeedUpdateDeliveryTicket = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_NeedUpdateFlagDeliveryTicket";

        //public static String GetMeterTicket = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetMeterTicket?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateMeterTicket = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateMeterTicket?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateNeedUpdateMeterTicket = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_NeedUpdateFlagMeterTicket";

        //public static String GetDcoMessage = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetDocMessage?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateDocMessage = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateDocMessage?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();

        //public static String GetAttachment = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetAttachment?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateAttachment = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateAttachment?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateNeedUpdateAttachment = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_NeedUpdateFlagAttachment";

        //public static String GetTankType = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetTankType?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateTankType = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateTankType?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();

        //public static String GetProdCont = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetProdCont?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateProdCont = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateProdCont?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateSyncFlagProdCont = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagProdCont";

        //public static String GetAdHocVessel = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetAdHocVessel?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateAdHocVessel = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateAdHocVessel?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateSyncVesselFlag = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateSyncVesselFlag";

        //public static String GetINSiteTankVolume = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetINSiteTankVolume?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String GetINSiteTankVolumeDetail = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetINSiteTankVolumeDetails?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateINSiteTankVolume = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateINSiteTankVolume?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateINSiteTankIsUpdatedFlag = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateINSiteTankVolumeIsUpdatedFlag";

        //public static String GetDeletedINSiteBillingItem = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetDeletedINSiteBillingItem?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String DeleteINSiteBillingItem = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_DeleteINSiteBillingItem";
        //public static String UpdateDeletedINSiteBillingItemSyncFlag = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateINSiteBillingItemDeletedTrxSyncFlag";

        //public static String GetDeletedINSiteProdCont = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetDeletedINSiteProdCont?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String DeleteINSiteProdCont = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_DeleteINSiteProdCont";
        //public static String UpdateINSiteProdContDeletedTrxSyncFlag = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateINSiteProdContDeletedTrxSyncFlag";

        //public static String GetDeletedPersonPhone = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetDeletedPersonPhone?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String DeletePersonPhone = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_DeletePersonPhone";
        //public static String UpdatePersonPhoneDeletedTrxSyncFlag = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdatePersonPhoneDeletedTrxSyncFlag";

        //public static String GetDeletedSubstitutes = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetDeletedSubstitutes?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String DeleteSubstitutes = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_DeleteSubstitutes";
        //public static String UpdateSubstitutesDeletedTrxSyncFlag = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSubstitutesDeletedTrxSyncFlag";

        //public static String GetDeletedTankChartDetail = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetDeletedTankChartDetail?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String DeleteTankChartDetail = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_DeleteTankChartDetail";
        //public static String UpdateTankChartDetailDeletedTrxSyncFlag = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateTankChartDetailDeletedTrxSyncFlag";

        //public static String GetDeletedVehicleSubCompartments = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetDeletedVehicleSubCompartments?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String DeleteVehicleSubCompartments = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_DeleteVehicleSubCompartments";
        //public static String UpdateVehicleSubCompartmentsDeletedTrxSyncFlag = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateVehicleSubCompartmentsDeletedTrxSyncFlag";

        //public static String GetSyncDeletedTrx = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetSyncDeletedTrx?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateSyncDeletedTrx = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateSyncDeleted?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateSyncDeletedTrxIsUpdatedFlag = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncDeletedIsUpdatedFlag";

        //public static String GetOrderNote = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetOrderNotes?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateOrderNote = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateOrderNote?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateOrderNoteSyncFlag = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateOrderNoteSyncFlag";
        
        //public static String GetCloudOrderNotes = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_GetCloudOrderNotes?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateOrderNoteToClient = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateOrderNote?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String UpdateCloudOrderNoteSyncFlag = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagOrderNote";

        //public static String GetDeleteSalesPLUButtons = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_GetDeletedMarineAppSalesPLUButtons?" + ConfigurationManager.AppSettings["ClientAPIKEY"].ToString();
        //public static String DeleteSalesPLUButtons = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["CloudAPIName"].ToString() + "/_proc/MN_DeleteMarineAppSalesPLUButtons?" + ConfigurationManager.AppSettings["CloudAPIKEY"].ToString();
        //public static String UpdateSalesPLUButtonsDeletedSyncFlag = ConfigurationManager.AppSettings["APIURL"].ToString() + ConfigurationManager.AppSettings["ClientAPIName"].ToString() + "/_proc/MN_UpdateSyncFlagSalesPLUButtonsDeletedTrx";

       
    }
}
