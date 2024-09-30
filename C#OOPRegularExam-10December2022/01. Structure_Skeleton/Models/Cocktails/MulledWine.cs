using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        private const double BasePrice = 13.5;
        public MulledWine(string name, string size) : base(name, size, BasePrice)
        {
        }
    }
}
