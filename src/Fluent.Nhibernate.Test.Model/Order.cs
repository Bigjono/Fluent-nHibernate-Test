using System;
using System.Collections.Generic;

namespace Fluent.Nhibernate.Test.Model
{
    public class Order
    {
        public virtual int Id { get; private set; }
            public virtual Customer Customer { get; set; }
            public virtual DateTime DateOfOrder { get; set; }

            public virtual IList<OrderItem> OrderItems { get; set; }


            public virtual void AddOrderItem(string productName, int qty, decimal itemPrice, DateTime? requiredBy)
            {
                var item = new OrderItem
                {
                    ProductName = productName,
                    Qty = qty,
                    ItemPrice = itemPrice,
                    RequiredBy = requiredBy

                };

                if (OrderItems == null) OrderItems = new List<OrderItem>();
                this.OrderItems.Add(item);
            }

    }
}
