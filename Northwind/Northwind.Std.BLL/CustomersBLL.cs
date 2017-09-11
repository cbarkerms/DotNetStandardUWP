using Northwind.NET.DAL.NorthwindDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static Northwind.NET.DAL.NorthwindDataSet;

namespace Northwind.NET.BLL
{
    public class CustomersBLL
    {
        private CustomersBLL() { }

        private static CustomersBLL current;

        public static CustomersBLL Current => current ?? (current = new CustomersBLL());
        
        private CustomersTableAdapter customersTableAdapter;

        protected CustomersTableAdapter CustomersTableAdapter
        {
            get { return customersTableAdapter ?? (customersTableAdapter = new CustomersTableAdapter()); }
        }

        public CustomersDataTable GetCustomers()
        {
            return CustomersTableAdapter.GetCustomers();
        }

        public CustomersDataTable GetCustomerByCustomerId(string customerId)
        {
            return CustomersTableAdapter.GetCustomerByCustomerId(customerId);
        }
    }
}
