using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Entities
{
    public class SellerEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Guid ProductId { get; set; }

        public ProductEntity Product { get; set; }
    }
}
