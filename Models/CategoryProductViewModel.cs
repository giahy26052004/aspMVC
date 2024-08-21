using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using huy2.Context;
namespace huy2.Models
{
    public class CategoryProductViewModel
    {
        public Categories Category { get; set; }
        public List<Products> Products { get; set; }
        public List<Categories> Categories {  get; set; }
    }

}