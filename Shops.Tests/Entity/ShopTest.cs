﻿using System;
using NUnit.Framework;
using Shops.Entity;
using Shops.Exception;

namespace Shops.Tests.Entity
{
    public class ShopTests
    {
        private Shop _shop;

        [SetUp]
        public void Setup()
        {
            _shop = new Shop("123", "Lenta", "Tama, 5");
        }

        [Test]
        public void AddProductToShop_ShopHasProduct()
        {
            var apple = new ProductName("123", "apple");
            _shop.AddProduct(apple, 10, 10);
            Product product = _shop.FindProduct(apple);
            Assert.AreEqual(product.Name, apple);
            Assert.AreEqual(product.Count, 10);
        }
        
        [Test]
        public void AddExistingProductToShop_Throw()
        {
            Assert.Catch<ProductAlreadyExist>(() =>
            {
                var apple = new ProductName("123", "apple");
                _shop.AddProduct(apple, 0, 10);
                _shop.AddProduct(apple, 0, 10);
            });
        }
        
        [Test]
        public void AddProductsWithNegativeCountAndPriceToShop_ThrowArgumentOutOfRangeException()
        {

            Assert.Catch<ArgumentOutOfRangeException>(() =>
            {
                var apple = new ProductName("123", "apple");
                _shop.AddProduct(apple, -1, 10);
            });
            
            Assert.Catch<ArgumentOutOfRangeException>(() =>
            {
                var apple = new ProductName("123", "apple");
                _shop.AddProduct(apple, -0, -10);
            });

        }
        
        public void ChangePriceAndCountToNegative_ThrowArgumentOutOfRangeException()
        {

            Assert.Catch<ArgumentOutOfRangeException>(() =>
            {
                var apple = new ProductName("123", "apple");
                _shop.AddProduct(apple, 0, 10);
                _shop.ChangeProductCount(apple, 100);
            });
            
            Assert.Catch<ArgumentOutOfRangeException>(() =>
            {
                var apple = new ProductName("123", "apple");
                _shop.AddProduct(apple, 0, 10);
                _shop.ChangeProductPrice(apple, 100);
            });

        }
    }
}