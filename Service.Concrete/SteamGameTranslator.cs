using Domain.Entites;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Service.Concrete
{
    public class SteamGameTranslator : IGameTranslator
    {
        public int id = 0;

        public List<Game> TranslateGames(List<string> responses)
        {
            var doc = new HtmlDocument();
            string title;
            List<string> titles = new List<string>();
            List<Game> games = new List<Game>();


            foreach (var response in responses)
            {
                doc.LoadHtml(response);


                title = doc.DocumentNode
                    .InnerText;
                title = System.Net.WebUtility.HtmlDecode(title);

                if (!titles.Contains(title))
                {
                    games.Add(new Game()
                    {
                        GameId = ++id,
                        SystemId = 1,
                        Title = title
                    });
                    titles.Add((title));
                }
            }

            return games;
        }
    }
}