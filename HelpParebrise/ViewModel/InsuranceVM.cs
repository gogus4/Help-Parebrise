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
    class InsuranceVM
    {
        private static InsuranceVM _instance = null;
        public static InsuranceVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InsuranceVM();
                return _instance;
            }
        }

        private ObservableCollection<Assurance> _insurances = null;
        public ObservableCollection<Assurance> Insurances
        {
            get
            {
                if (_insurances == null)
                    _insurances = new ObservableCollection<Assurance>();
                return _insurances;
            }
        }

        public InsuranceVM()
        {

        }

        public async void getInsurances()
        {
            _insurances = await SQLDataHelper.Instance.getInsurances();
        }

        public async Task<List<string>> insertInsurance(Assurance _insurance)
        {
            try
            {
                if (await SQLDataHelper.Instance.insertInsurance(_insurance))
                    return new List<String> { "Succès", "La mise à jour en base de données s'est correctement déroulé." };

                else
                    return new List<String> { "Echec", "Une erreur est survenu lors de la mise à jour en base de données." };
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return new List<String> { "Echec", e.Message };
            }
        }

        public async Task<List<String>> updateInsurance(Assurance _insurance)
        {
            try
            {
                if (await SQLDataHelper.Instance.updateInsurance(_insurance))
                    return new List<String> { "Succès", "La mise à jour en base de données s'est correctement déroulé." };

                else
                    return new List<String> { "Echec", "Une erreur est survenu lors de la mise à jour en base de données." };
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return new List<String> { "Echec", e.Message };
            }
        }
    }
}