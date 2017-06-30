using Phonebook.Contracts.Models;

namespace Phonebook.Models
{
    public class Address : IAddress
    {
        public object Street { get; set; }
        public object StreetNumber { get; set; }
    }
}