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
    class ModePaiementVM
    {
        private static ModePaiementVM _instance = null;
        public static ModePaiementVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ModePaiementVM();
                return _instance;
            }
        }

        private ObservableCollection<ModePaiement> _modesPaiement = null;
        public ObservableCollection<ModePaiement> ModesPaiement
        {
            get
            {
                if (_modesPaiement == null)
                    _modesPaiement = new ObservableCollection<ModePaiement>();
                return _modesPaiement;
            }
        }

        public ModePaiementVM()
        {

        }

        public async void getModesPaiement()
        {
            _modesPaiement = await SQLDataHelper.Instance.getPaymentMethod();
        }
    }
}