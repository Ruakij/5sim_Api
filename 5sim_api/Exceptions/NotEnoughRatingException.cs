﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeBot._5sim.Exceptions
{
    [Serializable]
    public class NotEnoughRatingException : Exception
    {
        public NotEnoughRatingException()
        {
        }
        public NotEnoughRatingException(String message)
            : base(message)
        { 
        }
    }
}
