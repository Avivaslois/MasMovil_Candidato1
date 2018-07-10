using Order.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.ControllerWorkers
{
    public interface IOrderCW
    {
        Task<bool> processOrder(OrderDTO order);
        Task<List<OrderDetailResultDto>> getPrices(List<OrderDetailDto> details);
        List<OrderDetailResultDto> completeInfo(OrderDTO order, List<OrderDetailResultDto> detailsResults);
        string getMessage(CustomerDto customer, List<OrderDetailResultDto> detailsResults);
    }
}
