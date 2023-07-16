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
    public partial class User_Window_VM : ObservableObject
    {
        public int temp_id;
        public string? temp_nic;
        public string? temp_firstName;
        public string? temp_lastName;
        public bool Message_Box(string title, string message, string buttontext)
        {
            MessageWindow_VM tep = new MessageWindow_VM(title, message, buttontext);
            Message_Window tp = new Message_Window(tep);
            tp.ShowDialog();
            return tep.isConformed;
        }

        public string? First_Name
        {
            get
            {
                if (Is_UserChanged)
                {
                    num_of_notified = 1;
                    temp_firstName = Selected_Customer.FirstName;
                    return Selected_Customer.FirstName;
                }
                return temp_firstName;
            }
            set
            {
                num_of_notified++;
                temp_firstName = value;
            }
        }

        public string? Last_Name
        {
            get
            {
                if (Is_UserChanged)
                {
                    num_of_notified = 1;
                    temp_lastName = Selected_Customer.Last_Name;
                    return Selected_Customer.Last_Name;
                }
                return temp_lastName;
            }
            set
            {
                num_of_notified++;
                temp_lastName = value;
            }
        }

        [ObservableProperty]
        public string? search_Box;

        public int num_of_notified;

        public bool Is_UserChanged
        {
            get
            {
                if (Selected_Customer == null)
                    return false;
                if (Selected_Customer.Id != temp_id || num_of_notified > 0)
                {
                    if (Selected_Customer.Id != temp_id)
                        num_of_notified = 1;
                    temp_id = Selected_Customer.Id;
                    if (num_of_notified == 0 || num_of_notified == 1)
                        return true;
                    return false;
                }
                return false;
            }

        }
        public string? NIC_Number
        {
            get
            {
                if (Is_UserChanged)
                {
                    num_of_notified = 1;
                    temp_nic = Selected_Customer.NicNumber;
                    return Selected_Customer.NicNumber;
                }
                return temp_nic;
            }
            set
            {
                num_of_notified++;
                temp_nic = value;
            }
        }

        
        public ObservableCollection<Customer> Customer_List { get; set; }

        [NotifyPropertyChangedFor(nameof(NIC_Number))]
        [NotifyPropertyChangedFor(nameof(First_Name))]
        [NotifyPropertyChangedFor(nameof(Last_Name))]
        [ObservableProperty]
        public Customer? selected_Customer;


        [RelayCommand]
        public void Search_Button()
        {
            using (var data_base = new DatabaseContext())
            {
                
                if (Search_Box == null || Search_Box == "")
                {
                    User_Window temp = new User_Window();
                    temp.Show();
                }

                else
                {
                    User_Window temp = new User_Window(Search_Box);
                    temp.Show();
                }
                foreach (Window windw in Application.Current.Windows)
                    if (windw.DataContext == this) windw.Close();




            }
        }
        [RelayCommand]
        public void Add_And_View_Goods_Button()
        {
            if (Selected_Customer == null) Message_Box("Warning", "No Student was Selected", "OK");
            else
            {

                Item_Window temp = new Item_Window(Selected_Customer.Id);
                temp.Show();
                
                foreach (Window windw in Application.Current.Windows)
                    if (windw.DataContext == this) windw.Close();
            }
        }
        [RelayCommand]
        public void Add_Button()
        {
            using (var data_base = new DatabaseContext())
            {

                int t_id = 1;
                if (Customer_List.Count > 0) t_id = data_base.Customers_table.Max(x => x.Id) + 1;
                while (data_base.Customers_table.Any(x => x.Id == t_id)) t_id++;
                if (temp_nic == null && (temp_firstName == null || temp_lastName == null)) Message_Box("Warning", "Please fill all deatels", "OK");
                else if (data_base.Customers_table.Any(x => x.NicNumber == temp_nic)) Message_Box("Warning", "Nic number has been\n already registerd", "OK");
                else
                {
                    Customer temp = new Customer()
                    {

                        Id = t_id,

                        NicNumber = temp_nic,
                        FirstName = temp_firstName,
                        Last_Name = temp_lastName,
                        Totle = 0
                    };
                    data_base.Add(temp);

                    Customer_List.Add(temp);

                    data_base.SaveChanges();
                }








            }

        }
        [RelayCommand]
        public void Delete_Button()
        {
            if (Selected_Customer == null) Message_Box("Warning", "No Student was Selected", "OK");
            else
            {
                {
                    using (var data_base = new DatabaseContext())
                    {


                        if (Message_Box("Warning", "Customer will be removed", "Remove"))
                        {
                            data_base.Remove(Selected_Customer);

                            Customer_List.Remove(Selected_Customer);

                            data_base.SaveChanges();
                        }

                    }
                }
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

        

        public User_Window_VM()
        {

            
            using (var data_base = new DatabaseContext())
            {
                
                var adminlist = data_base.Customers_table.OrderBy(u => u.NicNumber).ToList();
                Customer_List = new ObservableCollection<Customer>(adminlist);


            }
        }
        public User_Window_VM(string keyWord)
        {
            
            using (var data_base = new DatabaseContext())
            {
                
                var adminlist = data_base.Customers_table.Where(u => u.NicNumber == keyWord || u.FirstName == keyWord || u.Last_Name == keyWord).ToList();

                Customer_List = new ObservableCollection<Customer>(adminlist);


            }
        }
    }
}
