using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeBot._5sim.Exceptions
{
    [Serializable]
    class NoFreePhonesException : Exception
    {
        public NoFreePhonesException()
        {
        }
        public NoFreePhonesException(String message)
            : base(message)
        { 
        }
    }
}
