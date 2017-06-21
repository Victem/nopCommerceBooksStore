using Nop.Core;
using Nop.Plugin.Widgets.DeliveryDiscount.Domain;
using Nop.Plugin.Widgets.DeliveryDiscount.Models;
using Nop.Plugin.Widgets.DeliveryDiscount.Services;
using Nop.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nop.Plugin.Widgets.DeliveryDiscount.Controllers
{
    public class WidgetsDeliveryDiscountController : BasePluginController
    {
        private readonly IDeliveryDiscountService _deliveryDiscountService;
        

        public WidgetsDeliveryDiscountController(IDeliveryDiscountService delivaeryDiscountService)
        {
            _deliveryDiscountService = delivaeryDiscountService;
        }

        [AdminAuthorize]
        [HttpGet]
        public ActionResult Configure()
        {
            var deliveryDiscountLabel = _deliveryDiscountService.GetValue();

            var model = new DeliveryDiscountConfigurationModel()
            {
                Label = deliveryDiscountLabel.Label
            };
            return View("~/Plugins/Widgets.DeliveryDiscount/Views/Configure.cshtml", model);
        }

        [AdminAuthorize]
        [HttpPost]
        public ActionResult Configure(DeliveryDiscountConfigurationModel model)
        {
            var deliveryDiscountLabel = new DeliveryDiscountLabel
            {
                Id = model.Id,
                Label = model.Label
            };
            _deliveryDiscountService.Put(deliveryDiscountLabel);
            return Configure();
        }

        [ChildActionOnly]
        public ActionResult RenderWidget()
        {
            var deliveryDiscountLabel = _deliveryDiscountService.GetValue();
            var model = new DeliveryDiscountConfigurationModel()
            {
                Label = deliveryDiscountLabel.Label
            };
            return View("~/Plugins/Widgets.DeliveryDiscount/Views/_DeliveryDiscount.cshtml", model);
        }
    }
}
