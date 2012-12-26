namespace ProvinceSpy.ViewModels
{
    public class ProvinceViewModel : ViewModelBase
    {
        // TODO not a INPC
        public string ProvinceName { get; set; }
        public FarmsViewModel FarmsViewModel { get; set; }
        public BuildPrediction BuildPrediction { get; set; }

        public ProvinceViewModel()
        {
            FarmsViewModel = new FarmsViewModel();
        }
    }
}