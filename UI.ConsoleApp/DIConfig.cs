using Ninject;
 
namespace UI.ConsoleApp
{
    public class DIConfig
    {
        private readonly StandardKernel _kernel;
        public DIConfig(StandardKernel kernel)
        {
            _kernel = kernel;
        }
        
        public StandardKernel GetConfiguredKernel()
        {
            //kernel.Bind<>()
            return _kernel;
        }
    }
}