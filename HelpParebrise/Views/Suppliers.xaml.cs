using FirstFloor.ModernUI.Windows.Controls;
using HelpParebrise.Model;
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
    public partial class Suppliers : UserControl
    {
        public static Suppliers Instance { get; private set; }

        public Suppliers()
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
            SupplierVM.Instance.getSuppliers();
        }

        void LoadSuppliersDataComplete(object sender,RunWorkerCompletedEventArgs e)
        {
            GridProgressRing.Visibility = Visibility.Collapsed;
            suppliersDataGrid.ItemsSource = SupplierVM.Instance.Suppliers; 
        }

        private void stockDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateStackPanel.Visibility = Visibility.Visible;
            UpdateStackPanel.DataContext = suppliersDataGrid.SelectedItem;
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;

            Fournisseur supplier = (Fournisseur)suppliersDataGrid.SelectedItem;
            var result = await SupplierVM.Instance.updateSupplier(supplier);

            ModernDialog.ShowMessage(result[1], result[0], btn);
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;
            int enCours = 0;
            int.TryParse(EnCoursAdd.Text, out enCours);

            Fournisseur _supplier = new Fournisseur { adresse = AddrAdd.Text, adresse_email = AddrEmailAdd.Text, en_cours = enCours, nom = NameAdd.Text , numero_fax = NumFaxAdd.Text , numero_telephone = NumTelAdd.Text };
            var result = await SupplierVM.Instance.insertSupplier(_supplier);

            ModernDialog.ShowMessage(result[1], result[0], btn);

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadSuppliersData;
            _backgroundWorker.RunWorkerCompleted += LoadSuppliersDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;

            Fournisseur supplier = (Fournisseur)suppliersDataGrid.SelectedItem;
            var result = await SupplierVM.Instance.deleteSupplier(supplier);

            ModernDialog.ShowMessage(result[1], result[0], btn);

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadSuppliersData;
            _backgroundWorker.RunWorkerCompleted += LoadSuppliersDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }
    }
}