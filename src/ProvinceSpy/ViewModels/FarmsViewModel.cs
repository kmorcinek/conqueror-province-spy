using System.Windows.Input;

namespace ProvinceSpy.ViewModels
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

        RelayCommand increaseCount;
        public ICommand IncreaseCount
        {
            get
            {
                if (increaseCount == null)
                {
                    increaseCount = new RelayCommand(param => this.FarmsCount++,
                        param => true);
                }
                return increaseCount;
            }
        }
    }
}