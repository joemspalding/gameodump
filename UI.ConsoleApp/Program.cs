using System;
using System.Reflection;
using Domain.Entites;
using Ninject;

namespace UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

        }
    }
}
