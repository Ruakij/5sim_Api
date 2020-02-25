using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeBot._5sim.Exceptions
{
    [Serializable]
    public class OrderExpiredException : Exception
    {
        public OrderExpiredException()
        {
        }
        public OrderExpiredException(String message)
            : base(message)
        { 
        }
    }
}
