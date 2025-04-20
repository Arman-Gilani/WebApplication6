using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Areas.MST_Student.Models
{
	public class MST_StudentModel
	{
		public int StudentID { get; set; }
		public int BranchID { get; set; }
		public int CityID { get; set; }
		
		[Required]
		public string StudentName { get; set; } = string.Empty;
        
		[Required]
        public string MobileNoStudent { get; set; } = string.Empty;
        
		[Required]
        public string Email { get; set; } = string.Empty;
        
		[Required] 
		public string MobileNoFather { get; set; } = string.Empty;
        
		[Required]
        public string Address { get; set; } = string.Empty;
        
		[Required]
        public string BirthDate { get; set; } = string.Empty;
        
		[Required]
        public string Age { get; set; } = string.Empty;
        
		[Required]
        public string IsActive { get; set; } = string.Empty;
        
		[Required]
        public string Gender { get; set; } = string.Empty;
        
		[Required] 
		public string Password { get; set; } = string.Empty;
	}
}
