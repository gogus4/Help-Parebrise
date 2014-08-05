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
    class InterventionVM
    {
        private static InterventionVM _instance = null;
        public static InterventionVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InterventionVM();
                return _instance;
            }
        }

        private ObservableCollection<Intervention> _interventions = null;
        public ObservableCollection<Intervention> Interventions
        {
            get
            {
                if (_interventions == null)
                    _interventions = new ObservableCollection<Intervention>();
                return _interventions;
            }
        }

        public InterventionVM()
        {

        }

        public Intervention getIntervention(int indiceInter)
        {
            return Interventions.Where(x => x.indice_intervention == indiceInter).FirstOrDefault();
        }

        public async void getInterventions()
        {
            _interventions = await SQLDataHelper.Instance.getInterventions();
        }

        public async Task<List<String>> updateIntervention(Intervention _intervention)
        {
            try
            {
                if(await SQLDataHelper.Instance.updateIntervention(_intervention))
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

        public async Task<List<String>> insertIntervention(Intervention _intervention)
        {
            try
            {
                if (await SQLDataHelper.Instance.insertIntervention(_intervention))
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