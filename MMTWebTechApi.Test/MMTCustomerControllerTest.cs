using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MMTWebTechApi.Controllers;
using MMTWebTechApi.Models;
using MMTWebTechApi.Services;
using Xunit;

namespace MMTWebTechApi.Test
{
    public class MMTCustomerControllerTest
    {
        MMTCustomerController _controller;
        IMMTCustomerService _service;

        public MMTCustomerControllerTest()
        {
            _service = new MMTCustomerService();
            _controller = new MMTCustomerController(_service);
        }
        [Fact]
        public void GetAllUserTest()
        {
            //Arrange
            //Act
            var result = _controller.Get();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<List<MMTCustomer>>(list.Value);
            var listOfCustomer = list.Value as List<MMTCustomer>;
            Assert.Equal(5, listOfCustomer.Count);
        }

        [Theory]
        [InlineData("bob@mmtdigital.co.uk", "R223232")]
        public void GetCustomerByIdTest(string user, string customerId)
        {
            //Act 
            var okResult = _controller.Post(user, customerId);

            //Assert 
            Assert.IsType<OkObjectResult>(okResult.Result);

            //Now we need to check the value of the result for the ok object result.
            var item = okResult.Result as OkObjectResult;

            //We Expect to return a single book
            Assert.IsType<MMTCustomer>(item.Value);

            //Now, let us check the value of the customer.
            var customerItem = item.Value as MMTCustomer;
            Assert.Equal(customerId, customerItem.customerId);
            Assert.Equal(user, customerItem.email);
        }

        [Theory]
        [InlineData("R223232")]
        public void GetLatestOrderByCustomerIdTest(string customerId)
        {
            //Act 
            var okResult = _controller.GetOrder(customerId);

            //Assert 
            Assert.IsType<OkObjectResult>(okResult.Result);

            //Now we need to check the value of the result for the ok object result.
            var item = okResult.Result as OkObjectResult;

            //We Expect to return a single book
            Assert.IsType<MMTOrder>(item.Value);

            //Now, let us check the value of the customer.
            var customerOrder = item.Value as MMTOrder;
            Assert.Equal(customerId, customerOrder.customerId);
            Assert.Equal(654, customerOrder.orderNumber);
        }

        [Theory]
        [InlineData(654)]
        public void GetAllOrderItemByorderNumberTest(int customerId)
        {
            //Arrange
            //Act
            var result = _controller.GetOrderItem(customerId);
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<List<MMTOrderItem>>(list.Value);
            var listOfCustomerOrder = list.Value as List<MMTOrderItem>;
            Assert.Equal(2, listOfCustomerOrder.Count);
        }
    }
}
