using API.HelperClasses;
using System.Text;

namespace API.Models
{
    public class Human
    {

        public int Id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }

        protected Human(int id, string name, string phoneNumber, string email)
        {
            Id = id;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
    }
}
