using System.Windows.Input;

namespace ProvinceSpy.WpfGui.ViewModels
{
    public class NumericViewModel : EventBasedViewModel
    {
        private int count = 1;
        public int Count 
        { 
            get { return this.count; }
            set
            {
                SetField(ref this.count, value, () => this.Count);
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
            this.Count++;
            OnModelUpdated();
        }
    }
}