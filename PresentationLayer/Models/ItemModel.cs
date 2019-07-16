using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
    }
    public class ItemCreateModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
    }
    public class ItemUpdateModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
    }
}
