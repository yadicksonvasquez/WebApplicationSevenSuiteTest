using System.Web.Http;
using Unity;
using Unity.WebApi;
using WebApplicationSevenSuiteTest.model.repositories;
using WebApplicationSevenSuiteTest.services;

namespace WebApplicationSevenSuiteTest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IEstadoCivilRepository, EstadoCivilRepositoryImpl>();
            container.RegisterType<IEstadoCivilService, EstadoCivilServiceImpl>();
            container.RegisterType<IUsuarioRepository, UsuarioRepositoryImpl>();
            container.RegisterType<IUsuarioService, UsuarioServiceImpl>();
            container.RegisterType<ISevenSuiteClienteRepository, SevenSuiteClienteRepositoryImpl>();
            container.RegisterType<ISevenSuiteClienteService, SevenSuiteClienteServiceImpl>();
            

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}