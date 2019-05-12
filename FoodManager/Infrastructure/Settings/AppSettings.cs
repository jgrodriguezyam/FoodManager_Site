using System.Configuration;
using FoodManager.Infrastructure.Exceptions.AppSettings;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Resolvers;

namespace FoodManager.Infrastructure.Settings
{
    public static class AppSettings
    {
        public static string ServerApi
        {
            get
            {
                var serverApi  =  ConfigurationManager.AppSettings["ServerApi"];
                if(serverApi.IsNullOrEmpty())
                    throw  new UnconfiguredServerException();
                return serverApi;
            }
        }

        public static string Serial
        {
            get
            {
                return ConfigurationManager.AppSettings["Serial"];
            }
        }

        public static string AllowedFileExtensions
        {
            get
            {
                return ConfigurationManager.AppSettings["AllowedFileExtensions"];
            }
        }

        public static int MaxRequestLength
        {
            get
            {
                return ConfigurationManager.GetSection("system.web/httpRuntime").ExtractProperty<int>("MaxRequestLength");
            }
        }

        public static string FilesFolder
        {
            get
            {
                return string.Format("{0}{1}", RootResolver.Resolver, "Content/Images/Files/");
            }
        }

        public static string PointersFolder
        {
            get
            {
                return string.Format("{0}{1}", RootResolver.Resolver, "Content/Images/Pointers/");
            }
        }

        public static string SystemFolder
        {
            get
            {
                return string.Format("{0}{1}", RootResolver.Resolver, "Content/Images/System/");
            }
        }
    }
}