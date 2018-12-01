using Infrastructure.Data.API.Abstract;
using HtmlAgilityPack;
using System.Web;
using Infrastructure.Data.API.Settings;

namespace Infrastructure.Data.API.Concrete
{
    public class PlayStation4GameGetter : IGameGetter
    {   
        public string GetGameResponse(int page)
        {
            var web = new HtmlWeb();
            for (int i = 0; i < Playstation4Settings.MAXPAGES; i++)
            {
                var doc = web.Load(Playstation4Settings.URL+ "/" + i.ToString());
                
                
            }
            return "";
        }
    }
}