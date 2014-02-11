using System.Web.Mvc;
using Autofac;
using Reload.Common.Authentication;
using Reload.Repository;
using Reload.Service;

namespace ReloadingApp.Configuration.Dependencies
{
	/// <summary>The dependency configuration class.</summary>
	public static class DependencyConfig
	{
		/// <summary>Configures the dependencies.</summary>
		public static void Initialize()
		{
			DependencyResolver.SetResolver(new Dependency(RegisterServices()));
		}

		/// <summary>Registers the services as dependencies.</summary>
		private static IContainer RegisterServices()
		{
			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).PropertiesAutowired();

			//builder.RegisterType<UserIdentityData>().As<IUserIdentityData>();

			// Auto register all Services.
			builder.RegisterAssemblyTypes(typeof(BaseService).Assembly)
				.Where(t => t.Name.EndsWith("Service"))
				.AsImplementedInterfaces()
				.PropertiesAutowired();

			// Auto register all Repositories.
			builder.RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
				.Where(t => t.Name.EndsWith("Repository"))
				.AsImplementedInterfaces()
				.PropertiesAutowired();

			return builder.Build();
		}
	}
}