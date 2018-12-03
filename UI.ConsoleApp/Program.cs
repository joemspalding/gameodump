using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using Domain.Entites;
using Infrastructure.Data.API.Abstract;
using Infrastructure.Data.API.Concrete;
using Ninject;
using Service.Abstract;
using Service.Concrete;

namespace UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var diConfig = new DIConfig(kernel);
            kernel = diConfig.GetConfiguredKernel();

            //GetGames(new PlayStation4GameGetter(), new Playstation4GameTranslator());
            GetGames(new SteamGameGetter(), new SteamGameTranslator());

            Console.WriteLine("honk honk 2 stronk");
        }

        static void GetGames(IGameGetter gameGetter, IGameTranslator gameTranslator)
        {
            List<Game> gameList = new List<Game>();
            var responses = gameGetter.GetGameResponse();


            gameList = gameTranslator.TranslateGames(responses);
            foreach (var game in gameList)
            {
                Console.WriteLine(game);
            }
        }
    }
}