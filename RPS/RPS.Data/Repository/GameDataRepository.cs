using RPS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Data.Repository
{
    public class GameDataRepository : IGameDataRepository
    {

        private readonly RPS_DBContext _rpsContext;

        public GameDataRepository(RPS_DBContext rpsDbContext)
        {
            _rpsContext = rpsDbContext;
        }

        public void createGameData(GameData gameData)
        {
            GameData gameStats = gameData;
            _rpsContext.Games.Add(gameStats);
            _rpsContext.SaveChanges();
        }

    }
}
