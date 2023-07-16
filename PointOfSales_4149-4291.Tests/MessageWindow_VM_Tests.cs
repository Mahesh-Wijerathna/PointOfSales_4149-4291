using PointOfSales_4149_4291.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PointOfSales_4149_4291.Tests
{
    public class MessageWindowVMTests
    {


        [Fact]
        public void Title_ShouldSetAndGetCorrectValue()
        {
             
            var viewModel = new MessageWindow_VM();

             
            viewModel.Title = "Test Title";

             
            Assert.Equal("Test Title", viewModel.Title);
        }

        [Fact]
        public void Message_ShouldSetAndGetCorrectValue()
        {
             
            var viewModel = new MessageWindow_VM();

             
            viewModel.Message = "Test Message";

             
            Assert.Equal("Test Message", viewModel.Message);
        }

        [Fact]
        public void ButtonText_ShouldSetAndGetCorrectValue()
        {
             
            var viewModel = new MessageWindow_VM();

             
            viewModel.ButtonText = "Test Button";

             
            Assert.Equal("Test Button", viewModel.ButtonText);
        }

        // Add more tests for other methods and properties as needed...
    }
}


