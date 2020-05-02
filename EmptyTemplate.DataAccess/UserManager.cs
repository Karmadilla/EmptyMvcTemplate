using Dapper;
using EmptyTemplate.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyTemplate.DataAccess
{
    public class UserManager
    {
        public User GetUser(string email)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Email", email);

            IEnumerable<User> result;

            using (SqlConnection con = new SqlConnection())
            {
                result = con.Query<User>(@"
                SELECT *
                FROM [User]
                WHERE [Email] = @Email", p);
            }

            return result.SingleOrDefault();
        }
    }
}