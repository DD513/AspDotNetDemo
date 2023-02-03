﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetDemo.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set;}
        [ValidateNever] //本次新增部分
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}