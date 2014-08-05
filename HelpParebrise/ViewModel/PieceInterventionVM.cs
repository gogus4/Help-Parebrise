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
    class PieceInterventionVM
    {
        private static PieceInterventionVM _instance = null;
        public static PieceInterventionVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PieceInterventionVM();
                return _instance;
            }
        }

        private ObservableCollection<PieceIntervention> _piecesIntervention = null;
        public ObservableCollection<PieceIntervention> PiecesIntervention
        {
            get
            {
                if (_piecesIntervention == null)
                    _piecesIntervention = new ObservableCollection<PieceIntervention>();
                return _piecesIntervention;
            }
        }

        public PieceInterventionVM()
        {
            
        }

        public async void getPiecesIntervention()
        {
            _piecesIntervention = await SQLDataHelper.Instance.getPiecesIntervention();
        }

        public async Task<List<String>> insertPieceIntervention(PieceIntervention _piece)
        {
            try
            {
                if (await SQLDataHelper.Instance.insertPieceIntervention(_piece))
                    return new List<String> { "Succès", "L'enregistrement en base de données s'est correctement déroulé." };

                else
                    return new List<String> { "Echec", "La piece est peut être déja présente dans votre stock." };
            }
            catch(Exception e)
            {
                Debug.Write(e.Message);
                return new List<String> { "Echec", e.Message };
            }
        }

        public async Task<List<String>> updatePieceIntervention(PieceIntervention _pieceIntervention)
        {
            try
            {
                if (await SQLDataHelper.Instance.updatePieceIntervention(_pieceIntervention))
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

        public async Task<List<String>> deletePieceIntervention(PieceIntervention _pieceIntervention)
        {
            try
            {
                if (await SQLDataHelper.Instance.deletePieceIntervention(_pieceIntervention))
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
    }
}
