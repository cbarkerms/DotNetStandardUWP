using Northwind.NET.DAL.NorthwindDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static Northwind.NET.DAL.NorthwindDataSet;

namespace Northwind.NET.BLL
{
    public class ProductsBLL
    {
        private ProductsBLL() { }

        private static ProductsBLL current;

        public static ProductsBLL Current => current ?? (current = new ProductsBLL());

        private ProductsTableAdapter productsTableAdapter;

        protected ProductsTableAdapter ProductsTableAdapter
        {
            get { return productsTableAdapter ?? (productsTableAdapter = new ProductsTableAdapter()); }
        }

        public ProductsDataTable GetProducts()
        {
            return ProductsTableAdapter.GetData();
        }
    }
}
