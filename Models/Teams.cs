using ballfight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BallFight.Models
{
    public class Teams
    {

        private ballfightContext context;


        public int team_id { get; set; }
        public string team_name { get; set; }
        public string team_abr { get; set; }  
        public string city { get; set; }
        public string US_state { get; set; }
        public int W { get; set; }
        public int L { get; set; }
        


    }
}
