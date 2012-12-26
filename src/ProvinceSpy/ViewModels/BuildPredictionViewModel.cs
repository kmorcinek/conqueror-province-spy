namespace ProvinceSpy.ViewModels
{
    public class BuildPredictionViewModel : ViewModelBase
    {
        public Buildings Building { get; set; }
        private int turnsLeft;
        public int TurnsLeft 
        { 
            get { return this.turnsLeft; }
            set { SetField(ref this.turnsLeft, value, () => TurnsLeft); } 
        } 
    }
}