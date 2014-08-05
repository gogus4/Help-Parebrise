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
    class SupplierVM
    {
        private static SupplierVM _instance = null;
        public static SupplierVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SupplierVM();
                return _instance;
            }
        }

        private ObservableCollection<Fournisseur> _suppliers = null;
        public ObservableCollection<Fournisseur> Suppliers
        {
            get
            {
                if (_suppliers == null)
                    _suppliers = new ObservableCollection<Fournisseur>();
                return _suppliers;
            }
        }

        public SupplierVM()
        {

        }

        public async void getSuppliers()
        {
            _suppliers = await SQLDataHelper.Instance.getSuppliers();
        }

        public async Task<List<String>> insertSupplier(Fournisseur _supplier)
        {
            try
            {
                if (await SQLDataHelper.Instance.insertSupplier(_supplier))
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

        public async Task<List<String>> deleteSupplier(Fournisseur _supplier)
        {
            try
            {
                if (await SQLDataHelper.Instance.deleteSupplier(_supplier))
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

        public async Task<List<String>> updateSupplier(Fournisseur _supplier)
        {
            try
            {
                if (await SQLDataHelper.Instance.updateSupplier(_supplier))
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
