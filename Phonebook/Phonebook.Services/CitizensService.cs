using Phonebook.Contracts.Services;
using Phonebook.Data;
using Phonebook.Models;
using System;
using System.Collections.Generic;

namespace Phonebook.Services
{
    public class CitizensService : ICitizensService
    {
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

        private IEnumerable<Citizen> GetCitizens(string command, string commandParameter = null)
        {
            var citizens = new List<Citizen>();
            var result = database.ReadCommand(command, commandParameter);

            while (result.Read())
            {
                citizens.Add(
                    new Citizen
                    {
                        FirstName = result.GetValue(0).ToString(),
                        LastName = result.GetValue(1).ToString(),
                        Phone = new Phone { PhoneNumber = Int32.Parse(result.GetValue(2).ToString()) },
                        City = new City { Name = result.GetValue(3).ToString() },
                        Address = new Address { Street = result.GetValue(4).ToString(), StreetNumber = result.GetValue(5).ToString() }
                    }
                );
            }

            return citizens;
        }

        public IEnumerable<Citizen> GetCitizens()
        {
            string Get_All_Citizens = "usp_SelectAllCitizens";

            IEnumerable<Citizen> sortedCitizens = GetCitizens(Get_All_Citizens);

            return sortedCitizens;
        }

        public IEnumerable<Citizen> GetCitizensOrderBy(string value)
        {
            string Get_Citizens_OrderBy = "usp_SelectCitizensOrderBy";

            IEnumerable<Citizen> sortedCitizens = GetCitizens(Get_Citizens_OrderBy, value);

            return sortedCitizens;
        }

        public IEnumerable<Citizen> GetCitizensOrderByDesc(string value)
        {
            string Get_Citizens_OrderByDesc = "usp_SelectCitizensOrderByDesc";

            IEnumerable<Citizen> sortedCitizens = GetCitizens(Get_Citizens_OrderByDesc, value);

            return sortedCitizens;
        }
    }
}