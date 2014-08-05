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
    public partial class Insurances : UserControl
    {
        public static Insurances Instance { get; private set; }

        public Insurances()
        {
            InitializeComponent();

            Instance = this;

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadInsurancesData;
            _backgroundWorker.RunWorkerCompleted += LoadInsurancesDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }

        void LoadInsurancesData(object sender, DoWorkEventArgs e)
        {
            InsuranceVM.Instance.getInsurances();
            ContactsVM.Instance.getContacts();
        }

        void LoadInsurancesDataComplete(object sender,RunWorkerCompletedEventArgs e)
        {
            GridProgressRing.Visibility = Visibility.Collapsed;
            listInsurances.ItemsSource = InsuranceVM.Instance.Insurances;

            if(InsuranceVM.Instance.Insurances.Count > 0)
                DataStackPanel.DataContext = InsuranceVM.Instance.Insurances[0];
        }

        private void SearchInsurances_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text != "")
                listInsurances.ItemsSource = searchInsurances(((TextBox)sender).Text);

            else
                listInsurances.ItemsSource = InsuranceVM.Instance.Insurances;
        }

        public IEnumerable<Assurance> searchInsurances(string request)
        {
            if (request == string.Empty)
                return new List<Assurance>();

            var query = (from Assurance assurance in InsuranceVM.Instance.Insurances
                         where assurance.nom.ToUpper().StartsWith(request.ToUpper())
                         select assurance).Take(50);

            return query;
        }

        private void listInsurances_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataStackPanel.DataContext = listInsurances.SelectedItem;

            try
            {
                Assurance assuranceSelected = (Assurance)listInsurances.SelectedItem;
                Contact contact = ContactsVM.Instance.Contacts.Where(x => x.indice_contact == assuranceSelected.indice_contact).FirstOrDefault();

                LastNameClient.Text = contact.nom;
                FirstNameClient.Text = contact.prenom;
                FunctionClient.Text = contact.fonction;
                NumTel1Client.Text = contact.numero_telephone1;
                NumTel2Client.Text = contact.numero_telephone2;
                EmailClient.Text = contact.adresse_email;
                NumFaxClient.Text = contact.numero_fax;
            }
            catch (Exception E) { }
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            if (listInsurances.SelectedItem != null)
            {
                MessageBoxButton btn = MessageBoxButton.OKCancel;
                var result = await InsuranceVM.Instance.updateInsurance((Assurance)listInsurances.SelectedItem);

                ModernDialog.ShowMessage(result[1], result[0], btn);
            }
        }
    }
}
