using PointOfSales_4149_4291.Model;
using PointOfSales_4149_4291.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PointOfSales_4149_4291.Tests
{
    public class UserWindowVMTests
    {
        [Fact]
        public void IsUserChanged_WithNoSelectedCustomer_ShouldReturnFalse()
        {
             
            var viewModel = new User_Window_VM();

             
            var isUserChanged = viewModel.Is_UserChanged;

             
            Assert.False(isUserChanged);
        }

        [Fact]
        public void IsUserChanged_WithSelectedCustomer_ShouldReturnTrue()
        {
             
            var viewModel = new User_Window_VM();
            viewModel.selected_Customer = new Customer { Id = 1 };

             
            var isUserChanged = viewModel.Is_UserChanged;

             
            Assert.True(isUserChanged);
        }

        [Fact]
        public void First_Name_WhenUserChanged_ShouldReturnSelectedFirstName()
        {
             
            var viewModel = new User_Window_VM();
            viewModel.selected_Customer = new Customer { Id = 1, FirstName = "John" };

             
            var firstName = viewModel.First_Name;

             
            Assert.Equal("John", firstName);
        }

        [Fact]
        public void Last_Name_WhenUserChanged_ShouldReturnSelectedLastName()
        {
             
            var viewModel = new User_Window_VM();
            viewModel.selected_Customer = new Customer { Id = 1, Last_Name = "Doe" };

             
            var lastName = viewModel.Last_Name;

             
            Assert.Equal("Doe", lastName);
        }


    }
}
