using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public byte[] Image { get; set; } = Array.Empty<byte>();
        public string Size { get; set; } = string.Empty;
        public decimal Count { get; set; } = 0;
    }
}
