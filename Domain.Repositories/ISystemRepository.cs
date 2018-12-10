using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites;

namespace Domain.Repositories
{
    public interface ISystemRepository
    {
        void AddGameSystem(GameSystem gameSystem);
        IEnumerable<GameSystem> GetGameSystems();
        GameSystem GetGameSystemById(int id);
    }
}
