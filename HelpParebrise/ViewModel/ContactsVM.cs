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
    class ContactsVM
    {
        private static ContactsVM _instance = null;
        public static ContactsVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ContactsVM();
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

        public ContactsVM()
        {

        }

        public async void getContacts()
        {
            _contacts = await SQLDataHelper.Instance.getContacts();
        }

        public void updateSupplier(Contact _contact)
        {
            /*try
            {
                var supplier = db.Assurances.Where(x => x.IndiceAssurance == _contact.IndiceContact);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }*/
        }
    }
}