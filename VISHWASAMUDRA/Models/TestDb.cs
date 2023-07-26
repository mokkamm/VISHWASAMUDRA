using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace VISHWASAMUDRA.Models
{
	public class TestDb
	{
		public int VHTID { get; set; }
		public string VHT_Name { get; set; }
		public int LOADCAPACITYCBM { get; set; }
		public string RecordStatus { get; set; }

		SqlConnection conn = new SqlConnection("Server = 172.16.16.22; Database=TEST_DB;User Id = administrator; Password=Admin@321$;");
		SqlCommand cmd;
		public DataTable GetVehicleType()
		{
			cmd = new SqlCommand("VehicleTypes", conn);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			return dt;
		}
		public int TestInsert()
		{
			cmd = new SqlCommand("InsertData", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@VHTTYPE", VHT_Name);
			cmd.Parameters.AddWithValue("@LOADCAPACITY", LOADCAPACITYCBM);
			cmd.Parameters.AddWithValue("@RecordStatus", RecordStatus);
			conn.Open();
			int i = cmd.ExecuteNonQuery();
			conn.Close();
			return i;
		}
		public int Delete()
		{
			cmd = new SqlCommand("Delete", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@VHTID", VHTID);
			conn.Open();
			int i = cmd.ExecuteNonQuery();
			conn.Close();
			return i;
		}
		public int Update()
		{
			cmd = new SqlCommand("Update", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@VHTID", VHTID);
			cmd.Parameters.AddWithValue("@LOADCAPACITY", LOADCAPACITYCBM);
			conn.Open();
			int i = cmd.ExecuteNonQuery();
			conn.Close();
			return i;
		}
		public DataTable Get()
		{
			cmd = new SqlCommand("GETVEHICLETYPE", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@VHTID", VHTID);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			return dt;
		}
	}
}