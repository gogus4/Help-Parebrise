using FirstFloor.ModernUI.Windows.Controls;
using HelpParebrise.Common;
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
using System.Windows.Threading;

namespace HelpParebrise.Views
{
    public partial class Customers : UserControl
    {
        public static Customers Instance { get; private set; }

        public Customers()
        {
            InitializeComponent();

            Instance = this; 

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadCustomersData;
            _backgroundWorker.RunWorkerCompleted += LoadCustomersDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }

        void LoadCustomersData(object sender, DoWorkEventArgs e)
        {
            CustomerVM.Instance.getCustomers();
            InterventionVM.Instance.getInterventions();
            ContactVM.Instance.getContacts();
            InsuranceVM.Instance.getInsurances();
        }

        void LoadCustomersDataComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            GridProgressRing.Visibility = Visibility.Collapsed;
            listCustomers.ItemsSource = CustomerVM.Instance.Customers;

            if (CustomerVM.Instance.Customers.Count > 0)
            {
                listCustomers.SelectedIndex = 0;
                Client customer = (Client)listCustomers.SelectedItem;

                var inter = (from c in InterventionVM.Instance.Interventions
                             where c.indice_client == customer.indice_client
                             select c).ToList();

                interventionsDataGrid.ItemsSource = inter;
            }
        }

        private void SearchCustomers_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text != "")
                listCustomers.ItemsSource = searchCustomers(((TextBox)sender).Text);

            else
                listCustomers.ItemsSource = CustomerVM.Instance.Customers;
        }

        public IEnumerable<Client> searchCustomers(string request)
        {
            if (request == string.Empty)
                return new List<Client>();

            var query = (from Client customer in CustomerVM.Instance.Customers
                         where customer.nom.ToUpper().StartsWith(request.ToUpper())
                         select customer).Take(50);

            return query;
        }

        private void listCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Client customer = (Client)listCustomers.SelectedItem;

                DataCustomerStackPanel.DataContext = listCustomers.SelectedItem;
                DataContactStackPanel.DataContext = ContactVM.Instance.Contacts.Where(x => x.indice_contact == customer.indice_contact);
                DataInsuranceStackPanel.DataContext = InsuranceVM.Instance.Insurances.Where(x => x.indice_assurance == customer.indice_assurance);

                var inter = (from c in InterventionVM.Instance.Interventions
                             where c.indice_client == customer.indice_client
                             select c).ToList();

                interventionsDataGrid.ItemsSource = inter;

                if (inter.Count > 0)
                    interventionsDataGrid.Visibility = Visibility.Visible;

                else
                    interventionsDataGrid.Visibility = Visibility.Collapsed;
            }
            catch (Exception E) { }
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            if (listCustomers.SelectedItem != null)
            {
                MessageBoxButton btn = MessageBoxButton.OKCancel;
                var result = await CustomerVM.Instance.updateCustomer((Client)listCustomers.SelectedItem);

                ModernDialog.ShowMessage(result[1], result[0], btn);
            }

            else
            {
                MessageBoxButton btn = MessageBoxButton.OKCancel;
                ModernDialog.ShowMessage("Vous devez d'abord selectionner un client.", "ERREUR CLIENT NON SELECTIONNE", btn);
            }
        }

        private void interventionsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Intervention inter = (Intervention)interventionsDataGrid.SelectedItem;
                UpdateInterventionCustomer interCustomer = new UpdateInterventionCustomer((Client)listCustomers.SelectedItem, inter.indice_intervention);
                interCustomer.Show();
            }
            catch (Exception E) { }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listCustomers.SelectedItem != null)
                {
                    Intervention inter = (Intervention)interventionsDataGrid.SelectedItem;
                    AddInterventionCustomer interCustomer = new AddInterventionCustomer((Client)listCustomers.SelectedItem);
                    interCustomer.Show();
                }

                else
                {
                    MessageBoxButton btn = MessageBoxButton.OKCancel;
                    ModernDialog.ShowMessage("Vous devez d'abord selectionner un client.", "ERREUR CLIENT NON SELECTIONNE", btn);
                }
            }
            catch (Exception E) { }
        }

        /*private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CustomerVM.Instance.getCustomers();
                listCustomers.ItemsSource = CustomerVM.Instance.Customers;
                InterventionVM.Instance.getInterventions();
                Client customer = (Client)listCustomers.SelectedItem;

                var inter = (from c in InterventionVM.Instance.Interventions
                             where c.indice_client == customer.indice_client
                             select c).ToList();

                if (inter.Count > 0)
                    interventionsDataGrid.Visibility = Visibility.Visible;

                interventionsDataGrid.ItemsSource = inter;
            }
            catch (Exception E) { }
        }*/

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DateTime? date = SearchInterventionDatePicker.SelectedDate;

                Client customer = (Client)listCustomers.SelectedItem;

                var inter = (from c in InterventionVM.Instance.Interventions
                             where c.indice_client == customer.indice_client
                             select c).ToList();

                var interSelected = inter.Where(x => int.Parse(x.date_intervention.Substring(3, 2)) == date.Value.Month && int.Parse(x.date_intervention.Substring(6, 4)) == date.Value.Year);
                interventionsDataGrid.ItemsSource = interSelected;
            }
            catch (Exception E) { }
        }
    }
}
