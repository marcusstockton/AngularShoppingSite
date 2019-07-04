using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebServer.Interfaces;
using WebServer.Models.DTOs.Items;
using WebServer.Models;
using System.Collections.Generic;
using WebServer.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WebServer.Test
{
    [TestClass]
    public class ItemControllerTests
    {
        public ItemControllerTests()
        {
            
        }
        [TestMethod]
        public void Test_Create_New_Item()
        {
            // arrange
            var mockRepo = new Mock<IItemsService>();
            var mockImageService = new Mock<IImageService>();
            mockRepo.Setup(repo => repo.GetItems())
                .Returns(GetTestSessions());
            var controller = new ItemsController(mockRepo.Object, mockImageService.Object);

            // act
            var result = await controller.Get();

            // assert
            //var viewResult = Assert.IsType<ActionResult<IEnumerable<ItemDetails>>>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<ItemDetails>>(viewResult);
            //Assert.Equal(2, model.Count());
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
