using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeBot._5sim.Exceptions
{
    [Serializable]
    class OrderNotFoundException : Exception
    {
        public OrderNotFoundException()
        {
        }
        public OrderNotFoundException(String message)
            : base(message)
        { 
        }
    }
}
