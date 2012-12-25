using System.ComponentModel;
using ProvinceSpy.WpfGui.Annotations;

namespace ProvinceSpy.WpfGui.ViewModels
{
    public class FarmsViewModel : INotifyPropertyChanged
    {
        private int farmsCount = 1;
        public int FarmsCount 
        { 
            get { return this.farmsCount; }
            set
            {
                if(this.farmsCount == value) return;
                this.farmsCount = value;
                OnPropertyChanged("FarmsCount");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}