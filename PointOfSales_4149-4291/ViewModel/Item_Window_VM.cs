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
    public partial class Item_Window_VM : ObservableObject
    {

        Customer? selected_custo;
        private int numofnotify;
        public int temp_id;
        public string? temp_itemName;
        public double temp_unitPrice;
        public int temp_quantity;
        public double temp_discountPercentage;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNewItemSelected))]
        [NotifyPropertyChangedFor(nameof(ItemName))]
        [NotifyPropertyChangedFor(nameof(UnitPrice))]
        [NotifyPropertyChangedFor(nameof(Quantity))]
        [NotifyPropertyChangedFor(nameof(DiscountPercentage))]
        [NotifyPropertyChangedFor(nameof(SubTotal))]
        [NotifyPropertyChangedFor(nameof(Discount))]
        [NotifyPropertyChangedFor(nameof(Total))]
        public Item selected_Item;
        [ObservableProperty]
        public string searchBox;
        [ObservableProperty]
        public string nic;
        [ObservableProperty]
        public string firstName;
        [ObservableProperty]
        public string lastName;


        public ObservableCollection<Item> Item_List { get; set; }

        public bool IsNewItemSelected
        {
            get
            {
                if (Selected_Item == null)
                    return false;
                if (Selected_Item.Id != temp_id || numofnotify > 0)
                {
                    if (Selected_Item.Id != temp_id)
                        numofnotify = 1;
                    temp_id = Selected_Item.Id;
                    if (numofnotify == 0 || numofnotify == 1)
                        return true;
                    return false;
                }
                return false;
            }

        }
        public string? ItemName
        {
            get
            {
                if (IsNewItemSelected)
                {
                    numofnotify = 1;
                    temp_itemName = Selected_Item.ItemName;
                }

                return temp_itemName;
            }
            set
            {
                numofnotify++;
                temp_itemName = value;
            }
        }
        public double UnitPrice
        {
            get
            {
                if (IsNewItemSelected)
                {
                    numofnotify = 1;
                    temp_unitPrice = Selected_Item.UnitPrice;
                }
                return temp_unitPrice;
            }
            set
            {
                numofnotify++;
                temp_unitPrice = value;
            }
        }
        public int Quantity
        {
            get
            {
                if (IsNewItemSelected)
                {
                    numofnotify = 1;
                    temp_quantity = Selected_Item.Quantity;
                }
                return temp_quantity;
            }
            set { numofnotify++; temp_quantity = value; }
        }
        public double DiscountPercentage
        {
            get
            {
                if (IsNewItemSelected)
                {
                    numofnotify = 1;
                    temp_discountPercentage = Selected_Item.DiscountPercentage;
                }
                return temp_discountPercentage;
            }
            set { numofnotify++; temp_discountPercentage = value; }
        }



        public double SubTotal { get { return Calc_subtotle(); } }
        public double Discount { get { return Calc_discount(); } }
        public double Total { get { return (Calc_subtotle() - Calc_discount()); } }
        public bool Message_Box(string title, string message, string buttontext)
        {
            MessageWindow_VM tep = new MessageWindow_VM(title, message, buttontext);
            Message_Window tp = new Message_Window(tep);
            tp.ShowDialog();
            return tep.isConformed;
        }

        [RelayCommand]
        public void SearchButton()
        {
            using (var data_base = new DatabaseContext())
            {
                
                if (SearchBox == null || SearchBox == "")
                {
                    Item_Window temp = new Item_Window(selected_custo.Id);
                    temp.Show();
                }

                else
                {
                    Item_Window temp = new Item_Window(selected_custo.Id, SearchBox);
                    temp.Show();
                }
                foreach (Window windw in Application.Current.Windows)
                    if (windw.DataContext == this) windw.Close();

            }
        }
        [RelayCommand]

        public void SaveItemButton()
        {

            using (var data_base = new DatabaseContext())
            {

                if (Selected_Item == null) Message_Box("Warning", "No Student was Selected", "OK");
                else
                {
                    Item p = new Item(temp_id, Nic, FirstName, LastName, temp_itemName, temp_unitPrice, temp_quantity, temp_discountPercentage, UnitPrice * Quantity);



                    data_base.Remove(Selected_Item);
                    data_base.Add(p);
                    Item_List.Remove(Selected_Item);
                    Item_List.Add(p);
                    data_base.SaveChanges();
                    Selected_Item = data_base.Items_table.Find(temp_id);
                }
            }
        }
        [RelayCommand]
        public void AddItemButton()
        {
            using (var data_base = new DatabaseContext())
            {
                if (temp_itemName == null) Message_Box("Warning", "No Student was Selected", "OK");
                int t_id = 1;
                if (Item_List.Count > 0) t_id = data_base.Items_table.Max(x => x.Id) + 1;
                while (data_base.Items_table.Any(x => x.Id == t_id)) t_id++;
                Item p = new Item(t_id, Nic, FirstName, LastName, temp_itemName, temp_unitPrice, temp_quantity, temp_discountPercentage, UnitPrice * Quantity);



                data_base.Add(p);
                
                Item_List.Add(p);
                data_base.SaveChanges();

                Selected_Item = data_base.Items_table.Find(t_id);
            }

        }
        [RelayCommand]
        public void DeleteItemButton()
        {
            if (Selected_Item == null) Message_Box("Warning", "No Item was Selected", "OK");
            else
            {
                using (var data_base = new DatabaseContext())
                {


                    if (Message_Box("Warning", "Item will be removed", "Remove"))
                    {
                        data_base.Remove(Selected_Item);

                        Item_List.Remove(Selected_Item);

                        data_base.SaveChanges();
                    }

                }
            }
        }
        [RelayCommand]
        public void SaveAllButton()
        {
            if (Selected_Item != null) SaveItemButton();

            using (var data_base = new DatabaseContext())
            {
                foreach (Item t in data_base.Items_table)
                {
                    if (t.NIC == selected_custo.NicNumber)
                    {
                        t.NIC = Nic;
                    }
                }

                data_base.SaveChanges();



            }
            using (var data_base = new DatabaseContext())
            {

                Customer p = new Customer()
                {
                    Id = selected_custo.Id,
                    NicNumber = Nic,
                    FirstName = FirstName,
                    Last_Name = LastName,
                    Totle = Total

                };


                data_base.Remove(selected_custo);
                data_base.Add(p);
                
                data_base.SaveChanges();


                User_Window temp = new User_Window();
                temp.Show();
                foreach (Window windw in Application.Current.Windows)
                    if (windw.DataContext == this) windw.Close();

            }
        }

        [RelayCommand]
        public void Close_Button()
        {
            User_Window temp = new User_Window();
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

        public Item_Window_VM()
        {

        }

        public Item_Window_VM(int selected_id, string keyWord)
        {
            using (var data_base = new DatabaseContext())
            {
                
                selected_custo = data_base.Customers_table.Find(selected_id);



            }
            nic = selected_custo.NicNumber;
            firstName = selected_custo.FirstName;
            lastName = selected_custo.Last_Name;
            using (var data_base = new DatabaseContext())
            {
                
                var adminlist = data_base.Items_table.Where(u => u.ItemName == keyWord).ToList();
                Item_List = new ObservableCollection<Item>(adminlist);


            }
        }


        public Item_Window_VM(int selected_id)
        {
            temp_id = -1;
            numofnotify = 0;
            using (var data_base = new DatabaseContext())
            {
                
                selected_custo = data_base.Customers_table.Find(selected_id);



            }

            nic = selected_custo.NicNumber;
            firstName = selected_custo.FirstName;
            lastName = selected_custo.Last_Name;




            using (var data_base = new DatabaseContext())
            {
                
                var adminlist = data_base.Items_table.Where(u => u.NIC == nic).ToList();
                Item_List = new ObservableCollection<Item>(adminlist);


            }
        }
        public double Calc_subtotle()
        {
            double subtotle = 0;
            if (Item_List != null)
                foreach (Item temp in Item_List)
                {
                    if (temp.NIC == Nic) subtotle += temp.Price;
                }
            return subtotle;
        }
        public double Calc_discount()
        {
            double discount = 0;
            if (Item_List != null)
                foreach (Item temp in Item_List)
                {
                    if (temp.NIC == Nic)
                    {
                        discount += (temp.UnitPrice * temp.DiscountPercentage / 100) * temp.Quantity;
                    }
                }
            return discount;
        }
    }
}

