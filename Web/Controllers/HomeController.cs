using System.Threading.Tasks;
using Data;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index([FromQuery]string discordId)
        {
            var monsterRepository = new MonsterRepository(Settings.GetConnectionString("Database"), Settings.GetDatabaseSchemaName());
            var player = await monsterRepository.GetPlayer(discordId);
            var homeModel = new HomeModel
            {
                Player = player,
                PlayerMonsterList = await monsterRepository.GetList(player)
            };
            
            return View(homeModel);
        }
    }
}
