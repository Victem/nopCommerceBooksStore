using Nop.Plugin.Widgets.DeliveryDiscount.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.DeliveryDiscount.Data
{
    public class DeliveryDiscountLabelMap : EntityTypeConfiguration<DeliveryDiscountLabel>
    {
        public DeliveryDiscountLabelMap()
        {
            ToTable("DeliveryDiscountLabels");
            HasKey(m => m.Id);
            Property(m => m.Label);
        }
    }
}
