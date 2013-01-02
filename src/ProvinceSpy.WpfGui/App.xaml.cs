using System.Windows;
using Autofac;

namespace ProvinceSpy.WpfGui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new NeededTurnsCalculator()).As<INeededTurnsCalculator>().SingleInstance();

            AutofacServiceLocator.Container = builder.Build();
        }
    }
}
