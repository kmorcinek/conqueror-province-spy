using System;
using System.Windows.Input;

namespace ProvinceSpy.WpfGui.ViewModels
{
    public class CultureViewModel : ViewModelBase
    {
        private CultureLevel cultureLevel = CultureLevel.Primitive;
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
                        param => OnWasUpdated() == false && CultureLevel != CultureLevel.Advanced);
                }
                return upgradeCultureCommand;
            }
        }

        private void UpgradeCulture()
        {
            var intValue = (int)CultureLevel;
            intValue++;
            OnModelUpdated();
            CultureLevel = (CultureLevel)intValue;
        }
    }
}