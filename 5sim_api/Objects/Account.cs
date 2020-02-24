using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeBot._5sim.Objects
{
    public class Account
    {
        public int id;
        public string email;
        /// <summary>Funds in Rubel (RUB)</summary>
        public float balance;
        /// <summary>Total numbers of orders</summary>
        public int rating;

        public Account()
        {
        }
    }
}
