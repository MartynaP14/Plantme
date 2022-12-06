using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class ProductControllerTests
    {
        
        public ApplicationDbContext Create_database()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()


                .UseInMemoryDatabase(databaseName: "PlantMeDatabase")
                .Options;
            var database = new ApplicationDbContext(options);

            // seeding database
            if (!database.Products.Any<Product>())
            {

                database.Products.Add(new Product
                {
                    ProductId = 0001,
                    BeginnerFriendly = true,
                    ChildFriendly = false,
                    Description = "house plant, sunny enviroment",
                    DifficultyLevel = "Easy",
                    Documentation = "n/a",
                    GrowingConditions = "Grows in high humid enviroment",
                    PetFriendly = false,
                    Rating = 4,
                    ProductName = "snake plant",
                    ProductTypes = ProductTypes.IndoorPalms,
                    ProductPrice = 15,
                    PlantingInstructions = "n/a",
                    ProductImage = "n/a"
                });
                database.Products.Add(new Product
                {
                    ProductId = 0002,
                    BeginnerFriendly = true,
                    ChildFriendly = false,
                    Description = "house plant, enviroment",
                    DifficultyLevel = "hard",
                    Documentation = "n/a",
                    GrowingConditions = "Grows in hot enviroment",
                    PetFriendly = false,
                    Rating = 5,
                    ProductName = "rose plant",
                    ProductTypes = ProductTypes.IndoorPalms,
                    ProductPrice = 200,
                    PlantingInstructions = "n/a",
                    ProductImage = "n/a"
                });
                database.SaveChanges();

            }
                return database;

        }


        [Fact]
        public void TestIndex_Product_WithResponseSuccess()
        {
            //Arrange
            //database created 
            ApplicationDbContext database = Create_database();

            //controller created
            ProductsController products_controller = new ProductsController(database);




            //Act
            var result = products_controller.Index();

            //Assert
            Assert.NotNull(result);



        }
        [Fact]
        public void TestCreate_CreateProduct_WithResponseSuccess()
        {
            //Arrange
            //database created 
            ApplicationDbContext database = Create_database();

            //controller created
            ProductsController products_controller = new ProductsController(database);

            Product product = new Product()
            {
                ProductId = 0010,
                BeginnerFriendly = true,
                ChildFriendly = false,
                Description = "house plant, enviroment",
                DifficultyLevel = "hard",
                Documentation = "n/a",
                GrowingConditions = "Grows in hot enviroment",
                PetFriendly = false,
                Rating = 5,
                ProductName = "rose plant",
                ProductTypes = ProductTypes.IndoorPalms,
                ProductPrice = 200,
                PlantingInstructions = "n/a",
                ProductImage = "n/a"
            };


            //Act
            var result = products_controller.Create(product);

            //Assert
            Assert.NotNull(result);
            


        }




        [Fact]
        public void TestDetails_ShowDetailsProduct_WithResponseSuccess()
        {
            //Arrange
            //database created 
            ApplicationDbContext database = Create_database();

            //controller created
            ProductsController products_controller = new ProductsController(database);


            //Act
            var result = products_controller.Details(0001);

            //Assert
            Assert.NotNull(result);

        }

        [Fact]
        public async void TestDetails_ShowIncorrectDetailsProduct_WithResponseFail()
        {
            //Arrange
            //database created 
            ApplicationDbContext database = Create_database();

            //controller created
            ProductsController products_controller = new ProductsController(database);


            //Act
            var result = await products_controller.Details(0011);

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }


        [Fact]
        public async void TestDelete_DeleteProductById_WithResponseFail()
        {
            //Arrange
            //database created 
            ApplicationDbContext database = Create_database();

            //controller created
            ProductsController products_controller = new ProductsController(database);


            //Act
            var result = await products_controller.Delete(0011);

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public  async void TestDelete_DeleteProductById_WithResponseSuccess()
        {
            //Arrange
            //database created 
            ApplicationDbContext database = Create_database();
            Product product = new Product()
            {
                ProductId = 0003,
                BeginnerFriendly = true,
                ChildFriendly = false,
                Description = "house plant, enviroment",
                DifficultyLevel = "hard",
                Documentation = "n/a",
                GrowingConditions = "Grows in hot enviroment",
                PetFriendly = false,
                Rating = 5,
                ProductName = "rose plant",
                ProductTypes = ProductTypes.IndoorPalms,
                ProductPrice = 200,
                PlantingInstructions = "n/a",
                ProductImage = "n/a"
            };
            

            //controller created
            ProductsController products_controller = new ProductsController(database);


            //Act
            var result = await products_controller.Delete(0003);

            //Assert
            Assert.IsType<ViewResult>(result);

        }


        [Fact]
        public async void TestUpdate_UpdateProductById_WithResponseSuccess()
        {
            //Arrange
            //database created 
            ApplicationDbContext database = Create_database();
            Product product = new Product()
            {
                ProductId = 0003,
                BeginnerFriendly = true,
                ChildFriendly = false,
                Description = "house plant, enviroment",
                DifficultyLevel = "hard",
                Documentation = "n/a",
                GrowingConditions = "Grows in hot enviroment",
                PetFriendly = false,
                Rating = 5,
                ProductName = "rose plant",
                ProductTypes = ProductTypes.IndoorPalms,
                ProductPrice = 200,
                PlantingInstructions = "n/a",
                ProductImage = "n/a"
            };

            //controller created
            ProductsController products_controller = new ProductsController(database);
            var product_create = products_controller.Create(product);

            //Act
            var result = await products_controller.Edit(0003);

            //Assert
            Assert.IsType<ViewResult>(result);

        }

    }
}
