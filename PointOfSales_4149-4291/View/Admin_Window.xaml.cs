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
    /// Interaction logic for Admin_Window.xaml
    /// </summary>
    public partial class Admin_Window : Window
    {
        public Admin_Window(Admin_Window_VM vm)
        {
            InitializeComponent();
            DataContext = vm;

        }
        public Admin_Window(string keyWord)
        {
            InitializeComponent();
            DataContext = new Admin_Window_VM(keyWord);


        }
    }
}
