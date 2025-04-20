using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Areas.LOC_City.Models
{
	public class LOC_CityModel
	{
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        
		[Required]
        public string CityName { get; set; } = string.Empty;
		
		[Required]
		public string CityCode { get; set; } = string.Empty;
		
	}

	public class LOC_CityDropDownModel
	{
		public int CityID { get; set; }
		public string CityName { get; set; } = string.Empty;

	}

}
