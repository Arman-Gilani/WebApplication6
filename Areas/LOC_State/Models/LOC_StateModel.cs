using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Areas.LOC_State.Models
{
	public class LOC_StateModel
	{
		public int StateID { get; set; }

		[Required]
		public int CountryID { get; set; }

        [Required]
        public string StateName { get; set; } = string.Empty;
		
		[Required] 
		public string StateCode { get; set; } = string.Empty;
	}

	public class LOC_StateDropDownModel
	{
		public int StateID { get; set; }

		public string StateName { get; set; } = string.Empty;

	}

}
