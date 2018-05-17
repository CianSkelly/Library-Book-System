using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryBookSystem;
using LibraryBookSystem.Controllers;

namespace LibraryBookSystem.Controllers.Tests
{
    [TestClass()]
    public class BooksControllerTest
    {
        [TestMethod()]
        public void IndexTest()
        {
            return view(db.LMSEntities.ToList());
            //Assert.Fail();
        }
    }
}

namespace LibraryBookSystem.Tests.Controllers
{
    [TestClass]
    public class BooksControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            BooksController controller = new BooksController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            BooksController controller = new BooksController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            BooksController controller = new BooksController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
