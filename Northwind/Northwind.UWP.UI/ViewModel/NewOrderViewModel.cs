using Northwind.NET.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;
using static Northwind.NET.DAL.NorthwindDataSet;
using Windows.UI.Xaml.Controls;
using Windows.UI.Core;

namespace Northwind.UWP.UI.ViewModel
{
    public class NewOrderViewModel : INotifyPropertyChanged
    {
        public event EventHandler OrderSubmitted;

        public NewOrderViewModel()
        {
            Customers = CustomersBLL.Current.GetCustomers().Cast<CustomersRow>().ToList();
            Products = ProductsBLL.Current.GetProducts().Cast<ProductsRow>().ToList();
            IsSubmitEnabled = true;
            StatusForeground = new SolidColorBrush(Colors.Black);
        }

        private List<CustomersRow> customers;

        public List<CustomersRow> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                OnPropertyChanged("Customers");
            }
        }

        private List<ProductsRow> products;

        public List<ProductsRow> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged("Products");
            }
        }

        private CustomersRow selectedCustomer;

        public CustomersRow SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (selectedCustomer != value)
                {
                    ResetStatus();
                    selectedCustomer = value;
                    OnPropertyChanged("SelectedCustomer");
                }
            }
        }

        private ProductsRow selectedProduct;

        public ProductsRow SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if (selectedProduct != value)
                {
                    selectedProduct = value;
                    OnPropertyChanged("SelectedProduct");

                    QuantityPerUnit = selectedProduct?.QuantityPerUnit;
                    PricePerUnit = selectedProduct?.UnitPrice.ToString("C", CultureInfo.CurrentCulture);

                    Total = (Units * Convert.ToDouble(selectedProduct?.UnitPrice)).ToString("C", CultureInfo.CurrentCulture);
                }
            }
        }

        private string quantityPerUnit;

        public string QuantityPerUnit
        {
            get { return quantityPerUnit; }
            set
            {
                quantityPerUnit = value;
                OnPropertyChanged("QuantityPerUnit");
            }
        }

        private double units;

        public double Units
        {
            get { return units; }
            set
            {
                units = value;
                OnPropertyChanged("Units");

                Total = (Units * Convert.ToDouble(SelectedProduct?.UnitPrice)).ToString("C", CultureInfo.CurrentCulture);
            }
        }

        private string pricePerUnit;

        public string PricePerUnit
        {
            get { return pricePerUnit; }
            set
            {
                pricePerUnit = value;
                OnPropertyChanged("PricePerUnit");
            }
        }

        private string total;

        public string Total
        {
            get { return total; }
            set
            {
                total = value;
                OnPropertyChanged("Total");
            }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        private SolidColorBrush statusForeground;

        public SolidColorBrush StatusForeground
        {
            get { return statusForeground; }
            set
            {
                statusForeground = value;
                OnPropertyChanged("StatusForeground");
            }
        }


        private bool isSubmitEnabled;

        public bool IsSubmitEnabled
        {
            get { return isSubmitEnabled; }
            set
            {
                isSubmitEnabled = value;
                OnPropertyChanged("IsSubmitEnabled");
            }
        }

        private InkCanvas inkCanvas;

        public InkCanvas InkCanvas
        {
            get { return inkCanvas; }
            set
            {
                inkCanvas = value;
                inkCanvas.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Touch | CoreInputDeviceTypes.Mouse;
            }
        }

        public async Task SubmitOrderAsync()
        {
            var strokeCount = InkCanvas?.InkPresenter?.StrokeContainer?.GetStrokes()?.Count();

            if (SelectedCustomer == null || SelectedProduct == null || Units == 0 || strokeCount == null || strokeCount == 0)
            {
                WriteStatus("Incomplete Order", false);
                return;
            }

            IsSubmitEnabled = false;

            int orderId = -1;

            try
            {
                orderId = OrdersBLL.Current.AddOrder(
                    selectedCustomer.CustomerID,
                    DateTime.Now,
                    DateTime.Now.AddDays(30)
                    );
            }
            catch (SqlException ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
                IsSubmitEnabled = true;
                return;
            }

            if (orderId == -1)
            {
                await new MessageDialog("Error creating order.").ShowAsync();
                IsSubmitEnabled = true;
                return;
            }

            try
            {
                orderId = OrderDetailsBLL.Current.AddOrderDetails(
                    orderId,
                    SelectedProduct.ProductID,
                    SelectedProduct.UnitPrice,
                    (short)Units,
                    0);
            }
            catch (SqlException ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
                IsSubmitEnabled = true;
                return;
            }

            if (orderId == -1)
            {
                await new MessageDialog("Error creating order details.").ShowAsync();
                IsSubmitEnabled = true;
                return;
            }

            WriteStatus("Submitted");

            OrderSubmitted?.Invoke(this, EventArgs.Empty);

            IsSubmitEnabled = true;
        }

        public void CancelOrder()
        {

        }

        private void WriteStatus(string message, bool success)
        {
            StatusForeground = success ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
            Status = message;
        }

        private void WriteStatus(string message)
        {
            WriteStatus(message, true);
        }

        private void ResetStatus()
        {
            WriteStatus(string.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
