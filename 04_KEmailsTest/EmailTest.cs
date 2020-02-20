using System;
using _05_KEmails;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_KEmailsTest
{
    [TestClass]
    public class EmailTest
    {
        private CustomerRepo _customerRepo;
        private Customer _customer;

        [TestInitialize]
        public void Arrange()
        {
            _customerRepo = new CustomerRepo();
            _customer= new Customer(1234, "Amanda", "Knight", "This is only a test", CustomerType.Potential);
        }

        [TestMethod]
        public void AddNewCustomerTest()
        {
            _customerRepo.AddNewCustomer(_customer);
            var expected = 1;
            var actual = _customerRepo.ReturnAllCustomer().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveCustomer()
        {
            _customerRepo.AddNewCustomer(_customer);
            _customerRepo.DeleteCustomer(_customer.CustomerID);
            var expected = 0;
            var actual = _customerRepo.ReturnAllCustomer().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateCustomer()
        {
            _customerRepo.AddNewCustomer(_customer);
            var updatedCustomer = new Customer(1234, "Amanda", "Knight", "This is only a test", CustomerType.Current);
            _customerRepo.UpdateCustomer(updatedCustomer);
            var check=_customerRepo.GetOneCustomer(_customer.CustomerID);
            var expected = CustomerType.Current;
            var actual = check.TypeOfCustomer;
            Assert.AreEqual(expected, actual);
        }
    }
}
