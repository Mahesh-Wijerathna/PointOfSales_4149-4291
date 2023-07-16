using PointOfSales_4149_4291.Model;
using PointOfSales_4149_4291.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PointOfSales_4149_4291.Tests
{
    public class ItemWindowVMTests
    {
        [Fact]
        public void CalcSubtotle_WithNoItems_ShouldReturnZero()
        {
             
            var viewModel = new Item_Window_VM();
            viewModel.Item_List = null;

             
            var subtotle = viewModel.Calc_subtotle();

             
            Assert.Equal(0, subtotle);
        }

        [Fact]
        public void CalcSubtotle_WithItemsMatchingNic_ShouldReturnCorrectSubtotle()
        {
             
            var viewModel = new Item_Window_VM();
            viewModel.Item_List = new ObservableCollection<Item>
            {
                new Item { NIC = "ABC123", Price = 10 },
                new Item { NIC = "XYZ456", Price = 20 },
                new Item { NIC = "ABC123", Price = 30 }
            };
            viewModel.Nic = "ABC123";

             
            var subtotle = viewModel.Calc_subtotle();

             
            Assert.Equal(40, subtotle);
        }

        [Fact]
        public void CalcDiscount_WithNoItems_ShouldReturnZero()
        {
             
            var viewModel = new Item_Window_VM();
            viewModel.Item_List = null;

             
            var discount = viewModel.Calc_discount();

             
            Assert.Equal(0, discount);
        }

        [Fact]
        public void CalcDiscount_WithItemsMatchingNic_ShouldReturnCorrectDiscount()
        {
             
            var viewModel = new Item_Window_VM();
            viewModel.Item_List = new ObservableCollection<Item>
            {
                new Item { NIC = "ABC123", UnitPrice = 10, DiscountPercentage = 20, Quantity = 2 },
                new Item { NIC = "XYZ456", UnitPrice = 20, DiscountPercentage = 15, Quantity = 3 },
                new Item { NIC = "ABC123", UnitPrice = 30, DiscountPercentage = 25, Quantity = 1 }
            };
            viewModel.Nic = "ABC123";

             

        }
    }
}