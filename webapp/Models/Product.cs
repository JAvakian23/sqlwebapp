﻿using System.ComponentModel.DataAnnotations;

namespace webapp.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
