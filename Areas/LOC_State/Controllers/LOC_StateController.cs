using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebApplication6.Areas.LOC_State.Models;
using WebApplication6.Areas.LOC_Country.Models;

namespace WebApplication6.Areas.LOC_State.Controllers
{
	[Area("LOC_State")]
	[Route("LOC_State/LOC_State/{Action}")]
	public class LOC_StateController : Controller
	{
		private readonly IConfiguration Configuration;
		public LOC_StateController(IConfiguration _configuration)
		{
			Configuration = _configuration;
		}

		#region StateList
		public IActionResult LOC_StateList()
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_State_SelectAll";
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			return View(dt);
		}
		#endregion

		#region StateAdd
		public IActionResult LOC_StateAdd()
		{
			LOC_StateDropDown();
            return View();
		}
		public IActionResult LOC_StateAddFormPage(LOC_StateModel model)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_State_Insert";
			cmd.Parameters.AddWithValue("CountryID", model.CountryID);
			cmd.Parameters.AddWithValue("StateName", model.StateName);
			cmd.Parameters.AddWithValue("StateCode", model.StateCode);
			cmd.ExecuteNonQuery();
			return RedirectToAction("LOC_StateList");
		}
		#endregion

		#region StateEdit
		public IActionResult LOC_StateEdit(int StateID)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_State_SelectByPK";
			cmd.Parameters.AddWithValue("StateID", StateID);
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			string CountryID = dt.Rows[0]["CountryID"].ToString();
			string CountryName = dt.Rows[0]["CountryName"].ToString();
			string StateName = dt.Rows[0]["StateName"].ToString();
			string StateCode = dt.Rows[0]["StateCode"].ToString();
			ViewBag.CountryID = CountryID;
			ViewBag.CountryName = CountryName;
			ViewBag.StateID = StateID;
			ViewBag.StateName = StateName;
			ViewBag.StateCode = StateCode;

			return View();
		}
		public IActionResult LOC_StateEditFormPage(LOC_StateModel model)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_State_UpdateByPK";
			cmd.Parameters.AddWithValue("StateID", model.StateID);
			cmd.Parameters.AddWithValue("StateName", model.StateName);
			cmd.Parameters.AddWithValue("StateCode", model.StateCode);
			cmd.Parameters.AddWithValue("CountryID", model.CountryID);
			cmd.ExecuteNonQuery();
			return RedirectToAction("LOC_StateList");
		}
		#endregion

		#region StateDelete
		public IActionResult LOC_StateDelete(int StateID)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_State_DeleteByPK";
			cmd.Parameters.AddWithValue("StateID", StateID);
			cmd.ExecuteNonQuery();
			conn.Close();
			return RedirectToAction("LOC_StateList");
		}
		#endregion

		#region StateSearch
		public IActionResult LOC_StateSearch(LOC_StateModel model)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_LOC_State_Search";
			cmd.Parameters.AddWithValue("StateName", model.StateName);
			cmd.Parameters.AddWithValue("StateCode", model.StateCode);
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			return View("LOC_StateList", dt);
		}
		#endregion

		#region StateDropDown
		public IActionResult LOC_StateDropDown() 
		{

            string str = this.Configuration.GetConnectionString("connectionString");
			List<LOC_CountryDropDownModel> list = new List<LOC_CountryDropDownModel>();
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
					list.Add(country);	
				}
				sqlDataReader.Close();	
			}

			sqlDataReader.Close();
			ViewBag.CountryList = list;
            conn.Close();
            return RedirectToAction("LOC_StateList");

        }
		#endregion

	}
}