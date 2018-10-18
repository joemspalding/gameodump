using Domain.Repositories;
using Infrastructure.Data;
using Ninject.Modules;

namespace UI.ConsoleApp
{
    class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameRepository>().To<GameRepository>();
            Bind<ISystemRepository>().To<SystemRepository>();
        }
    }
}
