using RPS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPS.Data.Repository
{
    public interface IGameDataRepository
    {
        public void createGameData(GameData gameData);
    }
}
