using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebServer.Interfaces;
using WebServer.Models.DTOs.Items;
using System.Collections.Generic;
using WebServer.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WebServer.Test
{
    [TestClass]
    public class ItemControllerTests
    {

        [TestInitialize]
        public void Setup()
        {
             // Runs before each test. (Optional)
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
            mockRepo.Setup(repo => repo.GetItems()).Returns(GetTestSessions());
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

        private async Task<IEnumerable<ItemDetails>> GetTestSessions()
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
                Price = 12.34,
            });
            
            return sessions;
        }
    }
}
