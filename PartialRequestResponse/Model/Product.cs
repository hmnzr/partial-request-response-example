namespace PartialRequestResponse.Model
{
    /// <summary>
    /// Sample product model
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string[] Tags { get; set; }
        
        public decimal Price { get; set; }
        
        public decimal Discount { get; set; }
    }
}