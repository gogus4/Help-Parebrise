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
    class ContactVM
    {
        private static ContactVM _instance = null;
        public static ContactVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ContactVM();
                return _instance;
            }
        }

        private ObservableCollection<Contact> _contacts = null;
        public ObservableCollection<Contact> Contacts
        {
            get
            {
                if (_contacts == null)
                    _contacts = new ObservableCollection<Contact>();
                return _contacts;
            }
        }

        public ContactVM()
        {

        }

        public async void getContacts()
        {
            _contacts = await SQLDataHelper.Instance.getContacts();
        }

        public async Task<List<String>> insertContact(Contact _contact)
        {
            try
            {
                if (await SQLDataHelper.Instance.insertContact(_contact))
                    return new List<String> { "Succès", "L'enregistrement en base de données s'est correctement déroulé." };

                else
                    return new List<String> { "Echec", "Une erreur s'est produite lors de l'ajout du contact." };
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return new List<String> { "Echec", e.Message };
            }
        }

        public async Task<List<String>> deleteContact(Contact _contact)
        {
            try
            {
                if (await SQLDataHelper.Instance.deleteContact(_contact))
                    return new List<String> { "Succès", "L'enregistrement en base de données s'est correctement déroulé." };

                else
                    return new List<String> { "Echec", "Le contact est peut être en liaison avec un Client." };
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return new List<String> { "Echec", e.Message };
            }
        }

        public async Task<List<String>> updateContact(Contact _contact)
        {
            try
            {
                if (await SQLDataHelper.Instance.updateContact(_contact))
                    return new List<String> { "Succès", "L'enregistrement en base de données s'est correctement déroulé." };

                else
                    return new List<String> { "Echec", "Le contact est peut être déja présente dans votre stock." };
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return new List<String> { "Echec", e.Message };
            }
        }
    }
}