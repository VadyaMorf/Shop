using System;
using System.Collections.Generic;
using System.Drawing;
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
        public string Size {  get; set; } = string.Empty;

        public SellerEntity Seller { get; set; }

        public Guid SellerId { get; set; }

        public List<BuyerEntity> Buyers { get; set; }
    }
}
