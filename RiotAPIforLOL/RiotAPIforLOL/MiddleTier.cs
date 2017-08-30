using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RiotAPIforLOL
{
    public class MiddleTier
    {
        private SqlConnection conn = new SqlConnection();
        //Command objects
        private SqlCommand scmd = new SqlCommand();

        public MiddleTier()
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["LOLDBConnection"].ToString();
        }

        public SqlDataReader Login(string username, string password)//(string email, string password, out string firstname, out string lastname, out string value)
        {
            OpenDatabase();
            try
            {
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = "select Firstname from ProfileInformation where LOLusername = @user and Password = @password";


                scmd.Parameters.Clear();
                scmd.Parameters.Add("@user", SqlDbType.VarChar).Value = username;
                scmd.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = password;

                return scmd.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (SqlException sqx)
            {
                throw sqx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlConnection OpenDatabase()
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    //open the connection to pubs
                    conn.Open();
                    //return the object
                    return conn;
                }
                catch (SqlException sqx)
                {
                    throw sqx;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        public SqlConnection CloseDatabase()
        {
            try
            {
                //close the database connection
                conn.Close();

                //return the object
                return conn;
            }
            catch (SqlException sqx)
            {
                throw sqx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ReturnSelectedChamps(string id)
        {
            OpenDatabase();
            try
            {
                DataTable dt = new DataTable();
                dt.TableName = "Champions";

                //scmd = new SqlCommand("ReturnChampName", conn);
                scmd.Connection = conn;
                scmd.CommandType = System.Data.CommandType.StoredProcedure;
                scmd.CommandText = "ReturnChampName";

                scmd.Parameters.Clear();
                scmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                SqlDataReader dr = scmd.ExecuteReader();
                dt.Load(dr);

                //RvvrbDataTable rdt = new RvvrbDataTable(dt);
                CloseDatabase();
                return dt;
            }
            catch (SqlException sqx)
            {
                throw sqx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader returnChampName(string id)
        {
            OpenDatabase();
            try
            {
                //conn.Open();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.CommandText = "ReturnChampName";

                scmd.Parameters.Clear();
                scmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                return scmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException sqx)
            {
                throw sqx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddNewChampion(string id, string name)
        {
            try
            {
                conn.Open();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.CommandText = "AddNewChampion";

                scmd.Parameters.Clear();

                scmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                scmd.Parameters.Add("@champname", SqlDbType.VarChar, 30).Value = name;

                scmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException sqx)
            {
                throw sqx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddANewRecord(string id, string fname, string lname, string email, string region, string username, string password)
        {
            try
            {
                conn.Open();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.CommandText = "NewUser";

                scmd.Parameters.Clear();

                scmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                scmd.Parameters.Add("@fname", SqlDbType.VarChar, 30).Value = fname;
                scmd.Parameters.Add("@lname", SqlDbType.VarChar, 30).Value = lname;
                scmd.Parameters.Add("@username", SqlDbType.NVarChar, 20).Value = username;
                scmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                scmd.Parameters.Add("@pass", SqlDbType.VarChar, 20).Value = password;
                scmd.Parameters.Add("@region", SqlDbType.VarChar, 4).Value = region;

                scmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException sqx)
            {
                throw sqx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string returnUsername(string username)
        {
            try
            {
                conn.Open();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.CommandText = "CheckUsername";

                scmd.Parameters.Clear();
                scmd.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = username;
                scmd.Parameters.Add("@retval", SqlDbType.VarChar, 1).Direction = ParameterDirection.Output;

                scmd.ExecuteNonQuery();
                string value = (string)scmd.Parameters["@retval"].Value;
                return value;
            }
            catch (SqlException sqx)
            {
                throw sqx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public string returnEmail(string email)
        {
            try
            {
                conn.Open();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.CommandText = "CheckEmail";

                scmd.Parameters.Clear();
                scmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                scmd.Parameters.Add("@retval", SqlDbType.VarChar, 1).Direction = ParameterDirection.Output;

                scmd.ExecuteNonQuery();
                string value = (string)scmd.Parameters["@retval"].Value;
                return value;
            }
            catch (SqlException sqx)
            {
                throw sqx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}