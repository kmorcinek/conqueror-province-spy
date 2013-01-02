using System;
using System.Windows.Input;

namespace ProvinceSpy.WpfGui.ViewModels
{
    public class ProvinceViewModel : ViewModelBase
    {
        public event Action<ProvinceViewModel> ProvinceRemoved = delegate { };

        // TODO not a INPC

        private bool isFirstTurn;
        public bool IsFirstTurn
        {
            get { return isFirstTurn; }
            set
            {
                isFirstTurn = value;
                WasChildrenChanged = false;
            }
        }

        private bool WasChildrenChanged { get; set; }
        public string ProvinceName { get; set; }
        public BuildPredictionViewModel BuildPrediction { get; set; }
        
        private ResourceViewModel resourceViewModel;
        public ResourceViewModel ResourceViewModel
        {
            get { return resourceViewModel; }
            set
            {
                SetEvents(value);
                SetField(ref resourceViewModel, value, () => ResourceViewModel);
            }
        }

        private NumericViewModel soldiersViewModel;
        public NumericViewModel SoldiersViewModel
        {
            get { return soldiersViewModel; }
            set
            {
                SetEvents(value);
                SetField(ref soldiersViewModel, value, () => SoldiersViewModel);
            }
        }

        private CultureViewModel cultureViewModel;
        public CultureViewModel CultureViewModel
        {
            get { return cultureViewModel; }
            set
            {
                SetEvents(value);
                SetField(ref cultureViewModel, value, () => CultureViewModel);
            }
        }

        private NumericViewModel farmsViewModel;
        public NumericViewModel FarmsViewModel
        {
            get { return farmsViewModel; }
            set
            {
                SetEvents(value);
                SetField(ref farmsViewModel, value, () => FarmsViewModel);
            }
        }

        private void SetEvents(EventBasedViewModel value)
        {
            value.ModelUpdated += () =>
                {
                    if (IsFirstTurn == false)
                        WasChildrenChanged = true;
                };
            value.WasUpdated += () => WasChildrenChanged;
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