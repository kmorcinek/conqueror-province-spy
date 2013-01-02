using System;
using System.Windows.Input;

namespace ProvinceSpy.WpfGui.ViewModels
{
    public class ProvinceViewModel : ViewModelBase
    {
        public event Action<ProvinceViewModel> ProvinceRemoved = delegate {  };

        // TODO not a INPC
        private bool isFirstTurn;
        public bool IsFirstTurn
        {
            get { return isFirstTurn; }
            set { 
                isFirstTurn = value;
                WasChildrenChanged = false;
            }
        }
        private bool WasChildrenChanged { get; set; }
        public string ProvinceName { get; set; }
        private FarmsViewModel farmsViewModel;
        public BuildPredictionViewModel BuildPrediction { get; set; }
        public FarmsViewModel SoldiersViewModel { get; set; }

        private CultureViewModel cultureViewModel;
        public CultureViewModel CultureViewModel
        {
            get { return cultureViewModel; }
            set
            {
                value.ModelUpdated += value_ModelUpdated;
                value.WasUpdated += value_WasUpdated;
                SetField(ref cultureViewModel, value, () => CultureViewModel);
            }
        }

        bool value_WasUpdated()
        {
            return WasChildrenChanged;
        }

        void value_ModelUpdated()
        {
            if (IsFirstTurn == false)
                WasChildrenChanged = true;
        }

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