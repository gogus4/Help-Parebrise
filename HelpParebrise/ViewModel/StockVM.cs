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
    class StockVM
    {
        private static StockVM _instance = null;
        public static StockVM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StockVM();
                return _instance;
            }
        }

        private ObservableCollection<Stock> _stock = null;
        public ObservableCollection<Stock> Stock
        {
            get
            {
                if (_stock == null)
                    _stock = new ObservableCollection<Stock>();
                return _stock;
            }
        }

        public StockVM()
        {
            
        }

        public async void getStock()
        {
            _stock = await SQLDataHelper.Instance.getStock();
        }

        public async Task<List<String>> insertStock(Stock _stock)
        {
            try
            {
                if (await SQLDataHelper.Instance.insertStock(_stock))
                    return new List<String> { "Succès", "La mise à jour en base de données s'est correctement déroulé." };

                else
                    return new List<String> { "Echec", "Une erreur est survenu lors de la mise à jour en base de données." };
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return new List<String> { "Echec", "La piece est peut être déja présente dans votre stock."};
            }
            return null;
        }

        public async Task<List<String>> updateStock(Stock _article)
        {
            try
            {
                if (await SQLDataHelper.Instance.updateStock(_article))
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
