using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpParebrise.Model
{
    public class Stock
    {
        public int indice_stock { get; set; }
        public int indice_piece { get; set; }
        public int quantite { get; set; }

        public string reference { get; set; }
        public double prix { get; set; }
        public string designation { get; set; }
    }
}
