using MMTWebTechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTWebTechApi.Services
{
    public interface IMMTCustomerService
    {
        IEnumerable<MMTCustomer> GetAllUser();
        MMTCustomer GetUserById(string user, string customerId);
        MMTOrder GetOrderByCustomerId(string customerId);
        IEnumerable<MMTOrderItem> GetAllOrderItemByorderNumber(int orderNumber);
    }
}
