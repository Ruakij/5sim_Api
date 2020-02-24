using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeBot._5sim.Exceptions
{
    [Serializable]
    class OrderHasSmsException : Exception
    {
        public OrderHasSmsException()
        {
        }
        public OrderHasSmsException(String message)
            : base(message)
        { 
        }
    }
}
