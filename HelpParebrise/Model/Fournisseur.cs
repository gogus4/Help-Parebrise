using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpParebrise.Model
{
    public class Fournisseur
    {
        public int indice_fournisseur { get; set; }
        public string nom { get; set; }
        public string adresse { get; set; }
        public string numero_telephone { get; set; }
        public string adresse_email { get; set; }
        public string numero_fax { get; set; }
        public double en_cours { get; set; }
    }
}
