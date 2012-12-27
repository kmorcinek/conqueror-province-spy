using System;
using System.Windows.Input;

namespace ProvinceSpy.ViewModels
{
    public class ProvinceViewModel : ViewModelBase
    {
        public event Action<ProvinceViewModel> ProvinceRemoved = delegate {  };

        // TODO not a INPC
        public string ProvinceName { get; set; }
        private FarmsViewModel farmsViewModel;
        public BuildPredictionViewModel BuildPrediction { get; set; }
        public FarmsViewModel SoldiersViewModel { get; set; }
        public CultureViewModel CultureViewModel { get; set; }

        public FarmsViewModel FarmsViewModel 
        { 
            get { return farmsViewModel; }
            set { SetField(ref farmsViewModel, value, () => FarmsViewModel); }
        }

        RelayCommand removeProvinceCommand;
        public ICommand RemoveProvinceCommand
        {
            get
            {
                if (removeProvinceCommand == null)
                {
                    removeProvinceCommand = new RelayCommand(param => this.ProvinceRemoved(this),
                        param => true);
                }
                return removeProvinceCommand;
            }
        }
    }
}