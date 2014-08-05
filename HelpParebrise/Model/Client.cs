using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpParebrise.Model
{
    public class Client
    {
        public int indice_client { get; set; }
        public string adresse_siege { get; set; }
        public string code_postal { get; set; }
        public string ville { get; set; }
        public string nom { get; set; }
        public int indice_contact { get; set; }
        public string numero_telephone_1 { get; set; }
        public string numero_telephone_2 { get; set; }
        public string numero_telephone_3 { get; set; }
        public string adresse_email { get; set; }
        public string numero_fax { get; set; }
        public int ? indice_assurance { get; set; }
    }
}
