using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Infrastructure.Data.API.Abstract;
using Infrastructure.Data.API.Settings;

namespace Infrastructure.Data.API.Concrete
{
    public class SteamGameGetter : IGameGetter
    {
        private HtmlWeb web;

        public List<string> GetGameResponse()
        {
            List<string> steamGamesList = new List<string>();
            web = new HtmlWeb();

            Parallel.For(0, SteamSettings.MAXPAGES,
                index =>
                {
                    Console.WriteLine(index);
                    var doc = web.Load(SteamSettings.URL + index.ToString());

                    List<string> games = doc.DocumentNode
                        .SelectNodes(SteamSettings.XPATH)
                        .Select(x => x.OuterHtml)
                        .ToList();

                    steamGamesList.AddRange(games);
                });


            return steamGamesList;
        }
    }
}
