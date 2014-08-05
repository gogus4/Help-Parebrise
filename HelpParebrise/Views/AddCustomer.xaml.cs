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
    /// <summary>
    /// Interaction logic for ControlsStyles.xaml
    /// </summary>
    public partial class AddCustomer : UserControl
    {
        public static AddCustomer Instance { get; private set; }


        public AddCustomer()
        {
            InitializeComponent();

            Instance = this; 

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadData;
            _backgroundWorker.RunWorkerCompleted += LoadDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }

        void LoadData(object sender, DoWorkEventArgs e)
        {
            ContactsVM.Instance.getContacts();
            InsuranceVM.Instance.getInsurances();
        }

        void LoadDataComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            GridProgressRing.Visibility = Visibility.Collapsed;
            ComboListInsurances.ItemsSource = InsuranceVM.Instance.Insurances;
            ComboListContact.ItemsSource = ContactsVM.Instance.Contacts;
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ComboListContact.SelectedItem != null)
            {
                Contact contact = (Contact)ComboListContact.SelectedItem;
                Assurance insurance = (Assurance)ComboListInsurances.SelectedItem;
                MessageBoxButton btn = MessageBoxButton.OKCancel;

                int ? indice_assurance;
                if (insurance == null)
                    indice_assurance = null;

                else
                    indice_assurance = insurance.indice_assurance;

                Client _customer = new Client { adresse_email = Email.Text, adresse_siege = AddrSiege.Text, code_postal = CodePostalClient.Text, nom = NameCustomer.Text, numero_fax = NumFaxClient.Text, numero_telephone_1 = NumTel1Client.Text, numero_telephone_2 = NumTel2Client.Text, numero_telephone_3 = NumTel3.Text, ville = Ville.Text, indice_assurance = indice_assurance, indice_contact = contact.indice_contact };
                var result = await CustomerVM.Instance.insertCustomer(_customer);

                ModernDialog.ShowMessage(result[1], result[0], btn);

                refreshCustomers();
            }
        }

        private void refreshCustomers()
        {
            CustomerVM.Instance.getCustomers();
            InterventionVM.Instance.getInterventions();
            ContactVM.Instance.getContacts();
            InsuranceVM.Instance.getInsurances();

            Customers.Instance.listCustomers.ItemsSource = CustomerVM.Instance.Customers;

            if (CustomerVM.Instance.Customers.Count > 0)
            {
                Customers.Instance.listCustomers.SelectedIndex = 0;
                Client customer = (Client)Customers.Instance.listCustomers.SelectedItem;

                var inter = (from c in InterventionVM.Instance.Interventions
                             where c.indice_client == customer.indice_client
                             select c).ToList();

                Customers.Instance.interventionsDataGrid.ItemsSource = inter;
            }
        }

        private void ComboListContact_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContact.DataContext = ComboListContact.SelectedItem;
        }

        private void ComboListInsurances_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataInsurance.DataContext = ComboListInsurances.SelectedItem;
        }

        private void CreateContact_Click(object sender, RoutedEventArgs e)
        {
            CreateContact createContact = new CreateContact();
            createContact.Show();
        }

        private void CreateInsurance_Click(object sender, RoutedEventArgs e)
        {
            CreateInsurance createInsurance = new CreateInsurance();
            createInsurance.Show();
        }
    }
}