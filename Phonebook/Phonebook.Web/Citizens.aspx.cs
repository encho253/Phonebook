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
        private IEnumerable<Citizen> citizens;

        public Citizens()
        {
            this.citizensService = new CitizensService();
            this.citizens = new List<Citizen>();
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

            if ((cookie.Value == queryParameter) && (queryParameter != null))
            {
                cookie.Value = builder.Append(queryParameter).Append("Descending").ToString();

                this.citizens = citizensService.GetCitizensOrderByDesc(queryParameter);
            }
            else if(queryParameter == null)
            {
                this.citizens = citizensService.GetCitizens();
            }
            else
            {
                cookie.Value = queryParameter;

                this.citizens = citizensService.GetCitizensOrderBy(queryParameter);
            }

            Response.Cookies.Add(cookie);

            return citizens;
        }
    }
}