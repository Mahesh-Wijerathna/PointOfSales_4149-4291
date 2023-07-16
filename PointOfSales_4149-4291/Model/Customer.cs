using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales_4149_4291.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string NicNumber { get; set; }
        public string FirstName { get; set; }
        public string Last_Name { get; set; }
        public double Totle { get; set; }

        public Customer()
        {
            NicNumber = "no";
            FirstName = "no";
            Last_Name = "no";
            Totle = 0;

        }

        public Customer(int id, string nicNumber, string firstName, string last_Name, double totle)
        {
            Id = id;
            NicNumber = nicNumber;
            FirstName = firstName;
            Last_Name = last_Name;
            Totle = totle;
        }
    }
}
