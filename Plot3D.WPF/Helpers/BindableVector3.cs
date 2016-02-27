using System.ComponentModel;
using System.Windows;
using Plot3D.WPF.TypeConverters;

namespace Plot3D.WPF.Helpers
{
    [TypeConverter(typeof(BindableVectorTypeConverter))]
    public class BindableVector3 : DependencyObject, INotifyPropertyChanged
    {
        public double X
        {
            get { return (double)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double), typeof(BindableVector3), new PropertyMetadata(0.0, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var self = (BindableVector3)d;
            self.PropertyChanged?.Invoke(self, new PropertyChangedEventArgs(e.Property.Name));
        }

        public double Y
        {
            get { return (double)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double), typeof(BindableVector3), new PropertyMetadata(0.0, OnPropertyChanged));

        public double Z
        {
            get { return (double)GetValue(ZProperty); }
            set { SetValue(ZProperty, value); }
        }

        public static readonly DependencyProperty ZProperty =
            DependencyProperty.Register("Z", typeof(double), typeof(BindableVector3), new PropertyMetadata(0.0, OnPropertyChanged));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
