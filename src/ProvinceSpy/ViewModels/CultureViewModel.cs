using System.Windows.Input;

namespace ProvinceSpy.ViewModels
{
    public class CultureViewModel : ViewModelBase
    {
        private CultureLevel cultureLevel = ProvinceSpy.CultureLevel.Primitive;
        public CultureLevel CultureLevel
        {
            get { return this.cultureLevel; }
            set
            {
                SetField(ref this.cultureLevel, value, () => this.CultureLevel);
            }
        }

        RelayCommand upgradeCultureCommand;
        public ICommand UpgradeCultureCommand
        {
            get
            {
                if (upgradeCultureCommand == null)
                {
                    upgradeCultureCommand = new RelayCommand(param => this.UpgradeCulture(),
                        param => CultureLevel != CultureLevel.Advanced);
                }
                return upgradeCultureCommand;
            }
        }

        private void UpgradeCulture()
        {
            var intValue = (int) CultureLevel;
            intValue++;
            CultureLevel = (CultureLevel) intValue;
        }
    }
}