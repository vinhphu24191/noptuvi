using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Localization;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.LaSoTuVi.Infrastructure
{
    /// <summary>
    /// Represents provider that provided generic routes
    /// </summary>
    public partial class CustomGenericUrlRouteProvider : IRouteProvider
    {
        #region Methods

        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="routeBuilder">Route builder</param>
        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {

            //define this routes to use in UI views (in case if you want to customize some of them later)
            routeBuilder.CustomMapGenericPathRoute("Nop.Plugin.LaSoTuVi.Controllers.TVHomeController", "TVHome/Index",
                 new { controller = "TVHome", action = "Index" });

        }


        #endregion

        #region Properties

        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority
        {
            //it should be the last route. we do not set it to -int.MaxValue so it could be overridden (if required)
            get { return -12; }
        }

        #endregion
    }
}
