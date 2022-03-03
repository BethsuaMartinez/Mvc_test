using System.ComponentModel.DataAnnotations;
using Xunit;

namespace ballfight.Models
{
    public class userModel
    {

    
            private ballfightContext context;


            
            public int id { get; set; }

            [Required(ErrorMessage = "Please enter name")]
            public string name { get; set; }

            public string email { get; set; }

            public string password { get; set; }

    }
}
