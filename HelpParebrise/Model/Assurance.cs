using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpParebrise.Model
{
    public class Assurance
    {
        public int indice_assurance { get; set; }
        public string nom { get; set; }
        public string adresse { get; set; }
        public string code_postal { get; set; }
        public string ville { get; set; }
        public string numero_telephone { get; set; }
        public string numero_fax { get; set; }
        public string adresse_email { get; set; }
        public int indice_contact { get; set; }
        public string numero_contrat { get; set; }
    }
}
