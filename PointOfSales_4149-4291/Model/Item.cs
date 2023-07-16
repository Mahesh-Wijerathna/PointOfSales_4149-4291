using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales_4149_4291.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string? NIC { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ItemName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double DiscountPercentage { get; set; }
        public double Price { get; set; }

        public Item() { }

        public Item(int id, string nIC, string firstName, string lastName, string itemName, double unitPrice, int quantity, double discountPercentage, double price)
        {
            Id = id;
            NIC = nIC;
            FirstName = firstName;
            LastName = lastName;
            ItemName = itemName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            DiscountPercentage = discountPercentage;
            Price = price;
        }

        public Item(string nIC, string firstName, string lastName, string itemName, double unitPrice, int quantity, double discountPercentage, double price)
        {
            NIC = nIC;
            FirstName = firstName;
            LastName = lastName;
            ItemName = itemName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            DiscountPercentage = discountPercentage;
            Price = price;
        }
    }
}
