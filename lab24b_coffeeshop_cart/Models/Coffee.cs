using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab24b_coffeeshop_cart.Models
{
    public class Coffee
    {
        private string name;
        private int size;
        private string origin;

        public Coffee(string name, int size, string origin)
        {
            this.name = name;
            this.size = size;
            this.origin = origin;
        }

        public Coffee()
        {

        }
        public string Name { get => name; set => name = value; }
        public int Size { get => size; set => size = value; }
        public string Origin { get => origin; set => origin = value; }
    }
}