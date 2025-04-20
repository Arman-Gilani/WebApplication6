using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Areas.MST_Branch.Models
{
	public class MST_BranchModel
	{
		public int BranchID { get; set; }

		[Required]
		public string BranchName { get; set; } = string.Empty;

		[Required]
		public string BranchCode { get; set; } = string.Empty;
	}

	public class MST_BranchDropDownModel
	{
		public int BranchID { get; set; }
		public string BranchName { get; set; } = string.Empty;

	}

}
