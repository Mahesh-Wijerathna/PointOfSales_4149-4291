using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSales_4149_4291.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User()
        {

            //Id= 62;
            FirstName = "admin";
            LastName = "admin";
            UserType = "admin";
            UserName = "admin";
            Password = "admin";


        }
        public User(int id, string fistname, string lastname, string usertype, string username, string password)
        {

            Id = id;
            FirstName = fistname;
            LastName = lastname;
            UserType = usertype;
            UserName = username;
            Password = password;



        }
    }
}
