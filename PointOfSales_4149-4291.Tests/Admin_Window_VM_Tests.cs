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
    public class AdminWindowVMTests
    {
        [Fact]
        public void IsUserChanged_WithNoSelectedUser_ShouldReturnFalse()
        {
            
            var viewModel = new Admin_Window_VM();

            
            var isUserChanged = viewModel.Is_UserChanged;

            
            Assert.False(isUserChanged);
        }

        [Fact]
        public void IsUserChanged_WithSelectedUser_ShouldReturnTrue()
        {
           
            var viewModel = new Admin_Window_VM();
            viewModel.selected_User = new User { Id = 1 };

            
            var isUserChanged = viewModel.Is_UserChanged;

           
            Assert.True(isUserChanged);
        }

        [Fact]
        public void User_Type_WhenUserChanged_ShouldReturnSelectedUserType()
        {
            
            var viewModel = new Admin_Window_VM();
            viewModel.selected_User = new User { Id = 1, UserType = "admin" };

          
            var userType = viewModel.User_Type;

          
            Assert.Equal("admin", userType);
        }

        [Fact]
        public void First_Name_WhenUserChanged_ShouldReturnSelectedFirstName()
        {
            
            var viewModel = new Admin_Window_VM();
            viewModel.selected_User = new User { Id = 1, FirstName = "John" };

            
            var firstName = viewModel.First_Name;

          
            Assert.Equal("John", firstName);
        }

        [Fact]
        public void Last_Name_WhenUserChanged_ShouldReturnSelectedLastName()
        {
             
            var viewModel = new Admin_Window_VM();
            viewModel.selected_User = new User { Id = 1, LastName = "Doe" };

             
            var lastName = viewModel.Last_Name;

             
            Assert.Equal("Doe", lastName);
        }

        [Fact]
        public void User_Name_WhenUserChanged_ShouldReturnSelectedUserName()
        {
             
            var viewModel = new Admin_Window_VM();
            viewModel.selected_User = new User { Id = 1, UserName = "johndoe" };

             
            var userName = viewModel.User_Name;

             
            Assert.Equal("johndoe", userName);
        }

        [Fact]
        public void Pass_Word_WhenUserChanged_ShouldReturnSelectedPassword()
        {
             
            var viewModel = new Admin_Window_VM();
            viewModel.selected_User = new User { Id = 1, Password = "password123" };

             
            var password = viewModel.Pass_Word;

             
            Assert.Equal("password123", password);
        }



    }
}

