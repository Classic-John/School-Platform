using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MVPTema3.Models.DataAccessLayer
{
    static class DALHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MVPTema3.Properties.Settings.MVP_DBConnectionString"].ConnectionString;

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
