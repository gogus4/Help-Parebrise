using FirstFloor.ModernUI.Windows.Controls;
using HelpParebrise.Common;
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
    /// <summary>
    /// Interaction logic for ControlsStyles.xaml
    /// </summary>
    public partial class PrintBill : UserControl
    {
        public PrintBill()
        {
            InitializeComponent();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Intervention inter = new Intervention();
                if (NumInter.Text != "")
                    inter = InterventionVM.Instance.getIntervention(int.Parse(NumInter.Text));

                else if(dateInter.Text != "")
                    inter = InterventionVM.Instance.Interventions.Where(x => x.date_intervention == dateInter.Text).FirstOrDefault();

                Printing.printIntervention(inter);

                MessageBoxButton btn = MessageBoxButton.OKCancel;
                ModernDialog.ShowMessage(string.Format("L'intervention n°{0} s'est correctement imprimé.",inter.indice_intervention),"Impression de la facture réussi.", btn);
            }
            catch (Exception E)
            {
                MessageBoxButton btn = MessageBoxButton.OKCancel;
                ModernDialog.ShowMessage("Le numéro d'intervention est incorrect.","Erreur numéro d'intervention",btn);
                Debug.Write(E.Message);
            }
        }
    }
}