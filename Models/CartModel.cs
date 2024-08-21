using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using huy2.Context;

namespace huy2.Models
{
    public class CartModel
    {
        public Products Product { get; set; }
        public int Quantity { get; set; }
    }
}

