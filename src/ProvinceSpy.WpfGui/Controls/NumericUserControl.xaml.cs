using System.Windows.Controls;

namespace ProvinceSpy.WpfGui.Controls
{
    public partial class NumericUserControl : UserControl
    {
        public NumericUserControl()
        {
            InitializeComponent();
        }

        protected NumericUserControl(string label)
            :this()
        {
            lbl.Content = label;
        }
    }
}
