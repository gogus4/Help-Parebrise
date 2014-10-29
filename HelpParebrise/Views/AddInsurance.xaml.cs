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
    public partial class AddInsurance : UserControl
    {
        public static AddInsurance Instance { get; private set; }

        public AddInsurance()
        {
            InitializeComponent();

            Instance = this;

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadContactData;
            _backgroundWorker.RunWorkerCompleted += LoadContactDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }

        void LoadContactData(object sender, DoWorkEventArgs e)
        {
            ContactsVM.Instance.getContacts();
        }

        void LoadContactDataComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            GridProgressRing.Visibility = Visibility.Collapsed;
            ComboListContact.ItemsSource = ContactsVM.Instance.Contacts;
        }

        private void ComboListContact_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContact.DataContext = ComboListContact.SelectedItem;
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;

            if (ComboListContact.SelectedItem != null)
            {
                Contact contact = (Contact)ComboListContact.SelectedItem;
                var result = await InsuranceVM.Instance.insertInsurance(new Assurance { adresse = Adresse.Text, adresse_email = Email.Text, code_postal = CodePostal.Text, indice_contact = contact.indice_contact, nom = Name.Text, numero_contrat = NumContrat.Text, numero_fax = NumFax.Text, numero_telephone = NumTel.Text, ville = Ville.Text });

                ModernDialog.ShowMessage(result[1], result[0], btn);

                InsuranceVM.Instance.getInsurances();

                refreshInsurance();
            }

            else
                ModernDialog.ShowMessage("Aucun contact selectionné. Merci d'en selectionner un.", "Contact non selectionné", btn);
        }

        void refreshInsurance()
        {
            Insurances.Instance.listInsurances.ItemsSource = InsuranceVM.Instance.Insurances;

            if (InsuranceVM.Instance.Insurances.Count > 0)
                Insurances.Instance.DataStackPanel.DataContext = InsuranceVM.Instance.Insurances[0];
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            CreateContact createContact = new CreateContact();
            createContact.Show();
        }
    }
}