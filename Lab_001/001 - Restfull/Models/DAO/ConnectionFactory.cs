using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _001___Restfull.Models.DAO
{
    public static class ConnectionFactory
    {

        public static SqlConnection GetConnection()
        {
            string ConnectionString = String.Format(@ConfigurationManager.AppSettings["SQLCONN"].ToString(),
            ConfigurationManager.AppSettings["DBSERVER"].ToString(),
            ConfigurationManager.AppSettings["DBNAME"].ToString(),
            ConfigurationManager.AppSettings["DBUSER"].ToString(),
            ConfigurationManager.AppSettings["DBPASS"].ToString());

            return new SqlConnection(ConnectionString);
        }
    }
}