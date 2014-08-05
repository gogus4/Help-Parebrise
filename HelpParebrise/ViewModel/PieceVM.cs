using HelpParebrise.Data;
using HelpParebrise.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpParebrise.ViewModel
{
    class PieceVM
    {
        private static PieceVM _instance = null;
        public static PieceVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PieceVM();
                return _instance;
            }
        }

        private ObservableCollection<Piece> _pieces = null;
        public ObservableCollection<Piece> Pieces
        {
            get
            {
                if (_pieces == null)
                    _pieces = new ObservableCollection<Piece>();
                return _pieces;
            }
        }

        public PieceVM()
        {
            
        }

        public async Task<List<String>> deletePiece(Piece _piece)
        {
            try
            {
                if (await SQLDataHelper.Instance.deletePiece(_piece))
                    return new List<String> { "Succès", "L'enregistrement en base de données s'est correctement déroulé." };

                else
                    return new List<String> { "Echec", "Le contact est peut être déja présente dans votre stock." };
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return new List<String> { "Echec", e.Message };
            }
        }

        public async Task<List<String>> updatePiece(Piece _piece)
        {
            try
            {
                if (await SQLDataHelper.Instance.updatePiece(_piece))
                    return new List<String> { "Succès", "L'enregistrement en base de données s'est correctement déroulé." };

                else
                    return new List<String> { "Echec", "La pièce est peut être déja présente dans votre stock." };
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return new List<String> { "Echec", e.Message };
            }
        }

        public async Task<List<String>> insertPiece(Piece _piece)
        {
            try
            {
                if (await SQLDataHelper.Instance.insertPiece(_piece))
                    return new List<String> { "Succès", "La mise à jour en base de données s'est correctement déroulé." };
                else
                    return new List<String> { "Echec", "La mise en base de données a échouée." };
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return new List<String> { "Echec", e.Message };
            }
        }

        public async void getPieces()
        {
            _pieces = await SQLDataHelper.Instance.getPieces();
        }
    }
}
