using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int OrderNumber { get; set; }
        public string Status { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }

    }
    public class OrderCreateModel
    {
        public int CustomerId { get; set; }
        public List<OrderItemCreateModel> OrderItems { get; set; }


    }
    public class OrderUpdateModel
    {
        public int Id { get; set; }
      
        public string Status { get; set; }
        public DateTime ShipmentDate { get; set; }

    }
}
