using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPlusSportTDD.Core.Tests
{
    class ShoppingCartTests
    {
        [SetUp]
        public void SetUp() { }

        [Test]
        public void ShouldReturnArticleAddedToCart()
        {
            var item = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                Item = item
            };

            var manager = new ShoppingCartManager();

            AddToCartResponse response = manager.AddToCart(request);

            Assert.NotNull(response);
            Assert.Contains(item, response.Items);
        }


        [Test]
        public void ShouldReturnTwoArticlesAddedToCart()
        {
            var item1 = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                Item = item1
            };

            var manager = new ShoppingCartManager();

            AddToCartResponse response = manager.AddToCart(request);

            var item2= new AddToCartItem()
            {
                ArticleId = 43,
                Quantity = 5
            };

            request = new AddToCartRequest()
            {
                Item = item2
            };
            response = manager.AddToCart(request);

            Assert.NotNull(response);
            Assert.Contains(item1, response.Items);
            Assert.Contains(item2, response.Items);
        }

        [Test]
        public void ShouldValidateQuantitiesForSameArticle()
        {
            int myQuantity =55;
            AddToCartResponse response = new AddToCartResponse();
            var manager = new ShoppingCartManager();
            for (int i=0; i <= 10; i++)
            {
                
                var item = new AddToCartItem()
                {
                    ArticleId = 42,
                    Quantity = i
                };

                var request = new AddToCartRequest()
                {
                    Item = item
                };
                response = manager.AddToCart(request);
                myQuantity++;
            }
            
            Assert.NotNull(response);
            Assert.That(Array.Exists(response.Items, item => item.Quantity == 55));
        }


        [Test]
        public void ShouldReturnArticleAddedToCartUsingMock()
        {
            var item = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                Item = item
            };
            var mockManager = new Mock<IShoppingCartManager>();
            mockManager.Setup(manager => manager.AddToCart(It.IsAny<AddToCartRequest>()))
                .Returns((AddToCartRequest req) => new AddToCartResponse()
                {
                    Items = new AddToCartItem[] { req.Item }
                });
           //var manager = new ShoppingCartManager();

            AddToCartResponse response = mockManager.Object.AddToCart(request);

            Assert.NotNull(response);
            Assert.Contains(item, response.Items);
        }
    }
}
