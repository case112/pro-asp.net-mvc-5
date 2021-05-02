using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class MinimumDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalparam)
        {
            if (totalparam < 0)
            {
                throw new ArgumentOutOfRangeException();
            } else if (totalparam > 100)
            {
                return totalparam * 0.9M;
            } else if (totalparam >= 10 && totalparam <= 100)
            {
                return totalparam - 5;
            } else
            {
                return totalparam;
            }
        }
    }
}