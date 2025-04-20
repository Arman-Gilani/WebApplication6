using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebApplication6.Areas.MST_Student.Models;
using WebApplication6.Areas.LOC_Country.Models;
using WebApplication6.Areas.MST_Branch.Models;
using WebApplication6.Areas.LOC_State.Models;
using WebApplication6.Areas.LOC_City.Models;

namespace WebApplication6.Areas.MST_Student.Controllers
{
	[Area("MST_Student")]
	[Route("MST_Student/MST_Student/{Action}")]
	public class MST_StudentController : Controller
	{
		private readonly IConfiguration Configuration;
		public MST_StudentController(IConfiguration _configuration)
		{
			Configuration = _configuration;
		}

		#region StudentList
		public IActionResult MST_StudentList()
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SelectAll_Student";
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			return View(dt);
		}
		#endregion

		#region StudentAdd
		public IActionResult MST_StudentAdd()
		{
			LOC_StudentDropDown();
			return View();
		}
		public IActionResult MST_StudentAddFormPage(MST_StudentModel model)
		{
			DateTime dateTime = DateTime.Now;
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Insert_Student";
			cmd.Parameters.AddWithValue("branchid", model.BranchID);
			cmd.Parameters.AddWithValue("cityid", model.CityID);
			cmd.Parameters.AddWithValue("studentname", model.StudentName);
			cmd.Parameters.AddWithValue("mobileno_student", model.MobileNoStudent);
			cmd.Parameters.AddWithValue("email", model.Email);
			cmd.Parameters.AddWithValue("mobileno_father", model.MobileNoFather);
			cmd.Parameters.AddWithValue("address", model.Address);
			cmd.Parameters.AddWithValue("dob", model.BirthDate);
			cmd.Parameters.AddWithValue("age", model.Age);
			cmd.Parameters.AddWithValue("isActive", model.IsActive);
			cmd.Parameters.AddWithValue("gender", model.Gender);
			cmd.Parameters.AddWithValue("password", model.Password);
			cmd.Parameters.AddWithValue("created", dateTime);
			cmd.Parameters.AddWithValue("modified", dateTime);
			cmd.ExecuteNonQuery();
			return RedirectToAction("MST_StudentList");
		}
		#endregion

		#region StudentEdit
		public IActionResult MST_StudentEdit(int StudentID)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SelectByPk_Student";
			cmd.Parameters.AddWithValue("studentid", StudentID);
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			string studentID = dt.Rows[0]["StudentID"].ToString();
			string branchID = dt.Rows[0]["BranchID"].ToString();
			string cityID = dt.Rows[0]["CityID"].ToString();
			string StudentName = dt.Rows[0]["StudentName"].ToString();
			string MobileNoStudent = dt.Rows[0]["MobileNoStudent"].ToString();
			string Email = dt.Rows[0]["Email"].ToString();
			string MobileNoFather = dt.Rows[0]["MobileNoFather"].ToString();
			string Address = dt.Rows[0]["Address"].ToString();
			string BirthDate = dt.Rows[0]["BirthDate"].ToString();
			string Age = dt.Rows[0]["Age"].ToString();
			string IsActive = dt.Rows[0]["IsActive"].ToString();
			string Gender = dt.Rows[0]["Gender"].ToString();
			string Password = dt.Rows[0]["Password"].ToString();

			ViewBag.BranchID = branchID;
			ViewBag.CityID = cityID;
			ViewBag.StudentID = studentID;
			ViewBag.StudentName = StudentName;
			ViewBag.MobileNoStudent = MobileNoStudent;
			ViewBag.Email = Email;
			ViewBag.MobileNoFather = MobileNoFather;
			ViewBag.Address = Address;
			ViewBag.BirthDate = BirthDate;
			ViewBag.Age = Age;
			ViewBag.IsActive = IsActive;
			ViewBag.Gender = Gender;
			ViewBag.Password = Password;
			ViewBag.StudentID = StudentID;
			return View();
		}
		public IActionResult MST_StudentUpdateFillFormData(MST_StudentModel model)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Update_Student";
			cmd.Parameters.AddWithValue("studentid", model.StudentID);
			cmd.Parameters.AddWithValue("branchid", model.BranchID);
			cmd.Parameters.AddWithValue("cityid", model.CityID);
			cmd.Parameters.AddWithValue("studentname", model.StudentName);
			cmd.Parameters.AddWithValue("mobileno_student", model.MobileNoStudent);
			cmd.Parameters.AddWithValue("email", model.Email);
			cmd.Parameters.AddWithValue("mobileno_father", model.MobileNoFather);
			cmd.Parameters.AddWithValue("address", model.Address);
			cmd.Parameters.AddWithValue("dob", model.BirthDate);
			cmd.Parameters.AddWithValue("age", model.Age);
			cmd.Parameters.AddWithValue("isActive", model.IsActive);
			cmd.Parameters.AddWithValue("gender", model.Gender);
			cmd.Parameters.AddWithValue("password", model.Password);
			cmd.ExecuteNonQuery();
			return RedirectToAction("MST_StudentList");
		}
		#endregion

		#region StudentDelete
		public IActionResult MST_StudentDelete(int StudentID)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Delete_Student";
			cmd.Parameters.AddWithValue("studentid", StudentID);
			cmd.ExecuteNonQuery();
			conn.Close();
			return RedirectToAction("MST_StudentList");
		}
		#endregion

		#region StudentSearch
		public IActionResult MST_StudentSearch(MST_StudentModel model)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_Student_Search";
			cmd.Parameters.AddWithValue("StudentName", model.StudentName);
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			return View("MST_StudentList", dt);
		}
		#endregion

		#region StudentDropDown
		public IActionResult LOC_StudentDropDown()
		{

			string str = this.Configuration.GetConnectionString("connectionString");
			List<MST_BranchDropDownModel> list1 = new List<MST_BranchDropDownModel>();
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_BRANCH_DROPDOWN";

			SqlDataReader sqlDataReader = cmd.ExecuteReader();

			if (sqlDataReader.HasRows)
			{
				while (sqlDataReader.Read())
				{
					MST_BranchDropDownModel branch = new MST_BranchDropDownModel()
					{
						BranchID = Convert.ToInt32(sqlDataReader["BranchID"]),
						BranchName = sqlDataReader["BranchName"].ToString()
					};
					list1.Add(branch);
				}
				sqlDataReader.Close();
			}

			sqlDataReader.Close();
			ViewBag.BranchList = list1;
			conn.Close();



			List<LOC_CityDropDownModel> list2 = new List<LOC_CityDropDownModel>();
			conn.Open();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_CITY_DROPDOWN";
			sqlDataReader = cmd.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				while (sqlDataReader.Read())
				{
					LOC_CityDropDownModel city = new LOC_CityDropDownModel()
					{
						CityID = Convert.ToInt32(sqlDataReader["CityID"]),
						CityName = sqlDataReader["CityName"].ToString()
					};
					list2.Add(city);
				}
				sqlDataReader.Close();
			}

			sqlDataReader.Close();
			ViewBag.CityList = list2;
			conn.Close();

			return RedirectToAction("MST_StudentList");

		}
		#endregion

	}
}