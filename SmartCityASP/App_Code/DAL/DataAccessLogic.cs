using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SmartCityASP.App_Code.DAL
{
    public class DataAccessLogic
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataSet ds = null;

        public DataAccessLogic()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        public DataSet ExecuteDataset(string sqlCommandText)
        {
            da = new SqlDataAdapter(sqlCommandText, con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet ExecuteDataset(string sqlCommandText, CommandType commandType)
        {
            da = new SqlDataAdapter(sqlCommandText, con);
            da.SelectCommand.CommandType = commandType;
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet ExecuteDataset(string sqlCommandText, CommandType commandType, SqlParameter p)
        {
            da = new SqlDataAdapter(sqlCommandText, con);
            da.SelectCommand.CommandType = commandType;
            da.SelectCommand.Parameters.Add(p);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet ExecuteDataset(string sqlCommandText, CommandType commandType, SqlParameter[] p)
        {
            da = new SqlDataAdapter(sqlCommandText, con);
            da.SelectCommand.CommandType = commandType;
            da.SelectCommand.Parameters.AddRange(p);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int ExecuteNonQuery(string sqlCommandText)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sqlCommandText, con);
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();

            return rowAffected;
        }

        public int ExecuteNonQuery(string sqlCommandText, CommandType commandType, SqlParameter p)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sqlCommandText, con);
            cmd.CommandType = commandType;
            cmd.Parameters.Add(p);
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();

            return rowAffected;
        }

        public int ExecuteNonQuery(string sqlCommandText, CommandType commandType, SqlParameter[] p)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sqlCommandText, con);
            cmd.CommandType = commandType;
            cmd.Parameters.AddRange(p);
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();

            return rowAffected;
        }

        public string ExecuteScalar(string sqlCommandText)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sqlCommandText, con);
            string rowAffected = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            return rowAffected;
        }

        public string ExecuteScalar(string sqlCommandText, CommandType commandType, SqlParameter p)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sqlCommandText, con);
            cmd.CommandType = commandType;
            cmd.Parameters.Add(p);
            string rowAffected = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            return rowAffected;
        }

        public string ExecuteScalar(string sqlCommandText, CommandType commandType, SqlParameter[] p)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd = new SqlCommand(sqlCommandText, con);
            cmd.CommandType = commandType;
            cmd.Parameters.AddRange(p);
            string rowAffected = Convert.ToString(cmd.ExecuteScalar());
            con.Close();

            return rowAffected;
        }
    }
}