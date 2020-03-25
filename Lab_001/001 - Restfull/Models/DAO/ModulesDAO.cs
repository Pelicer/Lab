using _001___Restfull.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _001___Restfull.Models.DAO
{
    public class ModulesDAO
    {
        private SqlConnection conn;

        public ModulesDAO()
        {
            this.conn = ConnectionFactory.GetConnection();
        }

        public DSLDataType AuthenticateCredentials(int ModuleID, string PrivateKey)
        {
            DSLDataType oReturn = new DSLDataType();
            try
            {
                string query = String.Format("SELECT PrivateKey FROM [lab].Module WHERE ID = {0}", ModuleID);
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if(PrivateKey.ToUpper() == reader[0].ToString().ToUpper())
                    {
                        oReturn.BoolValue = true;
                        oReturn.Value = PrivateKey.ToUpper();
                        break;
                    }
                    else
                    {
                        oReturn.BoolValue = false;
                        oReturn.Value = "Unauthorized";
                    }
                }
                cmd.Connection.Close();

            }
            catch (Exception e)
            {
                oReturn.BoolValue = false;
                oReturn.Value = e.Message.ToString();
            }
            return oReturn;

        }
    }
}