using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.DeliveryDiscount.Domain
{
    public class DeliveryDiscountLabel : BaseEntity
    {
        public virtual string Label { get; set; }
    }
}
