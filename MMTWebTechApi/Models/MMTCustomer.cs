using System;


namespace MMTWebTechApi.Models
{
    public class MMTCustomer
    {
        public string email { get; set; }
        //public Guid customerId { get; set; }
        public string customerId { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        //public MMTOrder order { get; set; }

    }
    public class MMTAddress
    {
        public Guid AddressId { get; set; }
        public string houseNumber { get; set; }
        public string Street { get; set; }
        public string town { get; set; }
        public string postcode { get; set; }

    }
    public class MMTOrder
    {
        public string customerId { get; set; }
        //public Guid orderNumber { get; set; }
        public int orderNumber { get; set; }
        public DateTime orderDate { get; set; }
        //public MMTAddress deliveryAddress { get; set; }
        //public IEnumerable<MMTOrderItem> orderItems { get; set; }
        public DateTime deliveryExpected { get; set; }
    }
    public class MMTOrderItem
    {
        public int orderNumber { get; set; }
        public string product { get; set; }
        public int quantity { get; set; }
        public double priceEach { get; set; }
    }
}
