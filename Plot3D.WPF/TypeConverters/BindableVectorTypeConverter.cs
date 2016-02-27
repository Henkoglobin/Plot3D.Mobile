using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plot3D.WPF.Helpers;

namespace Plot3D.WPF.TypeConverters
{
    public class BindableVectorTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(String)) return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(BindableVector3)) return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var values = ((string)value).Split(',').Select(x => Double.Parse(x)).ToArray();
            return new BindableVector3()
            {
                X = values[0],
                Y = values[1],
                Z = values[2]
            };
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var vector = (BindableVector3)value;
            return $"{vector.X},{vector.Y},{vector.Z}";
        }
    }
}
