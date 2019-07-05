using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebServer.Interfaces;
using WebServer.Models.DTOs.Items;
using System.Collections.Generic;
using WebServer.Controllers;
using WebServer.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;


namespace WebServer.Test
{
    [TestClass]
    public class ItemControllerTests
    {
        private List<Item> itemList = new List<Item>();
        private List<ItemDetails> getItems = new List<ItemDetails>();

        [TestInitialize]
        public void Setup()
        {
             // Runs before each test. (Optional)
            var demoUser = new ApplicationUser{UserName="TestUser", Id = new Guid("c4af7c05-0714-49d8-a674-3e3d316f1cc9")};

            itemList.Add(new Item{Id = new Guid("b754c240-817f-4e1e-97b8-6ee09700f399"), Title = "Test Title", Description = "Test Description", Price = 12.34, CreatedDate = new DateTime(2019, 01, 23), CreatedBy=demoUser});
            itemList.Add(new Item{Id = new Guid("57fb77b1-6d69-4b8e-a424-03e3f304118d"), Title = "Another Test Title", Description = "Another Test Description", Price = 98.33, CreatedDate = new DateTime(2019, 01, 25), CreatedBy=demoUser});
        
        }
        
        [TestCleanup]
        public void TearDown()
        { 
            // Runs after each test. (Optional)
        }

        [TestMethod]
        public async Task Test_Index_Works()
        {
            // arrange
            var mockRepo = new Mock<IItemsService>();
            var mockImageService = new Mock<IImageService>();
            mockRepo.Setup(repo => repo.GetItems()).Returns(GetItems());
            var controller = new ItemsController(mockRepo.Object, mockImageService.Object);

            // act
            ActionResult<IEnumerable<ItemDetails>> result = await controller.Get();

            // assert
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            OkObjectResult okResult = result.Result as OkObjectResult;

            List<ItemDetails> items = okResult.Value as List<ItemDetails>;
            Assert.AreEqual(2, items.Count);
        }

        [TestMethod]
        public async Task Test_Get_Item_By_Id()
        {
            // Arrange
            var mockRepo = new Mock<IItemsService>();
            var mockImageService = new Mock<IImageService>();
            mockRepo.Setup(x => x.GetItemById(new Guid("c8bdd28c-caf0-459b-b46c-5d3c45a38ba6"))).ReturnsAsync(new ItemDetails { Title = "Demo", Description = "Test Description", Price = 123.43});
            var controller = new ItemsController(mockRepo.Object, mockImageService.Object);

           
            // Act
            ActionResult<ItemDetails> result = await controller.Get("c8bdd28c-caf0-459b-b46c-5d3c45a38ba6");

            // Assert
            Assert.IsNotNull(result);

            OkObjectResult okResult = result.Result as OkObjectResult;
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        }


        private async Task<IEnumerable<ItemDetails>> GetItems()
        {
            var sessions = new List<ItemDetails>();
            sessions.Add(new ItemDetails()
            {
                Title = "Some test title",
                CreatedDate = new System.DateTime(2019,01,12),
                Description = "Some Long winded description",
                Name = "Name",
                Price = 12.34,
            });
            sessions.Add(new ItemDetails()
            {
                Title = "Some Second test title",
                CreatedDate = new System.DateTime(2019,01,15),
                Description = "Some Second Long winded description",
                Name = "Second Name",
                Price = 43.21,
            });
            
            return sessions;
        }
    }
}
