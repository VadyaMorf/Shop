using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shop.Core.Models
{
    public class Product
    {
        public const int Max_Titile_Lenght = 250;
        private Product(Guid id, string title, string description, decimal price, byte[] image, string size, decimal count)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Image = image;
            Size = size;
            Count = count; 
        }
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }
        public byte[] Image { get; } = Array.Empty<byte>();
        public string Size { get;}=string.Empty;
        public decimal Count { get; }

        public static (Product Product, string Error) Create(Guid id, string title, string description, decimal price, byte[] image, string size, decimal count)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > Max_Titile_Lenght)
            {
                error = "Title can not be empty or longer then 250 symbols";
            }

            if (image == null)
            {
                error = "Image cannot be empty.";
            }

            var product = new Product(id, title, description, price, image, size, count);

            return (product, error);
        }
    }
}
