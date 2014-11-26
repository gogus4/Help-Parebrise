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
    public partial class CreateVehicle : ModernDialog
    {
        public CreateVehicle()
        {
            InitializeComponent();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxButton btn = MessageBoxButton.OKCancel;

                var result = await VehiculeVM.Instance.insertVehicle(new Vehicule { date_mise_en_service = DateMES.Text, immatriculation = Immatriculation.Text, kilometrage = double.Parse(Kilometrage.Text), marque = Marque.Text, modele = Modele.Text, numero_serie = NumSerie.Text, type_vehicule = TypeVehicule.Text, numero_parc = NumParc.Text });

                ModernDialog.ShowMessage(result[1], result[0], btn);
                PieceVM.Instance.getPieces();

                refreshAddIntervention();
                this.Close();
            }
            catch(Exception E){}
        }

        private void refreshAddIntervention()
        {
            VehiculeVM.Instance.getVehicules();
            TypePrestationVM.Instance.getTypePrestations();
            ModePaiementVM.Instance.getModesPaiement();
            PieceVM.Instance.getPieces();
            TvaVM.Instance.getTva();

            AddInterventionCustomer.Instance.ComboListVehicules.ItemsSource = VehiculeVM.Instance.Vehicules;
            AddInterventionCustomer.Instance.ComboListTypePrestation.ItemsSource = TypePrestationVM.Instance.TypePrestations;
            AddInterventionCustomer.Instance.ComboListModesPaiement.ItemsSource = ModePaiementVM.Instance.ModesPaiement;
            AddInterventionCustomer.Instance.ComboListTauxTVA.ItemsSource = TvaVM.Instance.TVA;
        }
    }
}