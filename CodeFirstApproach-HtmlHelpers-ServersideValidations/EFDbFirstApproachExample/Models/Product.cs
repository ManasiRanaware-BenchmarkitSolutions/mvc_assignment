﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDbFirstApproachExample.Models
{
    [Table("Products", Schema ="dbo")]
    public class Product
    {
        [Key]
        [Display(Name = "Product ID")]
        public long ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        [Required]
        public Nullable<decimal> Price { get; set; }
        
        [Column("DateOfPurchase", TypeName = "datetime")]
        [Display(Name = "Date of Purchase")]
        
        public Nullable<System.DateTime> DOP { get; set; }

        [Display(Name = "Availability Status")]
        
        public string AvailabilityStatus { get; set; }

        [Display(Name = "Category")]
        [Required]
        public Nullable<long> CategoryID { get; set; }

        [Display(Name = "Brand")]
        [Required]
        public Nullable<long> BrandID { get; set; }

        [Display(Name = "Active")]
        
        public Nullable<bool> Active { get; set; }

        [Display(Name = "Photo")]
        [Required]
        public string Photo { get; set; }
        
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}


