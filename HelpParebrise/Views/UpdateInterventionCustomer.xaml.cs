using FirstFloor.ModernUI.Windows.Controls;
using HelpParebrise.Data;
using HelpParebrise.Model;
using HelpParebrise.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
            PhotosInterventionVM.Instance.getPhotosIntervention();
            ContactsVM.Instance.getContacts();
        }

        void LoadDataComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (PhotosInterventionVM.Instance.PhotosIntervention.Where(x => x.indice_intervention == intervention.indice_intervention).ToList().Count != 0)
                {
                    PicturesIntervention.Visibility = Visibility.Visible;
                    listviewImagesIntervention.ItemsSource = PhotosInterventionVM.Instance.PhotosIntervention.Where(x => x.indice_intervention == intervention.indice_intervention);
                }

                ComboListContact.ItemsSource = ContactsVM.Instance.Contacts;
                DataContact.DataContext = ContactsVM.Instance.Contacts.Where(x => x.indice_contact == intervention.indice_contact).FirstOrDefault();

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
            MessageBoxButton btn = MessageBoxButton.OKCancel;

            if (ComboListContact.SelectedItem != null)
            {
                try
                {
                    var inter = DataInterventionGrid.DataContext;

                    Prestation prestation = (Prestation)ComboListTypePrestation.SelectedItem;
                    ModePaiement mode_paiement = (ModePaiement)ComboListModesPaiement.SelectedItem;
                    Tva tva = (Tva)ComboListTauxTva.SelectedItem;
                    Contact contact = (Contact)ComboListContact.SelectedItem;

                    intervention.id_tva = tva.id_tva;
                    intervention.indice_mode_paiement = mode_paiement.indice_mode_paiement;
                    intervention.indice_prestation = prestation.indice_prestation;
                    intervention.date_facture = DateFacture.Text;
                    intervention.date_intervention = DateIntervention.Text;
                    intervention.date_sinistre = DateSinistre.Text;
                    intervention.date_echeance = date_echeance.Text;
                    intervention.indice_contact = contact.indice_contact;

                    var result = await InterventionVM.Instance.updateIntervention(intervention);

                    ModernDialog.ShowMessage(result[1], result[0], btn);
                    this.Close();
                }
                catch (Exception E) { Debug.Write(E.Message); }
            }

            else
            {
                ModernDialog.ShowMessage("Merci de selectionner un contact.", "Erreur", btn);
            }
        }

        private async void AddPiece_Click(object sender, RoutedEventArgs e)
        {
            Piece piece = (Piece)ComboListPieces.SelectedItem;
            PieceIntervention piece_intervention = new PieceIntervention();
            piece_intervention.indice_intervention = intervention.indice_intervention;
            piece_intervention.indice_piece = piece.indice_piece;
            piece_intervention.quantite = int.Parse(QuantitePieceIntervention.Text);
            piece_intervention.reference = piece.reference;

            double remise;
            double.TryParse(RemisePieceIntervention.Text, out remise);

            piece_intervention.remise = remise;

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
            catch (Exception E) { Debug.Write(E.Message); }
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
            pieceIntervention.remise = double.Parse(RemisePieceInter.Text.Replace(".", ","));

            await PieceInterventionVM.Instance.deletePieceIntervention(pieceIntervention);

            PieceInterventionVM.Instance.getPiecesIntervention();
            pieceInterventionDataGrid.ItemsSource = PieceInterventionVM.Instance.PiecesIntervention.Where(x => x.indice_intervention == intervention.indice_intervention);
        }

        private void listviewImagesIntervention_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            popup.Visibility = Visibility.Visible;

            PhotosIntervention _picture = (PhotosIntervention)listviewImagesIntervention.SelectedItem;

            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(_picture.lien); ;
            bitmapImage.EndInit();

            imagePopup.Source = bitmapImage;
        }

        private void ClosePopup_Click(object sender, RoutedEventArgs e)
        {
            popup.Visibility = Visibility.Collapsed;
        }

        private async void AddPicture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.DefaultExt = "*.jpg";
                openfile.Filter = "Image Files|*.jpg";
                Nullable<bool> result = openfile.ShowDialog();
                if (result == true)
                {
                    FtpWebRequest ftpClient = (FtpWebRequest)FtpWebRequest.Create("ftp://92.222.162.33/help_parebrise/" + openfile.SafeFileName);
                    ftpClient.Credentials = new System.Net.NetworkCredential("help_parebrise", "help_parebrise");
                    ftpClient.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
                    ftpClient.UseBinary = true;
                    ftpClient.KeepAlive = true;
                    System.IO.FileInfo fi = new System.IO.FileInfo(openfile.FileName);
                    ftpClient.ContentLength = fi.Length;
                    byte[] buffer = new byte[4097];
                    int bytes = 0;
                    int total_bytes = (int)fi.Length;
                    System.IO.FileStream fs = fi.OpenRead();
                    System.IO.Stream rs = ftpClient.GetRequestStream();
                    while (total_bytes > 0)
                    {
                        bytes = fs.Read(buffer, 0, buffer.Length);
                        rs.Write(buffer, 0, bytes);
                        total_bytes = total_bytes - bytes;
                    }
                    fs.Close();
                    rs.Close();

                    FtpWebResponse uploadResponse = (FtpWebResponse)ftpClient.GetResponse();
                    string value = uploadResponse.StatusDescription;
                    uploadResponse.Close();

                    Intervention inter = (Intervention)DataInterventionGrid.DataContext;
                    await PhotosInterventionVM.Instance.insertPhotosIntervention(new PhotosIntervention() { lien = "http://92.222.162.33/help_parebrise/" + openfile.SafeFileName, indice_intervention = inter.indice_intervention });

                    #region THREAD
                    BackgroundWorker _backgroundWorker = new BackgroundWorker();

                    _backgroundWorker.DoWork += LoadData;
                    _backgroundWorker.RunWorkerCompleted += LoadDataComplete;
                    _backgroundWorker.RunWorkerAsync(5000);
                    #endregion
                }
            }
            catch (Exception E) { Debug.Write(E.Message); }
        }

        private void ComboListContact_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContact.DataContext = ComboListContact.SelectedItem;
        }
    }
}