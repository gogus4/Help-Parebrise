using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpParebrise.Model
{
    public class PieceIntervention
    {
        public int indice_piece_intervention { get; set; }
        public int indice_intervention { get; set; }
        public int indice_piece { get; set; }
        public int quantite { get; set; }
        public double remise { get; set; }

        // Add
        public string reference { get; set; }
        public string designation { get; set; }
        public double prix { get; set; }
    }
}
