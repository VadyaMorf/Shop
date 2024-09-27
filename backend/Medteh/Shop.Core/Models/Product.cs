using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class Product
    {
        public const int Max_Titile_Lenght = 250;
        private Product(Guid id, string title,string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }

        public static (Product Product, string Error) Create(Guid id, string title, string description, decimal price)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(title) || title.Length > Max_Titile_Lenght)
            {
                error = "Title can not be empty or longer then 250 symbols";
            }

            var product = new Product(id, title, description, price);

            return (product, error);
        }
    }
}
