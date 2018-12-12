using Utlity;
namespace QueryBase
{
    public class MasterCommand : IQueryFetch
    {

        string Query = string.Empty;
        public string GetQuery<T>(T command)
        {
            if (command.Equals(QueryCommands.Master.GetCompany))
            {
                Query = "MN_GetCompany";
            }
            else if (command.Equals( QueryCommands.Master.UpdateCompany))
            {
                Query = "MN_UpdateCompany";
            }
            else if (command.Equals(QueryCommands.Master.GetLoginUser))
            {
                Query = "MN_GetLoginUser";
            }
            else if (command.Equals(QueryCommands.Master.UpdateLoginUser))
            {
                Query = "MN_UpdateLoginUser";
            }
            else if (command.Equals(QueryCommands.Master.GetInSite))
            {
                Query = "MN_GetINSite";
            }
            else if (command.Equals(QueryCommands.Master.UpdateInSite))
            {
                Query = "MN_UpdateINSite";
            }
            else if (command.Equals(QueryCommands.Master.UpdateSyncFlagInSite))
            {
                Query = "MN_UpdateSyncFlagInSite";
            }
            else if (command.Equals(QueryCommands.Master.GetTankType))
            {
                Query = "MN_GetTankType";
            }
            else if (command.Equals(QueryCommands.Master.UpdateTankType))
            {
                Query = "MN_UpdateTankType";
            }
            else if (command.Equals(QueryCommands.Master.GetInSiteTank))
            {
                Query = "MN_GetINSiteTank";
            }
            else if (command.Equals(QueryCommands.Master.UpdateInSiteTank))
            {
                Query = "MN_UpdateINSiteTank";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagInSiteTank))
            {
                Query = "MN_UpdateSyncFlagINSiteTank";
            }
            else if (command.Equals( QueryCommands.Master.GetInSiteTankProducts))
            {
                Query = "MN_GetINSiteTankProducts";
            }
            else if (command.Equals( QueryCommands.Master.UpdateInSiteTankProducts))
            {
                Query = "MN_UpdateINSiteTankProducts";
            }
            else if (command.Equals( QueryCommands.Master.GetInSiteTankSubCompartments))
            {
                Query = "MN_GetInSiteTankSubCompartments";
            }
            else if (command.Equals( QueryCommands.Master.UpdateInSiteTankSubCompartments))
            {
                Query = "MN_UpdateInSiteTankSubCompartments";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagInSiteTankSubCompartments))
            {
                Query = "MN_UpdateSyncFlagInSiteTankSubCompartments";
            }
            else if (command.Equals( QueryCommands.Master.GetInSiteBillingItem))
            {
                Query = "MN_GetINSiteBillingItem";
            }
            else if (command.Equals( QueryCommands.Master.UpdateInSiteBillingItem))
            {
                Query = "MN_UpdateINSiteBillingItem";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagINSiteBillingItem))
            {
                Query = "MN_UpdateSyncFlagINSiteBillingItem";
            }
            else if (command.Equals( QueryCommands.Master.GetProdCont))
            {
                Query = "MN_GetProdCont";
            }
            else if (command.Equals( QueryCommands.Master.UpdateProdCont))
            {
                Query = "MN_UpdateProdCont";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagProdCont))
            {
                Query = "MN_UpdateSyncFlagProdCont";
            }
            else if (command.Equals( QueryCommands.Master.GetInSiteProdCont))
            {
                Query = "MN_GetInSiteProdCont";
            }
            else if (command.Equals( QueryCommands.Master.UpdateInSiteProdCont))
            {
                Query = "MN_UpdateINSiteProdCont";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagINSiteProdCont))
            {
                Query = "MN_UpdateSyncFlagINSiteProdCont";
            }
            else if (command.Equals( QueryCommands.Master.GetSubProdCont))
            {
                Query = "MN_GetSubProdCont";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSubProdCont))
            {
                Query = "MN_UpdateSubProdCont";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagSubProdCont))
            {
                Query = "MN_UpdateSyncFlagSubProdCont";
            }
            else if (command.Equals( QueryCommands.Master.GetInSiteTankProductsAPI))
            {
                Query = "MN_GetINSiteTankProductsAPI";
            }
            else if (command.Equals( QueryCommands.Master.UpdateInSiteTankProductAPI))
            {
                Query = "MN_UpdateINSiteTankProductAPI";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagInSiteTankProductAPI))
            {
                Query = "MN_UpdateSyncFlagINSiteTankProductAPI";
            }
            else if (command.Equals( QueryCommands.Master.GetUOM))
            {
                Query = "MN_GetUOM";
            }
            else if (command.Equals( QueryCommands.Master.UpdateUOM))
            {
                Query = "MN_UpdateUOM";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagUOM))
            {
                Query = "MN_UpdateSyncFlagUOM";
            }
            else if (command.Equals( QueryCommands.Master.GetUOMType))
            {
                Query = "MN_GetUOMType";
            }
            else if (command.Equals( QueryCommands.Master.UpdateUMOType))
            {
                Query = "MN_UpdateUOMType";
            }
            else if (command.Equals( QueryCommands.Master.GetProducts))
            {
                Query = "MN_GetProducts";
            }
            else if (command.Equals( QueryCommands.Master.UpdateProducts))
            {
                Query = "MN_UpdateProducts";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagProduct))
            {
                Query = "MN_UpdateSyncFlagProduct";
            }
            else if (command.Equals( QueryCommands.Master.GetVessel))
            {
                Query = "MN_GetShipToVessel";
            }
            else if(command.Equals( QueryCommands.Master.UpdateVessel))
            {
                Query = "MN_UpdateVessel";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagVessel))
            {
                Query = "MN_UpdateSyncFlagShipToVessel";
            }
            else if (command.Equals( QueryCommands.Master.GetAdHocVessel))
            {
                Query = "MN_GetAdHocVessel";
            }
            else if (command.Equals( QueryCommands.Master.UpdateAdHocVessel))
            {
                Query = "MN_UpdateAdHocVessel";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncVesselFlag))
            {
                Query = "MN_UpdateSyncVesselFlag";
            }
            else if (command.Equals( QueryCommands.Master.GetCarriers))
            {
                Query = "MN_GetCarriers";
            }
            else if (command.Equals( QueryCommands.Master.UpdateCarriers))
            {
                Query = "MN_UpdateCarrier";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagCarrier))
            {
                Query = "MN_UpdateSyncFlagCarrier";
            }
            else if (command.Equals( QueryCommands.Master.GetDrivers))
            {
                Query = "MN_GetDrivers";
            }
            else if (command.Equals( QueryCommands.Master.UpdateDrivers))
            {
                Query = "MN_UpdateDrivers";
            }
            else if (command.Equals( QueryCommands.Master.GetVehicle))
            {
                Query = "MN_GetVehicles";
            }
            else if (command.Equals( QueryCommands.Master.UpdateVehicle))
            {
                Query = "MN_UpdateVehicle";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagVehicle))
            {
                Query = "MN_UpdateSyncFlagVehicle";
            }
            else if (command.Equals( QueryCommands.Master.GetVehicleCompartments))
            {
                Query = "MN_GetVehicleCompartments";
            }
            else if (command.Equals( QueryCommands.Master.UpdateVehicleCompartment))
            {
                Query = "MN_UpdateVehicleCompartment";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagVehicleCompartments))
            {
                Query = "MN_UpdateSyncFlagVehicleCompartments";
            }
            else if (command.Equals( QueryCommands.Master.GetTankChart))
            {
                Query = "MN_GetTankChart";
            }
            else if (command.Equals( QueryCommands.Master.UpdateTankChart))
            {
                Query = "MN_UpdateTankChart";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagTankChart))
            {
                Query = "MN_UpdateSyncFlagTankChart";
            }
            else if (command.Equals( QueryCommands.Master.GetVehicleSubCompartments))
            {
                Query = "MN_GetVehicleSubCompartments";
            }
            else if (command.Equals( QueryCommands.Master.UpdateVehicleSubCompartments))
            {
                Query = "MN_UpdateVehicleSubCompartment";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagVehicleSubCompartments))
            {
                Query = "MN_UpdateSyncFlagVehicleSubCompartments";
            }
            else if (command.Equals( QueryCommands.Master.GetMarineLocType))
            {
                Query = "MN_GetMarineLocType";
            }
            else if (command.Equals( QueryCommands.Master.UpdateMarineLocType))
            {
                Query = "MN_UpdateMarineLocType";
            }
            else if (command.Equals( QueryCommands.Master.GetMarineRegion))
            {
                Query = "MN_GetMarineRegion";
            }
            else if (command.Equals( QueryCommands.Master.UpdateMarineRegion))
            {
                Query = "MN_UpdateMarineRegion";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagMarineRegion))
            {
                Query = "MN_UpdateSyncFlagMarineRegion";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagMarineRegion))
            {
                Query = "MN_GetMarineLoc";
            }
            else if (command.Equals( QueryCommands.Master.GetMarineLocation))
            {
                Query = "MN_GetMarineLoc";
            }
            else if (command.Equals( QueryCommands.Master.UpdateMarineLocation))
            {
                Query = "MN_UpdateMarineLoc";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagMarineLocation))
            {
                Query = "MN_UpdateSyncFlagMarineLoc";
            }
            else if (command.Equals( QueryCommands.Master.GetMarineAppSalesPLUButtons))
            {
                Query = "MN_GetSalesPLUButtons";
            }
            else if (command.Equals( QueryCommands.Master.UpdateMarineAppSalesPLUButtons))
            {
                Query = "MN_UpdateMarineAppSalesPLUButtons";
            }
            else if (command.Equals( QueryCommands.Master.GetARShipTo))
            {
                Query = "MN_GetARShipTo";
            }
            else if (command.Equals( QueryCommands.Master.UpdateARShipTo))
            {
                Query = "MN_UpdateARShipTo";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagARShipTo))
            {
                Query = "MN_UpdateSyncFlagARShipTo ";
            }
            else if (command.Equals( QueryCommands.Master.GetPerson))
            {
                Query = "MN_GetPerson";
            }
            else if (command.Equals( QueryCommands.Master.UpdatePerson))
            {
                Query = "MN_UpdatePerson";
            }
            else if (command.Equals( QueryCommands.Master.GetPersonPhone))
            {
                Query = "MN_GetPersonPhone ";
            }
            else if (command.Equals( QueryCommands.Master.UpdatePersonPhone))
            {
                Query = "MN_UpdatePersonPhone";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagPersonPhone))
            {
                Query = "MN_UpdateSyncFlagPersonPhone";
            }
            else if (command.Equals( QueryCommands.Master.GetTankChartDetails))
            {
                Query = "MN_GetTankChartDetails ";
            }
            else if (command.Equals( QueryCommands.Master.UpdateTankChartDetails))
            {
                Query = "MN_UpdateTankChartDetail";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagTankChartDetail))
            {
                Query = "MN_UpdateSyncFlagTankChartDetail";
            }
            else if (command.Equals( QueryCommands.Master.GetTankChartKeel))
            {
                Query = "MN_GetTankChartKeel ";
            }
            else if (command.Equals( QueryCommands.Master.UpdateTankChartKeel))
            {
                Query = "MN_UpdateTankChartKeel";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagTankChartKeel))
            {
                Query = "MN_UpdateSyncFlagTankChartKeel";
            }
            else if (command.Equals( QueryCommands.Master.GetTankChartTrim))
            {
                Query = "MN_GetTankChartTrim ";
            }
            else if (command.Equals( QueryCommands.Master.UpdateTankChartTrim))
            {
                Query = "MN_UpdateTankChartTrim";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncFlagTankChartTrim))
            {
                Query = "MN_UpdateSyncFlagTankChartTrim";
            }
            else if (command.Equals( QueryCommands.Master.GetInSiteTankVolume))
            {
                Query = "MN_GetINSiteTankVolume";
            }
            else if (command.Equals( QueryCommands.Master.UpdateInSiteTankVolume))
            {
                Query = "MN_UpdateINSiteTankVolume";
            }
            else if (command.Equals( QueryCommands.Master.UpdateInSiteTankVolumeIsUpdatedFlag))
            {
                Query = "MN_UpdateINSiteTankVolumeIsUpdatedFlag";
            }
            else if (command.Equals( QueryCommands.Master.GetSyncDeletedTrx))
            {
                Query = "MN_GetSyncDeletedTrx";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncDeletedTrx))
            {
                Query = "MN_UpdateSyncDeleted";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSyncDeletedTrxIsUpdatedFlag))
            {
                Query = "MN_UpdateSyncDeletedIsUpdatedFlag";
            }
            else if (command.Equals( QueryCommands.Master.UpdateTankChartDetailsNew))
            {
                Query = "MN_UpdateTankChartNew";
            }
            else if (command.Equals( QueryCommands.Master.UpdateInSiteProdContNew))
            {
                Query = "MN_UpdateINSiteProdContNew";
            }
            else if (command.Equals( QueryCommands.Master.GetOrderAttachment))
            {
                Query = "MN_GetOrderAttachement";
            }
            else if (command.Equals( QueryCommands.Master.UpdateOrderAttachment))
            {
                Query = "MN_UpdateOrderNotesAttachment";
            }
            else if (command.Equals( QueryCommands.Master.DeleteINSiteTankProducts))
            {
                Query = "MN_DeleteINSiteTankProducts";
            }
            else if (command.Equals( QueryCommands.Master.DeleteOrderAttachment))
            {
                Query = "MN_DeleteOrderAttachment";
            }
            else if (command.Equals( QueryCommands.Master.UpdateDocLogo))
            {
                Query = "MN_UpdateDocLogo";
            }
            else if (command.Equals( QueryCommands.Master.GetDeletedINSiteProdCont))
            {
                Query = "MN_GetDeletedINSiteProdCont";
            }
            else if (command.Equals( QueryCommands.Master.DeleteINSiteProdCont))
            {
                Query = "MN_DeleteINSiteProdCont";
            }
            else if (command.Equals( QueryCommands.Master.UpdateINSiteProdContDeletedTrxSyncFlag))
            {
                Query = "MN_UpdateINSiteProdContDeletedTrxSyncFlag";
            }
            else if (command.Equals( QueryCommands.Master.GetDeletedPersonPhone))
            {
                Query = "MN_GetDeletedPersonPhone";
            }
            else if (command.Equals( QueryCommands.Master.DeletePersonPhone))
            {
                Query = "MN_DeletePersonPhone";
            }
            else if (command.Equals( QueryCommands.Master.UpdatePersonPhoneDeletedTrxSyncFlag))
            {
                Query = "MN_UpdatePersonPhoneDeletedTrxSyncFlag";
            }
            else if (command.Equals( QueryCommands.Master.GetDeletedSubstitutes))
            {
                Query = "MN_GetDeletedSubstitutes";
            }
            else if (command.Equals( QueryCommands.Master.DeleteSubstitutes))
            {
                Query = "MN_DeleteSubstitutes";
            }
            else if (command.Equals( QueryCommands.Master.UpdateSubstitutesDeletedTrxSyncFlag))
            {
                Query = "MN_UpdateSubstitutesDeletedTrxSyncFlag";
            }
            else if (command.Equals( QueryCommands.Master.GetDeletedTankChartDetail))
            {
                Query = "MN_GetDeletedTankChartDetail";
            }
            else if (command.Equals( QueryCommands.Master.DeleteTankChartDetail))
            {
                Query = "MN_DeleteTankChartDetail";
            }
            else if (command.Equals( QueryCommands.Master.UpdateTankChartDetailDeletedTrxSyncFlag))
            {
                Query = "MN_UpdateTankChartDetailDeletedTrxSyncFlag";
            }
            else if (command.Equals( QueryCommands.Master.GetDeletedVehicleSubCompartments))
            {
                Query = "MN_GetDeletedVehicleSubCompartments";
            }
            else if (command.Equals( QueryCommands.Master.DeleteVehicleSubCompartments))
            {
                Query = "MN_DeleteVehicleSubCompartments";
            }
            else if (command.Equals( QueryCommands.Master.UpdateVehicleSubCompartmentsDeletedTrxSyncFlag))
            {
                Query = "MN_UpdateVehicleSubCompartmentsDeletedTrxSyncFlag";
            }
            else if (command.Equals( QueryCommands.Master.GetDeletedINSiteBillingItem))
            {
                Query = "MN_GetDeletedINSiteBillingItem";
            }
            else if (command.Equals( QueryCommands.Master.DeleteINSiteBillingItem))
            {
                Query = "MN_DeleteINSiteBillingItem";
            }
            else if (command.Equals( QueryCommands.Master.UpdateDeletedINSiteBillingItemSyncFlag))
            {
                Query = "MN_UpdateINSiteBillingItemDeletedTrxSyncFlag";
            }
            else if (command.Equals(QueryCommands.Master.GetInSiteTankVolumeDetail))
            {
                Query = "MN_GetINSiteTankVolumeDetails";
            }

            return Query;
        }
    }
}



