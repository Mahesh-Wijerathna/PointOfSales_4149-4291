using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PointOfSales_4149_4291.Database;
using PointOfSales_4149_4291.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PointOfSales_4149_4291.ViewModel
{
    public partial class Login_Window_VM : ObservableObject
    {
        [ObservableProperty]
        public string? windowTitle;
        [ObservableProperty]
        public string? userNAmeHead;
        [ObservableProperty]
        public string? userName;
        [ObservableProperty]
        public string? passWord;
        [ObservableProperty]
        public string? swichButtonText;
        public bool IsAdmin;

        public bool Message_Box(string title, string message, string buttontext)
        {
            MessageWindow_VM tep = new MessageWindow_VM(title, message, buttontext);
            Message_Window tp = new Message_Window(tep);
            tp.ShowDialog();
            return tep.isConformed;
        }
        public Login_Window_VM()
        {

        }

        public Login_Window_VM(bool isAdmin)
        {
            IsAdmin = isAdmin;
            if (IsAdmin == false)
            {
                windowTitle = "User Login";
                userNAmeHead = "User Name";
                userName = "user";
                passWord = "user";
                swichButtonText = "Login as admin";
            }
            else if (IsAdmin == true)
            {
                windowTitle = "Admin Login";
                userNAmeHead = "Admin Name";
                userName = "admin";
                passWord = "admin";
                swichButtonText = "Login as User";
            }
        }


        [RelayCommand]
        public void Login_Button()
        {
            using (var data_base = new DatabaseContext())
            {

                if (IsAdmin == false)
                {
                    if (data_base.UserAndAdmins_list.Any(user => user.UserType == "user" && user.UserName == UserName && user.Password == PassWord))
                    {
                        User_Window temp = new User_Window();
                        temp.Show();


                        Close_Button();


                    }
                    else Message_Box("Alert", " Please check \n Username And Password again", "OK");
                }
                else
                {
                    if (data_base.UserAndAdmins_list.Any(user => user.UserType == "admin" && user.UserName == UserName && user.Password == PassWord))
                    {


                        Admin_Window temp = new Admin_Window(new Admin_Window_VM());
                        temp.Show();
                        Close_Button();
                    }
                    else Message_Box("Alert", " Please check \n Adminname And Password again", "OK");
                }










            }
        }
        [RelayCommand]
        public void Switch_Button()
        {
             

            if (!IsAdmin)
            {
                Login_Window temp = new Login_Window(true);
                temp.Show();
            }
            else
            {
                Login_Window temp = new Login_Window(false);
                temp.Show();
            }
            Close_Button();


        }
        [RelayCommand]
        public void Close_Button()
        {
            foreach (Window windw in Application.Current.Windows)
                if (windw.DataContext == this) windw.Close();
        }
        [RelayCommand]
        public void MinimizeButton()
        {
            foreach (Window windw in Application.Current.Windows)
                if (windw.DataContext == this) windw.WindowState = WindowState.Minimized;
        }






    }
}

