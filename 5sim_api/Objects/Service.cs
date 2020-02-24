using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeBot._5sim.Objects
{
    /// <summary>
    /// Service from 5sim
    /// </summary>
    public class Service
    {
        public String name;
        public String category;
        public int quantity;
        /// <summary>Price in Rubel (RUB)</summary>
        public float price;

        public Service()
        {
        }
        public Service(String name, String category, int quantity, float price)
        {
            this.name = name;
            this.category = category;
            this.quantity = quantity;
            this.price = price;
        }
    }
}
