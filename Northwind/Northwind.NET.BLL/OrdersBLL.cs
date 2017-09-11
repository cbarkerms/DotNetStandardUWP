using Northwind.NET.DAL.NorthwindDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static Northwind.NET.DAL.NorthwindDataSet;

namespace Northwind.NET.BLL
{
    public class OrdersBLL
    {
        private OrdersBLL() { }

        private static OrdersBLL current;

        public static OrdersBLL Current => current ?? (current = new OrdersBLL());

        private OrdersTableAdapter ordersTableAdapter;

        protected OrdersTableAdapter OrdersTableAdapter
        {
            get { return ordersTableAdapter ?? (ordersTableAdapter = new OrdersTableAdapter()); }
        }

        public OrdersDataTable GetOrders()
        {
            return OrdersTableAdapter.GetOrders();
        }

        public OrdersDataTable GetOrderByOrderId(int orderId)
        {
            return OrdersTableAdapter.GetOrderByOrderId(orderId);
        }

        public OrdersDataTable GetOrdersByCustomerId(string customerId)
        {
            return OrdersTableAdapter.GetOrdersByCustomerId(customerId);
        }

        public int AddOrder(string customerId,
                                DateTime orderDate,
                                DateTime requiredDate,
                                DateTime? shippedDate = null,
                                int? shipVia = null,
                                int? employeeId = null,
                                decimal? freight = null,
                                string shipName = null,
                                string shipAddress = null,
                                string shipCity = null,
                                string shipRegion = null,
                                string shipPostalCode = null)
        {
            var ordersDataTable = new OrdersDataTable();
            var ordersRow = ordersDataTable.NewOrdersRow();

            ordersRow.CustomerID = customerId;
            ordersRow.OrderDate = orderDate;
            ordersRow.RequiredDate = requiredDate;

            ordersRow.EmployeeID = employeeId.HasValue == true ? employeeId.Value : 1;
            ordersRow.ShippedDate = shippedDate.HasValue == true ? shippedDate.Value : DateTime.Today.AddMonths(1);

            if (shipVia == null) ordersRow.SetShipViaNull(); else ordersRow.ShipVia = shipVia.Value;
            if (freight == null) ordersRow.SetFreightNull(); else ordersRow.Freight = freight.Value;
            if (shipName == null) ordersRow.SetShipNameNull(); else ordersRow.ShipName = shipName;
            if (shipAddress == null) ordersRow.SetShipAddressNull(); else ordersRow.ShipAddress = shipAddress;
            if (shipCity == null) ordersRow.SetShipCityNull(); else ordersRow.ShipCity = shipCity;
            if (shipRegion == null) ordersRow.SetShipRegionNull(); else ordersRow.ShipRegion = shipRegion;
            if (shipPostalCode == null) ordersRow.SetShipPostalCodeNull(); else ordersRow.ShipPostalCode = shipPostalCode;

            ordersDataTable.AddOrdersRow(ordersRow);
            var rowsAffected = OrdersTableAdapter.Update(ordersDataTable);

            if (rowsAffected == 1)
            {
                return ordersRow.OrderID;
            }
            else
            {
                return -1;
            }
        }

        public bool DeleteOrder(int orderId)
        {
            OrderDetailsBLL.Current.DeleteOrderDetails(orderId);

            int rowsAffected = OrdersTableAdapter.DeleteOrder(orderId);

            return rowsAffected == 1;
        }
    }
}
