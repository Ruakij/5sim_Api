using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeBot._5sim.Exceptions
{
    [Serializable]
    class NotEnoughProductQuantityException : Exception
    {
        public NotEnoughProductQuantityException()
        {
        }
        public NotEnoughProductQuantityException(String message)
            : base(message)
        { 
        }
    }
}
