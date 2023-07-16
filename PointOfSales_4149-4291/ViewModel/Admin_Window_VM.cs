using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PointOfSales_4149_4291.Database;
using PointOfSales_4149_4291.Model;
using PointOfSales_4149_4291.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PointOfSales_4149_4291.ViewModel
{
    public partial class Admin_Window_VM : ObservableObject
    {
        
        public ObservableCollection<User> Userlist { get; set; }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Is_UserChanged))]
        [NotifyPropertyChangedFor(nameof(User_Type))]
        [NotifyPropertyChangedFor(nameof(First_Name))]
        [NotifyPropertyChangedFor(nameof(Last_Name))]
        [NotifyPropertyChangedFor(nameof(User_Name))]
        [NotifyPropertyChangedFor(nameof(Pass_Word))]
        public User? selected_User;

        [ObservableProperty]
        public string[] userTypeList = { "user", "admin" };

        
        public string SearchBoxText { get; set; }


        public int isFirstTime;
        public int numOfNotified;
        public int temp_id;
        public string temp_usertype;
        public string tepmname;
        public string temp_lastname;
        public string temp_username;
        public string temp_password;

        public bool Message_Box(string title, string message, string buttontext)
        {
            MessageWindow_VM tep = new MessageWindow_VM(title, message, buttontext);
            Message_Window tp = new Message_Window(tep);
            tp.ShowDialog();
            return tep.isConformed;
        }





        public bool Is_UserChanged
        {
            get
            {
                if (Selected_User == null)
                    return false;
                if (Selected_User.Id != temp_id || numOfNotified > 0)
                {
                    if (Selected_User.Id != temp_id)
                        numOfNotified = 1;
                    temp_id = Selected_User.Id;
                    if (numOfNotified == 0 || numOfNotified == 1)
                        return true;
                    return false;
                }
                return false;
            }

        }
        public string User_Type
        {
            get
            {
                if (Is_UserChanged)
                {
                    numOfNotified = 1;
                    temp_usertype = Selected_User.UserType;
                    return Selected_User.UserType;
                }
                return temp_usertype;
            }
            set
            {
                numOfNotified++;
                temp_usertype = value;
            }
        }
        public string First_Name
        {
            get
            {
                if (Is_UserChanged)
                {
                    numOfNotified = 1;
                    tepmname = Selected_User.FirstName;
                    return Selected_User.FirstName;
                }
                return tepmname;
            }
            set
            {
                numOfNotified++;
                tepmname = value;
            }
        }

        public string Last_Name
        {
            get
            {
                if (Is_UserChanged)
                {
                    numOfNotified = 1;
                    temp_lastname = Selected_User.LastName;
                    return Selected_User.LastName;
                }
                return temp_lastname;

            }
            set
            {
                numOfNotified++;
                temp_lastname = value;
            }
        }
        public string User_Name
        {
            get
            {
                if (Is_UserChanged)
                {
                    numOfNotified = 1;
                    temp_username = Selected_User.UserName;
                    return Selected_User.UserName;
                }
                return temp_username;

            }
            set
            {
                numOfNotified++;
                temp_username = value;
            }
        }
        public string Pass_Word
        {
            get
            {
                if (Is_UserChanged)
                {
                    numOfNotified = 1;
                    temp_password = Selected_User.Password;
                    return Selected_User.Password;
                }
                return temp_password;

            }
            set
            {
                numOfNotified++;
                temp_password = value;
            }
        }




        public Admin_Window_VM()
        {
            
            temp_id = -1;
            numOfNotified = 0;
            
            using (var data_base = new DatabaseContext())
            {
                
                var adminlist = data_base.UserAndAdmins_list.OrderBy(u => u.UserType).ToList();
                Userlist = new ObservableCollection<User>(adminlist);


            }
        }
        public Admin_Window_VM(string keyWord)
        {
            
            using (var data_base = new DatabaseContext())
            {
                
                var adminlist = data_base.UserAndAdmins_list.Where(u => u.UserType == keyWord || u.FirstName == keyWord || u.LastName == keyWord || u.UserName == keyWord).ToList();

                Userlist = new ObservableCollection<User>(adminlist);


            }
        }

        
        [RelayCommand]
        public void Save()
        {
            if (Selected_User == null) Message_Box("Warning", "No Student was Selected", "OK");
            else
                using (var data_base = new DatabaseContext())
                {
                    User p = new User()
                    {
                        Id = temp_id,
                        UserType = temp_usertype,
                        FirstName = tepmname,
                        LastName = temp_lastname,
                        UserName = temp_username,
                        Password = temp_password,

                    };


                    data_base.Remove(Selected_User);
                    data_base.Add(p);
                    Userlist.Remove(Selected_User);
                    Userlist.Add(p);
                    data_base.SaveChanges();

                }
        }
        [RelayCommand]
        public void Add()
        {
            if (temp_usertype == null || tepmname == null || temp_lastname == null || temp_username == null || temp_password == null) Message_Box("Warning", "Please Enter All Deatels", "OK");

            else
                using (var data_base = new DatabaseContext())
                {
                    User p = new User()
                    {
                        
                        UserType = temp_usertype,
                        FirstName = tepmname,
                        LastName = temp_lastname,
                        UserName = temp_username,
                        Password = temp_password,

                    };



                    data_base.Add(p);

                    Userlist.Add(p);
                    data_base.SaveChanges();

                }
        }
        [RelayCommand]
        public void Delete()
        {
            if (Selected_User == null) Message_Box("Warning", "No Student was Selected", "OK");
            else
                using (var data_base = new DatabaseContext())
                {

                    if (Message_Box("Warning", "Item will be removed", "Remove"))
                    {

                        data_base.Remove(Selected_User);

                        Userlist.Remove(Selected_User);

                        data_base.SaveChanges();
                    }

                }
        }
        [RelayCommand]
        public void Search()
        {
            using (var data_base = new DatabaseContext())
            {
                
                if (SearchBoxText == null || SearchBoxText == "")
                {
                    Admin_Window temp = new Admin_Window(new Admin_Window_VM());
                    temp.Show();
                }

                else
                {
                    Admin_Window temp = new Admin_Window(new Admin_Window_VM(SearchBoxText));
                    temp.Show();
                }
                foreach (Window windw in Application.Current.Windows)
                    if (windw.DataContext == this) windw.Close();




            }
        }
        [RelayCommand]
        public void Close_Button()
        {
            Login_Window temp = new Login_Window(false);
            temp.Show();
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
