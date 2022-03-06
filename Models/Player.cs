using ballfight.Models;

namespace BallFight.Models
{
    public class Player
    {

        private ballfightContext context;

        public int player_id { get; set; }
        public int team_id { get; set; }
        public int player_num { get; set; }
        public string player_name { get; set; }
        public string player_pos { get; set; }
        public int PTS { get; set; }
        public int REB { get; set; }
        public int AST { get; set; }
        public int BLK { get; set; }
        public int GP { get; set; }
        public int FGM { get; set; }
        public int FGA { get; set; }
        public int three_PM { get; set; }
        public int three_PA { get; set; }
        public int FTM { get; set; }
        public int FTA { get; set; }
        public int STL { get; set; }
        public int PF { get; set; }
    }
}
