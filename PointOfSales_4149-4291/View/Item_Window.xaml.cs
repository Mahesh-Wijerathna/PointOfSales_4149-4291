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
    /// Interaction logic for Item_Window.xaml
    /// </summary>
   
        public partial class Item_Window : Window
        {
            public Item_Window()
            {
                InitializeComponent();
            }
            public Item_Window(int id)
            {
                InitializeComponent();
                DataContext = new Item_Window_VM(id);
            }
            public Item_Window(int id, string keyword)
            {
                InitializeComponent();
                DataContext = new Item_Window_VM(id, keyword);
            }


        }
    }

