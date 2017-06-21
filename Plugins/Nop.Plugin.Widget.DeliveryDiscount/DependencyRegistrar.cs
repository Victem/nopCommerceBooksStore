using Nop.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Plugin.Widgets.DeliveryDiscount.Services;
using Nop.Data;
using Nop.Plugin.Widgets.DeliveryDiscount.Domain;
using Autofac.Core;
using Nop.Core.Data;
using Nop.Web.Framework.Mvc;
using Nop.Plugin.Widgets.DeliveryDiscount.Data;

namespace Nop.Plugin.Widgets.DeliveryDiscount
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "nop_object_context_delivery_discount_label";

        public virtual void Register(
            ContainerBuilder builder, 
            ITypeFinder typeFinder, 
            NopConfig config)
        {
            builder.RegisterType<DeliveryDiscountService>()
                   .As<IDeliveryDiscountService>()
                   .InstancePerLifetimeScope();

            this.RegisterPluginDataContext<DeliveryDiscountLabelObjectContext>(builder, CONTEXT_NAME);

            builder.RegisterType<EfRepository<DeliveryDiscountLabel>>()
                   .As<IRepository<DeliveryDiscountLabel>>()
                   .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                   .InstancePerLifetimeScope();
        }

        public int Order => 1;
    }
}
