using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminNameSpace;
using UserNamespace;

namespace DatabaseNameSpace
{
    public  class DataBase
    {
        public User[] Users { get; set; }
        public int UserCount { get; set; }
        public Admin[] Admins { get; set; }
        public int AdminCount { get; set; }
        public User GetUserByEmail(string email)
        {
            foreach (var user in Users)
            {
                if (user.Email == email) return user;
            }
            return null;
        }
        public Admin GetAdminByEmail(string email)
        {
            foreach (var admin in Admins)
            {
                if (admin.Email == email) return admin;
            }
            return null;
        }


    }
}
