using MMTWebTechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTWebTechApi.Services
{
    public class MMTCustomerService : IMMTCustomerService
    {
        private readonly List<MMTCustomer> _mmtCustomers;
        private readonly List<MMTOrder> _mmtOrders;
        private readonly List<MMTOrderItem> _mmtOrderItems;

        public MMTCustomerService()
        {
            _mmtCustomers = new List<MMTCustomer>()
            {

                new MMTCustomer(){email = "bob@mmtdigital.co.uk",customerId = "R223232",firstName ="Bob", lastName="Testperson"},
                new MMTCustomer(){email = "cat.owner@mmtdigital.co.uk",customerId = "C34454",firstName ="Cat", lastName="Owner"},
                new MMTCustomer(){email = "dog.owner@fake-customer.com",customerId = "R34788",firstName ="Dog", lastName="Owner"},
                new MMTCustomer(){email = "sneeze@fake-customer.com",customerId = "A99001",firstName ="sneeze", lastName="fake-customer" },
                new MMTCustomer(){email = "santa@north-pole.lp.com",customerId = "XM45001",firstName ="Santa", lastName="north-pole"}

            };

            _mmtOrders = new List<MMTOrder>()
            {
               new MMTOrder(){ customerId = "R223232", orderNumber = 456, orderDate = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy")), deliveryExpected= Convert.ToDateTime(DateTime.Now.AddDays(6).ToString("dd-MMM-yyyy"))},
               new MMTOrder(){ customerId = "R223232", orderNumber = 654, orderDate = Convert.ToDateTime(DateTime.Now.AddDays(2).ToString("dd-MMM-yyyy")), deliveryExpected= Convert.ToDateTime(DateTime.Now.AddDays(10).ToString("dd-MMM-yyyy"))},
               new MMTOrder(){ customerId = "C34454", orderNumber = 546, orderDate = Convert.ToDateTime(DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy")), deliveryExpected= Convert.ToDateTime(DateTime.Now.AddDays(3).ToString("dd-MMM-yyyy")) },
            };
            _mmtOrderItems = new List<MMTOrderItem>()
            {
                new MMTOrderItem { orderNumber= 456, product = "Tennis Ball", quantity =10, priceEach = 2.99 },
                new MMTOrderItem { orderNumber = 654, product = "Tennis Net", quantity = 1, priceEach = 105.50 },
                new MMTOrderItem { orderNumber = 654, product = "Table Tennis Ball", quantity = 20, priceEach = 50.50 },
                new MMTOrderItem { orderNumber = 546, product = "Net Tennis ", quantity = 4, priceEach = 15.50 }
            };
        }
        public IEnumerable<MMTOrderItem> GetAllOrderItemByorderNumber(int orderNumber)
        {
            return _mmtOrderItems.Where(id => id.orderNumber == orderNumber).ToList();
        }

        public IEnumerable<MMTCustomer> GetAllUser()
        {
            return _mmtCustomers;
        }

        public MMTOrder GetOrderByCustomerId(string customerId)
        {
            return _mmtOrders.Where(id => id.customerId == customerId).OrderByDescending(date => date.orderDate).FirstOrDefault();
        }

        public MMTCustomer GetUserById(string user, string customerId)
        {
            return _mmtCustomers.Where(u => u.email == user).Where(id => id.customerId == customerId).FirstOrDefault();
        }
    }
}
