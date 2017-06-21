using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.DeliveryDiscount.Domain;
using Nop.Core.Data;

namespace Nop.Plugin.Widgets.DeliveryDiscount.Services
{
    public class DeliveryDiscountService : IDeliveryDiscountService
    {
        public readonly IRepository<DeliveryDiscountLabel> _deliveryDiscountRepository;

        public DeliveryDiscountService(IRepository<DeliveryDiscountLabel> deliveryDiscountRepository)
        {
            _deliveryDiscountRepository = deliveryDiscountRepository;
        }

        public DeliveryDiscountLabel GetValue()
        {
            return _deliveryDiscountRepository.TableNoTracking.FirstOrDefault() ?? new DeliveryDiscountLabel();
        }

        public void Put(DeliveryDiscountLabel deliveryDiscountLabel)
        {
            var repository = _deliveryDiscountRepository.Table.FirstOrDefault();
            if (repository != null)
            {
                repository.Label = deliveryDiscountLabel.Label;
                _deliveryDiscountRepository.Update(repository);
            }
            else
            {
                _deliveryDiscountRepository.Insert(deliveryDiscountLabel);
            }
            
        }
    }
}
