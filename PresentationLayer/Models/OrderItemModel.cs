using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public ItemViewModel Items { get; set; }
        public int ItemsCount { get; set; }
        public int ItemPrice { get; set; }
    }
    public class OrderItemCreateModel
    {
        public int OrderId { get; set; }
        public ItemViewModel Item { get; set; }
        public int ItemsCount { get; set; }
        public int ItemPrice { get; set; }
    }
    public class OrderItemUpdateModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int ItemsCount { get; set; }
        public int ItemPrice { get; set; }
    }
}
