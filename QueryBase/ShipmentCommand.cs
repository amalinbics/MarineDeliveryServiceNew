using Utlity;
namespace QueryBase
{
    class ShipmentCommand : IQueryFetch
    {
        string Query = string.Empty;
        public string GetQuery<T>(T command)
        {
            if (command.Equals( QueryCommands.Shipment.GetShipDoc))
            {
                Query = "MN_GetShipDoc";
            }
            else if (command.Equals( QueryCommands.Shipment.GetShipDocItem))
            {
                Query = "MN_GetShipDocItem";
            }
            else if (command.Equals( QueryCommands.Shipment.GetShipDocItemComp))
            {
                Query = "MN_GetShipDocItemComp";
            }
            else if (command.Equals( QueryCommands.Shipment.GetShipDocItemReading))
            {
                Query = "MN_GetShipDocItemReading";
            }
            else if (command.Equals( QueryCommands.Shipment.GetShipDocItemReadingDetail))
            {
                Query = "MN_GetShipDocItemReadingDtl";
            }
            else if (command.Equals( QueryCommands.Shipment.GetShipmentDetails))
            {
                Query = "MN_GetShipmentLoad";
            }
            else if (command.Equals( QueryCommands.Shipment.GetShipmentLoadDetails))
            {
                Query = "MN_GetShipmentLoadDetail";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateShipmentDetails))
            {
                Query = "MN_UpdateShipmentDetails";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateShipmentDetailsReview))
            {
                Query = "MN_UpdateShipmentDetailsReview";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateShipmentReadingDetailsNeedUpdateFlag))
            {
                Query = "MN_UpdateShipmentReadingDetailsNeedUpdateFlag";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateShipmentDetailsNeedUpdateFlag))
            {
                Query = "MN_UpdateShipmentDetailsNeedUpdateFlag";
            }
            else if (command.Equals( QueryCommands.Shipment.GetShipDocItemVessel))
            {
                Query = "MN_GetShipDocItemVessel";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateDeliveryDetails))
            {
                Query = "MN_UpdateDeliveryDetails";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateDeliveryDetailsNeedUpdateFlag))
            {
                Query = "MN_UpdateDeliveryDetailsNeedUpdateFlag";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateDeliveryDetailsLineUpdateFlag))
            {
                Query = "MN_UpdateShipDocItemLine";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateDeliveryReadingDetailsNeedUpdateFlag))
            {
                Query = "MN_UpdateDeliveryReadingDetailsNeedUpdateFlag";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateDeliveryDetailsReview))
            {
                Query = "MN_UpdateDeliveryDetailsReview";
            }
            else if (command.Equals( QueryCommands.Shipment.GetMeterTicket))
            {
                Query = "MN_GetMeterTicket";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateMeterTicker))
            {
                Query = "MN_UpdateMeterTicket";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateNeedUpdateMeterTicket))
            {
                Query = "MN_NeedUpdateFlagMeterTicket";
            }

            else if (command.Equals( QueryCommands.Shipment.GetDOI))
            {
                Query = "MN_GetDOIUpdate";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateDOI))
            {
                Query = "MN_UpdateDOI";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateDOINeedUpdate))
            {
                Query = "MN_NeedUpdateFlagDOI";
            }
            else if (command.Equals( QueryCommands.Shipment.GetDeliveryTicket))
            {
                Query = "MN_GetDeliveryTicketUpdate";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateDeliveryTicket))
            {
                Query = "MN_UpdateDeliveryTicket";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateNeedUpdateDeliveryTicket))
            {
                Query = "MN_NeedUpdateFlagDeliveryTicket";
            }

            else if (command.Equals( QueryCommands.Shipment.GetAttachment))
            {
                Query = "MN_GetAttachment";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateAttachment))
            {
                Query = "MN_UpdateAttachment";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateNeedUpdateAttachment))
            {
                Query = "MN_NeedUpdateFlagAttachment";
            }

            else if (command.Equals( QueryCommands.Shipment.GetDcoMessage))
            {
                Query = "MN_GetDocMessage";
            }
            else if (command.Equals( QueryCommands.Shipment.UpdateDcoMessage))
            {
                Query = "MN_UpdateDocMessage";
            }


            else if (command.Equals( QueryCommands.Shipment.GetDeliveryShipDoc))
            {
                Query = "MN_GetDeliveryDoc";
            }
            else if (command.Equals( QueryCommands.Shipment.GetDeliveryDocItem))
            {
                Query = "MN_GetDeliveryDocItem";
            }
            else if (command.Equals( QueryCommands.Shipment.GetDeliveryDocItemComp))
            {
                Query = "MN_GetDeliveryDocItemComp";
            }
            else if (command.Equals( QueryCommands.Shipment.GetDeliveryDocItemReading))
            {
                Query = "MN_GetDeliveryDocItemReading";
            }
            else if (command.Equals( QueryCommands.Shipment.GetDeliveryDocItemReadingDtl))
            {
                Query = "MN_GetDeliveryDocItemReadingDtl";
            }
            else if (command.Equals( QueryCommands.Shipment.GetDelivery))
            {
                Query = "MN_GetDelivery";
            }
            else if (command.Equals( QueryCommands.Shipment.GetDeliveryDetail))
            {
                Query = "MN_GetDeliveryDetail";
            }
            else if (command.Equals(QueryCommands.Shipment.GetCloudOrderItemCount))
            {
                Query = "MN_GetOrderItemCount";
            }
            else if (command.Equals(QueryCommands.Shipment.GetClientOrderItemCount))
            {
                Query = "MN_GetOrderItemCount";
            }
            else if (command.Equals(QueryCommands.Shipment.UpdateShipmentRetryCount))
            {
                Query = "MN_UpdateShipmentRetryCount";
            }
            else if (command.Equals(QueryCommands.Shipment.UpdateDeliveryRetryCount))
            {
                Query = "MN_UpdateDeliveryRetryCount";
            }

            return Query;
        }
    }
}
