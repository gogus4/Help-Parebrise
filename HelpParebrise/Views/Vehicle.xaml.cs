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
    public partial class Vehicle : UserControl
    {
        public static Vehicle Instance { get; private set; }

        public Vehicle()
        {
            InitializeComponent();

            Instance = this;

            #region THREAD
            BackgroundWorker _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += LoadVehiclesData;
            _backgroundWorker.RunWorkerCompleted += LoadVehiclesDataComplete;
            _backgroundWorker.RunWorkerAsync(5000);
            #endregion
        }

        void LoadVehiclesData(object sender, DoWorkEventArgs e)
        {
            VehiculeVM.Instance.getVehicules();
        }

        void LoadVehiclesDataComplete(object sender,RunWorkerCompletedEventArgs e)
        {
            GridProgressRing.Visibility = Visibility.Collapsed;
            listVehicles.ItemsSource = VehiculeVM.Instance.Vehicules;

            if (VehiculeVM.Instance.Vehicules.Count > 0)
                DataStackPanel.DataContext = VehiculeVM.Instance.Vehicules[0];
        }

        private void SearchVehicles_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text != "")
                listVehicles.ItemsSource = searchVehicles(((TextBox)sender).Text);

            else
                listVehicles.ItemsSource = VehiculeVM.Instance.Vehicules;
        }

        public IEnumerable<Vehicule> searchVehicles(string request)
        {
            if (request == string.Empty)
                return new List<Vehicule>();

            var query = (from Vehicule vehicle in VehiculeVM.Instance.Vehicules
                         where vehicle.immatriculation.ToUpper().StartsWith(request.ToUpper())
                         select vehicle).Take(50);

            return query;
        }

        private void listVehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataStackPanel.DataContext = listVehicles.SelectedItem;
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            if (listVehicles.SelectedItem != null)
            {
                MessageBoxButton btn = MessageBoxButton.OKCancel;
                var result = await VehiculeVM.Instance.updateVehicle((Vehicule)listVehicles.SelectedItem);

                ModernDialog.ShowMessage(result[1], result[0], btn);
            }
        }
    }
}
