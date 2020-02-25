﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeBot._5sim.Exceptions
{
    [Serializable]
    public class HostingOrderException : Exception
    {
        public HostingOrderException()
        {
        }
        public HostingOrderException(String message)
            : base(message)
        { 
        }
    }
}
