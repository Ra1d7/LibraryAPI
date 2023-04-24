using API.HelperClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Customer : Human
    {
        public int humanId { get; set; }
        public int productsBought { get; set; }
        public decimal amountBought { get; set; }
        public Customer(int id, string name, string phoneNumber, string email, string password) : base(id, name, phoneNumber, email)
        {
            this.productsBought = productsBought;
            this.amountBought = amountBought;
        }
    }
}
