using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ASP.NET_Exercise_02.App_Code
{
    public static class Base_Connection_Class
    {
        public static string excption;
        private static readonly string ConnString = ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString;
        public static DataTable Select_Query(string query)
        {
            SqlConnection con = null;
            DataTable ds = new DataTable();
            try
            {
                con = new SqlConnection(ConnString);
                SqlCommand cm = new SqlCommand(query, con);
                cm.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cm);
                sda.Fill(ds);
            }
            catch (Exception e)
            {
                excption = e.Message;
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public static string Delete_Query(string query, string ParameterName, int id)
        {
            SqlConnection con = null;
            try
            {
                excption = "";
                con = new SqlConnection(ConnString);
                SqlCommand cm = new SqlCommand(query, con);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue(ParameterName, id);
                con.Open();
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                excption = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return excption;
        }

        public static string Insert_Update_Query(string query, Dictionary<string, string> parameters)
        {
            SqlConnection con = null;
            try
            {
                excption = "";
                con = new SqlConnection(ConnString);
                SqlCommand cm = new SqlCommand(query, con);
                cm.CommandType = CommandType.StoredProcedure;
                foreach (var pair in parameters)
                {
                    cm.Parameters.AddWithValue(pair.Key, pair.Value);
                }
                con.Open();
                cm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                excption = e.Message;
            }
            finally
            {
                con.Close();
            }
            return excption;
        }

        public static Dictionary<string, string> Get_Assigned_Record(int id)
        {
            Dictionary<string, string> str = new Dictionary<string, string>();
            SqlConnection con = null;
            try
            {
                excption = "";
                con = new SqlConnection(ConnString);
                SqlCommand cm = new SqlCommand($"select * from assign_party where assign_id={id}", con);
                con.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                sdr.Read();
                string party_id = sdr["party_id"].ToString();
                string product_id = sdr["product_id"].ToString();
                str.Add("party", party_id);
                str.Add("product", product_id);
            }
            catch (Exception e)
            {
                excption = e.Message;
            }
            finally
            {
                con.Close();
            }
            str.Add("error", excption);
            return str;
        }

        public static Dictionary<string, string> Get_Rate_Record(int id)
        {
            Dictionary<string, string> str = new Dictionary<string, string>();
            SqlConnection con = null;
            try
            {
                excption = "";
                con = new SqlConnection(ConnString);
                SqlCommand cm = new SqlCommand($"select product_id from rate where rate_id={id}", con);
                con.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                sdr.Read();
                str.Add("value", sdr["product_id"].ToString());
            }
            catch (Exception e)
            {
                excption = e.Message;
            }
            finally
            {
                con.Close();
            }
            str.Add("error", excption);
            return str;
        }

        public static DataTable Get_Products_By_party(int id)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                SqlCommand product_query = new SqlCommand($"select distinct product.product_id as product_id, product.product_name as product_name from product,assign_party,rate where product.product_id=assign_party.product_id and rate.product_id=product.product_id and assign_party.party_id = {id}", con);
                SqlDataAdapter product_adapter = new SqlDataAdapter(product_query);
                product_adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                excption = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public static string Get_Rate(int id)
        {
            string text = "";
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                SqlCommand cm = new SqlCommand($"select top 1 rate from rate where product_id = {id} order by date_of_rate desc", con);
                con.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                sdr.Read();
                text = sdr["rate"].ToString();

            }
            catch (Exception ex)
            {
                excption = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return text;
        }

        public static DataTable Show_Invoice(string query, Dictionary<string, string> parameters)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            try
            {
                excption = "";
                con = new SqlConnection(ConnString);
                SqlCommand cm = new SqlCommand(query, con);
                cm.CommandType = CommandType.StoredProcedure;
                foreach (var pair in parameters)
                {
                    cm.Parameters.AddWithValue(pair.Key, pair.Value);
                }
                con.Open();
                SqlDataAdapter sde = new SqlDataAdapter(cm);
                sde.Fill(dt);
            }
            catch (Exception e)
            {
                excption = e.Message;
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
    }
}