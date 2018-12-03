using System;
using System.Collections.Generic;
using Domain.Entites;
using HtmlAgilityPack;
using Service.Abstract;

namespace Service.Concrete
{
    public class Playstation4GameTranslator : IGameTranslator
    {
        private int id = 0;
        private const string XPATH = "//span[@title]";

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
                    .SelectSingleNode(XPATH)
                    .InnerHtml;
                title = System.Net.WebUtility.HtmlDecode(title);

                if (!titles.Contains(title))
                {
                    games.Add(new Game()
                    {
                        GameId = ++id,
                        SystemId = 2,
                        Title = title
                    });
                    titles.Add((title));
                }
            }

            return games;
        }
    }
}