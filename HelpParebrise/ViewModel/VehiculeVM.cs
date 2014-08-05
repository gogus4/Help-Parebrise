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
    class VehiculeVM
    {
        private static VehiculeVM _instance = null;
        public static VehiculeVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new VehiculeVM();
                return _instance;
            }
        }

        private ObservableCollection<Vehicule> _vehicules = null;
        public ObservableCollection<Vehicule> Vehicules
        {
            get
            {
                if (_vehicules == null)
                    _vehicules = new ObservableCollection<Vehicule>();
                return _vehicules;
            }
        }

        public VehiculeVM()
        {

        }

        public async void getVehicules()
        {
            _vehicules = await SQLDataHelper.Instance.getVehicule();
        }

        public async Task<List<string>> insertVehicle(Vehicule _vehicle)
        {
            try
            {
                if (await SQLDataHelper.Instance.insertVehicule(_vehicle))
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

        public async Task<List<String>> updateVehicle(Vehicule _vehicle)
        {
            try
            {
                if (await SQLDataHelper.Instance.updateVehicule(_vehicle))
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