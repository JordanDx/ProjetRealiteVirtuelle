using BibDeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProjetRealiteVirtuelle
{
    public class ElemType2Image : IValueConverter
    {
        static Dictionary<ElemType, string> images = new Dictionary<ElemType, string>()
        {
            {ElemType.Feu, "fireball.png"},
            {ElemType.Eau, "waterball.png"},
            {ElemType.Terre, "grassball.png"}
        };

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ElemType elemType = (ElemType)value;
            if (!images.ContainsKey(elemType))
                return null;
            string image = images[elemType];
            Uri source = new Uri(string.Format("Images/Boules/{0}", image), UriKind.RelativeOrAbsolute);
            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
