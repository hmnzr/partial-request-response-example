using System;
using System.Collections.Generic;
using System.Linq;
using PartialRequestResponse.Model;

namespace PartialRequestResponse
{
    /// <summary>
    /// Sample storage API to Retrieve and update the data. Will be database or another storage in the real project.
    /// </summary>
    public class SampleStorage
    {
        private static readonly Lazy<List<Product>> _products = new Lazy<List<Product>>(() =>
        new List<Product>() {
            new Product
            {
                Id = 1,
                Name = "Computer mouse",
                Description = "A mouse that never lets you down.",
                Price = 29.99m,
                Discount = 0,
                Tags = new[] { "pc", "mouse", "electronics" }
            },
            new Product
            {
                Id = 1,
                Name = "Generic keyboard",
                Description = "Boring but reliable keyboard. Has no RGB though.",
                Price = 24.99m,
                Discount = 3m,
                Tags = new[] { "pc", "keyboard", "electronics" }
            },
            new Product
            {
                Id = 1,
                Name = "Hand sanitizer",
                Description = "Wash your hands and avoid pandemics.",
                Price = 6.70m,
                Discount = 0,
                Tags = new[] { "soap", "sanitizer", "home", "hygiene" }
            },
        });
        
        public List<Product> GetProducts() => _products.Value;

        public Product GetProduct(int id) => _products.Value.FirstOrDefault(it => it.Id == id);
        
        public void UpdateProduct(Product product)
        {
            var products = _products.Value;
            var updateIndex = products.FindIndex(it => it.Id == product.Id);
            products[updateIndex] = product;
        }
    }
}