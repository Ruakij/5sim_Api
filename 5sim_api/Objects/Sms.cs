using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeBot._5sim.Objects
{
    /// <summary>
    /// SMS received by a 5sim number
    /// </summary>
    public class Sms
    {
        public int id;
        public DateTime created_at;
        public DateTime date;
        public string sender;
        public string text;
        public string code;
    }
}
