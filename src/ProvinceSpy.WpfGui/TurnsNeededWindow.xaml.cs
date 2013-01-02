using System.Windows;
using System.Windows.Controls;

namespace ProvinceSpy.WpfGui
{
    /// <summary>
    /// Interaction logic for TurnsNeededWindow.xaml
    /// </summary>
    public partial class TurnsNeededWindow : Window
    {
        public TurnsNeededWindow()
        {
            InitializeComponent();
            CreateCultureRadioButtons();
        }

        private void CreateCultureRadioButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                var button = new RadioButton();
                button.Content = i;
                button.Checked += button_Checked;
                stack.Children.Add(button);
            }
        }

        void button_Checked(object sender, RoutedEventArgs e)
        {
            UpdateCalculations();
        }

        private void UpdateCalculations()
        {
            ProvinceRevision revision = new ProvinceRevision(1, 0, 0);

        }
}
