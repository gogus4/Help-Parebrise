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
    class TvaVM
    {
        private static TvaVM _instance = null;
        public static TvaVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TvaVM();
                return _instance;
            }
        }

        private ObservableCollection<Tva> _tva = null;
        public ObservableCollection<Tva> TVA
        {
            get
            {
                if (_tva == null)
                    _tva = new ObservableCollection<Tva>();
                return _tva;
            }
        }

        public TvaVM()
        {

        }

        public async void getTva()
        {
            _tva = await SQLDataHelper.Instance.getTva();
        }

        public List<string> insertTva(Tva tva)
        {
            /*try
            {
                db.Tvas.InsertOnSubmit(tva);
                db.SubmitChanges();

                return new List<String> { "Succès", "L'enregistrement en base de données s'est correctement déroulé." };
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return new List<String> { "Echec", e.Message };
            }*/
            return null;
        }

        public List<String> updateTva(Tva tva)
        {
            /*try
            {
                var supplier = db.Tvas.Where(x => x.IdTva == tva.IdTva);
                db.SubmitChanges();

                return new List<String> { "Succès", "La mise à jour en base de données s'est correctement déroulé." };
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return new List<String> { "Echec", e.Message };
            }*/
            return null;
        }
    }
}