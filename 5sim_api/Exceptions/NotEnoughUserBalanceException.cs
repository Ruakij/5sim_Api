using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeBot._5sim.Exceptions
{
    [Serializable]
    class NotEnoughUserBalanceException : Exception
    {
        public NotEnoughUserBalanceException()
        {
        }
        public NotEnoughUserBalanceException(String message)
            : base(message)
        { 
        }
    }
}
