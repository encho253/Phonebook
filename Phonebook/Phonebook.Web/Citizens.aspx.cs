using Phonebook.Models;
using Phonebook.Services;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Phonebook
{
    public partial class Citizens : Page
    {
        private CitizensService citizensService;   

        public Citizens()
        {
            this.citizensService = new CitizensService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CitizensCollection.DataSource = GetCitizens();
            this.DataBind();
        }

        protected ICollection<Citizen> GetCitizens()
        {
            var citizens = citizensService.GetAllCitizens();

            return citizens;
        }
    }
}