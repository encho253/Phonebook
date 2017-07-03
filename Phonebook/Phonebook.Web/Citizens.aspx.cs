using Phonebook.Models;
using Phonebook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
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
            //CitizensCollection.DataSource = GetCitizens();
            //this.DataBind();
        }


        public IEnumerable<Citizen> CitizensCollection_GetData()
        {          
            HttpCookie cookie = Request.Cookies["OrderBy"];

            if (cookie == null)
            {
                cookie = new HttpCookie("OrderBy");
                cookie.Expires = DateTime.Now.AddHours(1);
            }

            string queryParameter = Request.QueryString["id"];
            StringBuilder builder = new StringBuilder();

            if (cookie.Value == queryParameter)
            {
                cookie.Value = builder.Append(queryParameter).Append("Descending").ToString();
            }
            else
            {
                cookie.Value = queryParameter;
            }

            Response.Cookies.Add(cookie);

            switch (cookie.Value)
            {
                case "FirstName":
                    return citizensService.GetCitizensOrderBy();
                case "FirstNameDescending":
                    return citizensService.GetCitizens();
                case "LastName":
                    return citizensService.GetCitizens();
                case "LastNameDescending":
                    return citizensService.GetCitizens();
                default:
                    return citizensService.GetCitizens();
            }      
        }
    }
}