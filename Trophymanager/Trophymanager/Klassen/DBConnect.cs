using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        #region Club

        public static bool VerifyClub(string username, string password)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "SELECT null FROM Club WHERE Username = '" + username + "' AND Wachtwoord = '" + password + "'";
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
        }

        /// <summary>
        /// Returns all Users in the Database
        /// </summary>
        public static List<Club> GetClubs()
        {
            try
            {
                List<Club> rtrn = null;

                conn.Open();
                cmd.CommandText = "SELECT Username, Wachtwoord, Clubnaam, Bijnaam, Clubkleuren FROM Club";
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    rtrn = new List<Club>();
                    while (dr.Read())
                    {
                        rtrn.Add(new Club(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString()));
                    }
                }

                return rtrn;
            }
            catch
            {
                return null;
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
        }

        /// <summary>
        /// Returns the corresponding User
        /// </summary>
        public static Club GetClub(string username)
        {
            try
            {
                conn.OpenAsync();
                cmd.CommandText = "SELECT Username, Wachtwoord, Clubnaam, Bijnaam, Clubkleuren FROM Club WHERE Username = '" + username + "'";
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    return new Club(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                }
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
        }

        /// <summary>
        /// Saves all data from the User to the Database
        /// </summary>
        public static bool UpdateClub(Club c)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "UPDATE Club SET Clubnaam = '" + c.Clubnaam + "', Wachtwoord = '" + c.Wachtwoord+ "', Bijnaam = '" + c.Bijnaam + "', Clubkleuren = '" + c.Clubkleuren + "'";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Adds new User to the Database
        /// </summary>
        public static bool AddClub(Club c)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO Club (Clubcode, Landcode, Username, Wachtwoord, Clubnaam, Bijnaam, Fans, Clubkleuren) VALUES ('" + c.Clubcode + "', '" + c.Landcode + "', '" + c.Username+ "', '" + c.Wachtwoord + "', '" + c.Clubnaam + "', '" + c.Bijnaam + "', '" + c.Fans + "', '" + c.Clubkleuren + "')";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Delete current User from the Database
        /// </summary>
        public static bool DeleteClub(string clubnaam)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "DELETE FROM Club WHERE Clubnaam = '" + clubnaam + "'";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}