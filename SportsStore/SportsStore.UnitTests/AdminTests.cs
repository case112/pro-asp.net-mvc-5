﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Index_Contains_All_Products()
        {
            // arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"}
            });
            AdminController target = new AdminController(mock.Object);

            // act
            Product[] result = ((IEnumerable<Product>)target.Index().ViewData.Model).ToArray();

            // assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("P1", result[0].Name);
            Assert.AreEqual("P2", result[1].Name);
            Assert.AreEqual("P3", result[2].Name);
        }

        [TestMethod]
        public void Can_Edit_Product()
        {
            // arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"}
            });
            AdminController target = new AdminController(mock.Object);

            // act
            Product p1 = target.Edit(1).ViewData.Model as Product;
            Product p2 = target.Edit(2).ViewData.Model as Product;
            Product p3 = target.Edit(3).ViewData.Model as Product;

            // assert
            Assert.AreEqual(1, p1.ProductID);
            Assert.AreEqual(2, p2.ProductID);
            Assert.AreEqual(3, p3.ProductID);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Product()
        {
            // arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"}
            });
            AdminController target = new AdminController(mock.Object);

            // act
            Product result = (Product)target.Edit(4).ViewData.Model;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            
            AdminController target = new AdminController(mock.Object);

            Product product = new Product { Name = "Test" };

            // act
            ActionResult result = target.Edit(product);

            // assert
            // check that the repository was called
            mock.Verify(m => m.SaveProduct(product));
            // check the method result type
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Change_Invalid_Changes()
        {
            // arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            AdminController target = new AdminController(mock.Object);

            Product product = new Product { Name = "Test" };

            target.ModelState.AddModelError("error", "error");

            // act
            ActionResult result = target.Edit(product);

            // assert
            // check that the repository was called
            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());
            // check the method result type
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Can_Delete_Valid_Products()
        {

            // arrange
            Product prod = new Product { ProductID = 2, Name = "Test" };

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                prod,
                new Product {ProductID = 3, Name = "P3"},
            });

            AdminController target = new AdminController(mock.Object);

            // act
            target.Delete(prod.ProductID);

            // assert - ensure that the repository delete method was 
            // called with the correct Product 
            mock.Verify(m => m.DeleteProduct(prod.ProductID));
        }
    }

}
