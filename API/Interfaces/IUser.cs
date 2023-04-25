using API.Models;

namespace API.Interfaces
{
    public interface IUser
    {
        public int ContactId { get; set; }
        public string? Password { get; set; }
        public ContactDetail Contact { get; set; }
    }
}
