using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ReturnXmlWebApi;
using ReturnXmlWebApi.Controllers;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private UserController _controller;

        [TestInitialize]
        public void Setup()
        {
            _controller = new UserController();
        }

        [TestMethod]
        public void GetUser_WhenCalled_ReturnsXmlResult_WithUserObject()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _controller.GetUser(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult?.Value, typeof(User));
            var user = okResult.Value as User;
            Assert.AreEqual(id, user?.Id);
            Assert.AreEqual("Steve James", user?.Name);
        }
    }
}