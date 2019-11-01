

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebServer.Controllers;
using WebServer.Interfaces;
using WebServer.Models.DTOs.Reviews;

namespace WebServer.Test
{
    [TestClass]
    public class ReviewControllerTests
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
        public async Task Gets_Reviews_For_Item()
        {
            // Arrange
            var mockRepository = new Mock<IReviewService>();
            mockRepository.Setup(x => x.GetReviewsForItem(It.IsAny<Guid>()))
                .ReturnsAsync(new List<ReviewDetails>{ new ReviewDetails{Rating = 5, Description = "Some Description", Title = "Some Title"},
                                                        new ReviewDetails{Rating = 1, Description = "Some other Description", Title = "Some other Title"}});
            var controller = new ReviewController(mockRepository.Object);

            // Act
            var actionResult = await controller.GetReviewsForItem(Guid.NewGuid().ToString());
            
            // Assert
            Assert.IsNotNull(actionResult);
            // Debug.WriteLine(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            var okresult = actionResult as OkObjectResult;
            Assert.AreEqual(okresult.StatusCode, (int)HttpStatusCode.OK);
            var values = okresult.Value as List<ReviewDetails>;
            Assert.AreEqual(values.Count, 2);
        }

        [TestMethod]
        public async Task Get_Review_For_Item_By_Review_Id_With_Correct_Id_Returns_Review()
        {
            // Arrange
            var mockRepository = new Mock<IReviewService>();
            var reviewId = Guid.NewGuid();
            mockRepository.Setup(x => x.GetReviewById(It.IsAny<Guid>(), reviewId))
                .ReturnsAsync(new ReviewDetails{ Rating = 5, Description = "Some Description", Title = "Some Title", Id=reviewId});
            var controller = new ReviewController(mockRepository.Object);

            // Act
            var actionResult = await controller.GetReviewById(Guid.NewGuid(), reviewId);

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            var okresult = actionResult as OkObjectResult;
            Assert.AreEqual(okresult.StatusCode, (int)HttpStatusCode.OK);
            var value = okresult.Value as ReviewDetails;
            Assert.AreEqual(value.Id, reviewId);
            Assert.AreEqual(value.Description, "Some Description");
        }
    }
}