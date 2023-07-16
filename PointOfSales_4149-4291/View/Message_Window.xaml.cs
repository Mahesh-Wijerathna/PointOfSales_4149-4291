using PointOfSales_4149_4291.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PointOfSales_4149_4291.View
{
    /// <summary>
    /// Interaction logic for Message_Window.xaml
    /// </summary>
    public partial class Message_Window : Window
    {
        public Message_Window()
        {
            InitializeComponent();
        }
        public Message_Window(MessageWindow_VM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
