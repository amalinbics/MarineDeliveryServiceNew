using Utlity;
namespace QueryBase
{
    public class OrderCommand : IQueryFetch
    {
        string Query = string.Empty;
        public string GetQuery<T>(T command)
        {
            if (command.Equals(QueryCommands.Order.GetOrderHdr))
            {
                Query = "MN_GetOrderHdr";
            }
            else if (command.Equals(QueryCommands.Order.GetOrderItem))
            {
                Query = "MN_GetOrderItem";
            }
            else if (command.Equals(QueryCommands.Order.GetOrderItemComponent))
            {
                Query = "MN_GetOrderItemComponent";
            }
            else if (command.Equals(QueryCommands.Order.GetOrderNotes))
            {
                Query = "MN_GetOrderNotes";
            }
            else if (command.Equals(QueryCommands.Order.UpdateOrderDetails))
            {
                Query = "MN_UpdateOrderDetails";
            }
            else if (command.Equals(QueryCommands.Order.UpdateOrderDetailsNeedUpdateFlag))
            {
                Query = "MN_UpdateOrderDetailsNeedUpdateFlag";
            }

            else if (command.Equals(QueryCommands.Order.UpdateOrderDetailsNeedUpdateFlag))
            {
                Query = "MN_UpdateOrderDetailsNeedUpdateFlag";
            }

            else if (command.Equals(QueryCommands.Order.GetClientOrderHdr))
            {
                Query = "MN_GetClientOrderHdr";
            }
            else if (command.Equals(QueryCommands.Order.GetClientOrderItem))
            {
                Query = "MN_GetClientOrderItem";
            }
            else if (command.Equals(QueryCommands.Order.GetClientOrderItemComponent))
            {
                Query = "MN_GetClientOrderItemComponent";
            }
            else if (command.Equals(QueryCommands.Order.GetClientOrderNote))
            {
                Query = "MN_GetClientOrderNote";
            }
            else if (command.Equals(QueryCommands.Order.UpdateClientOrderDetails))
            {
                Query = "MN_UpdateClientOrderDetails";
            }
            else if (command.Equals(QueryCommands.Order.UpdateLoadStatus))
            {
                Query = "MN_UpdateLoadStatus";
            }
            else if (command.Equals(QueryCommands.Order.GetOrderStatusHistory))
            {
                Query = "MN_GetOrderStatusToUpdate";
            }
            else if (command.Equals(QueryCommands.Order.UpdateOrderStatusHistoryNeedUpdateFlag))
            {
                Query = "MN_UpdateOrderStatusNeedUpdateFlag";
            }
            else if (command.Equals(QueryCommands.Order.UpdateOrderRetryCount))
            {
                Query = "MN_UpdateOrderRetryCount";
            }
            else if (command.Equals(QueryCommands.Order.UpdateOrderNotes))
            {
                Query = "MN_UpdateOrderNote";
            }
            else if (command.Equals(QueryCommands.Order.UpdateOrderNoteSyncFlag))
            {
                Query = "MN_UpdateOrderNoteSyncFlag";
            }
            else if (command.Equals(QueryCommands.Order.GetCloudOrderNotes))
            {
                Query = "MN_GetCloudOrderNotes";
            }
            else if (command.Equals(QueryCommands.Order.UpdateOrderNoteToClient))
            {
                Query = "MN_UpdateOrderNote";
            }
            else if (command.Equals(QueryCommands.Order.UpdateCloudOrderNoteSyncFlag))
            {
                Query = "MN_UpdateSyncFlagOrderNote"; //
            }

            return Query;
        }                         
    }
}
