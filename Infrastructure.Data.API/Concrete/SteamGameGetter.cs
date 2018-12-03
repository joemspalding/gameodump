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
            int start = 1, end, interval = SteamSettings.MAXPAGES / 16;

            for (int i = 1; i <= SteamSettings.MAXPAGES; i++)
            {
                end = start + interval - 1;

                steamGamesList.AddRange(Task.Run(async () => await PaginateGameGetting(start, end)).Result);
                start += interval;
            }

            return steamGamesList;
        }

        private async Task<List<string>> PaginateGameGetting(int start, int end)
        {
            var subGamesList = new List<string>();
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
                var doc = await web.LoadFromWebAsync(SteamSettings.URL + i.ToString());

                List<string> games = doc.DocumentNode
                    .SelectNodes(SteamSettings.XPATH)
                    .Select(x => x.OuterHtml)
                    .ToList();

                subGamesList.AddRange(games);
            }

            return subGamesList;
        }
    }
}