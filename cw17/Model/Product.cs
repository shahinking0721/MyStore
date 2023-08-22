using System.Diagnostics;

namespace Mystore.Models
{
    public class Product
    {
        public int PruductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string DateProduction { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
