using System.ComponentModel.DataAnnotations;
using Xunit;

namespace ballfight.Models
{
    public class User
    {

    
            private ballfightContext context;


            
            public int id { get; set; }

            public string name { get; set; }

            public string email { get; set; }

            public string password { get; set; }

    }
}
