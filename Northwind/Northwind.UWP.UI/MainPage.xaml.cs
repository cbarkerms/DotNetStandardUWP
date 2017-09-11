using Northwind.NET.BLL;
using Northwind.NET.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using static Northwind.NET.DAL.NorthwindDataSet;

namespace Northwind.UWP.UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private NewOrderForm _newOrderForm = new NewOrderForm();

        private CustomersDataTable customersDataTable;

        public CustomersDataTable CustomersDataTable
        {
            get { return customersDataTable; }
            set
            {
                customersDataTable = value;
                OnPropertyChanged("CustomersDataTable");
            }
        }

        private OrdersDataTable ordersDataTable;

        public OrdersDataTable OrdersDataTable
        {
            get { return ordersDataTable; }
            set
            {
                ordersDataTable = value;
                OnPropertyChanged("OrdersDataTable");
            }
        }

        private Order_DetailsDataTable orderDetailsDataTable;

        public Order_DetailsDataTable OrderDetailsDataTable
        {
            get { return orderDetailsDataTable; }
            set
            {
                orderDetailsDataTable = value;
                OnPropertyChanged("OrderDetailsDataTable");
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            CustomersDataTable = CustomersBLL.Current.GetCustomers();
            _newOrderForm.NewOrderViewModel.OrderSubmitted += NewOrderModel_OrderSubmitted;
        }

        private void NewOrderModel_OrderSubmitted(object sender, EventArgs e)
        {
            _newOrderForm.Hide();
            CustomersDataTable = CustomersBLL.Current.GetCustomers();
            ToastNotificationService.Current.FireToastNotification("Order submitted. Pending shipping.");
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CustomersDataGrid_SelectionChanged(object sender, DataGridSelectionChangedEventArgs e)
        {
            var items = e.AddedItems.ToList();
            if (items.Count() > 0)
            {
                var customerRow = items[0] as CustomersRow;
                if (customerRow != null)
                {
                    OrdersDataTable = OrdersBLL.Current.GetOrdersByCustomerId(customerRow.CustomerID);
                }
            }
            else
            {
                OrdersDataTable = null;
            }
        }

        private void OrdersDataGrid_SelectionChanged(object sender, DataGridSelectionChangedEventArgs e)
        {
            var items = e.AddedItems.ToList();
            if (items.Count() > 0)
            {
                var orderRow = items[0] as OrdersRow;
                if (orderRow != null)
                {
                    OrderDetailsDataTable = OrderDetailsBLL.Current.GetOrderDetailsByOrderId(orderRow.OrderID);
                }
            }
            else
            {
                OrderDetailsDataTable = null;
            }
        }

        private async void NewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            await _newOrderForm.ShowAsync();
        }

        private async void EditModeButton_Click(object sender, RoutedEventArgs e)
        {
            bool isEditModeEnabled = NewOrderButton.IsEnabled;

            if (isEditModeEnabled)
            {
                NewOrderButton.IsEnabled = false;
            }
            else
            {
                if (await UserConsentService.Current.ConfirmUserConsent())
                {
                    NewOrderButton.IsEnabled = true;
                }
                else
                {
                    await new MessageDialog("Consent not granted.").ShowAsync();
                }
            }
        }
    }
}
