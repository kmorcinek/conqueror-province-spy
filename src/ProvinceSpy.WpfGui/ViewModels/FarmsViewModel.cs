using System.Windows.Input;

namespace ProvinceSpy.WpfGui.ViewModels
{
    public class FarmsViewModel : EventBasedViewModel
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

        RelayCommand increaseCountCommand;
        public ICommand IncreaseCountCommand
        {
            get
            {
                if (increaseCountCommand == null)
                {
                    increaseCountCommand = new RelayCommand(param => IncreaseCount(),
                        param => OnWasUpdated() == false);
                }
                return increaseCountCommand;
            }
        }

        private void IncreaseCount()
        {
            this.FarmsCount++;
            OnModelUpdated();
        }
    }
}