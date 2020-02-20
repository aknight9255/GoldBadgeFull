using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_KEmails
{
    public class CustomerRepo
    {
        private List<Customer> _customerList = new List<Customer>();
        public List<Customer> ReturnAllCustomer()
        {
            return _customerList.OrderBy(c => c.FirstName).ToList();
        }
        public Customer GetOneCustomer(int id)
        {
            foreach(Customer customer in _customerList)
            {
                if (id == customer.CustomerID)
                {
                    return customer;
                }
            }
            return null;
        }
        public void AddNewCustomer(Customer customer)
        {
            if(customer.TypeOfCustomer == CustomerType.Current)
            {
                customer.EmailContent = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon";
            }
            else if (customer.TypeOfCustomer == CustomerType.Past)
            {
                customer.EmailContent = "It's been a long time since we've heard from you, we want you back";

            }
            else if(customer.TypeOfCustomer == CustomerType.Potential)
            {
                customer.EmailContent = "We currently have the lowest rates on Helicopter Insurance!";
            }
            _customerList.Add(customer);
        }
        public void DeleteCustomer(int customerID)
        {
            var customerToRemove = GetOneCustomer(customerID);
            _customerList.Remove(customerToRemove);
        }
        public void UpdateCustomer(Customer customer)
        {
            DeleteCustomer(customer.CustomerID);
            _customerList.Add(customer);
        }
    }
}
