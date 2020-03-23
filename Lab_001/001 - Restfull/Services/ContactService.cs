using _001___Restfull.Models;
using _001___Restfull.Models.DAO;
using _001___Restfull.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _001___Restfull.Services
{
    public class ContactService
    {
        private const string CacheKey = "ContactList";
        private ContactDAO dao;

        public ContactService()
        {
            this.dao = new ContactDAO();
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                ctx.Cache[CacheKey] = GetAllContacts();
            }
        }
        public Contact[] GetAllContacts()
        {
            DSLDataType oReturn = dao.GetContacts();
            if (oReturn.BoolValue)
            {
                return (Contact[])oReturn.Value;
            }
            return null;
        }

        public bool SaveContact(Contact contact)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    DSLDataType oReturn = dao.SaveContact(contact);
                    if (oReturn.BoolValue)
                    {
                        var currentData = ((Contact[])ctx.Cache[CacheKey]).ToList();
                        currentData.Add(contact);
                        ctx.Cache[CacheKey] = currentData.ToArray();
                    }
                    else
                    {
                        throw new Exception(oReturn.Value.ToString());
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}