using System.Web.Http;
using koFun.Contracts;
using koFun.Data;
using koFun.Data.Helpers;
using Ninject;

namespace koFun
{
    public class IocConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var kernel = new StandardKernel();

            kernel.Bind<ICodeCamperUow>()
                .To<CodeCamperUow>();

            kernel.Bind<IRepositoryProvider>()
                .To<RepositoryProvider>();

            kernel.Bind<RepositoryFactories>()
                .To<RepositoryFactories>()
                .InSingletonScope();

            config.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}