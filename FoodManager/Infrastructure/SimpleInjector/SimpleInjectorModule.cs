using System.Reflection;
using System.Web.Mvc;
using FoodManager.Infrastructure.Attributes;
using FoodManager.Services;
using FoodManager.Services.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace FoodManager.Infrastructure.SimpleInjector
{
    public static class SimpleInjectorModule
    {
        private static Container _container;
        private static GlobalFilterCollection _filters;

        public static void SetContainer(Container container)
        {
            _container = container;
        }

        public static void SetFilters()
        {
            _filters = GlobalFilters.Filters;
        }

        public static void LoadServices()
        {
            _container.Register<IAccountService, AccountService>(Lifestyle.Singleton);
            _container.Register<IBranchService, BranchService>(Lifestyle.Transient);
            _container.Register<ICompanyService, CompanyService>(Lifestyle.Singleton);
            _container.Register<IDealerService, DealerService>(Lifestyle.Singleton);
            _container.Register<IDepartmentService, DepartmentService>(Lifestyle.Singleton);
            _container.Register<IDiseaseService, DiseaseService>(Lifestyle.Singleton);
            _container.Register<IIngredientGroupService, IngredientGroupService>(Lifestyle.Singleton);
            _container.Register<IIngredientService, IngredientService>(Lifestyle.Singleton);
            _container.Register<IJobService, JobService>(Lifestyle.Singleton);
            _container.Register<IMenuService, MenuService>(Lifestyle.Singleton);
            _container.Register<IRegionService, RegionService>(Lifestyle.Singleton);
            _container.Register<IReservationService, ReservationService>(Lifestyle.Singleton);
            _container.Register<ISaucerMultimediaService, SaucerMultimediaService>(Lifestyle.Singleton);
            _container.Register<ISaucerConfigurationService, SaucerConfigurationService>(Lifestyle.Singleton);
            _container.Register<ISaucerService, SaucerService>(Lifestyle.Singleton);
            _container.Register<ITipService, TipService>(Lifestyle.Singleton);
            _container.Register<IUserService, UserService>(Lifestyle.Singleton);
            _container.Register<IWarningService, WarningService>(Lifestyle.Singleton);
            _container.Register<IWorkerService, WorkerService>(Lifestyle.Singleton);
            _container.Register<IReservationDetailService, ReservationDetailService>(Lifestyle.Singleton);
            _container.Register<IRoleService, RoleService>(Lifestyle.Singleton);
        } 

        public static void LoadFilters()
        {
            _filters.Add(_container.GetInstance<ExceptionAttribute>());
            _filters.Add(_container.GetInstance<CompressAttribute>());
            _filters.Add(_container.GetInstance<ValidateAttribute>());
        }

        public static void VerifyContainer()
        {
            _container.RegisterMvcIntegratedFilterProvider();
            _container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            _container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(_container));
        }
    }
}