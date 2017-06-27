using Phonebook.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;

namespace Phonebook
{
    public partial class About : Page
    {
        private List<Citizen> citizens;        

        public About()
        {
            this.Citizens = new List<Citizen>();
        }

        public List<Citizen> Citizens
        {
            get
            {
                return this.citizens;
            }
            set
            {
                this.citizens = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Test.DataSource = GetCitizens();
            this.DataBind();
        }

        protected ICollection GetCitizens()
        {
            string con = "Data Source=.;Initial Catalog=Phonebook;Integrated Security=True";
            string com = "SELECT FirstName, LastName FROM dbo.Citizens;";

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand(com, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    //string result = ($"{ reader.GetValue(0)} { reader.GetValue(1)}");
                    var fname = reader.GetValue(0);
                    var lname = reader.GetValue(1);
                    this.Citizens.Add(new Citizen { FirstName = fname.ToString(), LastName = lname.ToString() });
                }

                //Console.WriteLine(String.Format("{0}, {1}", reader.GetValue(0), reader.GetValue(1)));
                connection.Close();
            }

            return this.Citizens;
        }
    }
}