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
    public partial class Pieces : UserControl
    {
        public Pieces()
        {
            InitializeComponent();

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadSuppliersData;
            _backgroundWorker.RunWorkerCompleted += LoadSuppliersDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }

        void LoadSuppliersData(object sender, DoWorkEventArgs e)
        {
            PieceVM.Instance.getPieces();
        }

        void LoadSuppliersDataComplete(object sender,RunWorkerCompletedEventArgs e)
        {
            GridProgressRing.Visibility = Visibility.Collapsed;
            piecesDataGrid.ItemsSource = PieceVM.Instance.Pieces; 
        }

        private void stockDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateStackPanel.Visibility = Visibility.Visible;
            UpdateStackPanel.DataContext = piecesDataGrid.SelectedItem;
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;

            Piece piece = (Piece)piecesDataGrid.SelectedItem;
            var result = await PieceVM.Instance.updatePiece(piece);

            ModernDialog.ShowMessage(result[1], result[0], btn);
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;
            double price = 0;

            if (PriceAdd.Text != "")
                price = double.Parse(PriceAdd.Text);

            Piece _piece = new Piece { designation = DesignationAdd.Text, prix = price, reference = RefAdd.Text };
            var result = await PieceVM.Instance.insertPiece(_piece);

            ModernDialog.ShowMessage(result[1], result[0], btn);

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadSuppliersData;
            _backgroundWorker.RunWorkerCompleted += LoadSuppliersDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;

            Piece piece = (Piece)piecesDataGrid.SelectedItem;
            var result = await PieceVM.Instance.deletePiece(piece);

            ModernDialog.ShowMessage(result[1], result[0], btn);

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadSuppliersData;
            _backgroundWorker.RunWorkerCompleted += LoadSuppliersDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }
    }
}