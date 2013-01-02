using Autofac;

namespace ProvinceSpy.WpfGui.ViewModels
{
    public class TurnsNeededViewModel
    {
        public int CalculateIt()
        {
            var revision = new ProvinceRevision(1, 0, 0);
            var calculator = AutofacServiceLocator.Container.Resolve<INeededTurnsCalculator>();
            
            return calculator.Calculate(revision, Buildings.Unknown);
        }
    }
}