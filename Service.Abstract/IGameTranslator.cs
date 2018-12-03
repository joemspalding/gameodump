using Domain.Entites;
using System.Collections.Generic;

namespace Service.Abstract
{
    public interface IGameTranslator
    {
        // TODO: Figure out what type to pass into parameter.
        List<Game> TranslateGames(List<string> response);
    }
}
