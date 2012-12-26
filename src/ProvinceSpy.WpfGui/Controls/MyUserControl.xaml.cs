using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProvinceSpy.WpfGui.Controls
{
    /// <summary>
    /// Interaction logic for MyUserControl.xaml
    /// </summary>
    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }

//        public string Title { get; set; }

        public static DependencyProperty LengthProperty = DependencyProperty.Register("Title", typeof(string),
                                                                              typeof(MyUserControl));

        public string Title
        {
            get { return (string)GetValue(LengthProperty); }
            set { SetValue(LengthProperty, value); }
        }
    }
}
