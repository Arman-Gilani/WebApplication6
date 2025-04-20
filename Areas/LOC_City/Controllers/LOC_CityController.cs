using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebApplication6.Areas.LOC_City.Models;
using WebApplication6.Areas.LOC_Country.Models;
using WebApplication6.Areas.LOC_State.Models;

namespace WebApplication6.Areas.LOC_City.Controllers
{
	[Area("LOC_City")]
	[Route("LOC_City/LOC_City/{Action}")]

	public class LOC_CityController : Controller
	{
		private readonly IConfiguration Configuration;
		public LOC_CityController(IConfiguration _configuration)
		{
			Configuration = _configuration;
		}

		#region CityList
		public IActionResult LOC_CityList()
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_City_SelectAll";
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			return View(dt);
		}
		#endregion

		#region CityAdd
		public IActionResult LOC_CityAdd()
		{
			LOC_CityDropDown();
			return View();
		}

		public IActionResult LOC_CityAddFormPage(LOC_CityModel modal)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_City_Insert";
			cmd.Parameters.AddWithValue("CityName", modal.CityName);
			cmd.Parameters.AddWithValue("CityCode", modal.CityCode);
			cmd.Parameters.AddWithValue("StateID", modal.StateID);
			cmd.Parameters.AddWithValue("CountryID", modal.CountryID);
			cmd.ExecuteNonQuery();
			return RedirectToAction("LOC_CityList");
		}
		#endregion

		#region CityEdit
		public IActionResult LOC_CityEdit(int CityID)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_City_SelectByPK";
			cmd.Parameters.AddWithValue("CityID", CityID);
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			string CityName = dt.Rows[0]["CityName"].ToString();
			string CityCode = dt.Rows[0]["CityCode"].ToString();
			string StateID = dt.Rows[0]["StateID"].ToString();
			string CountryID = dt.Rows[0]["CountryID"].ToString();
			ViewBag.CityID = CityID;
			ViewBag.CityName = CityName;
			ViewBag.CityCode = CityCode;
			ViewBag.StateID = StateID;
			ViewBag.CountryID = CountryID;
			return View();
		}
		public IActionResult LOC_CityUpdateFillFormData(LOC_CityModel modal)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_City_UpdateByPK";
			cmd.Parameters.AddWithValue("CityID", modal.CityID);
			cmd.Parameters.AddWithValue("CityName", modal.CityName);
			cmd.Parameters.AddWithValue("StateID", modal.StateID);
			cmd.Parameters.AddWithValue("CityCode", modal.CityCode);
			cmd.Parameters.AddWithValue("CountryID", modal.CountryID);
			cmd.ExecuteNonQuery();
			return RedirectToAction("LOC_CityList");
		}
		#endregion

		#region CityDelete
		public IActionResult LOC_CityDelete(int CityID)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_City_DeleteByPK";
			cmd.Parameters.AddWithValue("CityID", CityID);
			cmd.ExecuteNonQuery();
			conn.Close();
			return RedirectToAction("LOC_CityList");
		}
		#endregion

		#region CitySearch
		public IActionResult LOC_CitySearch(LOC_CityModel modal)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_LOC_City_Search";
			cmd.Parameters.AddWithValue("CityName", modal.CityName);
			cmd.Parameters.AddWithValue("CityCode", modal.CityCode);
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			return View("LOC_CityList",dt);
		}
		#endregion

		#region CityDropDown
		public IActionResult LOC_CityDropDown()
		{

			string str = this.Configuration.GetConnectionString("connectionString");
			List<LOC_CountryDropDownModel> list1 = new List<LOC_CountryDropDownModel>();
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_COUNTRY_DROPDOWN";

			SqlDataReader sqlDataReader = cmd.ExecuteReader();

			if (sqlDataReader.HasRows)
			{
				while (sqlDataReader.Read())
				{
					LOC_CountryDropDownModel country = new LOC_CountryDropDownModel()
					{
						CountryID = Convert.ToInt32(sqlDataReader["CountryID"]),
						CountryName = sqlDataReader["CountryName"].ToString()
					};
					list1.Add(country);
				}
				sqlDataReader.Close();
			}

			sqlDataReader.Close();
			ViewBag.CountryList = list1;
			conn.Close();

			List<LOC_StateDropDownModel> list2 = new List<LOC_StateDropDownModel>();
			conn.Open();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_STATE_DROPDOWN";
			sqlDataReader = cmd.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				while (sqlDataReader.Read())
				{
					LOC_StateDropDownModel state = new LOC_StateDropDownModel()
					{
						StateID = Convert.ToInt32(sqlDataReader["StateID"]),
						StateName = sqlDataReader["StateName"].ToString()
					};
					list2.Add(state);
				}
				sqlDataReader.Close();
			}

			sqlDataReader.Close();
			ViewBag.StateList = list2;
			conn.Close();

			return RedirectToAction("LOC_CityList");

		}
		#endregion

	}
}
