using Ninject;
using Phonebook.Contracts.Models;
using Phonebook.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Phonebook
{
    public partial class Citizens : Page
    {     
        private IEnumerable<ICitizen> citizens;

        public Citizens()
        {
            this.citizens = new List<ICitizen>();
        }

        [Inject]
        public ICitizensService CitizensService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //CitizensCollection.DataSource = GetCitizens();
            //this.DataBind();
        }


        public IEnumerable<ICitizen> CitizensCollection_GetData()
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

                this.citizens = this.CitizensService.GetCitizensOrderByDesc(queryParameter);
            }
            else if(queryParameter == null)
            {
                this.citizens = this.CitizensService.GetCitizens();
            }
            else
            {
                cookie.Value = queryParameter;

                this.citizens = this.CitizensService.GetCitizensOrderBy(queryParameter);
            }

            Response.Cookies.Add(cookie);

            return citizens;
        }
    }
}