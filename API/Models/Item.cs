using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Item
    {
        public Item(int itemid, string name, decimal price, int inStock, int reOrdered, int discounted)
        {
            Itemid = itemid;
            this.name = name;
            this.price = price;
            this.inStock = inStock;
            this.reOrdered = reOrdered;
            Discounted = discounted;
        }

        public int Itemid { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int inStock { get; set; }
        public int reOrdered { get; set; }
        public int Discounted { get; set; }
    }
}
