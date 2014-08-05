using HelpParebrise.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HelpParebrise.Common.Converter
{
    public sealed class InterventionsCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                InterventionVM.Instance.getInterventions();

                var inter = (from c in InterventionVM.Instance.Interventions
                             where c.indice_client == int.Parse(value.ToString())
                             select c).ToList();

                return inter.Count;
            }
            catch (Exception e)
            {
                return "0";
            }
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}