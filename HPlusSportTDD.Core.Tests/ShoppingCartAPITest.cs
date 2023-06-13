using HPlusSportTDD.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPlusSportTDD.Core.Tests
{
    public class ShoppingCartAPITest
    {
        [SetUp]
        public void SetUp() { }

        [Test]
        public void ShouldReturnArticles()
        {
            var controller = new ArticlesController();
            var result = controller.GetAll();
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void ShouldReturnSingleArticle()
        {
            var controller = new ArticlesController();
            var result = controller.Get(2);
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public void ShouldReturn404()
        {
            var controller = new ArticlesController();
            var result = controller.Get(5);
            Assert.AreEqual((result as StatusCodeResult)?.StatusCode, 404);
        }
    }
}
