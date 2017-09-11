using Northwind.NET.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Northwind.NET.DAL.NorthwindDataSet;

namespace Northwind.NET.WinForms
{
    public partial class NewOrderForm : Form
    {
        public event EventHandler OrderSubmitted;

        public NewOrderForm()
        {
            InitializeComponent();
        }

        private void NewOrderForm_Load(object sender, EventArgs e)
        {
            comboBoxCustomers.DataSource = CustomersBLL.Current.GetCustomers();
            comboBoxProducts.DataSource = ProductsBLL.Current.GetProducts();
        }

        private void comboBoxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetStatus();
        }

        private void comboBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = comboBoxProducts.SelectedItem;

            if (selectedItem != null)
            {
                var product = ((DataRowView)selectedItem)?.Row as ProductsRow;

                if (product != null)
                {
                    quantityPerUnit.Text = product?.QuantityPerUnit;
                    pricePerUnit.Tag = product?.UnitPrice;
                    pricePerUnit.Text = product?.UnitPrice.ToString("C", CultureInfo.CurrentCulture);

                    units_ValueChanged(sender, e);
                }
            }
            
            ResetStatus();
        }

        private void units_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pricePerUnit.Text))
            {
                total.Text = (units.Value * Convert.ToDecimal(pricePerUnit.Tag)).ToString("C", CultureInfo.CurrentCulture);
            }
            
            ResetStatus();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            var selectedCustomerItem = comboBoxCustomers.SelectedItem;
            var selectedProductItem = comboBoxProducts.SelectedItem;

            if (selectedCustomerItem == null || selectedProductItem == null || units.Value == 0)
            {
                WriteStatus("Incomplete Order", false);
                return;
            }

            submit.Enabled = false;

            var customer = ((DataRowView)selectedCustomerItem)?.Row as CustomersRow;
            var product = ((DataRowView)selectedProductItem)?.Row as ProductsRow;

            int orderId = -1;

            try
            {
                orderId = OrdersBLL.Current.AddOrder(
                    customer.CustomerID,
                    DateTime.Now,
                    DateTime.Now.AddDays(30)
                );
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                submit.Enabled = true;
                return;
            }

            if (orderId == -1)
            {
                MessageBox.Show("Error creating order.");
                submit.Enabled = true;
                return;
            }

            try
            {
                orderId = OrderDetailsBLL.Current.AddOrderDetails(
                    orderId,
                    product.ProductID,
                    (decimal)pricePerUnit.Tag,
                    (short)units.Value,
                    0);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                submit.Enabled = true;
                return;
            }

            if (orderId == -1)
            {
                MessageBox.Show("Error creating order details.");
                submit.Enabled = true;
                return;
            }

            WriteStatus("Submitted");

            OrderSubmitted?.Invoke(this, EventArgs.Empty);

            submit.Enabled = true;
        }

        private void WriteStatus(string message, bool success)
        {
            status.ForeColor = success ? Color.Green : Color.Red;
            status.Text = message;
        }

        private void WriteStatus(string message)
        {
            WriteStatus(message, true);
        }

        private void ResetStatus()
        {
            WriteStatus(string.Empty);
        }
    }
}
