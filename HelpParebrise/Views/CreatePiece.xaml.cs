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
    public partial class CreatePiece : ModernDialog
    {
        public CreatePiece()
        {
            InitializeComponent();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;

            double price = 0;

            if (Prix.Text != "")
                price = double.Parse(Prix.Text);

            var result = await PieceVM.Instance.insertPiece(new Piece {designation = Designation.Text,prix = price,reference = Reference.Text  });

            ModernDialog.ShowMessage(result[1], result[0], btn);
            PieceVM.Instance.getPieces();
        }
    }
}