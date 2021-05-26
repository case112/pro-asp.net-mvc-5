﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }
    }
}

// Should be with validation but did not want to migrate
//public class Product
//{
//    [HiddenInput(DisplayValue = false)]
//    public int ProductID { get; set; }

//    [Required(ErrorMessage = "Please enter a product name")]
//    public string Name { get; set; }

//    [Required(ErrorMessage = "Please enter a description")]
//    public string Description { get; set; }

//    [Required]
//    [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
//    public decimal Price { get; set; }

//    [Required(ErrorMessage = "Please specify a category")]
//    public string Category { set; get; }
//}

