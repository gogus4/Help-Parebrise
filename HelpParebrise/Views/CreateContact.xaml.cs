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
    public partial class CreateContact : ModernDialog
    {
        public CreateContact()
        {
            InitializeComponent();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;

            var result = await ContactVM.Instance.insertContact(new Contact { adresse_email = Email.Text, fonction = Function.Text,nom = Name.Text, numero_fax = NumFax.Text, numero_telephone1=NumTel1.Text,numero_telephone2 = NumTel2.Text,prenom = Firstname.Text });

            ModernDialog.ShowMessage(result[1], result[0], btn);
            PieceVM.Instance.getPieces();

            refreshAddCustomer();
            refreshAddInsurance();
            this.Close();
        }

        private void refreshAddInsurance()
        {
            try
            {
                ContactsVM.Instance.getContacts();
                AddInsurance.Instance.ComboListContact.ItemsSource = ContactsVM.Instance.Contacts;
            }
            catch (Exception e) { }
        }

        private void refreshAddCustomer()
        {
            try
            {
                ContactsVM.Instance.getContacts();
                InsuranceVM.Instance.getInsurances();

                AddCustomer.Instance.ComboListInsurances.ItemsSource = InsuranceVM.Instance.Insurances;
                AddCustomer.Instance.ComboListContact.ItemsSource = ContactsVM.Instance.Contacts;
            }
            catch (Exception e) { }
        }
    }
}