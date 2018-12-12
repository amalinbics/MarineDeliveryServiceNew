using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class OrderJSONParam
    {
        public List<OrderHdr> OrderHdrList = new List<OrderHdr>();
        public List<OrderItem> OrderItemList = new List<OrderItem>();
        public List<OrderItemComponent> OrderItemComponentList = new List<OrderItemComponent>();
        public List<OrderNote> OrderNoteList = new List<OrderNote>();

    }
    
    public class param
    {
        public string name = string.Empty;
        public string param_type = string.Empty;
        public string value = string.Empty;
    }

    public class parameterList
    {
        public List<string> Params = new List<string>();
    }

    public class parameter
    {
        public string name = string.Empty;        
        public string value = string.Empty;
    }

    public class ParamList
    {
        public List<parameter> Params = new List<parameter>(); 
    }

    public class Orders
    {
        public OrderJSONParam OrderList = new OrderJSONParam();
    }
    public class ShipmentJSONParam
    {
        public List<ShipDoc> ShipDocList = new List<ShipDoc>();
        public List<ShipDocItem> ShipDocItemList = new List<ShipDocItem>();
        public List<ShipDocItemComp> ShipDocItemCompList = new List<ShipDocItemComp>();
        public List<ShipDocItemReading> ShipDocItemReadingList = new List<ShipDocItemReading>();
        public List<ShipDocItemReadingDtl> ShipDocItemReadingDtlList = new List<ShipDocItemReadingDtl>();
        public List<MarineShipment> MarineShipmentList = new List<MarineShipment>();
        public List<MarineShipmentDetail> MarineShipmentDetailList = new List<MarineShipmentDetail>();
        public List<ShipDocItemVessel> MarineShipDocItemVesselList = new List<ShipDocItemVessel>();
        
    }


    public class Shipments
    {
        public ShipmentJSONParam ShipmentList = new ShipmentJSONParam();
    }
    public class INSiteJSONParam
    {
        public INSites INSites = new INSites();
    }
    public class INSites
    {
        public List<INSite> INSiteList = new List<INSite>();
    }
    public class INSiteTankJSONParam
    {
        public INSiteTankDetails INSiteTank = new INSiteTankDetails();
    }
    public class INSiteTankDetails
    {
        public List<INSiteTank> INSiteTankList = new List<INSiteTank>();
    }
    public class INSiteTankProductJSONParam
    {
        public INSiteTankProductDetails INSiteTankProducts = new INSiteTankProductDetails();
    }
    public class INSiteTankProductDetails
    {
        public List<INSiteTankProducts> INSiteTankProductsList = new List<INSiteTankProducts>();
    }
    public class InSiteTankSubCompartmentsJSONParam
    {
        public InSiteTankSubCompartmentsDetails InSiteTankSubCompartments = new InSiteTankSubCompartmentsDetails();
    }
    public class InSiteTankSubCompartmentsDetails
    {
        public List<InSiteTankSubCompartments> InSiteTankSubCompartmentsList = new List<InSiteTankSubCompartments>();
    }
    public class INSiteTankProductAPIJSONParam
    {
        public INSiteTankProductAPIDetails INSiteTankProductsAPI = new INSiteTankProductAPIDetails();
    }
    public class INSiteTankProductAPIDetails
    {
        public List<INSiteTankProductAPI> INSiteTankProductsAPIList = new List<INSiteTankProductAPI>();
    }
    public class CompanyJSONParam
    {
        public CompanyDetails Companies = new CompanyDetails();
    }
    public class CompanyDetails
    {
        public List<Company> CompanyList = new List<Company>();
    }
    public class VehicleJSONParam
    {
        public VehicleDetails Vehicles = new VehicleDetails();
    }
    public class VehicleDetails
    {
        public List<Vehicle> VehicleList = new List<Vehicle>();
    }
    public class LoginUserJSONParam
    {
        public LoginUserDetails LoginUser = new LoginUserDetails();
    }
    public class LoginUserDetails
    {
        public List<LoginUser> LoginUserList = new List<LoginUser>();
    }
    public class DriversJSONParam
    {
        public DriversDetails Drivers = new DriversDetails();
    }
    public class DriversDetails
    {
        public List<Drivers> DriversList = new List<Drivers>();
    }
    public class VehicleCompartmentJSONParam
    {
        public VehicleCompartmentDetails VehicleCompartments = new VehicleCompartmentDetails();
    }
    public class VehicleCompartmentDetails
    {
        public List<VehicleCompartments> VehicleCompartmentList = new List<VehicleCompartments>();
    }
    public class VehicleSubCompartmentJSONParam
    {
        public VehicleSubCompartmentDetails VehicleSubCompartments = new VehicleSubCompartmentDetails();
    }
    public class VehicleSubCompartmentDetails
    {
        public List<VehicleSubCompartments> VehicleSubCompartmentList = new List<VehicleSubCompartments>();
    }
    public class CarrierJSONParam
    {
        public CarrierDetails Carriers = new CarrierDetails();
    }
    public class CarrierDetails
    {
        public List<Carrier> CarrierList = new List<Carrier>();
    }
    public class ARShipToJSONParam
    {
        public ARShipToDetails ARShipTo = new ARShipToDetails();
    }
    public class ARShipToDetails
    {
        public List<ARShipTo> ARShipToList = new List<ARShipTo>();
    }
    public class PersonJSONParam
    {
        public PersonDetails Person = new PersonDetails();
    }
    public class PersonDetails
    {
        public List<Person> PersonList = new List<Person>();
    }
    public class PersonPhoneJSONParam
    {
        public PersonPhoneDetails PersonPhone = new PersonPhoneDetails();
    }
    public class PersonPhoneDetails
    {
        public List<PersonPhone> PersonPhoneList = new List<PersonPhone>();
    }
    public class ProductsJSONParam
    {
        public ProductsDetails Product = new ProductsDetails();
    }
    public class ProductsDetails
    {
        public List<Products> ProductList = new List<Products>();
    }
    public class UOMTypeJSONParam
    {
        public UOMTypeDetails UOMType = new UOMTypeDetails();
    }
    public class UOMTypeDetails
    {
        public List<UOMType> UOMTypeList = new List<UOMType>();
    }
    public class UOMJSONParam
    {
        public UOMDetails UOM = new UOMDetails();
    }
    public class UOMDetails
    {
        public List<UOM> UOMList = new List<UOM>();
    }
    public class MarineLocTypeJSONParam
    {
        public MarineLocTypeDetails MarineLocType = new MarineLocTypeDetails();
    }
    public class MarineLocTypeDetails
    {
        public List<MarineLocType> MarineLocTypeList = new List<MarineLocType>();
    }
    public class MarineRegionJSONParam
    {
        public MarineRegionDetails MarineRegion = new MarineRegionDetails();
    }
    public class MarineRegionDetails
    {
        public List<MarineRegion> MarineRegionList = new List<MarineRegion>();
    }
    public class MarineLocJSONParam
    {
        public MarineLocDetails MarineLoc = new MarineLocDetails();
    }
    public class MarineLocDetails
    {
        public List<MarineLoc> MarineLocList = new List<MarineLoc>();
    }

    public class MarineAppSalesPLUButtonsJSONParam
    {
        public MarineAppSalesPLUButtonsDetails MarineAppSalesPLUButtons = new MarineAppSalesPLUButtonsDetails();
    }
    public class MarineAppSalesPLUButtonsDetails
    {
        public List<MarineAppSalesPLUButtons> MarineAppSalesPLUButtonsList = new List<MarineAppSalesPLUButtons>();
    }

    public class TankChartJSONParam
    {
        public TankChartDetails TankChart = new TankChartDetails();
    }
    public class TankChartDetails
    {
        public List<TankChart> TankChartList = new List<TankChart>();
    }

    public class TankChartDetailsJSONParam
    {
        public TankChartDetailDetails TankChartDetail = new TankChartDetailDetails();
    }
    public class TankChartDetailDetails
    {
        public List<TankChartDetail> TankChartDetailList = new List<TankChartDetail>();
    }
    public class TankChartKeelJSONParam
    {
        public TankChartKeelDetails TankChartKeel = new TankChartKeelDetails();
    }
    public class TankChartKeelDetails
    {
        public List<TankChartKeel> TankChartKeelList = new List<TankChartKeel>();
    }
    public class TankChartTrimJSONParam
    {
        public TankChartTrimDetails TankChartTrim = new TankChartTrimDetails();
    }
    public class TankChartTrimDetails
    {
        public List<TankChartTrim> TankChartTrimList = new List<TankChartTrim>();
    }
    public class VesselJSONParam
    {
        public VesselDetails Vessel = new VesselDetails();
    }
    public class VesselDetails
    {
        public List<Vessel> VesselList = new List<Vessel>();
    }
    public class INSiteProdContJSONParam
    {
        public INSiteProdContDetails INSiteProdCont = new INSiteProdContDetails();
    }
    public class INSiteProdContDetails
    {
        public List<INSiteProdCont> INSiteProdContList = new List<INSiteProdCont>();
    }
    public class ProdContJSONParam
    {
        public ProdContUpdate ProdConts = new ProdContUpdate();
    }
    public class ProdContUpdate
    {
        public List<ProdCont> ProdContList = new List<ProdCont>();
    }
    public class SubProdContJSONParam
    {
        public SubProdContDetails SubProdConts = new SubProdContDetails();
    }
    public class SubProdContDetails
    {
        public List<Substitutes> SubProdContList = new List<Substitutes>();
    }
    public class INSiteBillingItemJSONParam
    {
        public INSiteBillingItemDetails INSiteBillingItem = new INSiteBillingItemDetails();
    }
    public class INSiteBillingItemDetails
    {
        public List<INSiteBillingItem> INSiteBillingItemList = new List<INSiteBillingItem>();
    }
    public class DOIUpdateJSONParam
    {
        public DOIUpdate DOIGetToUpdate = new DOIUpdate();
    }
    public class DOIUpdate
    {
        public List<DOIGetToUpdate> DOIUpdateList = new List<DOIGetToUpdate>();
    }
    public class DeliveryTicketJSONParam
    {
        public DeliveryTicketUpdate DeliveryTicketGetToUpdate = new DeliveryTicketUpdate();
    }
    public class DeliveryTicketUpdate
    {
        public List<DeliveryTicket> DeliveryTicketUpdateList = new List<DeliveryTicket>();
    }
    public class DocMessageJSONParam
    {
        public DocMessageUpdate DocMessageGetToUpdate = new DocMessageUpdate();
    }
    public class DocMessageUpdate
    {
        public List<DocMessage> DocMessageUpdateList = new List<DocMessage>();
    }
    public class MeterTicketJSONParam
    {
        public MeterTicketUpdate MeterTicketGetToUpdate = new MeterTicketUpdate();
    }
    public class MeterTicketUpdate
    {
        public List<MeterTicket> MeterTicketUpdateList = new List<MeterTicket>();
    }
    public class AttachmentJSONParam
    {
        public AttachmentUpdate AttachmentGetToUpdate = new AttachmentUpdate();
    }
    public class AttachmentUpdate
    {
        public List<Attachment> AttachmentUpdateList = new List<Attachment>();
    }
    public class TankTypeJSONParam
    {
        public TankTypeUpdate TankTypeGetToUpdate = new TankTypeUpdate();
    }
    public class TankTypeUpdate
    {
        public List<TankType> TankTypeUpdateList = new List<TankType>();
    }
    public class INSiteTankVolumeUpdate
    {
        public List<INSiteTankVolume> INSiteTankVolumeList = new List<INSiteTankVolume>();
        public List<INSiteTankVolumeDetails> INSiteTankVolumeDetailList = new List<INSiteTankVolumeDetails>();
    }
    public class INSiteTankVolumeJSONParam
    {
        public INSiteTankVolumeUpdate INSiteTankVolumeReading = new INSiteTankVolumeUpdate();
    }
    public class SyncDeletedTrxUpdate
    {
        public List<SyncDeletedTrx> SyncDeletedTrxList = new List<SyncDeletedTrx>();
    }
    public class SyncDeletedTrxJSONParam
    {
        public SyncDeletedTrxUpdate SyncDeletedTrx = new SyncDeletedTrxUpdate();
    }

    public class MarineSyncFlagUpdate
    {
        public List<MarineSyncFlag> marineSyncFlagUpdate = new List<MarineSyncFlag>();
    }

    public class JsonMarineSyncFlagUpdate
    {
        public MarineSyncFlagUpdate marineSyncFlag = new MarineSyncFlagUpdate();
    }

    public class INSiteBillingItemSyncFlagUpdate
    {
        public List<INSiteBillingItemSyncFlag> billingItemSyncFlagUpdate = new List<INSiteBillingItemSyncFlag>();
    }

    public class INSiteBillingItemSyncFlagUpdateJSONParam
    {
        public INSiteBillingItemSyncFlagUpdate billingItemSyncFlag = new INSiteBillingItemSyncFlagUpdate();
    }

    public class TankChartDetailSyncFlagUpdate
    {
        public List<TankChartDetailSyncFlag> tankChartDetailUpdate = new List<TankChartDetailSyncFlag>();
    }

    public class TankChartDetailSyncFlagUpdateJSONParam
    {
        TankChartDetailSyncFlagUpdate tankChartDetailSyncFlagUpdate = new TankChartDetailSyncFlagUpdate();
    }

    public class INSiteProdContSyncFlagUpdate
    {
        public List<INSiteProdContSyncFlag> inSiteProdContSyncFlagUpdate = new List<INSiteProdContSyncFlag>();
    }

    public class INSiteProdContSyncFlagUpdateJSONParam
    {
        public INSiteProdContSyncFlagUpdate inSiteProdContSyncFlag = new INSiteProdContSyncFlagUpdate();
    }

    public class SubstitutesSyncFlagUpdate
    {
        public List<SubstitutesSyncFlag> substitutesSyncFlagUpdate = new List<SubstitutesSyncFlag>();
    }

    public class SubstitutesSyncFlagJSONParam
    {
        public SubstitutesSyncFlagUpdate substitutesSyncFlag = new SubstitutesSyncFlagUpdate();
    }

    public class OrderNoteUpdate
    {
        public List<OrderNote> OderNoteList = new List<OrderNote>();
    }

    public class OrderNoteJSONParam
    {
       public OrderNoteUpdate orderNoteUpdate = new OrderNoteUpdate();
    }

    public class OrderAttachmentJSONParam
    {
        public List<OrderAttachment> OrderAttachmentList = new List<OrderAttachment>();
    }


}
