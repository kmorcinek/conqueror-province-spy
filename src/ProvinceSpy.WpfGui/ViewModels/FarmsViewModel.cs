using ProvinceSpy.WpfGui.Common;

namespace ProvinceSpy.WpfGui.ViewModels
{
    public class FarmsViewModel : ViewModelBase
    {
        private int farmsCount = 1;
        public int FarmsCount 
        { 
            get { return this.farmsCount; }
            set
            {
                SetField(ref this.farmsCount, value, () => this.FarmsCount);
            }
        }
    }
}