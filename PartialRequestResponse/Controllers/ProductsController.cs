using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PartialRequestResponse.Model;

namespace PartialRequestResponse.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly SampleStorage _storage;

        public ProductsController(SampleStorage storage)
        {
            _storage = storage;
        }
        
        /// <summary>
        /// Returns list of all available products
        /// </summary>
        public IActionResult GetAllProducts()
        {
            var allProducts = _storage.GetProducts();
            return Ok(allProducts);
        }

        /// <summary>
        /// Implements partial update of a product
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <param name="patch">Patch data</param>
        [HttpPatch]
        public IActionResult PatchProduct(int id, JsonPatchDocument<Product> patch)
        {
            var product = _storage.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            
            patch.ApplyTo(product);
            _storage.UpdateProduct(product);

            return NoContent();
        }
    }
}