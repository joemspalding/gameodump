using System.Collections.Generic;

namespace Infrastructure.Data.API.Abstract
{
    public interface IGameGetter
    {
        List<string> GetGameResponse();
    }
}