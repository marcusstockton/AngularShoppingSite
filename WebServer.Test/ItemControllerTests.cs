using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebServer.Interfaces;
using WebServer.Models.DTOs.Items;
using System.Collections.Generic;
using WebServer.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using WebServer.Models;
using WebServer.Models.Items;

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
            // Arrange
            var mockRepository = new Mock<IItemsService>();
            mockRepository.Setup(x => x.GetItems())
                .ReturnsAsync(new List<ItemDetails>{ new ItemDetails{Price = 12.34, Name = "Test 1"}, new ItemDetails{Price = 34.32, Name = "Test 2"}});
            var imageService = new Mock<IImageService>();
            var controller = new ItemsController(mockRepository.Object, imageService.Object);

            // Act
            var actionResult = await controller.Get();

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult.Result, typeof(OkObjectResult));
            var okresult = actionResult.Result as OkObjectResult;
            Assert.AreEqual(okresult.StatusCode, (int)HttpStatusCode.OK);
            var values = okresult.Value as List<ItemDetails>;
            Assert.AreEqual(values.Count, 2);

        }

        [TestMethod]
        public async Task Test_Get_Item_By_Id_With_Valid_Id_Returns_The_Item()
        {
            // Arrange
            var mockRepository = new Mock<IItemsService>();
            mockRepository.Setup(x => x.GetItemById(It.IsAny<Guid>()))
                .ReturnsAsync(new ItemDetails{Price = 12.34, Name = "Test 1"});
            var imageService = new Mock<IImageService>();
            var controller = new ItemsController(mockRepository.Object, imageService.Object);
           
            // Act
            var actionResult = await controller.Get(Guid.NewGuid().ToString());

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult.Result, typeof(OkObjectResult));

            var okresult = actionResult.Result as OkObjectResult;
            Assert.AreEqual(okresult.StatusCode, (int)HttpStatusCode.OK);

            var value = okresult.Value as ItemDetails;
            Assert.AreEqual(value.Name, "Test 1");
        }

        [TestMethod]
        public async Task Test_Get_Item_By_Id_With_Invalid_Id_Returns_404()
        {
            // Arrange
            var mockRepository = new Mock<IItemsService>();
            mockRepository.Setup(x => x.GetItemById(new Guid("f34722c9-7d74-4e13-8bc1-3c7e1c0d984f")))
                .ReturnsAsync(new ItemDetails{Price = 12.34, Name = "Test 1"});
            var imageService = new Mock<IImageService>();
            var controller = new ItemsController(mockRepository.Object, imageService.Object);
           
            // Act
            var actionResult = await controller.Get("f34722c9-7d74-4e13-8bc1-3c7e1c0d984A");

            // Assert
            Assert.IsNotNull(actionResult);
            var notFoundResult = actionResult.Result as NotFoundResult;
            Assert.AreEqual(notFoundResult.StatusCode, (int)HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task Test_Update_Item_By_Id_Returns_NoContentResult()
        {
            // Arrange
            var mockRepository = new Mock<IItemsService>();
            mockRepository.Setup(x=>x.UpdateItemById(It.IsAny<Guid>(), It.IsAny<ItemEdit>(), It.IsAny<List<Image>>())).ReturnsAsync(new Item{ Description = "Fluff" });
            var imageService = new Mock<IImageService>();
            var controller = new ItemsController(mockRepository.Object, imageService.Object);

            var guid = Guid.NewGuid();

            // Act
            var actionResult = await controller.Put(guid.ToString(), new ItemEdit { Id = guid, Name = "Product" }, new List<Microsoft.AspNetCore.Http.IFormFile>());
            var contentResult = actionResult as NoContentResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.StatusCode, (int)HttpStatusCode.NoContent);
            
        }

        [TestMethod]
        public async Task Test_Update_Item_By_Id_With_Invalid_Data_Returns_BadRequest()
        {
            // Arrange
            var itemEdit = new ItemEdit{
                Id = new Guid("f34722c9-7d74-4e13-8bc1-3c7e1c0d984f"),
                Title = "Super Crap Title"
            };

            var alternativeId = new Guid("f34722c9-7d74-4e13-8bc1-3c7e1c0d984A");

            var mockRepository = new Mock<IItemsService>();
            mockRepository.Setup(x=>x.UpdateItemById(itemEdit.Id, itemEdit, It.IsAny<List<Image>>())).ReturnsAsync(new Item{ Description = "Fluff" });
            var imageService = new Mock<IImageService>();
            var controller = new ItemsController(mockRepository.Object, imageService.Object);

            // Act
            var actionResult = await controller.Put(alternativeId.ToString(), itemEdit, new List<Microsoft.AspNetCore.Http.IFormFile>());
            var contentResult = actionResult as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.StatusCode, (int)HttpStatusCode.BadRequest);
            Assert.AreEqual(contentResult.Value, "Invalid Data");
        }

        [TestMethod]
        public async Task Test_Create_Item_With_Valid_Data_Works()
        {
            // Arrange
            var item = new ItemCreate{
                Description = "New Description",
                Name = "New Name",
                Price = 43.21,
                Title = "New Title"
            };
            var mockRepository = new Mock<IItemsService>();
            var newGuidId = Guid.NewGuid();
            mockRepository.Setup(x=>x.CreateItem(It.IsAny<ItemCreate>(), It.IsAny<List<Image>>())).ReturnsAsync(new Item{Id = newGuidId, Description = "New Description"});
            var imageService = new Mock<IImageService>();
            var controller = new ItemsController(mockRepository.Object, imageService.Object);

            // Act
            var actionResult = await controller.Post(item, new List<Microsoft.AspNetCore.Http.IFormFile>());
            var contentResult = actionResult as CreatedAtActionResult;

            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.StatusCode, (int)HttpStatusCode.Created);
            var value = contentResult.Value as Item;
            Assert.AreEqual(value.Id, newGuidId);
            Assert.AreEqual(value.Description, "New Description");
        }

        [TestMethod]
        public async Task Test_Delete_Item_With_Valid_Id_Works()
        {
            // Arrange
            var newGuidId = Guid.NewGuid();
            var mockRepository = new Mock<IItemsService>();
            mockRepository.Setup(x=>x.DeleteItemById(newGuidId)).ReturnsAsync(true);
            var imageService = new Mock<IImageService>();
            var controller = new ItemsController(mockRepository.Object, imageService.Object);

            // Act
            var actionResult = await controller.Delete(newGuidId.ToString());
            var contentResult = actionResult as NoContentResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.StatusCode, (int)HttpStatusCode.NoContent);
        }

        [TestMethod]
        public async Task Test_Delete_With_Invalid_Id_Returns_404()
        {
            // Arrange
            var mockRepository = new Mock<IItemsService>();
            mockRepository.Setup(x=>x.DeleteItemById(Guid.NewGuid())).ReturnsAsync(false);
            var imageService = new Mock<IImageService>();
            var controller = new ItemsController(mockRepository.Object, imageService.Object);

            // Act
            var actionResult = await controller.Delete(Guid.NewGuid().ToString());
            var contentResult = actionResult as BadRequestResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(contentResult.StatusCode, (int)HttpStatusCode.BadRequest);
        }
    }
}
