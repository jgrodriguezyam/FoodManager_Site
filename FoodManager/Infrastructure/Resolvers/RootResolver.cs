using System.Web;

namespace FoodManager.Infrastructure.Resolvers
{
    public static class RootResolver
    {
        public static string Resolver
        {
            get
            {
                var request = HttpContext.Current.Request;
                return string.Format("{0}://{1}{2}/", request.Url.Scheme, request.Url.Authority, request.ApplicationPath);
            }
        } 
    }
}