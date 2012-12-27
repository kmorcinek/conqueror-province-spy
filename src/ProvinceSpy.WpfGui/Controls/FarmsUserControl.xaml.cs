using System.Windows.Controls;

namespace ProvinceSpy.WpfGui.Controls
{
    public partial class FarmsUserControl : UserControl
    {
        public FarmsUserControl()
        {
            InitializeComponent();
        }

        protected FarmsUserControl(string label)
            :this()
        {
            lbl.Content = label;
        }
    }
}
