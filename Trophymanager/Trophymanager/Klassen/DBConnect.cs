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
        /// Initializeert de database connectie
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
        /// Returned true als er is geconnect met de database
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

        /// <summary>
        /// Checked of de username en het wachtwoord kloppen.
        /// </summary>

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
        /// Haalt alle clubs uit de database
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
        /// Haalt een bepaalde club uit de database
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

        /// <summary>
        /// Haalt een clubcode uit de database
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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
        /// Update een club in de database
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
        /// Voegt een club toe aan de database
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
        /// Verwijdert een club uit de database
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

        /// <summary>
        /// Speler wordt aan de database toegevoegd
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Spelercode wordt uit de database gehaald
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update de "InOpstelling" status van een speler
        /// </summary>
        public static bool UpdateSpeler(Speler s, string inOpstelling)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "UPDATE SPELER SET InOpstelling = '" + inOpstelling + "' WHERE Spelercode = '" + s.Spelercode + "'";
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

        #region Veldspeler

        /// <summary>
        /// Veldspeler wordt aan de database toegevoegd
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Veldspelers worden uit de database gehaald
        /// </summary>
        /// <param name="c"></param>
        /// <param name="basis"></param>
        /// <returns></returns>
        public static List<Veldspeler> GetVeldpspelers(Club c, string basis)
        {
            try
            {
                List<Veldspeler> rtrn = new List<Veldspeler>();

                conn.Open();
                cmd.CommandText = "SELECT S.Spelercode, S.Clubcode, S.Naam, S.Leeftijd, S.Nummer, S.InOpstelling, S.Passen, S.Snelheid, S.Kracht, S.Soort, V.Positiespel, V.Afwerken, V.Koppen, V.Tackelen, V.Dekken FROM Speler S, Veldspeler V WHERE S.Clubcode = '" + c.Clubcode + "' AND S.Soort = 'Veldspeler' AND S.Spelercode = V.Spelercode AND InOpstelling = '" + basis + "'";
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

        /// <summary>
        /// Keeper wordt aan de database toegevoegd
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Keepers worden uit de database gehaald
        /// </summary>
        /// <param name="c"></param>
        /// <param name="basis"></param>
        /// <returns></returns>
        public static List<Keeper> GetKeepers(Club c, string basis)
        {
            try
            {
                List<Keeper> rtrn = new List<Keeper>();

                conn.Open();
                cmd.CommandText = "SELECT S.Spelercode, S.Clubcode, S.Naam, S.Leeftijd, S.Nummer, S.InOpstelling, S.Passen, S.Snelheid, S.Kracht, S.Soort, K.Reflexen, K.Handelen, K.Uitkomen FROM Speler S, Keeper K WHERE S.Clubcode = '" + c.Clubcode + "' AND S.Soort = 'Keeper' AND S.Spelercode = K.Spelercode AND InOpstelling = '" + basis + "'";
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