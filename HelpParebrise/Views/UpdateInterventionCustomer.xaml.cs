using FirstFloor.ModernUI.Windows.Controls;
using HelpParebrise.Data;
using HelpParebrise.Model;
using HelpParebrise.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    public partial class UpdateInterventionCustomer : ModernDialog
    {
        Client client;
        Intervention intervention;
        int indiceIntervention;

        public UpdateInterventionCustomer(Client _client, int _indiceIntervention)
        {
            InitializeComponent();

            client = _client;

            indiceIntervention = _indiceIntervention;
            intervention = InterventionVM.Instance.Interventions.Where(c => c.indice_intervention == indiceIntervention).FirstOrDefault();
            DataInterventionGrid.DataContext = intervention;

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadData;
            _backgroundWorker.RunWorkerCompleted += LoadDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }

        void LoadData(object sender, DoWorkEventArgs e)
        {
            PieceVM.Instance.getPieces();
            PieceInterventionVM.Instance.getPiecesIntervention();
            TypePrestationVM.Instance.getTypePrestations();
            ModePaiementVM.Instance.getModesPaiement();
            TvaVM.Instance.getTva();
            VehiculeVM.Instance.getVehicules();
        }

        void LoadDataComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                ComboListPieces.ItemsSource = PieceVM.Instance.Pieces;
                VehiculeDataContext.DataContext = VehiculeVM.Instance.Vehicules.Where(x => x.indice_vehicule == intervention.indice_vehicule).FirstOrDefault();

                ComboListTauxTva.ItemsSource = TvaVM.Instance.TVA;
                ComboListTauxTva.SelectedValue = TvaVM.Instance.TVA.Where(x => x.id_tva == intervention.id_tva).FirstOrDefault();

                ComboListModesPaiement.ItemsSource = ModePaiementVM.Instance.ModesPaiement;
                ComboListModesPaiement.SelectedValue = ModePaiementVM.Instance.ModesPaiement.Where(x => x.indice_mode_paiement == intervention.indice_mode_paiement).FirstOrDefault();

                ComboListTypePrestation.ItemsSource = TypePrestationVM.Instance.TypePrestations;
                ComboListTypePrestation.SelectedValue = TypePrestationVM.Instance.TypePrestations.Where(x => x.indice_prestation == intervention.indice_prestation).FirstOrDefault();
                pieceInterventionDataGrid.ItemsSource = PieceInterventionVM.Instance.PiecesIntervention.Where(x => x.indice_intervention == intervention.indice_intervention);
            }
            catch (Exception E) { Debug.Write(E.Message); }
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxButton btn = MessageBoxButton.OKCancel;
                var inter = DataInterventionGrid.DataContext;

                Prestation prestation = (Prestation)ComboListTypePrestation.SelectedItem;
                ModePaiement mode_paiement = (ModePaiement)ComboListModesPaiement.SelectedItem;
                Tva tva = (Tva)ComboListTauxTva.SelectedItem;

                intervention.id_tva = tva.id_tva;
                intervention.indice_mode_paiement = mode_paiement.indice_mode_paiement;
                intervention.indice_prestation = prestation.indice_prestation;
                intervention.date_facture = DateFacture.Text;
                intervention.date_intervention = DateIntervention.Text;
                intervention.date_sinistre = DateSinistre.Text;

                var result = await InterventionVM.Instance.updateIntervention(intervention);

                ModernDialog.ShowMessage(result[1], result[0], btn);
                this.Close();
            }
            catch (Exception E) { }
        }

        private async void AddPiece_Click(object sender, RoutedEventArgs e)
        {
            Piece piece = (Piece)ComboListPieces.SelectedItem;
            PieceIntervention piece_intervention = new PieceIntervention();
            piece_intervention.indice_intervention = intervention.indice_intervention;
            piece_intervention.indice_piece = piece.indice_piece;
            piece_intervention.quantite = int.Parse(QuantitePieceIntervention.Text);
            piece_intervention.reference = piece.reference;
            piece_intervention.remise = int.Parse(RemisePieceIntervention.Text);

            await PieceInterventionVM.Instance.insertPieceIntervention(piece_intervention);
            PieceInterventionVM.Instance.getPiecesIntervention();
            pieceInterventionDataGrid.ItemsSource = PieceInterventionVM.Instance.PiecesIntervention.Where(x => x.indice_intervention == intervention.indice_intervention);
        }

        private void pieceInterventionDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PieceIntervention pieceIntervention = (PieceIntervention)pieceInterventionDataGrid.SelectedItem;
            PieceInterventionStackPanel.DataContext = pieceIntervention;
            PieceInterventionStackPanel.Visibility = Visibility.Visible;
        }

        private void CreatePiece_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CreatePiece createPiece = new CreatePiece(); ;
                createPiece.Show();
            }
            catch (Exception E) { }
        }

        private async void UpdatePieceIntervention_Click(object sender, RoutedEventArgs e)
        {
            PieceIntervention pieceIntervention = (PieceIntervention)pieceInterventionDataGrid.SelectedItem;
            pieceIntervention.quantite = int.Parse(quantitePieceInter.Text);
            pieceIntervention.remise = int.Parse(RemisePieceInter.Text);

            await PieceInterventionVM.Instance.updatePieceIntervention(pieceIntervention);
        }

        private async void DeletePieceIntervention_Click(object sender, RoutedEventArgs e)
        {
            PieceIntervention pieceIntervention = (PieceIntervention)pieceInterventionDataGrid.SelectedItem;
            pieceIntervention.quantite = int.Parse(quantitePieceInter.Text);
            pieceIntervention.remise = int.Parse(RemisePieceInter.Text);

            await PieceInterventionVM.Instance.deletePieceIntervention(pieceIntervention);

            PieceInterventionVM.Instance.getPiecesIntervention();
            pieceInterventionDataGrid.ItemsSource = PieceInterventionVM.Instance.PiecesIntervention.Where(x => x.indice_intervention == intervention.indice_intervention);
        }
    }
}