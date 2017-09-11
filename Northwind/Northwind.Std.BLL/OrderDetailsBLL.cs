using Northwind.NET.DAL.NorthwindDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static Northwind.NET.DAL.NorthwindDataSet;

namespace Northwind.NET.BLL
{
    public class OrderDetailsBLL
    {
        private OrderDetailsBLL() { }

        private static OrderDetailsBLL current;

        public static OrderDetailsBLL Current => current ?? (current = new OrderDetailsBLL());

        private Order_DetailsTableAdapter orderDetailsTableAdapter;

        protected Order_DetailsTableAdapter OrderDetailsTableAdapter
        {
            get { return orderDetailsTableAdapter ?? (orderDetailsTableAdapter = new Order_DetailsTableAdapter()); }
        }

        public Order_DetailsDataTable GetOrderDetails()
        {
            return OrderDetailsTableAdapter.GetOrderDetails();
        }

        public Order_DetailsDataTable GetOrderDetailsByOrderId(int orderId)
        {
            return OrderDetailsTableAdapter.GetOrderDetailsByOrderId(orderId);
        }

        public int AddOrderDetails(int orderId,
                                    int productId,
                                    decimal unitPrice,
                                    short quantity,
                                    float discount)
        {
            var orderDetailsDataTable = new Order_DetailsDataTable();
            var orderDetailsRow = orderDetailsDataTable.NewOrder_DetailsRow();

            orderDetailsRow.OrderID = orderId;
            orderDetailsRow.ProductID = productId;
            orderDetailsRow.UnitPrice = unitPrice;
            orderDetailsRow.Quantity = quantity;
            orderDetailsRow.Discount = discount;

            orderDetailsDataTable.AddOrder_DetailsRow(orderDetailsRow);
            var rowsAffected = OrderDetailsTableAdapter.Update(orderDetailsDataTable);

            if (rowsAffected == 1)
            {
                return orderDetailsRow.OrderID;
            }
            else
            {
                return -1;
            }
        }

        public bool DeleteOrderDetails(int orderId, int productId)
        {
            int rowsAffected = OrderDetailsTableAdapter.DeleteOrderDetails(orderId, productId);

            return rowsAffected == 1;
        }

        public bool DeleteOrderDetails(int orderId)
        {
            int rowsAffected = OrderDetailsTableAdapter.DeleteOrderDetailsByOrderId(orderId);

            return rowsAffected == 1;
        }
    }
}
