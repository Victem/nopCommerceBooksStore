using Nop.Services.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Plugins;
using System.Web.Routing;
using Nop.Plugin.Widgets.DeliveryDiscount.Data;

namespace Nop.Plugin.Widgets.DeliveryDiscount
{
    public class DeliveryDiscountPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly DeliveryDiscountLabelObjectContext _context;

        public DeliveryDiscountPlugin(DeliveryDiscountLabelObjectContext context)
        {
            _context = context;
        }

        public void GetConfigurationRoute(
            out string actionName, 
            out string controllerName, 
            out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "WidgetsDeliveryDiscount";
            routeValues = new RouteValueDictionary
            {
                { "Namespaces", "Nop.Plugin.Widgets.DeliveryDiscount.Controllers" },
                { "area", null }
            };
        }

        public void GetDisplayWidgetRoute(
            string widgetZone, 
            out string actionName, 
            out string controllerName, 
            out RouteValueDictionary routeValues)
        {

            actionName = "RenderWidget";
            controllerName = "WidgetsDeliveryDiscount";

            routeValues = new RouteValueDictionary
            {
                { "Namespaces", "Nop.Plugin.Widgets.DeliveryDiscount.Controllers" },
                { "area", null },
                { "widgetZone", widgetZone}
            };
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string> { "delivery-discount"};
        }


        public override void Install()
        {
            _context.Install();
            base.Install();
        }

        public override void Uninstall()
        {
            _context.Uninstall();
            base.Uninstall();
        }
    }
}
