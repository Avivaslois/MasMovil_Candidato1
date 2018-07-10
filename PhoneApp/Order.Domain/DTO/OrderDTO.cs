using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.DTO
{
    public class OrderDTO
    {
        public CustomerDto Customer { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
