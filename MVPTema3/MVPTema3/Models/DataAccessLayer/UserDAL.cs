using MVPTema3.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.DataAccessLayer
{
    class UserDAL
    {
        public ObservableCollection<User> GetAllUsers()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", con);
                ObservableCollection<User> result = new ObservableCollection<User>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string convert = "";
                while (reader.Read())
                {
                    User user = new User();
                    convert += reader.GetInt32(0);
                    user.UserID = convert;
                    convert = "";
                    user.Name = reader.GetString(1);
                    user.Surname = reader.GetString(2);
                    user.Password = reader.GetString(3);
                    result.Add(user);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
