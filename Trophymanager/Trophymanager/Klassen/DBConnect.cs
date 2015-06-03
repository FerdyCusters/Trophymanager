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

                if (dr.Read())
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

        public static int GetClubCode(Club c)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "SELECT Clubcode FROM Club WHERE Username = '" + c.Username + "' AND Clubnaam = '" + c.Clubnaam + "'";
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return Convert.ToInt32(dr[0]);
                }
                return 0;
            }
            catch
            {
                return 0;
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
                cmd.CommandText = "UPDATE Club SET Clubnaam = '" + c.Clubnaam + "', Wachtwoord = '" + c.Wachtwoord + "', Bijnaam = '" + c.Bijnaam + "', Clubkleuren = '" + c.Clubkleuren + "'";
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
                cmd.CommandText = "INSERT INTO Club (Landcode, Username, Wachtwoord, Clubnaam, Bijnaam, Fans, Clubkleuren) VALUES ('" + 1 + "', '" + c.Username + "', '" + c.Wachtwoord + "', '" + c.Clubnaam + "', '" + c.Bijnaam + "', '" + c.Fans + "', '" + c.Clubkleuren + "')";
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

        #region Speler

        public static bool AddSpeler(Speler s)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO Speler (Clubcode, Naam, Leeftijd, Nummer, InOpstelling, Passen, Snelheid, Kracht, Soort) VALUES ('" + s.Club.Clubcode + "', '" + s.Naam + "', '" + s.Leeftijd + "', '" + s.Nummer + "', '" + s.InOpstelling + "', '" + s.Passen + "', '" + s.Snelheid + "', '" + s.Kracht + "', '" + s.Soort + "')";
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

        public static int GetSpelerCode(Speler s)
        {
            try
            {
                conn.OpenAsync();
                cmd.CommandText = "SELECT Spelercode FROM Speler WHERE Nummer = '" + s.Nummer + "' AND Clubcode = '" + s.Club.Clubcode + "'";
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return Convert.ToInt32(dr[0]);
                }
                return 0;
            }
            catch
            {
                return 0;
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
        }
        #endregion

        #region Veldspeler
        public static bool AddVeldSpeler(Veldspeler s)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO Veldspeler (Spelercode, Soort, Positiespel, Afwerken, Koppen, Tackelen, Dekken) VALUES ('" + s.Spelercode + "', 'Veldspeler', '" + s.Positiespel + "', '" + s.Afwerken + "', '" + s.Koppen + "', '" + s.Tackelen + "', '" + s.Dekken + "')";
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

        public static List<Veldspeler> GetVeldpspelers(Club c)
        {
            try
            {
                List<Veldspeler> rtrn = null;

                conn.Open();
                cmd.CommandText = "SELECT S.Spelercode, S.Clubcode, S.Naam, S.Leeftijd, S.Nummer, S.InOpstelling, S.Passen, S.Snelheid, S.Kracht, S.Soort, V.Positiespel, V.Afwerken, V.Koppen, V.Tackelen, V.Dekken FROM Speler S, Veldspeler V WHERE S.Clubcode = '" + c.Clubcode + "' AND S.Soort = 'Veldspeler' AND S.Spelercode = V.Spelercode";
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    rtrn = new List<Veldspeler>();
                    while (dr.Read())
                    {
                        rtrn.Add(new Veldspeler(dr[2].ToString(), Convert.ToInt32(dr[4]), dr[5].ToString(), Convert.ToInt32(dr[3]), Convert.ToInt32(dr[6]), Convert.ToInt32(dr[7]), Convert.ToInt32(dr[8]), dr[9].ToString(), c, Convert.ToInt32(dr[10]), Convert.ToInt32(dr[11]), Convert.ToInt32(dr[12]), Convert.ToInt32(dr[13]), Convert.ToInt32(dr[14])));
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

        #endregion

        #region Keeper
        public static bool AddKeeper(Keeper s)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO Keeper (Spelercode, Soort, Reflexen, Handelen, Uitkomen) VALUES ('" + s.Spelercode + "', 'Keeper', '" + s.Reflexen + "', '" + s.Handelen + "', '" + s.Uitkomen + "')";
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

        public static List<Keeper> GetKeepers(Club c)
        {
            try
            {
                List<Keeper> rtrn = null;

                conn.Open();
                cmd.CommandText = "SELECT S.Spelercode, S.Clubcode, S.Naam, S.Leeftijd, S.Nummer, S.InOpstelling, S.Passen, S.Snelheid, S.Kracht, S.Soort, K.Reflexen, K.Handelen, K.Uitkomen FROM Speler S, Keeper K WHERE S.Clubcode = '" + c.Clubcode + "' AND S.Soort = 'Keeper' AND S.Spelercode = K.Spelercode";
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    rtrn = new List<Keeper>();
                    while (dr.Read())
                    {
                        rtrn.Add(new Keeper(Convert.ToString(dr[2]), Convert.ToInt32(dr[4]), Convert.ToString(dr[5]), Convert.ToInt32(dr[3]), Convert.ToInt32(dr[6]), Convert.ToInt32(dr[7]), Convert.ToInt32(dr[8]), Convert.ToString(dr[9]), c, Convert.ToInt32(dr[10]), Convert.ToInt32(dr[11]), Convert.ToInt32(dr[12])));
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

        #endregion

        #region CT

        public static bool AddCT(Club c, Competitie c2)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO Club_Toernooi (Clubcode, Toernooicode, Wedstrijden, Gewonnen, Verloren, Gelijk, BehaaldePunten) VALUES ('" + c.Clubcode + "', '" + c2.Toernooicode + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "')";
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

        public static List<Club> GetCTs()
        {
            try
            {
                List<Club> rtrn = null;
                conn.Open();
                cmd.CommandText = "SELECT C.Username, C.Wachtwoord, C.Clubnaam, C.Bijnaam, C.Clubkleuren, CT.Wedstrijden, CT.Gewonnen, CT.Gelijk, CT.Verloren, CT.BehaaldePunten FROM Club C, Club_Toernooi CT WHERE C.Clubcode = CT.Clubcode AND Toernooicode = 1";
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    rtrn = new List<Club>();
                    while (dr.Read())
                    {
                        rtrn.Add(new Club(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), Convert.ToInt32(dr[5]), Convert.ToInt32(dr[6]), Convert.ToInt32(dr[7]), Convert.ToInt32(dr[8]), Convert.ToInt32(dr[9])));
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

        #endregion
    }
}