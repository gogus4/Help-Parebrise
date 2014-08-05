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
    public partial class AddStock : UserControl
    {
        public AddStock()
        {
            InitializeComponent();

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadContactData;
            _backgroundWorker.RunWorkerCompleted += LoadContactDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }

        void LoadContactData(object sender, DoWorkEventArgs e)
        {
            PieceVM.Instance.getPieces();
        }

        void LoadContactDataComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            GridProgressRing.Visibility = Visibility.Collapsed;
            ComboListPiece.ItemsSource = PieceVM.Instance.Pieces;
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ComboListPiece.SelectedItem != null)
            {
                MessageBoxButton btn = MessageBoxButton.OKCancel;
                Piece piece = (Piece)ComboListPiece.SelectedItem;
                int quantity = 0;
                int.TryParse(Quantity.Text, out quantity);

                HelpParebrise.Model.Stock _stock = new HelpParebrise.Model.Stock { quantite = quantity, indice_piece = piece.indice_piece };
                var result = await StockVM.Instance.insertStock(_stock);

                ModernDialog.ShowMessage(result[1], result[0], btn);

                refreshAddStock();
            }
        }

        private void refreshAddStock()
        {
            StockVM.Instance.getStock();
            Stock.Instance.stockDataGrid.ItemsSource = StockVM.Instance.Stock;
        }
    }
}