using Data.Context.Models;
using System.Collections.Generic;

namespace Web.Models
{
    public class HomeModel
    {
        public List<PlayerMonster> PlayerMonsterList { get; set; }
        public Player Player { get; set; }
    }
}
