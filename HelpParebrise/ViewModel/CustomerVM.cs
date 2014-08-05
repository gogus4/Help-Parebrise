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
    class CustomerVM
    {
        private static CustomerVM _instance = null;
        public static CustomerVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CustomerVM();
                return _instance;
            }
        }

        private ObservableCollection<Client> _customers = null;
        public ObservableCollection<Client> Customers
        {
            get
            {
                if (_customers == null)
                    _customers = new ObservableCollection<Client>();
                return _customers;
            }
        }

        public CustomerVM()
        {

        }

        public async void getCustomers()
        {
            _customers = await SQLDataHelper.Instance.getCustomers();
        }

        public async Task<List<String>> updateCustomer(Client _customer)
        {
            try
            {
                if (await SQLDataHelper.Instance.updateCustomer(_customer))
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

        public async Task<List<String>> insertCustomer(Client _customer)
        {
            try
            {
                if (await SQLDataHelper.Instance.addCustomer(_customer))
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