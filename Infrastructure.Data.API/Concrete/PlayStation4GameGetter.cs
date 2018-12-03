using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Data.API.Abstract;
using HtmlAgilityPack;
using System.Web;
using Infrastructure.Data.API.Settings;

namespace Infrastructure.Data.API.Concrete
{
    public class PlayStation4GameGetter : IGameGetter
    {   
        public List<string> GetGameResponse()
        {
            Console.WriteLine("PS4");
            List<string> ps4GamesList = new List<string>();
            var web = new HtmlWeb();
            for (int i = 1; i <= Playstation4Settings.MAXPAGES; i++)
            {
                Console.WriteLine(i);
                var doc = web.Load(Playstation4Settings.URL+ "/" + i.ToString());

                List<string> games = doc.DocumentNode
                    .SelectNodes(Playstation4Settings.XPATH)
                    .Select(x => x.OuterHtml)
                    .ToList();
                
                ps4GamesList.AddRange(games);

            }
            
            
            return ps4GamesList;
        }
    }
}