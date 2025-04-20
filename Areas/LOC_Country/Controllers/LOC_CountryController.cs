using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebApplication6.Areas.LOC_Country.Models;

namespace WebApplication6.Areas.LOC_Country.Controllers
{

	[Area("LOC_Country")]
	[Route("LOC_Country/LOC_Country/{Action}")]

	public class LOC_CountryController : Controller
	{
		private readonly IConfiguration Configuration;
		public LOC_CountryController(IConfiguration _configuration)
		{
			Configuration = _configuration;
		}

		#region CountryList
		public IActionResult LOC_CountryList()
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_Country_SelectAll";
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			return View(dt);
		}
		#endregion

		#region CountryAdd
		public IActionResult LOC_CountryAdd()
		{
			return View();
		}
		public IActionResult LOC_CountryAddFormPage(LOC_CountryModel model)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_Country_Insert";
			cmd.Parameters.AddWithValue("CountryName", model.CountryName);
			cmd.Parameters.AddWithValue("CountryCode", model.CountryCode);
			cmd.ExecuteNonQuery();
			return RedirectToAction("LOC_CountryList");
		}
		#endregion

		#region CountryEdit

		public IActionResult LOC_CountryEdit(int CountryID)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_Country_SelectByPK";
			cmd.Parameters.AddWithValue("CountryID", CountryID);
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			string CountryName = dt.Rows[0]["CountryName"].ToString();
			string CountryCode = dt.Rows[0]["CountryCode"].ToString();
			ViewBag.CountryID = CountryID;
			ViewBag.CountryName = CountryName;
			ViewBag.CountryCode = CountryCode;
			return View();
		}
		public IActionResult LOC_CountryEditFormPage(LOC_CountryModel model)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_Country_UpdateByPK";
			cmd.Parameters.AddWithValue("CountryID", model.CountryID);
			cmd.Parameters.AddWithValue("CountryCode", model.CountryCode);
			cmd.Parameters.AddWithValue("CountryName", model.CountryName);
			cmd.ExecuteNonQuery();
			return RedirectToAction("LOC_CountryList");
		}
		#endregion

		#region CountryDelete
		public IActionResult LOC_CountryDelete(int CountryID)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_Country_DeleteByPK";
			cmd.Parameters.AddWithValue("CountryID", CountryID);
			cmd.ExecuteNonQuery();
			return RedirectToAction("LOC_CountryList");
		}
		#endregion

		#region CountrySearch
		public IActionResult LOC_CountrySearch(LOC_CountryModel model)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_LOC_Country_Search";
			cmd.Parameters.AddWithValue("CountryName", model.CountryName);
			cmd.Parameters.AddWithValue("CountryCode", model.CountryCode);
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			return View("LOC_CountryList", dt);
		}
		#endregion
	}
}