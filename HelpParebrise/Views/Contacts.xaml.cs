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
    public partial class Contacts : UserControl
    {
        public Contacts()
        {
            InitializeComponent();

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadSuppliersData;
            _backgroundWorker.RunWorkerCompleted += LoadSuppliersDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }

        void LoadSuppliersData(object sender, DoWorkEventArgs e)
        {
            ContactVM.Instance.getContacts();
        }

        void LoadSuppliersDataComplete(object sender,RunWorkerCompletedEventArgs e)
        {
            GridProgressRing.Visibility = Visibility.Collapsed;
            suppliersDataGrid.ItemsSource = ContactVM.Instance.Contacts; 
        }

        private void stockDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateStackPanel.Visibility = Visibility.Visible;
            UpdateStackPanel.DataContext = suppliersDataGrid.SelectedItem;
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;

            Contact contact = (Contact)suppliersDataGrid.SelectedItem;
            var result = await ContactVM.Instance.updateContact(contact);

            ModernDialog.ShowMessage(result[1], result[0], btn);
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;

            Contact _contact = new Contact { adresse_email = AddrEmailAdd.Text, fonction = FunctionAdd.Text, nom = NameAdd.Text, prenom = FirstNameAdd.Text, numero_telephone1 = NumTelAdd1.Text, numero_telephone2 = NumTelAdd2.Text, numero_fax = NumFaxAdd.Text };
            var result = await ContactVM.Instance.insertContact(_contact);

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

            Contact contact = (Contact)suppliersDataGrid.SelectedItem;
            var result = await ContactVM.Instance.deleteContact(contact);

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