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
    public partial class AddInterventionCustomer : ModernDialog
    {
        public static AddInterventionCustomer Instance { get; private set; }


        Client client;
        public AddInterventionCustomer(Client _client)
        {
            InitializeComponent();

            Instance = this;
            client = _client;

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadData;
            _backgroundWorker.RunWorkerCompleted += LoadDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }

        void LoadData(object sender, DoWorkEventArgs e)
        {
            VehiculeVM.Instance.getVehicules();
            TypePrestationVM.Instance.getTypePrestations();
            ModePaiementVM.Instance.getModesPaiement();
            PieceVM.Instance.getPieces();
            TvaVM.Instance.getTva();
        }

        void LoadDataComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            GridProgressRing.Visibility = Visibility.Collapsed;
            ComboListVehicules.ItemsSource = VehiculeVM.Instance.Vehicules;
            ComboListTypePrestation.ItemsSource = TypePrestationVM.Instance.TypePrestations;
            ComboListModesPaiement.ItemsSource = ModePaiementVM.Instance.ModesPaiement;
            ComboListTauxTVA.ItemsSource = TvaVM.Instance.TVA;
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;

            try
            {
                Vehicule vehicule = (Vehicule)ComboListVehicules.SelectedItem;
                ModePaiement modePaiement = (ModePaiement)ComboListModesPaiement.SelectedItem;
                Prestation prestation = (Prestation)ComboListTypePrestation.SelectedItem;
                Tva tva = (Tva)ComboListTauxTVA.SelectedItem;

                string ACompte = "";
                string Franchise = "";

                if (acompte.Text == "")
                    ACompte = "0,0";

                else
                    ACompte = acompte.Text;

                if (franchise.Text == "")
                    Franchise = "0,0";

                else
                    Franchise = franchise.Text;

                double test = double.Parse(Franchise);

                Intervention intervention = new Intervention { bon_de_commande = NumBonCommande.Text, acompte = double.Parse(ACompte), cause_sinistre = CauseSinistre.Text, date_facture = DateFacture.Text, date_intervention = DateIntervention.Text, date_sinistre = DateSinistre.Text, franchise = double.Parse(Franchise), numero_facture = NumFacture.Text, prix_HT = double.Parse(PriceHT.Text), prix_TTC = double.Parse(PriceTTC.Text), remise = double.Parse(remise.Text), indice_vehicule = vehicule.indice_vehicule, indice_client = client.indice_client, indice_mode_paiement = modePaiement.indice_mode_paiement, indice_prestation = prestation.indice_prestation, id_tva = tva.id_tva, adresse_intervention = AdresseIntervention.Text, date_echeance = DateEcheance.Text };
                var result = await InterventionVM.Instance.insertIntervention(intervention);

                ModernDialog.ShowMessage(result[1], result[0], btn);
                CustomerVM.Instance.getCustomers();

                refreshCustomers();
                Close();
            }
            catch (Exception E)
            {
                ModernDialog.ShowMessage("Une erreur est intervenue lors de l'insertion de l'intervention", "Erreur", btn);
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

        private void ComboListVehicules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataVehiculeStackPanel.DataContext = ComboListVehicules.SelectedItem;
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            CreateVehicle createVehicule = new CreateVehicle();
            createVehicule.Show();
        }
    }
}