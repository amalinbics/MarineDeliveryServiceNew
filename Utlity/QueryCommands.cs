namespace Utlity
{
    public class QueryCommands
    {
        public enum Master
        {
            GetCompany,
            UpdateCompany,

            GetLoginUser,
            UpdateLoginUser,

            GetInSite,
            UpdateInSite,
            UpdateSyncFlagInSite,

            GetTankType,
            UpdateTankType,

            GetInSiteTank,
            UpdateInSiteTank,
            UpdateSyncFlagInSiteTank,

            GetInSiteTankProducts,
            UpdateInSiteTankProducts,

            GetInSiteTankSubCompartments,
            UpdateInSiteTankSubCompartments,
            UpdateSyncFlagInSiteTankSubCompartments,

            GetInSiteBillingItem,
            UpdateInSiteBillingItem,
            UpdateSyncFlagINSiteBillingItem,

            GetProdCont,
            UpdateProdCont,
            UpdateSyncFlagProdCont,

            GetInSiteProdCont,
            UpdateInSiteProdCont,
            UpdateInSiteProdContNew,
            UpdateSyncFlagINSiteProdCont,

            GetSubProdCont,
            UpdateSubProdCont,
            UpdateSyncFlagSubProdCont,

            GetInSiteTankProductsAPI,
            UpdateInSiteTankProductAPI,
            UpdateSyncFlagInSiteTankProductAPI,

            GetUOM,
            UpdateUOM,
            UpdateSyncFlagUOM,

            GetUOMType,
            UpdateUMOType,

            GetProducts,
            UpdateProducts,
            UpdateSyncFlagProduct,

            GetVessel,
            UpdateVessel,
            UpdateSyncFlagVessel,

            GetAdHocVessel,
            UpdateAdHocVessel,
            UpdateSyncVesselFlag,

            GetCarriers,
            UpdateCarriers,
            UpdateSyncFlagCarrier,

            GetDrivers,
            UpdateDrivers,

            GetVehicle,
            UpdateVehicle,
            UpdateSyncFlagVehicle,

            GetVehicleCompartments,
            UpdateVehicleCompartment,
            UpdateSyncFlagVehicleCompartments,

            GetTankChart,
            UpdateTankChart,
            UpdateSyncFlagTankChart,

            GetVehicleSubCompartments,
            UpdateVehicleSubCompartments,
            UpdateSyncFlagVehicleSubCompartments,

            GetMarineLocType,
            UpdateMarineLocType,

            GetMarineRegion,
            UpdateMarineRegion,
            UpdateSyncFlagMarineRegion,

            GetMarineLocation,
            UpdateMarineLocation,
            UpdateSyncFlagMarineLocation,

            GetMarineAppSalesPLUButtons,
            UpdateMarineAppSalesPLUButtons,

            GetARShipTo,
            UpdateARShipTo,
            UpdateSyncFlagARShipTo,

            GetPerson,
            UpdatePerson,

            GetPersonPhone,
            UpdatePersonPhone,
            UpdateSyncFlagPersonPhone,

            GetTankChartDetails,
            UpdateTankChartDetails,
            UpdateTankChartDetailsNew,
            UpdateSyncFlagTankChartDetail,

            GetTankChartKeel,
            UpdateTankChartKeel,
            UpdateSyncFlagTankChartKeel,

            GetTankChartTrim,
            UpdateTankChartTrim,
            UpdateSyncFlagTankChartTrim,

            GetInSiteTankVolume,
            GetInSiteTankVolumeDetail,
            UpdateInSiteTankVolume,
            UpdateInSiteTankVolumeIsUpdatedFlag,

            GetSyncDeletedTrx,
            UpdateSyncDeletedTrx,
            UpdateSyncDeletedTrxIsUpdatedFlag,

            GetDeletedINSiteBillingItem,
            DeleteINSiteBillingItem,
            UpdateDeletedINSiteBillingItemSyncFlag,

            GetOrderAttachment,
            UpdateOrderAttachment,

            DeleteINSiteTankProducts,
            DeleteOrderAttachment,

            UpdateDocLogo,

            GetDeletedINSiteProdCont,
            DeleteINSiteProdCont,
            UpdateINSiteProdContDeletedTrxSyncFlag,

            GetDeletedPersonPhone,
            DeletePersonPhone,
            UpdatePersonPhoneDeletedTrxSyncFlag,

            GetDeletedSubstitutes,
            DeleteSubstitutes,
            UpdateSubstitutesDeletedTrxSyncFlag,

            GetDeletedTankChartDetail,
            DeleteTankChartDetail,
            UpdateTankChartDetailDeletedTrxSyncFlag,

            GetDeletedVehicleSubCompartments,
            DeleteVehicleSubCompartments,
            UpdateVehicleSubCompartmentsDeletedTrxSyncFlag


        }

        public enum Order
        {
            GetOrderHdr,
            GetOrderItem,
            GetOrderItemComponent,
            GetOrderNotes,
            UpdateOrderDetails,
            UpdateOrderDetailsNeedUpdateFlag,

            GetClientOrderHdr,
            GetClientOrderItem,
            GetClientOrderItemComponent,
            GetClientOrderNote,
            UpdateClientOrderDetails,
            UpdateLoadStatus,

            GetOrderStatusHistory,
            UpdateOrderStatusHistoryNeedUpdateFlag,

            UpdateOrderRetryCount,
            UpdateOrderNotes,
            UpdateOrderNoteSyncFlag,

            GetCloudOrderNotes,
            UpdateOrderNoteToClient,
            UpdateCloudOrderNoteSyncFlag
        }

        public enum Shipment
        {

            GetShipDoc,
            GetShipDocItem,
            GetShipDocItemComp,
            GetShipDocItemReading,
            GetShipDocItemReadingDetail,
            GetShipmentDetails,
            GetShipmentLoadDetails,
            UpdateShipmentDetails,
            UpdateShipmentReadingDetailsNeedUpdateFlag,
            UpdateShipmentDetailsReview,
            UpdateShipmentDetailsNeedUpdateFlag,

            //Delivery
            GetDeliveryShipDoc,
            GetDeliveryDocItem,
            GetDeliveryDocItemComp,
            GetDeliveryDocItemReading,
            GetDeliveryDocItemReadingDtl,
            GetDelivery,
            GetDeliveryDetail,


            GetShipDocItemVessel,
            UpdateDeliveryDetails,
            UpdateDeliveryDetailsNeedUpdateFlag,
            UpdateDeliveryDetailsLineUpdateFlag,
            UpdateDeliveryReadingDetailsNeedUpdateFlag,
            UpdateDeliveryDetailsReview,


            GetMeterTicket,
            UpdateMeterTicker,
            UpdateNeedUpdateMeterTicket,

            GetDOI,
            UpdateDOI,
            UpdateDOINeedUpdate,

            GetDeliveryTicket,
            UpdateDeliveryTicket,
            UpdateNeedUpdateDeliveryTicket,

            GetAttachment,
            UpdateAttachment,
            UpdateNeedUpdateAttachment,

            GetDcoMessage,
            UpdateDcoMessage,

            GetCloudOrderItemCount,
            GetClientOrderItemCount,
            UpdateShipmentRetryCount,
            UpdateDeliveryRetryCount


        }


        public enum QueryCommandKey
        {
            Master,
            Order,
            Shipment,

        }
    }
}
