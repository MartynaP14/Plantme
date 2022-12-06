using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Plantme.Controllers;
using Plantme.Data;
using Plantme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PlantMe_Tests
{
    public class ProductOrdersControllerTests
    {

        public ApplicationDbContext Create_database()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()


                .UseInMemoryDatabase(databaseName: "PlantMeDatabase")
                .Options;
            var database = new ApplicationDbContext(options);

            // seeding database
            if (!database.ProductOrder.Any<ProductOrder>())
            {
                List<OrderItemInfo> orderItemInfo = new List<OrderItemInfo>();  
                database.ProductOrder.Add(new ProductOrder
                {
                    ProductOrderID = 1,
                    OrderDateTime = DateTime.Now,
                    OrderQuantity = 1,
                    OrderSubtotal = 1,
                    Id= "1",
                    OrderItemInfo = orderItemInfo,
                });
                database.ProductOrder.Add(new ProductOrder
                {
                    ProductOrderID = 2,
                    OrderDateTime = DateTime.Now,
                    OrderQuantity = 2,
                    OrderSubtotal = 2,
                    Id = "2",
                    OrderItemInfo = orderItemInfo,
                });
                database.SaveChanges();

            }
            return database;

        }


        [Fact]
        public void TestIndex_ProductOrder_WithResponseSuccess()
        {
            //Arrange
            //database created 
            ApplicationDbContext database = Create_database();

            //controller created
            ProductOrdersController productorder_controller = new ProductOrdersController(database);




            //Act
            var result = productorder_controller.Index();

            //Assert
            Assert.NotNull(result);



        }
        [Fact]
        public void TestCreate_ProductOrder_WithResponseSuccess()
        {
            //Arrange
            //database created 
            ApplicationDbContext database = Create_database();

            //controller created
            List<OrderItemInfo> orderItemInfo = new List<OrderItemInfo>();
            ProductOrdersController productorder_controller = new ProductOrdersController(database);

            ProductOrder product_order = new ProductOrder()
            {
                ProductOrderID = 100,
                OrderDateTime = DateTime.Now,
                OrderQuantity = 1,
                OrderSubtotal = 1,
                Id = "1",
                OrderItemInfo = orderItemInfo,
            };


            //Act
            var result = productorder_controller.Create(product_order);

            //Assert
            Assert.NotNull(result);



        }




        [Fact]
        public void TestDetails_ShowDetailsProductOrder_WithResponseSuccess()
        {
            //Arrange
            //database created 
            ApplicationDbContext database = Create_database();

            //controller created
            ProductOrdersController productorder_controller = new ProductOrdersController(database);


            //Act
            var result = productorder_controller.Details(0001);

            //Assert
            Assert.NotNull(result);

        }

        [Fact]
        public async void TestDetails_ShowIncorrectDetailsProductOrder_WithResponseFail()
        {
            //Arrange
            //database created 
            ApplicationDbContext database = Create_database();

            //controller created
            ProductOrdersController productorder_controller = new ProductOrdersController(database);

            //Act
            var result = await productorder_controller.Details(0011);

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }


        [Fact]
        public async void TestDelete_DeleteProductOrderById_WithResponseFail()
        {
            //Arrange
            //database created 
            ApplicationDbContext database = Create_database();

            //controller created
            ProductOrdersController productorder_controller = new ProductOrdersController(database);


            //Act
            var result = await productorder_controller.Delete(0011);

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async void TestDelete_DeleteProductOrderById_WithResponseSuccess()
        {
            //Arrange
            //database created 
            List<OrderItemInfo> orderItemInfo = new List<OrderItemInfo>();
            ApplicationDbContext database = Create_database();
            ProductOrder product_order = new ProductOrder()
            {
                ProductOrderID = 20,
                OrderDateTime = DateTime.Now,
                OrderQuantity = 1,
                OrderSubtotal = 1,
                Id = "1",
                OrderItemInfo = orderItemInfo,
            };



            //controller created
            ProductOrdersController productorder_controller = new ProductOrdersController(database);


            //Act
            var result = await productorder_controller.Delete(1);

            //Assert
            Assert.IsType<ViewResult>(result);

        }


        [Fact]
        public async void TestUpdate_UpdateProductOrderById_WithResponseSuccess()
        {
            //Arrange
            //database created 
            List<OrderItemInfo> orderItemInfo = new List<OrderItemInfo>();
            ApplicationDbContext database = Create_database();
            ProductOrder product_order = new ProductOrder()
            {
                ProductOrderID = 20,
                OrderDateTime = DateTime.Now,
                OrderQuantity = 1,
                OrderSubtotal = 1,
                Id = "1",
                OrderItemInfo = orderItemInfo,
            };

            //controller created
            ProductOrdersController productorder_controller = new ProductOrdersController(database);
            var product_order1_create = productorder_controller.Create(product_order);

            //Act
            var result = await productorder_controller.Edit(20);

            //Assert
            Assert.IsType<ViewResult>(result);

        }

    }
}









