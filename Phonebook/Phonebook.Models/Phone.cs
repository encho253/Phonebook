using Phonebook.Contracts.Models;

namespace Phonebook.Models
{
    public class Phone : IPhoneNumber
    {
        public int PhoneNumber { get; set; }
    }
}