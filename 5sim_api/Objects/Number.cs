using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeBot._5sim.Objects
{
    // Number from 5sim
    public class Number
    {
        public int id;

        /// <summary>The phone-number</summary>
        public string phone;
        
        /// <summary>The recieved sms (Activation only has 1 sms)</summary>
        public List<Sms> sms;

        public DateTime created_at;
        public DateTime expires;

        public bool forwarding;
        public string forwarding_number;

        public string product;
        public float price;

        public string carrier;
        public string country;

        public string status;

        public Number()
        {
        }
    }
}
