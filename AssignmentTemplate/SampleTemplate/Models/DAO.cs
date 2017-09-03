using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Helpers;
using System.Web.Configuration;

namespace SampleTemplate.Models
{
    public class DAO
    {
        SqlConnection conn;
        public string message = "";

        public void Connection ()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["conStringLocal"].ConnectionString);
        }
        //public int Insert ()
    }
}