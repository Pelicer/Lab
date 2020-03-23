using _001___Restfull.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _001___Restfull.Models.DAO
{
    public class ContactDAO
    {
        private SqlConnection conn;

        public ContactDAO()
        {
            this.conn = ConnectionFactory.GetConnection();
        }

        public DSLDataType SaveContact(Contact ctc)
        {
            DSLDataType oReturn = new DSLDataType();
            try
            {
                string query = String.Format(@"
                INSERT INTO
                    [lab].[Users]
                VALUES
                    ('{0}', '{1}')
                ", ctc.Name, ctc.Email);
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                oReturn.BoolValue = true;
                oReturn.Value = "Contact saved successully";
            }
            catch (Exception e)
            {
                oReturn.BoolValue = false;
                oReturn.Value = e.Message.ToString();
            }
            return oReturn;
        }

        public DSLDataType GetContacts()
        {
            DSLDataType oReturn = new DSLDataType();
            try
            {
                string query = "SELECT * FROM [lab].[Users]";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<Contact> ContactList = new List<Contact>();
                while (reader.Read())
                {
                    Contact c = new Contact()
                    {
                        Id = Int32.Parse(reader[0].ToString()),
                        Name = reader[1].ToString(),
                        Email = reader[2].ToString()
                    };
                    ContactList.Add(c);
                }
                cmd.Connection.Close();

                oReturn.BoolValue = true;
                oReturn.Value = ContactList.ToArray();
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