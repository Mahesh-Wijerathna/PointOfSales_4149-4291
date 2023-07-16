using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PointOfSales_4149_4291.ViewModel
{
    public partial class MessageWindow_VM : ObservableObject
    {
        [ObservableProperty]
        public string? title;
        [ObservableProperty]
        public string? message;
        [ObservableProperty]
        public string? buttonText;

        public bool isConformed;

        [RelayCommand]
        public void Main_Button()
        {
            isConformed = true;
            Close_Button();
        }
        [RelayCommand]
        public void Close_Button()
        {
            foreach (Window windw in Application.Current.Windows)
                if (windw.DataContext == this) windw.Close();
        }

        public MessageWindow_VM(string title, string message, string buttonText)
        {
            Title = title;
            Message = message;
            ButtonText = buttonText;
            isConformed = false;

        }

        public MessageWindow_VM()
        {
        }
    }
}

