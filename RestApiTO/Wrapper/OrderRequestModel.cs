using Newtonsoft.Json;
using RestApiTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiTO.Wrapper
{
    public class OrderRequestModel<T> : Order_items
    {
        public OrderRequestModel(T dataOrderItems, int OrderId, int ProductId, int Quantity)
        {
            Order_detail = dataOrderItems;
            this.OrderId = OrderId;
            this.ProductId = ProductId;
            this.Quantity = Quantity;
        }

        public int User_id { get; set; }
        public T Order_detail { get; set; }
    }
}
