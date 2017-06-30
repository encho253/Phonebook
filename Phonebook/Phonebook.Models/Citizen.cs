using Phonebook.Contracts.Models;

namespace Phonebook.Models
{
    public class Citizen : ICitizen
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public City City { get; set; }

        public Address Address { get; set; }

        public Phone Phone{ get; set; }
    }
}