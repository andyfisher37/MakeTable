using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeTable
{
	internal class DataProvider
	{
		// Get DataTable from SQLServer 
		public static DataTable _getDataSQL(string conn, string cmd)
		{
			try
			{
				SqlConnection Conn = new SqlConnection(conn);
				Conn.Open();
				SqlTransaction tr = Conn.BeginTransaction();
				DataTable dt = new DataTable();
				SqlCommand cm = new SqlCommand(cmd, Conn) { Transaction = tr };
				cm.CommandType = CommandType.Text;
				SqlDataReader dr = cm.ExecuteReader();
				dt.Load(dr);
				tr.Commit();
				Conn.Close();
				dr.Dispose();
				cm.Dispose();
				tr.Dispose();
				return dt;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		// Get data from SQLServer with one result (int)
		public static int _getDataSQLs(string conn, string cmd)
		{
			try
			{
				SqlConnection Conn = new SqlConnection(conn);
				Conn.Open();
				SqlCommand cm = new SqlCommand(cmd, Conn);
				cm.CommandType = CommandType.Text;
				int res = Convert.ToInt16(cm.ExecuteScalar());
				Conn.Close();
				cm.Dispose();
				return res;
			}
			catch (Exception ex)
			{
				return -1;
			}
		}
	}
}
