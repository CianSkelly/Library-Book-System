using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryBookSystem;
//using LibraryBookSystem.Controllers;

namespace LibraryBookSystem.Tests.Controllers
{
    [TestClass]
    public class LibUsersControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            LibUsersController controller = new LibUsersController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            LibUsersController controller = new LibUsersController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            LibUsersController controller = new LibUsersController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
