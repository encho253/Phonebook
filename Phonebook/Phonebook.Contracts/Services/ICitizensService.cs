using Phonebook.Contracts.Models;
using System.Collections.Generic;

namespace Phonebook.Contracts.Services
{
    public interface ICitizensService
    {
        IEnumerable<ICitizen> GetCitizens();

        IEnumerable<ICitizen> GetCitizensOrderBy(string value);


        IEnumerable<ICitizen> GetCitizensOrderByDesc(string value);
    }
}