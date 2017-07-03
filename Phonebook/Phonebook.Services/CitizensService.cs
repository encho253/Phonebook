using Phonebook.Contracts.Services;
using Phonebook.Data;
using Phonebook.Models;
using System;
using System.Collections.Generic;

namespace Phonebook.Services
{
    public class CitizensService : ICitizensService
    {
        private const string Get_All_Citizens = "usp_SelectAllCitizens";
        private const string Get_All_Citizens_OrderBy = "usp_SelectCitizensOrderBy";

        private DatabaseProvider database;

        public CitizensService()
        {
            this.Database = new DatabaseProvider();

        }

        public DatabaseProvider Database
        {
            get
            {
                return this.database;
            }
            set
            {
                this.database = value;
            }
        }

        private IEnumerable<Citizen> GetCitizens(string command)
        {
            var citizens = new List<Citizen>();
            var result = database.ReadCommand(command);

            while (result.Read())
            {
                citizens.Add(
                    new Citizen
                    {
                        FirstName = result.GetValue(0).ToString(),
                        LastName = result.GetValue(1).ToString(),
                        Phone = new Phone { PhoneNumber = Int32.Parse(result.GetValue(2).ToString()) },
                        City = new City { Name = result.GetValue(3).ToString()},
                        Address = new Address { Street = result.GetValue(4).ToString(), StreetNumber = result.GetValue(5).ToString() }
                    }
                );
            }

            return citizens;
        }

        public IEnumerable<Citizen> GetCitizens()
        {
            IEnumerable<Citizen> sortedCitizens = GetCitizens(Get_All_Citizens);

            return sortedCitizens;
        }

        public IEnumerable<Citizen> GetCitizensOrderBy()
        {
            IEnumerable<Citizen> sortedCitizens = GetCitizens(Get_All_Citizens_OrderBy);

            return sortedCitizens;
        }
    }
}