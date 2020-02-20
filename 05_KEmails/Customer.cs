using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_KEmails
{
    public enum CustomerType
    {
        Current =1,
        Past,
        Potential
    }
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailContent { get; set; }
        public CustomerType TypeOfCustomer { get; set; }

        public Customer() { }
        public Customer(int customerID,string firstName, string lastName, string emailContent, CustomerType typeOfCustomer)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            EmailContent = emailContent;
            TypeOfCustomer = typeOfCustomer;

        }

    }
}
