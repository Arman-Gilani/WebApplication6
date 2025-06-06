﻿using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebApplication6.Areas.MST_Branch.Models;

namespace WebApplication6.Areas.MST_Branch.Controllers
{
	[Area("MST_Branch")]
	[Route("MST_Branch/MST_Branch/{Action}")]

	public class MST_BranchController : Controller
	{
		private readonly IConfiguration Configuration;
		public MST_BranchController(IConfiguration _configuration)
		{ 
			Configuration = _configuration;
		}

		#region BranchList
		public IActionResult MST_BranchList()
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SelectAll_Branch";
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			return View(dt);
		}
		#endregion

		#region BranchAdd
		public IActionResult MST_BranchAdd()
		{
			return View();
		}
		public IActionResult MST_BranchAddFormPage(MST_BranchModel model)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Insert_Branch";
			cmd.Parameters.AddWithValue("bcode", model.BranchCode);
			cmd.Parameters.AddWithValue("bname", model.BranchName);
			cmd.ExecuteNonQuery();
			return RedirectToAction("MST_BranchList");
		}
		#endregion

		#region BranchEdit
		public IActionResult MST_BranchEdit(int BranchID)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SelectBy_PK_Branch";
			cmd.Parameters.AddWithValue("bid", BranchID);
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			string BranchName = dt.Rows[0]["BranchName"].ToString();
			string BranchCode = dt.Rows[0]["BranchCode"].ToString();
			ViewBag.BranchID = BranchID;
			ViewBag.BranchName = BranchName;
			ViewBag.BranchCode = BranchCode;
			return View();
		}

		public IActionResult MST_BranchEditFormPage(MST_BranchModel model)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Update_Branch";
			cmd.Parameters.AddWithValue("bid", model.BranchID);
			cmd.Parameters.AddWithValue("bocde", model.BranchCode);
			cmd.Parameters.AddWithValue("bname", model.BranchName);
			cmd.ExecuteNonQuery();
			return RedirectToAction("MST_BranchList");
		}
		#endregion

		#region BranchDelete
		public IActionResult MST_BranchDelete(int BranchID)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "Delete_Branch";
			cmd.Parameters.AddWithValue("bid", BranchID);
			cmd.ExecuteNonQuery();
			return RedirectToAction("MST_BranchList");
		}
		#endregion

		#region BranchSearch
		public IActionResult MST_BranchSearch(MST_BranchModel model)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_Branch_Search";
			cmd.Parameters.AddWithValue("BranchName", model.BranchName);
			cmd.Parameters.AddWithValue("BranchCode", model.BranchCode);
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			return View("MST_BranchList",dt);
		}
		#endregion
	}
}