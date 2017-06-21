using Nop.Plugin.Widgets.DeliveryDiscount.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.DeliveryDiscount.Services
{
    public interface IDeliveryDiscountService
    {
        DeliveryDiscountLabel GetValue();
        void Put(DeliveryDiscountLabel deliveryDiscountLabel);
    }
}
