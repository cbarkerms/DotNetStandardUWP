using Northwind.UWP.UI.ViewModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Northwind.UWP.UI
{
    public sealed partial class NewOrderForm : ContentDialog, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private NewOrderViewModel newOrderViewModel;

        public NewOrderViewModel NewOrderViewModel
        {
            get { return newOrderViewModel; }
            set
            {
                newOrderViewModel = value;
                OnPropertyChanged("NewOrderViewModel");
            }
        }

        public NewOrderForm()
        {
            this.InitializeComponent();

            NewOrderViewModel = new NewOrderViewModel { InkCanvas = InkCanvas };
        }

        private async void ContentDialog_SubmitOrderClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            args.Cancel = true;
            await NewOrderViewModel.SubmitOrderAsync();
        }

        private void ContentDialog_CancelOrderClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            NewOrderViewModel.CancelOrder();
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
