namespace ProvinceSpy.ViewModels
{
    public class ProvinceViewModel : ViewModelBase
    {
        // TODO not a INPC
        public string ProvinceName { get; set; }
        private FarmsViewModel farmsViewModel;
        public BuildPrediction BuildPrediction { get; set; }

        public ProvinceViewModel()
        {
            FarmsViewModel = new FarmsViewModel();
        }

        public FarmsViewModel FarmsViewModel 
        { 
            get { return farmsViewModel; }
            set { SetField(ref farmsViewModel, value, () => FarmsViewModel); }
        }

    }
}