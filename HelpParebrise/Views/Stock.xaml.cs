using FirstFloor.ModernUI.Windows.Controls;
using HelpParebrise.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelpParebrise.Views
{
    public partial class Stock : UserControl
    {
        public static Stock Instance { get; private set; }


        public Stock()
        {
            InitializeComponent();
            Instance = this;

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadSuppliersData;
            _backgroundWorker.RunWorkerCompleted += LoadSuppliersDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }

        void LoadSuppliersData(object sender, DoWorkEventArgs e)
        {
            StockVM.Instance.getStock();
        }

        void LoadSuppliersDataComplete(object sender,RunWorkerCompletedEventArgs e)
        {
            GridProgressRing.Visibility = Visibility.Collapsed;
            stockDataGrid.ItemsSource = StockVM.Instance.Stock;
        }

        private void stockDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateStackPanel.Visibility = Visibility.Visible;
            UpdateStackPanel.DataContext = stockDataGrid.SelectedItem;
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;

            HelpParebrise.Model.Stock article = (HelpParebrise.Model.Stock)stockDataGrid.SelectedItem;
            var result = await StockVM.Instance.updateStock(article);

            ModernDialog.ShowMessage(result[1], result[0], btn);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StockVM.Instance.getStock();
            stockDataGrid.ItemsSource = StockVM.Instance.Stock;
        }
    }
}
