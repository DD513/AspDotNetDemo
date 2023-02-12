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
        [Range(1,10000)]
        public double Price { get; set; }
        [ValidateNever] //本次新增部分
        public string Image { get; set; }
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever] //本次新增部分
        public Category Category { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
