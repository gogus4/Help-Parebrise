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
    class PhotosInterventionVM
    {
        private static PhotosInterventionVM _instance = null;
        public static PhotosInterventionVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PhotosInterventionVM();
                return _instance;
            }
        }

        private ObservableCollection<PhotosIntervention> _photosIntervention = null;
        public ObservableCollection<PhotosIntervention> PhotosIntervention
        {
            get
            {
                if (_photosIntervention == null)
                    _photosIntervention = new ObservableCollection<PhotosIntervention>();
                return _photosIntervention;
            }
        }

        public PhotosInterventionVM()
        {
            
        }

        public async void getPhotosIntervention()
        {
            _photosIntervention = await SQLDataHelper.Instance.getPictures();
        }

        public async Task<List<String>> insertPhotosIntervention(PhotosIntervention _picture)
        {
            try
            {
                if (await SQLDataHelper.Instance.insertPicture(_picture))
                    return new List<String> { "Succès", "L'enregistrement en base de données s'est correctement déroulé." };

                else
                    return new List<String> { "Echec", "La photo est peut être déja présente." };
            }
            catch(Exception e)
            {
                Debug.Write(e.Message);
                return new List<String> { "Echec", e.Message };
            }
        }
    }
}
