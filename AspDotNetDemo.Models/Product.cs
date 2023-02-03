using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetDemo.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public double Price { get; set; }
        [ValidateNever]
        public string Image { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Category")] //本次新增部分
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever] 
        public Category Category { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
