using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpParebrise.Model
{
    public class Contact
    {
        public int indice_contact { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string fonction { get; set; }
        public string numero_telephone1 { get; set; }
        public string numero_telephone2 { get; set; }
        public string adresse_email { get; set; }
        public string numero_fax { get; set; }
    }
}
