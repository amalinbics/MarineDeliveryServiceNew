using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Utlity;
using MarineDeliveryWinServiceNew.Entity;
using System.Configuration;
using System.Net;
using System.IO;
using System.Data;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure;

namespace MarineDeliveryServiceNew
{
    public class ServiceRoutines
    {
        private readonly IDataHandler dataHandler;
        private readonly ILogging logging;

        public ServiceRoutines(IDataHandler dataHandler, ILogging logging)
        {
            this.dataHandler = dataHandler;
            this.logging = logging;
        }

        public void ExecuteRoutines()
        {

            if (ConfigurationManager.AppSettings["MasterTableUpdate"].ToString() == "Y")
            {

                UpdateCompany();
                UpdateLoginUser();
                UpdateINSite();
                UpdateINSiteTank();
                UpdateTankType();
                UpdateINSiteTankProducts();
                UpdateInSiteTankSubCompartments();
                UpdateINSiteBillingItem();
                UpdateProdCont();
                UpdateINSiteProdContNew();
                UpdateSubProdCont();
                UpdateINSiteTankProductAPI();
                UpdateUOM();
                UpdateUOMType();
                UpdateProducts();
                UpdateVessel();
                UpdateAdHocVessel();
                UpdateCarrier();
                UpdateDrivers();
                UpdateVehicles();
                UpdateVehicleCompartments();
                UpdateTankChartNew();
                UpdateVehicleSubCompartments();
                UpdateMarineLocType();
                UpdateMarineRegion();
                UpdateMarineLoc();
                UpdateMarineAppSalesPLUButtons();
                UpdateARShipTo();
                UpdatePerson();
                UpdatePersonPhone();
                UpdateINSiteTankVolume();

                UpdateSyncDeletedTrx();
                DeleteINSiteBillingItem();
                DeleteINSiteProdCont();
                DeletePersonPhone();
                DeleteSubstitutes();
                DeleteTankChartDetail();
                DeleteVehicleSubCompartments();
            }


            UpdateOrders();
            UpdateOrdersToCloud();
            UpdateOrderNotes();
            DeleteOrderAttachment();
            UpdateOrderNoteAttachment();


            UpdateOrderNotesToClient();
            UpdateShipments();
            UpdateOrderStatus('T');
            UpdateDeliveryDetails();
            UpdateMeterTicket();
            UpdateDOI();
            UpdateDeliveryTicket();
            UpdateAttachment();
            UpdateDocMessage();



        }

        /// <summary>
        /// To update Company details from Ascend to MarineDelivery DB
        /// </summary>
        public void UpdateCompany()
        {

            try
            {

                logging.WriteLog("UpdateCompany is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result getResult = dataHandler.Fetch<Company, QueryCommands.Master>(QueryCommands.Master.GetCompany);

                if (getResult.Success && getResult.AffectedRows > 0)
                {

                    CompanyJSONParam JsonParamValue = new CompanyJSONParam();
                    CompanyDetails Companys = new CompanyDetails();
                    Companys.CompanyList = ServiceUtility.EncodeObjects(getResult.Source);
                    JsonParamValue.Companies = Companys;


                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));
                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateCompany);
                    var procResult = marineResult.Source;
                    if (procResult.StatusNew.ToLower() != ApplicationConstants.Success)
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateCompany", procResult.Reason));
                    }
                }
                logging.WriteLog("UpdateCompany is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog("UpdateCompany - " + ex.Message);

            }


        }

        /// <summary>
        ///To update LoginUser details from Ascend to MarineDelivery DB
        /// </summary>

        public void UpdateLoginUser()
        {
            try
            {
                logging.WriteLog("UpdateLoginUser is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<LoginUser, QueryCommands.Master>(QueryCommands.Master.GetLoginUser);
                if (result.Success && result.AffectedRows > 0)
                {
                    LoginUserJSONParam JsonParamValue = new LoginUserJSONParam();
                    LoginUserDetails LoginUserDetail = new LoginUserDetails();
                    LoginUserDetail.LoginUserList = ServiceUtility.EncodeObjects(result.Source);

                    JsonParamValue.LoginUser = LoginUserDetail;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));
                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateLoginUser);
                    var procResult = marineResult.Source;
                    if (procResult.StatusNew.ToLower() != ApplicationConstants.Success)
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateLoginUser", procResult.Reason));
                    }
                }
                logging.WriteLog("UpdateLoginUser is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog("UpdateLoginUser - " + ex.Message);
            }
        }

        /// <summary>
        /// To update INSite details from Ascend to MarineDelivery DB
        /// </summary>
        public void UpdateINSite()
        {
            try
            {
                logging.WriteLog("UpdateINSite is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<INSite, QueryCommands.Master>(QueryCommands.Master.GetInSite);

                if (result.Success && result.AffectedRows > 0)
                {

                    INSiteJSONParam JsonParamValue = new INSiteJSONParam();
                    INSites INSite = new INSites();

                    INSite.INSiteList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.INSites = INSite;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateInSite);
                    var procResult = marineResult.Source;
                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in INSite.INSiteList
                                                                     select new MarineSyncFlag { ID = i.SiteID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.CommonParameters.SiteID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagInSite);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateINSite", syncProcResult.Reason));
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateINSite", procResult.Reason));
                    }
                }
                logging.WriteLog("UpdateINSite is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog("UpdateINSite - " + ex.Message);
            }
        }

        /// <summary>
        ///To update INSiteTank details from Ascend to MarineDelivery DB
        /// </summary>

        public void UpdateINSiteTank()
        {
            try
            {
                logging.WriteLog("UpdateINSiteTank is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<INSiteTank, QueryCommands.Master>(QueryCommands.Master.GetInSiteTank);

                if (result.Success && result.AffectedRows > 0)
                {
                    INSiteTankJSONParam JsonParamValue = new INSiteTankJSONParam();
                    INSiteTankDetails INSiteTank = new INSiteTankDetails();

                    INSiteTank.INSiteTankList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.INSiteTank = INSiteTank;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateInSiteTank);
                    var procResult = marineResult.Source;
                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in INSiteTank.INSiteTankList
                                                                     select new MarineSyncFlag { ID = i.INSiteTankID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.CommonParameters.INSiteTankID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagInSiteTank);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateINSiteTank", syncProcResult.Reason));
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateINSiteTank", procResult.Reason));
                    }
                }
                logging.WriteLog("UpdateINSiteTank is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog("UpdateINSiteTank - " + ex.Message);
            }
        }

        /// <summary>
        /// To update TankType details from Ascend to MarineDelivery DB
        /// </summary>
        public void UpdateTankType()
        {
            try
            {
                logging.WriteLog("UpdateTankType is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<TankType, QueryCommands.Master>(QueryCommands.Master.GetTankType);
                if (result.Success && result.AffectedRows > 0)
                {
                    TankTypeJSONParam JsonParamValue = new TankTypeJSONParam();
                    TankTypeUpdate TankType_Update = new TankTypeUpdate();
                    TankType_Update.TankTypeUpdateList = ServiceUtility.EncodeObjects(result.Source);

                    JsonParamValue.TankTypeGetToUpdate = TankType_Update;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));
                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateTankType);
                    var procResult = marineResult.Source;
                    if (procResult.StatusNew.ToLower() != ApplicationConstants.Success)
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateTankType", procResult.Reason));
                    }
                }
                logging.WriteLog("UpdateTankType is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog("UpdateTankType - " + ex.Message);
            }
        }

        /// <summary>
        /// To update INSiteTankProducts details from Ascend to MarineDelivery DB
        /// </summary>
        public void UpdateINSiteTankProducts()
        {
            try
            {
                logging.WriteLog("UpdateINSiteTankProducts is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<INSiteTankProducts, QueryCommands.Master>(QueryCommands.Master.GetInSiteTankProducts);
                if (result.Success && result.AffectedRows > 0)
                {
                    INSiteTankProductJSONParam JsonParamValue = new INSiteTankProductJSONParam();
                    INSiteTankProductDetails INSiteTankProducts = new INSiteTankProductDetails();
                    INSiteTankProducts.INSiteTankProductsList = ServiceUtility.EncodeObjects(result.Source);

                    JsonParamValue.INSiteTankProducts = INSiteTankProducts;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));
                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateInSiteTankProducts);
                    var procResult = marineResult.Source;
                    if (procResult.StatusNew.ToLower() != ApplicationConstants.Success)
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateINSiteTankProducts", procResult.Reason));
                    }
                }
                logging.WriteLog("UpdateINSiteTankProducts is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog("UpdateINSiteTankProducts - " + ex.Message);
            }
        }

        /// <summary>
        /// To update InSiteTankSubCompartments details from Ascend to MarineDelivery DB
        /// </summary>
        public void UpdateInSiteTankSubCompartments()
        {
            try
            {
                logging.WriteLog("UpdateInSiteTankSubCompartments is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<InSiteTankSubCompartments, QueryCommands.Master>(QueryCommands.Master.GetInSiteTankSubCompartments);
                if (result.Success && result.AffectedRows > 0)
                {
                    InSiteTankSubCompartmentsJSONParam JsonParamValue = new InSiteTankSubCompartmentsJSONParam();
                    InSiteTankSubCompartmentsDetails InSiteTankSubCompartments = new InSiteTankSubCompartmentsDetails();

                    InSiteTankSubCompartments.InSiteTankSubCompartmentsList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.InSiteTankSubCompartments = InSiteTankSubCompartments;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));


                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateInSiteTankSubCompartments);
                    var procResult = marineResult.Source;

                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in InSiteTankSubCompartments.InSiteTankSubCompartmentsList
                                                                     select new MarineSyncFlag { ID = i.SubCompartmentID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.CommonParameters.SubCompartmentID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagInSiteTankSubCompartments);

                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateInSiteTankSubCompartments", syncProcResult.Reason));
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateInSiteTankSubCompartments", procResult.Reason));
                    }

                }
                logging.WriteLog("UpdateInSiteTankSubCompartments is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog("UpdateInSiteTankSubCompartments - " + ex.Message);
            }
        }
        /// <summary>
        /// To update ProdCont details from Ascend to MarineDelivery DB
        /// </summary>
        public void UpdateProdCont()
        {
            logging.WriteLog("UpdateProdCont is started");
            try
            {
                logging.WriteLog("UpdateProdCont is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<ProdCont, QueryCommands.Master>(QueryCommands.Master.GetProdCont);
                if (result.Success && result.AffectedRows > 0)
                {
                    ProdContJSONParam JsonParamValue = new ProdContJSONParam();
                    ProdContUpdate ProdCont = new ProdContUpdate();

                    ProdCont.ProdContList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.ProdConts = ProdCont;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));


                    //var marineResult = dataHandler.FetchMany(QueryCommands.Master.UpdateProdCont);
                    //var updateResult = await marineResult;
                    //var procResult = updateResult.Source;

                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateProdCont);
                    var procResult = marineResult.Source;
                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in ProdCont.ProdContList
                                                                     select new MarineSyncFlag { ID = i.ProdContID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.CommonParameters.ProdContID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagProdCont);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateProdCont", syncProcResult.Reason));
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateProdCont", procResult.Reason));
                    }
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog("UpdateProdCont - " + ex.Message);
            }
            logging.WriteLog("UpdateProdCont is completed");
        }


        public void UpdateSubProdCont()
        {
            logging.WriteLog("UpdateSubProdCont is started");
            try
            {
                logging.WriteLog("UpdateSubProdCont is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<Substitutes, QueryCommands.Master>(QueryCommands.Master.GetSubProdCont);
                if (result.Success && result.AffectedRows > 0)
                {
                    SubProdContJSONParam JsonParamValue = new SubProdContJSONParam();
                    SubProdContDetails SubProdCont = new SubProdContDetails();

                    SubProdCont.SubProdContList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.SubProdConts = SubProdCont;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));


                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateSubProdCont);
                    var procResult = marineResult.Source;

                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        SubstitutesSyncFlagUpdate substitutesSyncFlagUpdate = new SubstitutesSyncFlagUpdate();
                        SubstitutesSyncFlagJSONParam json = new SubstitutesSyncFlagJSONParam();

                        substitutesSyncFlagUpdate.substitutesSyncFlagUpdate = (from i in SubProdCont.SubProdContList
                                                                               select new SubstitutesSyncFlag { ProdContID = i.ProdContID, SubProdContID = i.SubProdContID }).ToList<SubstitutesSyncFlag>();
                        json.substitutesSyncFlag = substitutesSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(json));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagSubProdCont);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateProdCont", syncProcResult.Reason));
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateProdCont", procResult.Reason));
                    }

                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateProdCont", ex.Message));
            }
            logging.WriteLog("UpdateSubProdCont is completed");
        }

        /// <summary>
        /// To update INSiteBillingItem details from Ascend to MarineDelivery DB
        /// </summary>
        public void UpdateINSiteBillingItem()
        {
            try
            {
                logging.WriteLog("UpdateINSiteBillingItem is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<INSiteBillingItem, QueryCommands.Master>(QueryCommands.Master.GetInSiteBillingItem);
                if (result.Success && result.AffectedRows > 0)
                {
                    INSiteBillingItemJSONParam JsonParamValue = new INSiteBillingItemJSONParam();
                    INSiteBillingItemDetails INSiteBillingItem = new INSiteBillingItemDetails();

                    INSiteBillingItem.INSiteBillingItemList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.INSiteBillingItem = INSiteBillingItem;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateInSiteBillingItem);
                    var procResult = marineResult.Source;

                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        INSiteBillingItemSyncFlagUpdate insiteBillingItemSyncFlagUpdate = new INSiteBillingItemSyncFlagUpdate();
                        INSiteBillingItemSyncFlagUpdateJSONParam JSONParam = new INSiteBillingItemSyncFlagUpdateJSONParam();

                        insiteBillingItemSyncFlagUpdate.billingItemSyncFlagUpdate = (from i in INSiteBillingItem.INSiteBillingItemList
                                                                                     select new INSiteBillingItemSyncFlag { BillingItemID = i.BillingItemID, SiteID = i.SiteID }).ToList();
                        JSONParam.billingItemSyncFlag = insiteBillingItemSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JSONParam));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagINSiteBillingItem);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateINSiteBillingItem", syncProcResult.Reason));
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateINSiteBillingItem", procResult.Reason));
                    }
                }
                logging.WriteLog("UpdateINSiteBillingItem is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog("UpdateINSiteBillingItem - " + ex.Message);
            }
        }
        /// <summary>
        /// To Update INSiteTankProductAPI details from Ascend to MarineDelivery DB
        /// </summary>
        public void UpdateINSiteTankProductAPI()
        {
            try
            {
                logging.WriteLog("UpdateINSiteTankProductAPI is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<INSiteTankProductAPI, QueryCommands.Master>(QueryCommands.Master.GetInSiteTankProductsAPI);
                if (result.Success && result.AffectedRows > 0)
                {
                    INSiteTankProductAPIJSONParam JsonParamValue = new INSiteTankProductAPIJSONParam();
                    INSiteTankProductAPIDetails INSiteTankProductAPI = new INSiteTankProductAPIDetails();

                    INSiteTankProductAPI.INSiteTankProductsAPIList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.INSiteTankProductsAPI = INSiteTankProductAPI;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateInSiteTankProductAPI);
                    var procResult = marineResult.Source;

                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in INSiteTankProductAPI.INSiteTankProductsAPIList
                                                                     select new MarineSyncFlag { ID = i.ProductAPIID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.CommonParameters.ProductAPIID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagInSiteTankProductAPI);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateINSiteTankProductAPI", syncProcResult.Reason));
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateINSiteTankProductAPI", procResult.Reason));
                    }

                }
                logging.WriteLog("UpdateINSiteTankProductAPI is completed");

            }
            catch (Exception ex)
            {
                logging.WriteErrorLog("UpdateINSiteTankProductAPI - " + ex.Message);

            }
        }
        /// <summary>
        /// To update Vehicles from Ascend to MarineDelivery db
        /// </summary>

        public void UpdateVehicles()
        {
            try
            {
                logging.WriteLog("UpdateVehicles is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<Vehicle, QueryCommands.Master>(QueryCommands.Master.GetVehicle);
                if (result.Success && result.AffectedRows > 0)
                {
                    VehicleJSONParam JsonParamValue = new VehicleJSONParam();
                    VehicleDetails Vehicle = new VehicleDetails();

                    Vehicle.VehicleList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.Vehicles = Vehicle;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateVehicle);
                    var procResult = marineResult.Source;

                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in Vehicle.VehicleList
                                                                     select new MarineSyncFlag { ID = i.VehicleID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.CommonParameters.VehicleID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagVehicle);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateVehicles", syncProcResult.Reason));
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateVehicles", procResult.Reason));
                    }
                }
                logging.WriteLog("UpdateVehicles is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog("UpdateVehicles - " + ex.Message);
            }
        }
        /// <summary>
        /// To update VehicleCompartment from Ascend to MarineDelivery db
        /// </summary>

        public void UpdateVehicleCompartments()
        {
            try
            {
                logging.WriteLog("UpdateVehicleCompartments is started");

                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<Vehicle, QueryCommands.Master>(QueryCommands.Master.GetVehicleCompartments);
                if (result.Success && result.AffectedRows > 0)
                {
                    VehicleCompartmentJSONParam JsonParamValue = new VehicleCompartmentJSONParam();
                    VehicleCompartmentDetails VehicleComparmtent = new VehicleCompartmentDetails();

                    VehicleComparmtent.VehicleCompartmentList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.VehicleCompartments = VehicleComparmtent;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateVehicleCompartment);

                    var procResult = marineResult.Source;

                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in VehicleComparmtent.VehicleCompartmentList
                                                                     select new MarineSyncFlag { ID = i.CompartmentID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.CommonParameters.CompartmentID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagVehicleCompartments);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateVehicleCompartments", syncProcResult.Reason));
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateVehicleCompartments", procResult.Reason));
                    }
                }
                logging.WriteLog("UpdateVehicleCompartments is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog("UpdateVehicleCompartments - " + ex.Message);
            }
        }

        /// <summary>
        /// To update UpdateVehicleSubCompartments from Ascend to MarineDelivery db
        /// </summary>
        public void UpdateVehicleSubCompartments()
        {
            try
            {
                logging.WriteLog("UpdateVehicleSubCompartments is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<Vehicle, QueryCommands.Master>(QueryCommands.Master.GetVehicleSubCompartments);
                if (result.Success && result.AffectedRows > 0)
                {
                    VehicleSubCompartmentJSONParam JsonParamValue = new VehicleSubCompartmentJSONParam();
                    VehicleSubCompartmentDetails VehicleSubComparmtent = new VehicleSubCompartmentDetails();

                    VehicleSubComparmtent.VehicleSubCompartmentList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.VehicleSubCompartments = VehicleSubComparmtent;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateVehicleSubCompartments);
                    var procResult = marineResult.Source;

                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in VehicleSubComparmtent.VehicleSubCompartmentList
                                                                     select new MarineSyncFlag { ID = i.SubCompartmentID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.CommonParameters.SubCompartmentID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagVehicleSubCompartments);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateVehicleSubCompartments", syncProcResult.Reason));
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateVehicleSubCompartments", procResult.Reason));
                    }
                }
                logging.WriteLog("UpdateVehicleSubCompartments is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog("UpdateVehicleSubCompartments - " + ex.Message);
            }

        }

        public void UpdateUOM()
        {
            try
            {
                logging.WriteLog("UpdateUOM is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<UOM, QueryCommands.Master>(QueryCommands.Master.GetUOM);
                if (result.Success && result.AffectedRows > 0)
                {
                    UOMJSONParam JsonParamValue = new UOMJSONParam();
                    UOMDetails UOMDetail = new UOMDetails();

                    UOMDetail.UOMList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.UOM = UOMDetail;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateUOM);
                    var procResult = marineResult.Source;

                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in UOMDetail.UOMList
                                                                     select new MarineSyncFlag { ID = i.UOMID }).ToList<MarineSyncFlag>();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.CommonParameters.UOMID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagUOM);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateUOM", syncProcResult.Reason));
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateUOM", procResult.Reason));
                    }
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateUOM", ex.Message));
            }
            logging.WriteLog("UpdateUOM is completed");
        }

        public void UpdateUOMType()
        {
            logging.WriteLog("UpdateUOMType is started");
            try
            {

                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<UOMType, QueryCommands.Master>(QueryCommands.Master.GetUOMType);
                if (result.Success && result.AffectedRows > 0)
                {
                    UOMTypeJSONParam JsonParamValue = new UOMTypeJSONParam();
                    UOMTypeDetails UOMTypeDetail = new UOMTypeDetails();

                    UOMTypeDetail.UOMTypeList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.UOMType = UOMTypeDetail;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateUMOType);
                    var procResult = marineResult.Source;

                    if (procResult.StatusNew.ToLower() != ApplicationConstants.Success)
                    {
                        if (procResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateUOMType", procResult.Reason));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateUOMType - {ex.Message}");
            }
        }

        public void UpdateProducts()
        {
            try
            {
                logging.WriteLog("UpdateProducts is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<Products, QueryCommands.Master>(QueryCommands.Master.GetProducts);
                if (result.Success && result.AffectedRows > 0)
                {
                    ProductsJSONParam JsonParamValue = new ProductsJSONParam();
                    ProductsDetails ProductsDetail = new ProductsDetails();

                    ProductsDetail.ProductList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.Product = ProductsDetail;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));


                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateProducts);
                    var procResult = marineResult.Source;

                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in ProductsDetail.ProductList
                                                                     select new MarineSyncFlag { ID = i.MasterProdID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagProduct);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog($"UpdateProducts - {syncProcResult.Reason}");
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog($"UpdateProducts - {procResult.Reason}");
                    }

                }
                logging.WriteLog("UpdateProducts is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateProducts - {ex.Message}");
            }
        }

        public void UpdateVessel()
        {
            try
            {
                logging.WriteLog("UpdateVessel is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<Vessel, QueryCommands.Master>(QueryCommands.Master.GetVessel);
                if (result.Success && result.AffectedRows > 0)
                {
                    VesselJSONParam JsonParamValue = new VesselJSONParam();
                    VesselDetails VesselDetail = new VesselDetails();

                    VesselDetail.VesselList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.Vessel = VesselDetail;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateVessel);

                    var procResult = marineResult.Source;

                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in VesselDetail.VesselList
                                                                     select new MarineSyncFlag { ID = i.ShipToVesselID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.CommonParameters.ShipToVesselID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagVessel);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog($"UpdateVessel - {syncProcResult.Reason}");
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog($"UpdateVessel - {procResult.Reason}");
                    }
                }
                logging.WriteLog("UpdateVessel is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateVessel - {ex.Message}");
            }
        }

        public void UpdateAdHocVessel()
        {
            try
            {
                logging.WriteLog("UpdateAdHocVessel is started");
                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                Result result = dataHandler.Fetch<Vessel, QueryCommands.Master>(QueryCommands.Master.GetAdHocVessel);
                if (result.Success && result.AffectedRows > 0)
                {
                    VesselJSONParam JsonParamValue = new VesselJSONParam();
                    VesselDetails VesselDetail = new VesselDetails();

                    VesselDetail.VesselList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.Vessel = VesselDetail;

                    dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var ascendResult = dataHandler.Fetch(QueryCommands.Master.UpdateAdHocVessel);
                    var procResult = ascendResult.Source;

                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in VesselDetail.VesselList
                                                                     select new MarineSyncFlag { ID = i.ShipToVesselID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                        dataHandler.AddParameter(Parameters.CommonParameters.ShipToVesselID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncVesselFlag);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog($"UpdateAdHocVessel - {syncProcResult.Reason}");
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog($"UpdateAdHocVessel - {procResult.Reason}");
                    }
                }



                logging.WriteLog("UpdateAdHocVessel is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateAdHocVessel - {ex.Message}");
            }
        }

        public void UpdateCarrier()
        {
            try
            {
                logging.WriteLog("UpdateCarrier is started");

                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<Carrier, QueryCommands.Master>(QueryCommands.Master.GetCarriers);

                if (result.Success && result.AffectedRows > 0)
                {
                    CarrierJSONParam JsonParamValue = new CarrierJSONParam();
                    CarrierDetails Carriers = new CarrierDetails();

                    Carriers.CarrierList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.Carriers = Carriers;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var ascendResult = dataHandler.Fetch(QueryCommands.Master.UpdateCarriers);

                    var procResult = ascendResult.Source;


                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in Carriers.CarrierList
                                                                     select new MarineSyncFlag { ID = i.CarrierID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                        dataHandler.AddParameter(Parameters.CommonParameters.CarrierID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagCarrier);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog($"UpdateCarrier - {syncProcResult.Reason}");
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog($"UpdateCarrier - {procResult.Reason}");
                    }
                }
                logging.WriteLog("UpdateCarrier is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateCarrier - {ex.Message}");
            }
        }

        public void UpdateDrivers()
        {
            try
            {
                logging.WriteLog("UpdateDrivers is started");

                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<Drivers, QueryCommands.Master>(QueryCommands.Master.GetDrivers);

                if (result.Success && result.AffectedRows > 0)
                {
                    DriversJSONParam JsonParamValue = new DriversJSONParam();
                    DriversDetails Drivers = new DriversDetails();

                    Drivers.DriversList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.Drivers = Drivers;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var ascendResult = dataHandler.Fetch(QueryCommands.Master.UpdateDrivers);
                    var procResult = ascendResult.Source;


                    if (procResult.StatusNew.ToLower() != ApplicationConstants.Success)
                    {
                        logging.WriteErrorLog($"UpdateCarrier - {procResult.Reason}");
                    }

                }

                logging.WriteLog("UpdateDrivers is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateDrivers - {ex.Message}");
            }
        }

        public void UpdateMarineLocType()
        {
            try
            {
                logging.WriteLog("UpdateMarineLocType is started");

                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<MarineLocType, QueryCommands.Master>(QueryCommands.Master.GetMarineLocType);

                if (result.Success && result.AffectedRows > 0)
                {
                    MarineLocTypeJSONParam JsonParamValue = new MarineLocTypeJSONParam();
                    MarineLocTypeDetails MarineLocTypeDetail = new MarineLocTypeDetails();

                    MarineLocTypeDetail.MarineLocTypeList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.MarineLocType = MarineLocTypeDetail;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var ascendResult = dataHandler.Fetch(QueryCommands.Master.UpdateMarineLocType);

                    var procResult = ascendResult.Source;

                    if (procResult.StatusNew.ToLower() != ApplicationConstants.Success)
                    {
                        logging.WriteErrorLog($"UpdateMarineLocType - {procResult.Reason}");
                    }

                }

                logging.WriteLog("UpdateMarineLocType is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateMarineLocType - {ex.Message}");
            }
        }

        public void UpdateMarineRegion()
        {
            try
            {
                logging.WriteLog("UpdateMarineRegion is started");

                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<MarineRegion, QueryCommands.Master>(QueryCommands.Master.GetMarineRegion);

                if (result.Success && result.AffectedRows > 0)
                {
                    MarineRegionJSONParam JsonParamValue = new MarineRegionJSONParam();
                    MarineRegionDetails MarineRegionDetail = new MarineRegionDetails();

                    MarineRegionDetail.MarineRegionList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.MarineRegion = MarineRegionDetail;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var ascendResult = dataHandler.Fetch(QueryCommands.Master.UpdateMarineRegion);
                    var procResult = ascendResult.Source;


                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in MarineRegionDetail.MarineRegionList
                                                                     select new MarineSyncFlag { ID = i.MarineRegionID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                        dataHandler.AddParameter(Parameters.CommonParameters.MarineLocID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagMarineRegion);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog($"UpdateMarineRegion - {syncProcResult.Reason}");
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog($"UpdateMarineRegion - {procResult.Reason}");
                    }

                }
                logging.WriteLog("UpdateMarineRegion is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateMarineRegion - {ex.Message}");
            }
        }

        public void UpdateMarineLoc()
        {
            try
            {
                logging.WriteLog("UpdateMarineLoc is started");

                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<MarineLoc, QueryCommands.Master>(QueryCommands.Master.GetMarineLocation);

                if (result.Success && result.AffectedRows > 0)
                {
                    MarineLocJSONParam JsonParamValue = new MarineLocJSONParam();
                    MarineLocDetails MarineLocDetail = new MarineLocDetails();

                    MarineLocDetail.MarineLocList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.MarineLoc = MarineLocDetail;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var ascendResult = dataHandler.Fetch(QueryCommands.Master.UpdateMarineLocation);
                    var procResult = ascendResult.Source;


                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in MarineLocDetail.MarineLocList
                                                                     select new MarineSyncFlag { ID = i.MarineLocID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                        dataHandler.AddParameter(Parameters.CommonParameters.MarineLocID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagMarineLocation);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog($"UpdateMarineLoc - {syncProcResult.Reason}");
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog($"UpdateMarineLoc - {procResult.Reason}");
                    }

                }
                logging.WriteLog("UpdateMarineLoc is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateMarineLoc - {ex.Message}");
            }
        }

        public void UpdateMarineAppSalesPLUButtons()
        {
            logging.WriteLog("UpdateMarineAppSalesPLUButtons is started");
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<MarineAppSalesPLUButtons, QueryCommands.Master>(QueryCommands.Master.GetMarineAppSalesPLUButtons);

                if (result.Success && result.AffectedRows > 0)
                {
                    MarineAppSalesPLUButtonsJSONParam JsonParamValue = new MarineAppSalesPLUButtonsJSONParam();
                    MarineAppSalesPLUButtonsDetails MarineAppSalesPLUButtonsDetail = new MarineAppSalesPLUButtonsDetails();

                    MarineAppSalesPLUButtonsDetail.MarineAppSalesPLUButtonsList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.MarineAppSalesPLUButtons = MarineAppSalesPLUButtonsDetail;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var ascendResult = dataHandler.Fetch(QueryCommands.Master.UpdateMarineAppSalesPLUButtons);

                    var procResult = ascendResult.Source;

                    if (procResult.StatusNew.ToLower() != ApplicationConstants.Success)
                    {
                        logging.WriteErrorLog($"UpdateMarineAppSalesPLUButtons - {procResult.Reason}");
                    }
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateMarineAppSalesPLUButtons - {ex.Message}");
            }
            logging.WriteLog("UpdateMarineAppSalesPLUButtons is completed");
        }

        public void UpdateARShipTo()
        {
            try
            {
                logging.WriteLog("UpdateARShipTo is started");

                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<ARShipTo, QueryCommands.Master>(QueryCommands.Master.GetARShipTo);

                if (result.Success && result.AffectedRows > 0)
                {
                    ARShipToJSONParam JsonParamValue = new ARShipToJSONParam();
                    ARShipToDetails ARShipToDetail = new ARShipToDetails();

                    ARShipToDetail.ARShipToList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.ARShipTo = ARShipToDetail;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var ascendResult = dataHandler.Fetch(QueryCommands.Master.UpdateARShipTo);
                    var procResult = ascendResult.Source;


                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in ARShipToDetail.ARShipToList
                                                                     select new MarineSyncFlag { ID = i.ShipToId }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                        dataHandler.AddParameter(Parameters.CommonParameters.MarineLocID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagARShipTo);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog($"UpdateARShipTo - {syncProcResult.Reason}");
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog($"UpdateARShipTo - {procResult.Reason}");
                    }

                }
                logging.WriteLog("UpdateARShipTo is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateARShipTo - {ex.Message}");
            }
        }

        public void UpdatePerson()
        {
            logging.WriteLog("UpdatePerson is started");
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<Person, QueryCommands.Master>(QueryCommands.Master.GetPerson);

                if (result.Success && result.AffectedRows > 0)
                {
                    PersonJSONParam JsonParamValue = new PersonJSONParam();
                    PersonDetails PersonDetail = new PersonDetails();

                    PersonDetail.PersonList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.Person = PersonDetail;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var ascendResult = dataHandler.Fetch(QueryCommands.Master.UpdatePerson);
                    var procResult = ascendResult.Source;

                    if (procResult.StatusNew.ToLower() != ApplicationConstants.Success)
                    {
                        logging.WriteErrorLog($"UpdatePerson - {procResult.Reason}");
                    }
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdatePerson - {ex.Message}");
            }
            logging.WriteLog("UpdatePerson is completed");
        }

        public void UpdatePersonPhone()
        {
            try
            {
                logging.WriteLog("UpdatePersonPhone is started");

                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<ARShipTo, QueryCommands.Master>(QueryCommands.Master.GetPersonPhone);

                if (result.Success && result.AffectedRows > 0)
                {
                    PersonPhoneJSONParam JsonParamValue = new PersonPhoneJSONParam();
                    PersonPhoneDetails PersonPhoneDetail = new PersonPhoneDetails();

                    PersonPhoneDetail.PersonPhoneList = ServiceUtility.EncodeObjects(result.Source);
                    JsonParamValue.PersonPhone = PersonPhoneDetail;

                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                    var ascendResult = dataHandler.Fetch(QueryCommands.Master.UpdatePersonPhone);
                    var procResult = ascendResult.Source;


                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in PersonPhoneDetail.PersonPhoneList
                                                                     select new MarineSyncFlag { ID = i.PhoneID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                        dataHandler.AddParameter(Parameters.CommonParameters.MarineLocID, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateSyncFlagPersonPhone);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog($"UpdatePersonPhone - {syncProcResult.Reason}");
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog($"UpdatePersonPhone - {procResult.Reason}");
                    }

                }
                logging.WriteLog("UpdatePersonPhone is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdatePersonPhone - {ex.Message}");
            }
        }

        public void UpdateINSiteTankVolume()
        {
            try
            {
                logging.WriteLog("UpdateINSiteTankVolume is started");

                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                Result resultInsiteTankVolume = dataHandler.Fetch<INSiteTankVolume, QueryCommands.Master>(QueryCommands.Master.GetInSiteTankVolume);

                List<INSiteTankVolume> ltINSiteTankVolume = ServiceUtility.EncodeObjects(resultInsiteTankVolume.Source);

                Result resultInsiteTankVolumeDetail = dataHandler.Fetch<INSiteTankVolumeDetails, QueryCommands.Master>(QueryCommands.Master.GetInSiteTankVolumeDetail);

                List<INSiteTankVolumeDetails> ltINSiteTankVolumeDetails = ServiceUtility.EncodeObjects(resultInsiteTankVolumeDetail.Source);

                if (ltINSiteTankVolume.Count > 0 && ltINSiteTankVolumeDetails.Count > 0)
                {
                    for (int i = 0; i < ltINSiteTankVolume.Count; i++)
                    {
                        try
                        {
                            INSiteTankVolume inSiteTankVolume = new INSiteTankVolume();
                            INSiteTankVolumeUpdate inSiteTankVolumeUpdate = new INSiteTankVolumeUpdate();
                            INSiteTankVolumeJSONParam inSiteTankVolumeJSONParam = new INSiteTankVolumeJSONParam();

                            int insiteTankVolumeID = ltINSiteTankVolume[i].INSiteTankVolumeID;
                            inSiteTankVolumeUpdate.INSiteTankVolumeList.Add(ltINSiteTankVolume[i]);

                            List<INSiteTankVolumeDetails> filteredINSiteTankVolumeDetails = ltINSiteTankVolumeDetails.Where(item => item.INSiteTankVolumeID == insiteTankVolumeID).ToList();
                            inSiteTankVolumeUpdate.INSiteTankVolumeDetailList = filteredINSiteTankVolumeDetails;

                            inSiteTankVolumeJSONParam.INSiteTankVolumeReading = inSiteTankVolumeUpdate;

                            dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                            dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(inSiteTankVolumeJSONParam));

                            var ascendResult = dataHandler.Fetch(QueryCommands.Master.UpdateInSiteTankVolume);
                            var procResult = ascendResult.Source;

                            if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                            {

                                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                                dataHandler.AddParameter(Parameters.CommonParameters.INSiteTankVolumeID, ltINSiteTankVolume[i].INSiteTankID);
                                dataHandler.AddParameter(Parameters.CommonParameters.ReadingDateTime, ltINSiteTankVolume[i].ReadingDateTime);

                                var syncResult = dataHandler.Fetch(QueryCommands.Master.UpdateInSiteTankVolumeIsUpdatedFlag);
                                var syncProcResult = syncResult.Source;
                                if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                                {
                                    logging.WriteErrorLog($"UpdateINSiteTankVolume - {syncProcResult.Reason}");
                                }
                            }
                            else
                            {
                                logging.WriteErrorLog($"UpdateINSiteTankVolume - {procResult.Reason}");
                            }
                        }
                        catch (Exception exception)
                        {
                            logging.WriteErrorLog($"UpdateINSiteTankVolume - {exception.Message}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateINSiteTankVolume - {ex.Message}");
            }
            logging.WriteLog("UpdateINSiteTankVolume is completed");
        }

        public async void UpdateINSiteProdContNew()
        {
            logging.WriteLog("UpdateINSiteProdContNew is started");
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                var ascendResult = dataHandler.FetchMany(QueryCommands.Master.UpdateInSiteProdContNew);
                var updateResult = await ascendResult;
                var procResult = updateResult.Source;

                if (procResult.StatusNew.ToLower() != ApplicationConstants.Success)
                {
                    logging.WriteErrorLog($"UpdateINSiteTankVolume - {procResult.Reason}");
                }

            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateINSiteProdContNew - {ex.Message}");
            }
            logging.WriteLog("UpdateINSiteProdContNew is completed");
        }

        public async void UpdateTankChartNew()
        {
            logging.WriteLog("UpdateTankChartNew is started");
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                var ascendResult = dataHandler.FetchMany(QueryCommands.Master.UpdateTankChartDetailsNew);
                var updateResult = await ascendResult;
                var procResult = updateResult.Source;

                if (procResult.StatusNew.ToLower() != ApplicationConstants.Success)
                {
                    logging.WriteErrorLog($"UpdateTankChartNew - {procResult.Reason}");
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateTankChartNew - {ex.Message}");
            }
            logging.WriteLog("UpdateTankChartNew is completed");
        }




        /// <summary>
        /// Sync the deleted masters in Ascend to MarineDelivery DB
        /// </summary>
        public void UpdateSyncDeletedTrx()
        {

            try
            {
                logging.WriteLog("UpdateSyncDeletedTrx is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<SyncDeletedTrx, QueryCommands.Master>(QueryCommands.Master.GetSyncDeletedTrx);

                SyncDeletedTrxJSONParam SyncDeletedTrxJSONParam = new SyncDeletedTrxJSONParam();
                SyncDeletedTrxUpdate SyncDeletedTrxUpdate = new SyncDeletedTrxUpdate();
                SyncDeletedTrxUpdate.SyncDeletedTrxList = ServiceUtility.EncodeObjects<SyncDeletedTrx>(result.Source);

                SyncDeletedTrxJSONParam.SyncDeletedTrx = SyncDeletedTrxUpdate;

                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(SyncDeletedTrxJSONParam));

                var Marineresult = dataHandler.FetchMany(QueryCommands.Master.UpdateSyncDeletedTrx);
                var updateResult = Marineresult.Result.Source;
                if (updateResult.StatusNew.ToLower() == ApplicationConstants.Success)
                {
                    dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                    for (int i = 0; i < SyncDeletedTrxUpdate.SyncDeletedTrxList.Count; i++)
                    {
                        dataHandler.AddParameter(Parameters.CommonParameters.ID, SyncDeletedTrxUpdate.SyncDeletedTrxList[i].ID);
                        dataHandler.AddParameter(Parameters.CommonParameters.TableName, SyncDeletedTrxUpdate.SyncDeletedTrxList[i].TableName);
                        var status = dataHandler.Update(QueryCommands.Master.UpdateSyncDeletedTrxIsUpdatedFlag);
                    }
                }
                logging.WriteLog("UpdateSyncDeletedTrx is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog("UpdateSyncDeletedTrx - " + ex.Message);
            }

        }
        /// <summary>
        /// To sync deleted INSiteBillingItem in Ascend to MarineDelivery DB
        /// </summary>
        public void DeleteINSiteBillingItem()
        {
            try
            {
                logging.WriteLog("DeleteINSiteBillingItem is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<INSiteBillingItemDeletedTrx, QueryCommands.Master>(QueryCommands.Master.GetDeletedINSiteBillingItem);

                List<INSiteBillingItemDeletedTrx> lstINSiteBillingItemDeletedTrx = result.Source;

                foreach (INSiteBillingItemDeletedTrx item in lstINSiteBillingItemDeletedTrx)
                {
                    try
                    {
                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                        dataHandler.AddParameter(Parameters.INSiteBillingItem.SiteID, item.SiteID);
                        dataHandler.AddParameter(Parameters.INSiteBillingItem.BillingItemID, item.BillingItemID);

                        var marineResult = dataHandler.FetchMany(QueryCommands.Master.DeleteINSiteBillingItem);

                        var status = marineResult.Result.Source;

                        if (status.StatusNew.ToLower() == ApplicationConstants.Success)
                        {
                            dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                            dataHandler.AddParameter(Parameters.INSiteBillingItem.SiteID, item.SiteID);
                            dataHandler.AddParameter(Parameters.INSiteBillingItem.BillingItemID, item.BillingItemID);

                            var ascendResult = dataHandler.FetchMany(QueryCommands.Master.UpdateDeletedINSiteBillingItemSyncFlag);
                            var ascendStatus = ascendResult.Result.Source;
                            if (ascendStatus.StatusNew.ToLower() != ApplicationConstants.Success)
                            {
                                logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteINSiteBillingItem", ascendStatus.Reason));
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteINSiteBillingItem", ex.Message));
                    }

                }
                logging.WriteLog("DeleteINSiteBillingItem is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteINSiteBillingItem", ex.Message));

            }
        }
        /// <summary>
        /// To sync deleted INSiteProdCont in Ascend to MarineDelivery DB
        /// </summary>
        public void DeleteINSiteProdCont()
        {
            try
            {
                logging.WriteLog("DeleteINSiteProdCont is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<INSiteProdContDeletedTrx, QueryCommands.Master>(QueryCommands.Master.GetDeletedINSiteProdCont);

                List<INSiteProdContDeletedTrx> lstINSiteProdContDeletedTrx = result.Source;

                foreach (INSiteProdContDeletedTrx item in lstINSiteProdContDeletedTrx)
                {
                    try
                    {
                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                        dataHandler.AddParameter(Parameters.INSiteProdCont.SiteID, item.SiteID);
                        dataHandler.AddParameter(Parameters.INSiteProdCont.ProdContID, item.ProdContID);

                        var marineResult = dataHandler.FetchMany(QueryCommands.Master.DeleteINSiteProdCont);

                        var status = marineResult.Result.Source;

                        if (status.StatusNew.ToLower() == ApplicationConstants.Success)
                        {
                            dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                            dataHandler.AddParameter(Parameters.INSiteProdCont.SiteID, item.SiteID);
                            dataHandler.AddParameter(Parameters.INSiteProdCont.ProdContID, item.ProdContID);

                            var ascendResult = dataHandler.FetchMany(QueryCommands.Master.UpdateINSiteProdContDeletedTrxSyncFlag);
                            var ascendStatus = ascendResult.Result.Source;
                            if (ascendStatus.StatusNew.ToLower() != ApplicationConstants.Success)
                            {
                                logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteINSiteProdCont", ascendStatus.Reason));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteINSiteProdCont", ex.Message));
                    }

                }
                logging.WriteLog("DeleteINSiteProdCont is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteINSiteBillingItem", ex.Message));
            }
        }


        public void DeletePersonPhone()
        {
            try
            {
                logging.WriteLog("DeletePersonPhone is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<PersonPhoneDeletedTrx, QueryCommands.Master>(QueryCommands.Master.GetDeletedPersonPhone);

                List<PersonPhoneDeletedTrx> lstPersonPhoneDeletedTrx = result.Source;

                foreach (PersonPhoneDeletedTrx item in lstPersonPhoneDeletedTrx)
                {
                    try
                    {
                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                        dataHandler.AddParameter(Parameters.PersonPhone.PhoneID, item.PhoneID);
                        dataHandler.AddParameter(Parameters.PersonPhone.PersonID, item.PersonID);

                        var marineResult = dataHandler.FetchMany(QueryCommands.Master.DeletePersonPhone);

                        var status = marineResult.Result.Source;

                        if (status.StatusNew.ToLower() == ApplicationConstants.Success)
                        {
                            dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                            dataHandler.AddParameter(Parameters.PersonPhone.PhoneID, item.PhoneID);
                            dataHandler.AddParameter(Parameters.PersonPhone.PersonID, item.PersonID);

                            var ascendResult = dataHandler.FetchMany(QueryCommands.Master.UpdatePersonPhoneDeletedTrxSyncFlag);
                            var ascendStatus = ascendResult.Result.Source;
                            if (ascendStatus.StatusNew.ToLower() != ApplicationConstants.Success)
                            {
                                logging.WriteErrorLog(string.Format("{0} - {1}", "DeletePersonPhone", ascendStatus.Reason));
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "DeletePersonPhone", ex.Message));
                    }

                }
                logging.WriteLog("DeletePersonPhone is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "DeletePersonPhone", ex.Message));
            }
        }

        public void DeleteSubstitutes()
        {
            try
            {
                logging.WriteLog("DeleteSubstitutes is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<SubstitutesDeletedTrx, QueryCommands.Master>(QueryCommands.Master.GetDeletedSubstitutes);

                List<SubstitutesDeletedTrx> lstSubstitutesDeletedTrx = result.Source;

                foreach (SubstitutesDeletedTrx item in lstSubstitutesDeletedTrx)
                {
                    try
                    {
                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                        dataHandler.AddParameter(Parameters.Substitutes.ProdContID, item.ProdContID);
                        dataHandler.AddParameter(Parameters.Substitutes.SubProdContID, item.SubProdContID);

                        var marineResult = dataHandler.FetchMany(QueryCommands.Master.DeleteSubstitutes);

                        var status = marineResult.Result.Source;

                        if (status.StatusNew.ToLower() == ApplicationConstants.Success)
                        {
                            dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                            dataHandler.AddParameter(Parameters.Substitutes.ProdContID, item.ProdContID);
                            dataHandler.AddParameter(Parameters.Substitutes.SubProdContID, item.SubProdContID);

                            var ascendResult = dataHandler.FetchMany(QueryCommands.Master.UpdateSubstitutesDeletedTrxSyncFlag);
                            var ascendStatus = ascendResult.Result.Source;
                            if (ascendStatus.StatusNew.ToLower() != ApplicationConstants.Success)
                            {
                                logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteSubstitutes", ascendStatus.Reason));
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteSubstitutes", ex.Message));
                    }

                }
                logging.WriteLog("DeleteSubstitutes is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteSubstitutes", ex.Message));
            }
        }

        public void DeleteTankChartDetail()
        {
            try
            {
                logging.WriteLog("DeleteTankChartDetail is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<TankChartDetailDeletedTrx, QueryCommands.Master>(QueryCommands.Master.GetDeletedTankChartDetail);

                List<TankChartDetailDeletedTrx> lstTankChartDetailDeletedTrx = result.Source;

                foreach (TankChartDetailDeletedTrx item in lstTankChartDetailDeletedTrx)
                {
                    try
                    {
                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                        dataHandler.AddParameter(Parameters.Substitutes.ProdContID, item.TankChartID);
                        dataHandler.AddParameter(Parameters.Substitutes.SubProdContID, item.Depth);
                        dataHandler.AddParameter(Parameters.Substitutes.SubProdContID, item.DepthFeet);
                        dataHandler.AddParameter(Parameters.Substitutes.SubProdContID, item.DepthFraction);

                        var marineResult = dataHandler.FetchMany(QueryCommands.Master.DeleteTankChartDetail);

                        var status = marineResult.Result.Source;

                        if (status.StatusNew.ToLower() == ApplicationConstants.Success)
                        {
                            dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                            dataHandler.AddParameter(Parameters.Substitutes.ProdContID, item.TankChartID);
                            dataHandler.AddParameter(Parameters.Substitutes.SubProdContID, item.Depth);
                            dataHandler.AddParameter(Parameters.Substitutes.SubProdContID, item.DepthFeet);
                            dataHandler.AddParameter(Parameters.Substitutes.SubProdContID, item.DepthFraction);

                            var ascendResult = dataHandler.FetchMany(QueryCommands.Master.UpdateTankChartDetailDeletedTrxSyncFlag);
                            var ascendStatus = ascendResult.Result.Source;
                            if (ascendStatus.StatusNew.ToLower() != ApplicationConstants.Success)
                            {
                                logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteTankChartDetail", ascendStatus.Reason));
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteTankChartDetail", ex.Message));
                    }

                }
                logging.WriteLog("DeleteSubstitutes is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteTankChartDetail", ex.Message));
            }
        }

        public void DeleteVehicleSubCompartments()
        {
            try
            {
                logging.WriteLog("DeleteVehicleSubCompartments is started");
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result result = dataHandler.Fetch<VehicleSubCompartmentsDeletedTrx, QueryCommands.Master>(QueryCommands.Master.GetDeletedVehicleSubCompartments);

                List<VehicleSubCompartmentsDeletedTrx> lstVehicleSubCompartmentsDeletedTrx = result.Source;

                foreach (VehicleSubCompartmentsDeletedTrx item in lstVehicleSubCompartmentsDeletedTrx)
                {
                    try
                    {
                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                        dataHandler.AddParameter(Parameters.Substitutes.ProdContID, item.CompartmentID);
                        dataHandler.AddParameter(Parameters.Substitutes.SubProdContID, item.TankChartID);
                        dataHandler.AddParameter(Parameters.Substitutes.SubProdContID, item.ReadingSide);

                        var marineResult = dataHandler.FetchMany(QueryCommands.Master.DeleteVehicleSubCompartments);

                        var status = marineResult.Result.Source;

                        if (status.StatusNew.ToLower() == ApplicationConstants.Success)
                        {
                            dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                            dataHandler.AddParameter(Parameters.Substitutes.ProdContID, item.CompartmentID);
                            dataHandler.AddParameter(Parameters.Substitutes.SubProdContID, item.TankChartID);
                            dataHandler.AddParameter(Parameters.Substitutes.SubProdContID, item.ReadingSide);

                            var ascendResult = dataHandler.FetchMany(QueryCommands.Master.UpdateVehicleSubCompartmentsDeletedTrxSyncFlag);
                            var ascendStatus = ascendResult.Result.Source;
                            if (ascendStatus.StatusNew.ToLower() != ApplicationConstants.Success)
                            {
                                logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteVehicleSubCompartments", ascendStatus.Reason));
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteVehicleSubCompartments", ex.Message));
                    }

                }
                logging.WriteLog("DeleteVehicleSubCompartments is completed");
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "DeleteSubstitutes", ex.Message));
            }
        }

        public void UpdateOrders()
        {
            logging.WriteLog("UpdateOrders is started");
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;

                dataHandler.AddParameter(Parameters.CommonParameters.RetryCount, ConfigurationManager.AppSettings["RetryCount"]);
                Result resultOrderHdr = dataHandler.Fetch<OrderHdr, QueryCommands.Order>(QueryCommands.Order.GetOrderHdr);
                dataHandler.AddParameter(Parameters.CommonParameters.RetryCount, ConfigurationManager.AppSettings["RetryCount"]);
                Result resultOrderItem = dataHandler.Fetch<OrderItem, QueryCommands.Order>(QueryCommands.Order.GetOrderItem);
                dataHandler.AddParameter(Parameters.CommonParameters.RetryCount, ConfigurationManager.AppSettings["RetryCount"]);
                Result resultOrderItemComponent = dataHandler.Fetch<OrderItemComponent, QueryCommands.Order>(QueryCommands.Order.GetOrderItemComponent);

                List<OrderHdr> lstOrderHdr = ServiceUtility.EncodeObjects(resultOrderHdr.Source);
                List<OrderItem> lstOrderItem = ServiceUtility.EncodeObjects(resultOrderItem.Source);
                List<OrderItemComponent> lstOrderItemComponent = ServiceUtility.EncodeObjects(resultOrderItemComponent.Source);

                for (int i = 0; i < lstOrderHdr.Count; i++)
                {
                    try
                    {
                        OrderJSONParam JsonParamValue = new OrderJSONParam();
                        JsonParamValue.OrderHdrList.Add(lstOrderHdr[i]);

                        List<OrderItem> lstOrderItemsFiltered = lstOrderItem.Where(item => item.SysTrxNo.Equals(lstOrderHdr[i].SysTrxNo)).ToList();
                        JsonParamValue.OrderItemList = lstOrderItemsFiltered;

                        List<OrderItemComponent> lstOrderItemCompFiltered = lstOrderItemComponent.Where(item => item.SysTrxNo.Equals(lstOrderHdr[i].SysTrxNo)).ToList();
                        JsonParamValue.OrderItemComponentList = lstOrderItemCompFiltered;

                        Orders OrderList = new Orders();
                        OrderList.OrderList = JsonParamValue;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.CommonParameters.OrderDetails, ServiceUtility.ToJsonString(OrderList));

                        var ascendResult = dataHandler.Fetch(QueryCommands.Order.UpdateOrderDetails);
                        var procResult = ascendResult.Source;

                        if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                        {

                            dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                            dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstOrderHdr[i].SysTrxNo);
                            dataHandler.AddParameter(Parameters.CommonParameters.OrderNo, lstOrderHdr[i].OrderNo);
                            dataHandler.AddParameter(Parameters.CommonParameters.CustomerID, lstOrderHdr[i].CustomerID);
                            dataHandler.AddParameter(Parameters.CommonParameters.CompanyID, lstOrderHdr[i].CompanyID);


                            var syncResult = dataHandler.Update(QueryCommands.Order.UpdateOrderDetailsNeedUpdateFlag);
                            var syncProcResult = syncResult.Source;
                            //if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                            //{
                            //    logging.WriteErrorLog($"UpdateOrders - {syncProcResult.Reason}");
                            //}
                        }
                        else
                        {
                            logging.WriteErrorLog($"UpdateOrders - {procResult.Reason}");
                            dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                            dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstOrderHdr[i].SysTrxNo);
                            var resultRetryCount = dataHandler.Update(QueryCommands.Order.UpdateOrderRetryCount);
                        }
                    }
                    catch (Exception exception)
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateOrders", exception.Message));
                    }

                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateOrders", ex.Message));
            }
            logging.WriteLog("UpdateOrders is completed");
        }

        public void UpdateOrdersToCloud()
        {
            logging.WriteLog("UpdateOrdersToCloud is started");
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;

                Result resultOrderHdr = dataHandler.Fetch<OrderHdr, QueryCommands.Order>(QueryCommands.Order.GetClientOrderHdr);
                Result resultOrderItem = dataHandler.Fetch<OrderItem, QueryCommands.Order>(QueryCommands.Order.GetClientOrderItem);
                Result resultOrderItemComponent = dataHandler.Fetch<OrderItemComponent, QueryCommands.Order>(QueryCommands.Order.GetClientOrderItemComponent);

                List<OrderHdr> lstOrderHdr = ServiceUtility.EncodeObjects(resultOrderHdr.Source);
                List<OrderItem> lstOrderItem = ServiceUtility.EncodeObjects(resultOrderItem.Source);
                List<OrderItemComponent> lstOrderItemComponent = ServiceUtility.EncodeObjects(resultOrderItemComponent.Source);

                for (int i = 0; i < lstOrderHdr.Count; i++)
                {
                    try
                    {
                        OrderJSONParam JsonParamValue = new OrderJSONParam();
                        JsonParamValue.OrderHdrList.Add(lstOrderHdr[i]);

                        List<OrderItem> lstOrderItemsFiltered = lstOrderItem.Where(item => item.SysTrxNo.Equals(lstOrderHdr[i].SysTrxNo)).ToList();
                        JsonParamValue.OrderItemList = lstOrderItemsFiltered;

                        List<OrderItemComponent> lstOrderItemCompFiltered = lstOrderItemComponent.Where(item => item.SysTrxNo.Equals(lstOrderHdr[i].SysTrxNo)).ToList();
                        JsonParamValue.OrderItemComponentList = lstOrderItemCompFiltered;

                        Orders OrderList = new Orders();
                        OrderList.OrderList = JsonParamValue;

                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                        dataHandler.AddParameter(Parameters.CommonParameters.OrderDetails, ServiceUtility.ToJsonString(OrderList));

                        var ascendResult = dataHandler.Fetch(QueryCommands.Order.UpdateClientOrderDetails);
                        var procResult = ascendResult.Source;

                        if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                        {
                            dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                            if (lstOrderHdr[i].Status == 'Z' && lstOrderHdr[i].OrderStatusID != ApplicationConstants.invoicedOrderStatusID)
                            {
                                dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstOrderHdr[i].SysTrxNo);
                                dataHandler.AddParameter(Parameters.CommonParameters.StatusCode, "O");
                                var result = dataHandler.Update(QueryCommands.Order.UpdateLoadStatus);

                                dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstOrderHdr[i].SysTrxNo);
                                dataHandler.AddParameter(Parameters.CommonParameters.StatusCode, "Z");
                                var resultStatus = dataHandler.Update(QueryCommands.Order.UpdateLoadStatus);
                            }
                            else if (lstOrderHdr[i].Status != 'Z')
                            {
                                dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstOrderHdr[i].SysTrxNo);
                                dataHandler.AddParameter(Parameters.CommonParameters.StatusCode, "I");
                                var result = dataHandler.Update(QueryCommands.Order.UpdateLoadStatus);
                            }
                            else if (lstOrderHdr[i].Status == 'Z')
                            {
                                dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstOrderHdr[i].SysTrxNo);
                                dataHandler.AddParameter(Parameters.CommonParameters.StatusCode, "Z");
                                var result = dataHandler.Update(QueryCommands.Order.UpdateLoadStatus);
                            }
                        }
                        else
                        {
                            logging.WriteErrorLog($"UpdateOrdersToCloud - {procResult.Reason}");
                        }
                    }
                    catch (Exception exception)
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateOrdersToCloud", exception.Message));
                    }
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateOrdersToCloud", ex.Message));
            }
            logging.WriteLog("UpdateOrdersToCloud is completed");
        }

        public void UpdateOrderNotes()
        {
            logging.WriteLog("UpdateOrderNotes is started");
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result resultOrderNotes = dataHandler.Fetch<OrderNote, QueryCommands.Order>(QueryCommands.Order.GetOrderNotes);

                if (resultOrderNotes != null && resultOrderNotes.AffectedRows > 0)
                {
                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                    OrderNoteUpdate orderNoteUpdate = new OrderNoteUpdate();
                    OrderNoteJSONParam orderNoteListJson = new OrderNoteJSONParam();

                    orderNoteUpdate.OderNoteList = ServiceUtility.EncodeObjects(resultOrderNotes.Source);
                    orderNoteListJson.orderNoteUpdate = orderNoteUpdate;

                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(orderNoteListJson));

                    var ascendResult = dataHandler.Fetch(QueryCommands.Order.UpdateOrderNotes);
                    var procResult = ascendResult.Source;

                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in orderNoteUpdate.OderNoteList
                                                                     select new MarineSyncFlag { ID = i.SysTrxNo }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                        dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Order.UpdateOrderNoteSyncFlag);

                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog($"UpdateOrderNotes - {syncProcResult.Reason}");
                        }
                    }
                    else
                    {
                        logging.WriteErrorLog($"UpdateOrderNotes - {procResult.Reason}");
                    }
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateOrderNotes", ex.Message));
            }
            logging.WriteLog("UpdateOrderNotes is completed");
        }

        public void DeleteOrderAttachment()
        {
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                Result resultOrderAttachment = dataHandler.Update(QueryCommands.Master.DeleteOrderAttachment);

                if (resultOrderAttachment != null && !resultOrderAttachment.Success)
                {
                    logging.WriteErrorLog($"UpdateOrderNotes - {resultOrderAttachment.Message}");
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateOrderNotes", ex.Message));
            }
        }

        public void UpdateOrderNoteAttachment()
        {
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result resultOrderAttachment = dataHandler.Fetch<CloudOrderAttachment, QueryCommands.Master>(QueryCommands.Master.GetOrderAttachment);

                List<CloudOrderAttachment> lstCloudOrderAttachment = resultOrderAttachment.Source;
                logging.WriteLog($"UpdateOrderNoteAttachment - {lstCloudOrderAttachment.Count}");
                for (int i = 0; i < lstCloudOrderAttachment.Count; i++)
                {
                    try
                    {

                        string storageConnection = CloudConfigurationManager.GetSetting("StorageConnectionString");
                        CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(storageConnection);

                        CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();

                        CloudBlobContainer blobContainer = blobClient.GetContainerReference("order-data");

                        blobContainer.CreateIfNotExists();
                        blobContainer.SetPermissions(
                        new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

                        if (blobContainer.Exists())
                        {
                            CloudBlobDirectory directory = blobContainer.GetDirectoryReference(ConfigurationManager.AppSettings["Env"].ToString());
                            CloudBlobDirectory subDirectory = directory.GetDirectoryReference(lstCloudOrderAttachment[i].OrderNo);


                            CloudBlockBlob blockBlob = subDirectory.GetBlockBlobReference(lstCloudOrderAttachment[i].FileDescr);

                            using (var stream = new MemoryStream((byte[])lstCloudOrderAttachment[i].DataFile, writable: true))
                            {
                                blockBlob.UploadFromStream(stream);
                            }

                            if (!string.IsNullOrEmpty(blockBlob.StorageUri.ToString()))
                            {
                                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                                dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstCloudOrderAttachment[i].SysTrxNo);
                                dataHandler.AddParameter(Parameters.CommonParameters.OrderNo, lstCloudOrderAttachment[i].OrderNo);
                                dataHandler.AddParameter(Parameters.OrderAttachment.AttachmentID, lstCloudOrderAttachment[i].AttachmentID);
                                dataHandler.AddParameter(Parameters.CommonParameters.UserID, lstCloudOrderAttachment[i].UserID);
                                dataHandler.AddParameter(Parameters.CommonParameters.CustomerID, lstCloudOrderAttachment[i].CustomerID);
                                dataHandler.AddParameter(Parameters.OrderAttachment.FileExt, lstCloudOrderAttachment[i].FileExt);
                                dataHandler.AddParameter(Parameters.OrderAttachment.FileName, lstCloudOrderAttachment[i].FileDescr);
                                dataHandler.AddParameter(Parameters.OrderAttachment.FilePath, blockBlob.StorageUri.PrimaryUri.ToString());
                                Result marineResult = dataHandler.Fetch(QueryCommands.Master.UpdateOrderAttachment);
                                ProcResult procResult = marineResult.Source;
                                logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateOrderNoteAttachment", procResult.Reason));
                                if (procResult.StatusNew.ToLower() != ApplicationConstants.Success)
                                {
                                    logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateOrderNoteAttachment", procResult.Reason));
                                }

                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateOrderNoteAttachment", exception.Message));
                    }
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateOrderNoteAttachment", ex.Message));
            }
        }

        public void UpdateOrderNotesToClient()
        {
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                Result resultOrderNotes = dataHandler.Fetch<OrderNote, QueryCommands.Order>(QueryCommands.Order.GetCloudOrderNotes);
                if (resultOrderNotes != null && resultOrderNotes.AffectedRows > 0)
                {
                    OrderNoteUpdate orderNoteUpdate = new OrderNoteUpdate();
                    OrderNoteJSONParam orderNoteListJson = new OrderNoteJSONParam();

                    orderNoteUpdate.OderNoteList = ServiceUtility.EncodeObjects(resultOrderNotes.Source);
                    orderNoteListJson.orderNoteUpdate = orderNoteUpdate;

                    dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(orderNoteListJson));

                    var ascendResult = dataHandler.Fetch(QueryCommands.Order.UpdateOrderNoteToClient);
                    var procResult = ascendResult.Source;

                    if (procResult.StatusNew.ToLower() == ApplicationConstants.Success)
                    {
                        MarineSyncFlagUpdate marineSyncFlagUpdate = new MarineSyncFlagUpdate();
                        JsonMarineSyncFlagUpdate jsonMarineSyncFlagUpdate = new JsonMarineSyncFlagUpdate();

                        marineSyncFlagUpdate.marineSyncFlagUpdate = (from i in orderNoteUpdate.OderNoteList
                                                                     select new MarineSyncFlag { ID = i.NoteID }).ToList();
                        jsonMarineSyncFlagUpdate.marineSyncFlag = marineSyncFlagUpdate;

                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                        dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(jsonMarineSyncFlagUpdate));
                        var syncResult = dataHandler.Fetch(QueryCommands.Order.UpdateCloudOrderNoteSyncFlag);
                        var syncProcResult = syncResult.Source;
                        if (syncProcResult.StatusNew.ToLower() != ApplicationConstants.Success)
                        {
                            logging.WriteErrorLog($"UpdateOrderNotesToClient - {syncProcResult.Reason}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateOrderNotesToClient", ex.Message));
            }
        }

        public void UpdateOrderStatus(char type)
        {
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                dataHandler.AddParameter(Parameters.CommonParameters.DocType, type);
                Result resultOrderNotes = dataHandler.Fetch<OrderStatusHistory, QueryCommands.Order>(QueryCommands.Order.GetOrderStatusHistory);

                List<OrderStatusHistory> lstOrderStatusHistory = resultOrderNotes.Source;

                if (resultOrderNotes != null && resultOrderNotes.AffectedRows > 0)
                {
                    for (int i = 0; i < lstOrderStatusHistory.Count; i++)
                    {
                        try
                        {
                            dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                            dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstOrderStatusHistory[i].SysTrxNo);
                            dataHandler.AddParameter(Parameters.CommonParameters.StatusCode, lstOrderStatusHistory[i].OrderStatusID);
                            Result resultUpdateOrderStatus = dataHandler.Update(QueryCommands.Order.UpdateLoadStatus);

                            if (resultUpdateOrderStatus.Success)
                            {
                                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                                dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstOrderStatusHistory[i].SysTrxNo);
                                dataHandler.AddParameter(Parameters.CommonParameters.OrderStatusID, lstOrderStatusHistory[i].OrderStatusID);
                                Result resultSyncOrderStatus = dataHandler.Update(QueryCommands.Order.UpdateOrderStatusHistoryNeedUpdateFlag);
                            }
                            else
                            {
                                logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateOrderStatus", resultUpdateOrderStatus.Message));
                            }

                        }
                        catch (Exception exception)
                        {
                            logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateOrderStatus", exception.Message));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "UpdateOrderStatus", ex.Message));
            }
        }

        public void UpdateShipments()
        {
            try
            {
                UpdateOrders();
                UpdateOrderStatus('L');

                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                dataHandler.AddParameter(Parameters.CommonParameters.RetryCount, ConfigurationManager.AppSettings["RetryCount"]);
                Result resultShipDoc = dataHandler.Fetch<ShipDoc, QueryCommands.Shipment>(QueryCommands.Shipment.GetShipDoc);
                List<ShipDoc> lstShipDocHdr = ServiceUtility.EncodeObjects(resultShipDoc.Source);

                dataHandler.AddParameter(Parameters.CommonParameters.RetryCount, ConfigurationManager.AppSettings["RetryCount"]);
                Result resultShipDocItem = dataHandler.Fetch<ShipDocItem, QueryCommands.Shipment>(QueryCommands.Shipment.GetShipDocItem);
                List<ShipDocItem> lstShipDocItem = ServiceUtility.EncodeObjects(resultShipDocItem.Source);

                dataHandler.AddParameter(Parameters.CommonParameters.RetryCount, ConfigurationManager.AppSettings["RetryCount"]);
                Result resultShipDocItemComp = dataHandler.Fetch<ShipDocItemComp, QueryCommands.Shipment>(QueryCommands.Shipment.GetShipDocItemComp);
                List<ShipDocItemComp> lstShipDocItemComp = ServiceUtility.EncodeObjects(resultShipDocItemComp.Source);

                Result resultShipDocItemReading = dataHandler.Fetch<ShipDocItemReading, QueryCommands.Shipment>(QueryCommands.Shipment.GetShipDocItemReading);
                List<ShipDocItemReading> lstShipDocItemReading = ServiceUtility.EncodeObjects(resultShipDocItemReading.Source);

                Result resultShipDocItemReadingDetails = dataHandler.Fetch<ShipDocItemReadingDtl, QueryCommands.Shipment>(QueryCommands.Shipment.GetShipDocItemReadingDetail);
                List<ShipDocItemReadingDtl> lstShipDocItemReadingDtl = ServiceUtility.EncodeObjects(resultShipDocItemReadingDetails.Source);

                Result resultShipmentLoad = dataHandler.Fetch<MarineShipment, QueryCommands.Shipment>(QueryCommands.Shipment.GetShipmentDetails);
                List<MarineShipment> lstMarineShipment = ServiceUtility.EncodeObjects(resultShipmentLoad.Source);

                Result resultShipmentLoadDetails = dataHandler.Fetch<MarineShipmentDetail, QueryCommands.Shipment>(QueryCommands.Shipment.GetShipmentLoadDetails);
                List<MarineShipmentDetail> lstMarineShipmentDetails = ServiceUtility.EncodeObjects(resultShipmentLoadDetails.Source);

                if (lstShipDocHdr.Count > 0)
                {
                    for (int i = 0; i < lstShipDocHdr.Count; i++)
                    {
                        try
                        {
                            int cloudOrderItemCount = GetCloudOrderItemCount(lstShipDocHdr[i].SysTrxNo);
                            int clientOrderItemCount = GetClientOrderItemCount(lstShipDocHdr[i].SysTrxNo);
                            int shipDocItemCount = lstShipDocItem.Where(item => item.SysTrxNo.Equals(lstShipDocHdr[i].SysTrxNo)).Count();

                            if (shipDocItemCount == cloudOrderItemCount && cloudOrderItemCount == clientOrderItemCount)
                            {
                                ShipmentJSONParam JsonParamValue = new ShipmentJSONParam();
                                JsonParamValue.ShipDocList.Add(lstShipDocHdr[i]);
                                JsonParamValue.MarineShipmentList = lstMarineShipment.Where(item => item.OrderSysTrxNo.Equals(lstShipDocHdr[i].SysTrxNo)).ToList();
                                JsonParamValue.MarineShipmentDetailList = lstMarineShipmentDetails.Where(item => item.SysTrxNo.Equals(lstShipDocHdr[i].SysTrxNo)).ToList();
                                JsonParamValue.ShipDocItemList = lstShipDocItem.Where(item => item.SysTrxNo.Equals(lstShipDocHdr[i].SysTrxNo)).ToList();


                                JsonParamValue.ShipDocItemCompList = lstShipDocItemComp.Where(item => item.SysTrxNo.Equals(lstShipDocHdr[i].SysTrxNo)).ToList();
                                List<ShipDocItemReading> lstFilteredShipDocItemReading = lstShipDocItemReading.Where(item => item.SysTrxNo.Equals(lstShipDocHdr[i].SysTrxNo)).ToList();
                                JsonParamValue.ShipDocItemReadingList = lstFilteredShipDocItemReading;

                                JsonParamValue.ShipDocItemReadingDtlList = (from sird in lstShipDocItemReadingDtl
                                                                            where lstFilteredShipDocItemReading.Select(x => x.ReadingID).Contains(sird.ReadingID)
                                                                            select sird).ToList();

                                Shipments ShipmentList = new Shipments();
                                ShipmentList.ShipmentList = JsonParamValue;

                                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                                dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(ShipmentList));

                                Result resultUpdateShipment = dataHandler.Fetch(QueryCommands.Shipment.UpdateShipmentDetails);
                                var resultStatus = resultUpdateShipment.Source;
                                if (resultStatus.StatusNew.ToLower() == ApplicationConstants.Success)
                                {
                                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                                    dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstShipDocHdr[i].SysTrxNo);
                                    var resultStatusSyncFlag = dataHandler.Update(QueryCommands.Shipment.UpdateShipmentDetailsNeedUpdateFlag);
                                    if (JsonParamValue.ShipDocItemReadingList.Count > 0)
                                    {
                                        dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstShipDocHdr[i].SysTrxNo);
                                        var resultStatusReadingSyncFlag = dataHandler.Update(QueryCommands.Shipment.UpdateShipmentReadingDetailsNeedUpdateFlag);
                                    }
                                }
                                else
                                {
                                    logging.WriteErrorLog($"UpdateShipments - {lstShipDocHdr[i].SysTrxNo} - {  resultStatus.Reason }");
                                    dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(ShipmentList));

                                    Result resultUpdateShipmentReview = dataHandler.Fetch(QueryCommands.Shipment.UpdateShipmentDetailsReview);
                                    var resultReviewStatus = resultUpdateShipmentReview.Source;

                                    if (resultStatus.StatusNew.ToLower() == ApplicationConstants.Success)
                                    {

                                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                                        dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstShipDocHdr[i].SysTrxNo);
                                        var resultStatusSyncFlag = dataHandler.Update(QueryCommands.Shipment.UpdateShipmentDetailsNeedUpdateFlag);

                                    }
                                    else
                                    {
                                        UpdateShipmentRetryCount(lstShipDocHdr[i].SysTrxNo);
                                    }
                                }
                            }
                            else
                            {
                                UpdateShipmentRetryCount(lstShipDocHdr[i].SysTrxNo);
                            }

                        }
                        catch (System.Data.SqlClient.SqlException sqlEx)
                        {
                            logging.WriteErrorLog(string.Format("Error in UpdateShipments -OrderNO - {0} , ErrorMessage - {1} ", lstShipDocHdr[i].BOLNo, sqlEx.Message.ToString()));
                            UpdateShipmentRetryCount(lstShipDocHdr[i].SysTrxNo);
                        }
                        catch (Exception exception)
                        {
                            logging.WriteErrorLog(string.Format("Error in UpdateShipments -OrderNO - {0} , ErrorMessage - {1} ", lstShipDocHdr[i].BOLNo, exception.Message.ToString()));
                            UpdateShipmentRetryCount(lstShipDocHdr[i].SysTrxNo);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("Error in UpdateShipments - {0}", ex.Message.ToString()));
            }
        }

        public void UpdateDeliveryDetails()
        {
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;

                dataHandler.AddParameter(Parameters.CommonParameters.RetryCount, ConfigurationManager.AppSettings["RetryCount"]);
                Result resultShipDoc = dataHandler.Fetch<ShipDoc, QueryCommands.Shipment>(QueryCommands.Shipment.GetDeliveryShipDoc);
                List<ShipDoc> lstShipDocHdr = ServiceUtility.EncodeObjects(resultShipDoc.Source);

                dataHandler.AddParameter(Parameters.CommonParameters.RetryCount, ConfigurationManager.AppSettings["RetryCount"]);
                Result resultShipDocItem = dataHandler.Fetch<ShipDocItem, QueryCommands.Shipment>(QueryCommands.Shipment.GetDeliveryDocItem);

                List<ShipDocItem> lstShipDocItem = ServiceUtility.EncodeObjects(resultShipDocItem.Source);

                dataHandler.AddParameter(Parameters.CommonParameters.RetryCount, ConfigurationManager.AppSettings["RetryCount"]);
                Result resultShipDocItemComp = dataHandler.Fetch<ShipDocItemComp, QueryCommands.Shipment>(QueryCommands.Shipment.GetDeliveryDocItemComp);
                List<ShipDocItemComp> lstShipDocItemComp = ServiceUtility.EncodeObjects(resultShipDocItemComp.Source);

                Result resultShipDocItemReading = dataHandler.Fetch<ShipDocItemReading, QueryCommands.Shipment>(QueryCommands.Shipment.GetDeliveryDocItemReading);
                List<ShipDocItemReading> lstShipDocItemReading = ServiceUtility.EncodeObjects(resultShipDocItemReading.Source);

                Result resultShipDocItemReadingDetails = dataHandler.Fetch<ShipDocItemReadingDtl, QueryCommands.Shipment>(QueryCommands.Shipment.GetDeliveryDocItemReadingDtl);
                List<ShipDocItemReadingDtl> lstShipDocItemReadingDtl = ServiceUtility.EncodeObjects(resultShipDocItemReadingDetails.Source);

                Result resultShipmentLoad = dataHandler.Fetch<MarineShipment, QueryCommands.Shipment>(QueryCommands.Shipment.GetDelivery);
                List<MarineShipment> lstMarineShipment = ServiceUtility.EncodeObjects(resultShipmentLoad.Source);

                Result resultShipmentLoadDetails = dataHandler.Fetch<MarineShipmentDetail, QueryCommands.Shipment>(QueryCommands.Shipment.GetDeliveryDetail);
                List<MarineShipmentDetail> lstMarineShipmentDetails = ServiceUtility.EncodeObjects(resultShipmentLoadDetails.Source);

                Result resultShipDocItemVessel = dataHandler.Fetch<ShipDocItemVessel, QueryCommands.Shipment>(QueryCommands.Shipment.GetShipDocItemVessel);
                List<ShipDocItemVessel> lstShipDocItemVessel = ServiceUtility.EncodeObjects(resultShipDocItemVessel.Source);

                if (lstShipDocHdr.Count > 0)
                {
                    for (int i = 0; i < lstShipDocHdr.Count; i++)
                    {
                        try
                        {
                            int cloudOrderItemCount = GetCloudOrderItemCount(lstShipDocHdr[i].SysTrxNo);
                            int clientOrderItemCount = GetClientOrderItemCount(lstShipDocHdr[i].SysTrxNo);
                            int shipDocItemCount = lstShipDocItem.Where(item => item.SysTrxNo.Equals(lstShipDocHdr[i].SysTrxNo)).Count();

                            if (shipDocItemCount == cloudOrderItemCount && cloudOrderItemCount == clientOrderItemCount)
                            {
                                ShipmentJSONParam JsonParamValue = new ShipmentJSONParam();
                                JsonParamValue.ShipDocList.Add(lstShipDocHdr[i]);
                                JsonParamValue.MarineShipmentList = lstMarineShipment.Where(item => item.OrderSysTrxNo.Equals(lstShipDocHdr[i].SysTrxNo)).ToList();
                                JsonParamValue.MarineShipmentDetailList = lstMarineShipmentDetails.Where(item => item.ShipSysTrxNo.Equals(lstShipDocHdr[i].SysTrxNo)).ToList();
                                JsonParamValue.MarineShipDocItemVesselList = lstShipDocItemVessel.Where(item => item.SysTrxNo.Equals(lstShipDocHdr[i].SysTrxNo)).ToList();
                                JsonParamValue.ShipDocItemList = lstShipDocItem.Where(item => item.SysTrxNo.Equals(lstShipDocHdr[i].SysTrxNo)).ToList();


                                JsonParamValue.ShipDocItemCompList = lstShipDocItemComp.Where(item => item.SysTrxNo.Equals(lstShipDocHdr[i].SysTrxNo)).ToList();
                                List<ShipDocItemReading> lstFilteredShipDocItemReading = lstShipDocItemReading.Where(item => item.SysTrxNo.Equals(lstShipDocHdr[i].SysTrxNo)).ToList();
                                JsonParamValue.ShipDocItemReadingList = lstFilteredShipDocItemReading;

                                JsonParamValue.ShipDocItemReadingDtlList = (from sird in lstShipDocItemReadingDtl
                                                                            where lstFilteredShipDocItemReading.Select(x => x.ReadingID).Contains(sird.ReadingID)
                                                                            select sird).ToList();

                                Shipments ShipmentList = new Shipments();
                                ShipmentList.ShipmentList = JsonParamValue;

                                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                                dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(ShipmentList));

                                Result resultUpdateDelivery = dataHandler.Fetch(QueryCommands.Shipment.UpdateDeliveryDetails);
                                var resultStatus = resultUpdateDelivery.Source;
                                if (resultStatus.StatusNew.ToLower() == ApplicationConstants.Success)
                                {
                                    dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                                    dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstShipDocHdr[i].SysTrxNo);
                                    var resultStatusSyncFlag = dataHandler.Update(QueryCommands.Shipment.UpdateDeliveryDetailsNeedUpdateFlag);


                                    dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                                    dataHandler.AddParameter(Parameters.CommonParameters.DocNo, lstShipDocHdr[i].DocNo);
                                    var resultDeliveryLineUpdate = dataHandler.Update(QueryCommands.Shipment.UpdateDeliveryDetailsLineUpdateFlag);

                                    if (JsonParamValue.ShipDocItemReadingList.Count > 0)
                                    {
                                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                                        dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstShipDocHdr[i].SysTrxNo);
                                        var resultStatusReadingSyncFlag = dataHandler.Update(QueryCommands.Shipment.UpdateDeliveryReadingDetailsNeedUpdateFlag);
                                    }
                                }
                                else
                                {
                                    logging.WriteErrorLog($"UpdateDeliveryDetails - {lstShipDocHdr[i].SysTrxNo} - {  resultStatus.Reason }");
                                    dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                                    dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(ShipmentList));

                                    Result resultUpdateShipmentReview = dataHandler.Fetch(QueryCommands.Shipment.UpdateDeliveryDetailsReview);
                                    var resultReviewStatus = resultUpdateShipmentReview.Source;

                                    if (resultStatus.StatusNew.ToLower() == ApplicationConstants.Success)
                                    {

                                        dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                                        dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, lstShipDocHdr[i].SysTrxNo);
                                        var resultStatusSyncFlag = dataHandler.Update(QueryCommands.Shipment.UpdateDeliveryDetailsNeedUpdateFlag);

                                    }
                                    else
                                    {
                                        UpdateDeliveryRetryCount(lstShipDocHdr[i].SysTrxNo);
                                    }
                                }
                            }
                            else
                            {
                                UpdateDeliveryRetryCount(lstShipDocHdr[i].SysTrxNo);
                            }

                        }
                        catch (System.Data.SqlClient.SqlException sqlEx)
                        {
                            logging.WriteErrorLog(string.Format("Error in UpdateDeliveryDetails -OrderNO - {0} , ErrorMessage - {1} ", lstShipDocHdr[i].BOLNo, sqlEx.Message.ToString()));
                            UpdateDeliveryRetryCount(lstShipDocHdr[i].SysTrxNo);
                        }
                        catch (Exception exception)
                        {
                            logging.WriteErrorLog(string.Format("Error in UpdateDeliveryDetails -OrderNO - {0} , ErrorMessage - {1} ", lstShipDocHdr[i].BOLNo, exception.Message.ToString()));
                            UpdateDeliveryRetryCount(lstShipDocHdr[i].SysTrxNo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("Error in UpdateDeliveryDetails - {0}", ex.Message.ToString()));
            }
        }


        public void UpdateMeterTicket()
        {
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                Result resultMeterTicket = dataHandler.Fetch<GetMeterTicket, QueryCommands.Shipment>(QueryCommands.Shipment.GetMeterTicket);
                List<GetMeterTicket> lstGetMeterTicket = ServiceUtility.EncodeObjects(resultMeterTicket.Source);

                List<MeterTicket> lstMeterTicket = (from mt in lstGetMeterTicket
                                                    select (new MeterTicket
                                                    {
                                                        CompanyID = mt.CompanyID,
                                                        OrderNo = mt.OrderNo,
                                                        CreatedDate = mt.CreatedDate,
                                                        DeviceTime = mt.DeviceTime,
                                                        FileName = mt.FileName,
                                                        ID = mt.ID,
                                                        CustomerID = mt.CustomerID,
                                                        NeedUpdate = mt.NeedUpdate,
                                                        MeterImage = mt.MeterImage.ToUTFString(),
                                                        SysTrxNo = mt.SysTrxNo,
                                                        SysTrxLineNo = mt.SysTrxLineNo,
                                                        EndMeter = mt.EndMeter,
                                                        File = mt.File,
                                                        Quantity = mt.Quantity,
                                                        StartMeter = mt.StartMeter,
                                                        Vessel = mt.Vessel
                                                    })).ToList();


                if (lstMeterTicket.Count > 0)
                {
                    try
                    {
                        for (int i = 0; i < lstMeterTicket.Count; i++)
                        {
                            MeterTicketJSONParam JsonParamValue = new MeterTicketJSONParam();
                            MeterTicketUpdate MeterTicketUpdate = new MeterTicketUpdate();


                            MeterTicketUpdate.MeterTicketUpdateList.Add(lstMeterTicket[i]);
                            JsonParamValue.MeterTicketGetToUpdate = MeterTicketUpdate;

                            dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                            dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                            Result resutlMeterTicket = dataHandler.Fetch(QueryCommands.Shipment.UpdateMeterTicker);
                            var status = resutlMeterTicket.Source;
                            if (status.StatusNew.ToLower() == ApplicationConstants.Success)
                            {
                                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                                dataHandler.AddParameter(Parameters.CommonParameters.ID, lstMeterTicket[i].ID);
                                var resultSyncMeterTicket = dataHandler.Update(QueryCommands.Shipment.UpdateNeedUpdateMeterTicket);
                            }
                            else
                            {
                                logging.WriteErrorLog($"UpdateMeterTicket - {lstMeterTicket[i].ID} - {status.Reason}");
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        logging.WriteErrorLog($"UpdateMeterTicket - {exception.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateMeterTicket - {ex.Message}");
            }
        }

        public void UpdateDOI()
        {
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                Result resultDOI = dataHandler.Fetch<DOIGet, QueryCommands.Shipment>(QueryCommands.Shipment.GetDOI);
                List<DOIGet> lstGetDOI = ServiceUtility.EncodeObjects(resultDOI.Source);

                List<DOIGetToUpdate> lstDOI = (from d in lstGetDOI
                                               select (new DOIGetToUpdate
                                               {
                                                   CompanyID = d.CompanyID,
                                                   File = d.File,
                                                   DOIImage = d.DOIImage.ToUTFString(),
                                                   DOIType = d.DOIType,
                                                   FileName = d.FileName,
                                                   ID = d.ID,
                                                   NeedUpdate = d.NeedUpdate,
                                                   OrderItemID = d.OrderItemID,
                                                   OrderNO = d.OrderNO,
                                                   UserID = d.UserID
                                               })).ToList();

                if (lstDOI.Count > 0)
                {
                    for (int i = 0; i < lstDOI.Count; i++)
                    {
                        try
                        {
                            DOIUpdateJSONParam JsonParamValue = new DOIUpdateJSONParam();
                            DOIUpdate Doiupdate = new DOIUpdate();

                            Doiupdate.DOIUpdateList.Add(lstDOI[i]);
                            JsonParamValue.DOIGetToUpdate = Doiupdate;

                            dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                            dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                            Result resultDOIStatus = dataHandler.Fetch(QueryCommands.Shipment.UpdateDOI);
                            var status = resultDOIStatus.Source;
                            if (status.StatusNew.ToLower() == ApplicationConstants.Success)
                            {
                                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                                dataHandler.AddParameter(Parameters.CommonParameters.ID, lstDOI[i].ID);
                                var resultSyncMeterTicket = dataHandler.Update(QueryCommands.Shipment.UpdateDOINeedUpdate);
                            }
                            else
                            {
                                logging.WriteErrorLog($"UpdateDOI - {lstDOI[i].ID} - {status.Reason}");
                            }
                        }
                        catch (Exception exception)
                        {
                            logging.WriteErrorLog($"UpdateDOI - {exception.Message}");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateDOI - {ex.Message}");
            }
        }

        public void UpdateDeliveryTicket()
        {
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                Result resultDeliveryTicket = dataHandler.Fetch<GetDeliveryTicket, QueryCommands.Shipment>(QueryCommands.Shipment.GetDeliveryTicket);
                List<GetDeliveryTicket> lstGetDeliveryTicket = ServiceUtility.EncodeObjects(resultDeliveryTicket.Source);
                List<DeliveryTicket> lstDeliveryTicket = (from dt in lstGetDeliveryTicket
                                                          select (new DeliveryTicket
                                                          {
                                                              CompanyID = dt.CompanyID,
                                                              OrderNo = dt.OrderNo,
                                                              CreatedDate = dt.CreatedDate,
                                                              DeviceTime = dt.DeviceTime,
                                                              FileName = dt.FileName,
                                                              ID = dt.ID,
                                                              CustomerID = dt.CustomerID,
                                                              NeedUpdate = dt.NeedUpdate,
                                                              DeliveryImage = dt.DeliveryImage.ToUTFString(),
                                                          })).ToList();

                if (lstDeliveryTicket.Count > 0)
                {


                    for (int i = 0; i < lstDeliveryTicket.Count; i++)
                    {
                        try
                        {
                            DeliveryTicketJSONParam JsonParamValue = new DeliveryTicketJSONParam();
                            DeliveryTicketUpdate DeliveryTicket_Update = new DeliveryTicketUpdate();

                            DeliveryTicket_Update.DeliveryTicketUpdateList.Add(lstDeliveryTicket[i]);
                            JsonParamValue.DeliveryTicketGetToUpdate = DeliveryTicket_Update;

                            dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                            dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                            Result resutlDeliveryTicket = dataHandler.Fetch(QueryCommands.Shipment.UpdateDeliveryTicket);
                            var status = resutlDeliveryTicket.Source;
                            if (status.StatusNew.ToLower() == ApplicationConstants.Success)
                            {
                                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                                dataHandler.AddParameter(Parameters.CommonParameters.ID, lstDeliveryTicket[i].ID);
                                var resultSyncMeterTicket = dataHandler.Update(QueryCommands.Shipment.UpdateNeedUpdateDeliveryTicket);
                            }
                            else
                            {
                                logging.WriteErrorLog($"UpdateDeliveryTicket - {lstDeliveryTicket[i].ID} - {status.Reason}");
                            }
                        }
                        catch (Exception ex)
                        {
                            logging.WriteErrorLog($"UpdateDeliveryTicket - {lstDeliveryTicket[i].ID} - {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateDeliveryTicket - {ex.Message}");
            }
        }

        public void UpdateAttachment()
        {
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                Result resultAttachment = dataHandler.Fetch<GetAttachment, QueryCommands.Shipment>(QueryCommands.Shipment.GetAttachment);
                List<GetAttachment> lstGetAttachment = ServiceUtility.EncodeObjects(resultAttachment.Source);


                List<Attachment> lstAttachment = (from a in lstGetAttachment
                                                  select (new Attachment
                                                  {
                                                      ID = a.ID,
                                                      CreatedDate = a.CreatedDate,
                                                      CustomerID = a.CustomerID,
                                                      AttachmentFile = a.AttachmentFile.ToUTFString(),
                                                      AttachmentName = a.AttachmentName,
                                                      CompanyID = a.CompanyID,
                                                      DeviceTime = a.DeviceTime,
                                                      File = a.File,
                                                      FileName = a.FileName,
                                                      NeedUpdate = a.NeedUpdate,
                                                      OrderNo = a.OrderNo,
                                                      Status = a.Status,
                                                      SysTrxNo = a.SysTrxNo

                                                  })).ToList();

                if (lstAttachment.Count > 0)
                {

                    for (int i = 0; i < lstAttachment.Count; i++)
                    {
                        try
                        {
                            AttachmentJSONParam JsonParamValue = new AttachmentJSONParam();
                            AttachmentUpdate Attachment_Update = new AttachmentUpdate();

                            Attachment_Update.AttachmentUpdateList.Add(lstAttachment[i]);
                            JsonParamValue.AttachmentGetToUpdate = Attachment_Update;

                            dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                            dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                            Result resutlAttachment = dataHandler.Fetch(QueryCommands.Shipment.UpdateAttachment);
                            var status = resutlAttachment.Source;
                            if (status.StatusNew.ToLower() == ApplicationConstants.Success)
                            {
                                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                                dataHandler.AddParameter(Parameters.CommonParameters.ID, lstAttachment[i].ID);
                                var resultSyncMeterTicket = dataHandler.Update(QueryCommands.Shipment.UpdateNeedUpdateAttachment);
                            }
                            else
                            {
                                logging.WriteErrorLog($"UpdateAttachment - {lstAttachment[i].ID} - {status.Reason}");
                            }
                        }
                        catch (Exception ex)
                        {
                            logging.WriteErrorLog($"UpdateAttachment - {lstAttachment[i].ID} - {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateAttachment - {ex.Message}");
            }
        }

        public void UpdateDocMessage()
        {
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result resultDocMessage = dataHandler.Fetch<DocMessage, QueryCommands.Shipment>(QueryCommands.Shipment.GetDcoMessage);
                List<DocMessage> lstDocMessage = ServiceUtility.EncodeObjects(resultDocMessage.Source);

                if (lstDocMessage.Count > 0)
                {
                    for (int i = 0; i < lstDocMessage.Count; i++)
                    {
                        try
                        {
                            DocMessageJSONParam JsonParamValue = new DocMessageJSONParam();
                            DocMessageUpdate DocMsgUpdate = new DocMessageUpdate();

                            DocMsgUpdate.DocMessageUpdateList.Add(lstDocMessage[i]);
                            JsonParamValue.DocMessageGetToUpdate = DocMsgUpdate;

                            dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                            dataHandler.AddParameter(Parameters.parameter, ServiceUtility.ToJsonString(JsonParamValue));

                            Result resutlDocMessage = dataHandler.Fetch(QueryCommands.Shipment.UpdateDcoMessage);
                            var status = resutlDocMessage.Source;
                            if (status.StatusNew.ToLower() != ApplicationConstants.Success)
                            {
                                logging.WriteErrorLog($"UpdateDocMessage - {lstDocMessage[i].DocMessageID} - {status.Reason}");
                            }

                        }
                        catch (Exception ex)
                        {
                            logging.WriteErrorLog($"UpdateDocMessage - {lstDocMessage[i].DocMessageID} - {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateDocMessage - {ex.Message}");
            }
        }


        public void UpdateDocLogo()
        {
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                Result resultDocLog = dataHandler.Update(QueryCommands.Master.UpdateDocLogo);
                var status = resultDocLog.Source;
                if (status.StatusNew.ToLower() != ApplicationConstants.Success)
                {
                    logging.WriteErrorLog($"UpdateDocLogo - {status.Reason}");
                }
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog($"UpdateDocLogo - {ex.Message}");
            }
        }

        private Result UpdateShipmentRetryCount(int sysTrxNo)
        {
            dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
            dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, sysTrxNo);
            var resultStatusSyncFlag = dataHandler.Update(QueryCommands.Shipment.UpdateShipmentDetailsNeedUpdateFlag);
            return resultStatusSyncFlag;
        }

        private Result UpdateDeliveryRetryCount(int sysTrxNo)
        {
            dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
            dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, sysTrxNo);
            var resultStatusSyncFlag = dataHandler.Update(QueryCommands.Shipment.UpdateDeliveryRetryCount);
            return resultStatusSyncFlag;
        }


        private int GetCloudOrderItemCount(int systrxNo)
        {
            Result resultOrderItemCount = new Result();
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.MarineDelivery;
                dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, systrxNo);
                resultOrderItemCount = dataHandler.FetchScalar(QueryCommands.Shipment.GetCloudOrderItemCount);
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "GetCloudOrderItemCount", ex.Message));
            }
            return resultOrderItemCount.Scalar;
        }


        private int GetClientOrderItemCount(int systrxNo)
        {
            Result resultOrderItemCount = new Result();
            try
            {
                dataHandler.ConnectionStringName = ApplicationConstants.Ascend;
                dataHandler.AddParameter(Parameters.CommonParameters.SysTrxNo, systrxNo);
                resultOrderItemCount = dataHandler.FetchScalar(QueryCommands.Shipment.GetClientOrderItemCount);
            }
            catch (Exception ex)
            {
                logging.WriteErrorLog(string.Format("{0} - {1}", "GetCloudOrderItemCount", ex.Message));
            }
            return resultOrderItemCount.Scalar;
        }


    }
}
