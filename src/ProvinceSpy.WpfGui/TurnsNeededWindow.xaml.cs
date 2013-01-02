using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Autofac;

namespace ProvinceSpy.WpfGui
{
    public partial class TurnsNeededWindow : Window
    {
        private readonly Dictionary<Buildings, string> keyValues = new Dictionary<Buildings, string>
            {
                { Buildings.Farm, Buildings.Farm.ToString() },
                { Buildings.Culture, Buildings.Culture.ToString() },
            };

        private RadioButton[] resources;

        public TurnsNeededWindow()
        {
            InitializeComponent();
            CreateCultureRadioButtons();
        }

        private void CreateCultureRadioButtons()
        {
            resources = new RadioButton[3];

            for (int i = 0; i < 3; i++)
            {
                var button = new RadioButton();
                button.Content = i;
                button.Checked += button_Checked;
                button.Tag = i;

                resources[i] = button;
                stack.Children.Add(button);
            }

            resources[0].IsChecked = true;
        }

        private void button_Checked(object sender, RoutedEventArgs e)
        {
            UpdateCalculations();
        }

        private void UpdateCalculations()
        {
            if (labelsStacks == null)
                return;

            labelsStacks.Children.Clear();

            int top = 10;
            foreach (var keyValue in keyValues)
            {
                Label label = new Label();
                label.Content = keyValue.Value + " " + CalculateIt(keyValue.Key);
                label.Margin = new Thickness(20, top, 0, 0);
                top += 20;
                labelsStacks.Children.Add(label);
            }
        }

        public int CalculateIt(Buildings building)
        {
            var revision = ProvinceRevisionFactory.FromFarmsAndCulture((int)farmsSlider.Value + GetResources(), CultureLevel.Primitive);
            var calculator = AutofacServiceLocator.Container.Resolve<INeededTurnsCalculator>();

            return calculator.Calculate(revision, building);
        }

        private int GetResources()
        {
            foreach (var resourceButton in resources)
            {
                if (resourceButton.IsChecked.HasValue && resourceButton.IsChecked.Value)
                {
                    return (int)resourceButton.Tag;
                }
            }

            return 0;
        }

        private void FarmsSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateCalculations();
        }
    }
}
