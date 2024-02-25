﻿using System;

namespace ProductManager.Models
{
    public class Product
    {
        public int id { get; set; }
        
        public string Name { get; set; }
        public long Price { get; set; }
        public bool Checked { get; set; }=false;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}
    }
}
