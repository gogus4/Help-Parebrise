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
    public partial class CreateInsurance : ModernDialog
    {
        public CreateInsurance()
        {
            InitializeComponent();

            ContactsVM.Instance.getContacts();
            ComboListContact.ItemsSource = ContactsVM.Instance.Contacts;
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;

            Contact contact = (Contact)ComboListContact.SelectedItem;
            var result = await InsuranceVM.Instance.insertInsurance(new Assurance { adresse = Addr.Text,adresse_email = Email.Text, code_postal=CodePostal.Text,indice_contact = contact.indice_contact,nom=Name.Text,numero_contrat=NumContrat.Text,numero_fax=NumFax.Text,numero_telephone=NumTel.Text,ville=City.Text  });

            ModernDialog.ShowMessage(result[1], result[0], btn);
            PieceVM.Instance.getPieces();

            refreshAddCustomer();
            this.Close();
        }

        private void refreshAddCustomer()
        {
            ContactsVM.Instance.getContacts();
            InsuranceVM.Instance.getInsurances();

            AddCustomer.Instance.ComboListInsurances.ItemsSource = InsuranceVM.Instance.Insurances;
            AddCustomer.Instance.ComboListContact.ItemsSource = ContactsVM.Instance.Contacts;
        }

        private void ComboListContact_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContact.DataContext = ComboListContact.SelectedItem;
        }
    }
}