﻿using FirstFloor.ModernUI.Windows.Controls;
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
    public partial class AddVehicle : UserControl
    {
        public AddVehicle()
        {
            InitializeComponent();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OKCancel;

            var result = await VehiculeVM.Instance.insertVehicle(new Vehicule { date_mise_en_service = dateMES.Text, immatriculation = Immatriculation.Text, kilometrage = double.Parse(kilometrage.Text), marque = Marque.Text, modele = Modele.Text, numero_serie = numSerie.Text, type_vehicule= TypeVehicule.Text });

            ModernDialog.ShowMessage(result[1], result[0], btn);
            VehiculeVM.Instance.getVehicules();

            refreshVehicule();
        }

        private void refreshVehicule()
        {
            VehiculeVM.Instance.getVehicules();

            Vehicle.Instance.listVehicles.ItemsSource = VehiculeVM.Instance.Vehicules;

            if (VehiculeVM.Instance.Vehicules.Count > 0)
                Vehicle.Instance.DataStackPanel.DataContext = VehiculeVM.Instance.Vehicules[0];
        }
    }
}