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
    class TypePrestationVM
    {
        private static TypePrestationVM _instance = null;
        public static TypePrestationVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TypePrestationVM();
                return _instance;
            }
        }

        private ObservableCollection<Prestation> _typePrestations = null;
        public ObservableCollection<Prestation> TypePrestations
        {
            get
            {
                if (_typePrestations == null)
                    _typePrestations = new ObservableCollection<Prestation>();
                return _typePrestations;
            }
        }

        public TypePrestationVM()
        {

        }

        public async void getTypePrestations()
        {
            _typePrestations = await SQLDataHelper.Instance.getPrestation();
        }
    }
}