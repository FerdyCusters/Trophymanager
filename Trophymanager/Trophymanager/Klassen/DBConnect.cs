using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

namespace Trophymanager.Klassen
{
    public static class DBConnect
    {
        #region Fields
        private static OracleConnection conn;
        private static OracleCommand cmd = new OracleCommand();
        private static OracleDataReader dr;
        #endregion

        #region General
        /// <summary>
        /// Initializes the database connection
        /// </summary>
        public static bool InitializeConnection()
        {
            try
            {
                string user = "SOFTWARE";
                string pw = "Wachtwoord";
                string connstring = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //localhost/xe" + ";";
                conn = new OracleConnection(connstring);
                cmd.Connection = conn;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true when we are connected to the database.
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}