namespace ProvinceSpy.ViewModels
{
    public class ProvinceViewModel : ViewModelBase
    {
        // TODO not a INPC
        public string ProvinceName { get; set; }
        private FarmsViewModel farmsViewModel;
        public BuildPredictionViewModel BuildPrediction { get; set; }

        public FarmsViewModel FarmsViewModel 
        { 
            get { return farmsViewModel; }
            set { SetField(ref farmsViewModel, value, () => FarmsViewModel); }
        }

    }
}