using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Areas.LOC_Country.Models
{
	public class LOC_CountryModel
	{
		public int CountryID { get; set; }
        
		[Required]
        public string CountryName { get; set; } = string.Empty;
        
		[Required]
        public string CountryCode { get; set; } = string.Empty;
	}
    
    public class LOC_CountryDropDownModel
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; } = string.Empty;

    }

}
