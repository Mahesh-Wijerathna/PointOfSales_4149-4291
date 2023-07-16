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
    /// Interaction logic for Login_Window.xaml
    /// </summary>
    public partial class Login_Window : Window
    {
        public Login_Window()
        {
            InitializeComponent();
            DataContext = new Login_Window_VM(false);

        }
        public Login_Window(bool isadmin)
        {
            InitializeComponent();
            DataContext = new Login_Window_VM(isadmin);
        }
    }
}
