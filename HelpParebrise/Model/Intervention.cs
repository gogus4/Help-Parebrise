using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpParebrise.Model
{
    public class Intervention
    {
        public int indice_intervention { get; set; }
        public int indice_client { get; set; }
        public int indice_vehicule { get; set; }
        public int indice_contact { get; set; }
        public string bon_de_commande { get; set; }
        public string date_intervention { get; set; }
        public string date_facture { get; set; }
        public string numero_facture { get; set; }
        public double prix_HT { get; set; }
        public double prix_TTC { get; set; }
        public int id_tva { get; set; }
        public double acompte { get; set; }
        public double remise { get; set; }
        public double franchise { get; set; }
        public int indice_prestation { get; set; }
        public int indice_mode_paiement { get; set; }
        public string date_sinistre { get; set; }
        public string cause_sinistre { get; set; }
        public string adresse_intervention { get; set; }
        public string date_echeance { get; set; }
        public string assurance_impression { get; set; }
    }
}