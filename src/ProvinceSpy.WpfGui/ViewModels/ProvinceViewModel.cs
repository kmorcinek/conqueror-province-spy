using System.ComponentModel;
using ProvinceSpy.WpfGui.Annotations;

namespace ProvinceSpy.WpfGui.ViewModels
{
    public class ProvinceViewModel : INotifyPropertyChanged
    {
        public string ProvinceName { get; set; }
        public FarmsViewModel FarmsViewModel { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}