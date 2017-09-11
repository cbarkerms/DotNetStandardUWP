using Northwind.NET.BLL;
using Northwind.NET.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Northwind.NET.DAL.NorthwindDataSet;

namespace Northwind.NET.WinForms
{
    public partial class MainForm : Form
    {
        private NewOrderForm _newOrderForm = new NewOrderForm();

        private bool _isEditModeEnabled = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeData();

            dataGridViewCustomers.SelectionChanged += DataGridViewCustomers_SelectionChanged;
            dataGridViewOrders.SelectionChanged += DataGridViewOrders_SelectionChanged;
            _newOrderForm.OrderSubmitted += _newOrderForm_OrderSubmitted;
        }

        private void _newOrderForm_OrderSubmitted(object sender, EventArgs e)
        {
            dataGridViewCustomers.ClearSelection();
            dataGridViewOrders.ClearSelection();
            dataGridViewOrderDetails.ClearSelection();
        }

        private void InitializeData()
        {
            dataGridViewCustomers.DataSource = CustomersBLL.Current.GetCustomers();
            DataGridViewCustomers_SelectionChanged(this, null);
        }

        private void DataGridViewCustomers_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridViewCustomers.SelectedRows;

            if(selectedRows != null && selectedRows.Count == 1)
            {
                var selectedRow = selectedRows[0];
                var item = ((DataRowView)selectedRow.DataBoundItem)?.Row as CustomersRow;

                if(item != null)
                {
                    dataGridViewOrders.DataSource = OrdersBLL.Current.GetOrdersByCustomerId(item.CustomerID);
                    DataGridViewOrders_SelectionChanged(this, null);
                }
            }
        }

        private void DataGridViewOrders_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridViewOrders.SelectedRows;

            if (selectedRows != null && selectedRows.Count == 1)
            {
                var selectedRow = selectedRows[0];
                var item = ((DataRowView)selectedRow.DataBoundItem)?.Row as OrdersRow;

                if (item != null)
                {
                    dataGridViewOrderDetails.DataSource = OrderDetailsBLL.Current.GetOrderDetailsByOrderId(item.OrderID);
                }
            }
        }

        private void dataGridViewOrders_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var item = ((DataRowView)e.Row.DataBoundItem)?.Row as OrdersRow;

            if (item != null && _isEditModeEnabled)
            {
                OrdersBLL.Current.DeleteOrder(item.OrderID);
            }
            else
            {
                MessageBox.Show("Unable to delete row.");
                e.Cancel = true;
            }
        }

        private void dataGridViewOrderDetails_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var item = ((DataRowView)e.Row.DataBoundItem)?.Row as Order_DetailsRow;

            if (item != null && _isEditModeEnabled)
            {
                OrderDetailsBLL.Current.DeleteOrderDetails(item.OrderID, item.ProductID);
            }
            else
            {
                MessageBox.Show("Unable to delete row.");
                e.Cancel = true;
            }
        }

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            if (!_newOrderForm.Visible)
            {
                _newOrderForm.ShowDialog();
            }
            else
            {
                _newOrderForm.Activate();
            }

            _newOrderForm.WindowState = FormWindowState.Normal;
        }

        private async void editModeButton_Click(object sender, EventArgs e)
        {
            _isEditModeEnabled = newOrderButton.Enabled;

            if (_isEditModeEnabled)
            {
                newOrderButton.Enabled = false;
            }
            else
            {
                if (await UserConsentService.Current.ConfirmUserConsent())
                {
                    newOrderButton.Enabled = true;
                    _isEditModeEnabled = true;
                }
                else
                {
                    MessageBox.Show("Consent not granted.");
                }
            }
        }
    }
}
