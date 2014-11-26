using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpParebrise.Model
{
    public class Vehicule
    {
        public int indice_vehicule { get; set; }
        public string marque { get; set; }
        public string modele { get; set; }
        public string date_mise_en_service { get; set; }
        public string immatriculation { get; set; }
        public string numero_serie { get; set; }
        public string type_vehicule { get; set; }
        public string numero_parc { get; set; }
        public double kilometrage { get; set; }
    }
}
