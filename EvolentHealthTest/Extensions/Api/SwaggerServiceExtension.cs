using EvolentHealthTest.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EvolentHealthTest.Extensions.Api
{
    /// <summary>
    /// Swagger service extension
    /// </summary>
    public static class SwaggerServiceExtension
    {
        #region Public Method

        /// <summary>
        /// Adding swagger user
        /// </summary>
        /// <param name="services">Iservicecollection</param>
        /// <param name="appSetting">Appsettings</param>
        /// <returns>Returns the service</returns>
        public static IServiceCollection AddUserSwagger(this IServiceCollection services, AppSettings appSetting)
        {
            if (appSetting.SwaggerEnabled)
            {

                services.AddSwaggerGen(c =>
                {

                    var version = "V1";
                    c.SwaggerDoc(version, new OpenApiInfo
                    {
                        Version = version,
                        Title = "Evolent Health Service"
                    });

                });
            }

            return services;
        }

        /// <summary>
        /// Use swagger 
        /// </summary>
        /// <param name="app">Iapplicationbuilder</param>
        /// <param name="appSetting">Appsettings</param>
        /// <returns>Returns the app</returns>
        public static IApplicationBuilder UseUserSwaggerUi(this IApplicationBuilder app, AppSettings appSetting)
        {

            if (appSetting.SwaggerEnabled)
            {
                var routePrefix = appSetting.BaseRoute;
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = BuildPath(includeStartingSlash: false, routePrefix, "swagger/{documentname}/swagger.json");
                });

                app.UseSwaggerUI(c =>
                {
                    var swaggerEndpointUrl = string.Empty;
                    var name = "V1";

                    swaggerEndpointUrl = BuildPath(includeStartingSlash: true, "swagger", name, "swagger.json");
                    c.SwaggerEndpoint(swaggerEndpointUrl, $"Evolent health Service Api {name}");
                    c.DefaultModelExpandDepth(3);
                    c.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
                    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                    c.EnableDeepLinking();
                    c.DisplayOperationId();
                });
            }
            return app;
        }

        #endregion

        #region Private Method

        private static string BuildPath(bool includeStartingSlash, params string[] paths)
        {
            const string delimiter = "/";
            var path = string.Join(delimiter, paths);
            return includeStartingSlash
                ? delimiter + path
                : path;
        }

        #endregion
    }
}
