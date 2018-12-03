using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Game
    {
        public int GameId { get; set; }
        public int SystemId { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return "{\n\tGameId = " + GameId + ",\n\tSystemId = " + SystemId + ",\n\tTitle = " + Title + "\n}";
        }
    }
}
