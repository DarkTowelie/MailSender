using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MailSender.Models;

namespace MailSender
{
    internal class DbManager
    {
        public List<User> selectUsers()
        {
            using (IDbConnection conn = new SQLiteConnection(loadConnString()))
            {
                return conn.Query<User>("SELECT * FROM [User]").ToList();
            }
        }

        public void insertUser(User user)
        {
            using (IDbConnection conn = new SQLiteConnection(loadConnString()))
            {
                conn.Execute("INSERT INTO [User] (Email, FirstName, LastName, MiddleName, Age)" +
                    "VALUES  (@Email, @FirstName, @LastName, @MiddleName, @Age)", user);
            }
        }

        private string loadConnString(string id = "default")
        {
            return "Data Source=.\\User.db; Version=3;";
        }
    }
}
