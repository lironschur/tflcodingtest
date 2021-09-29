using System;

namespace RoadStatusChecker.Service
{
    public class RoadNotFoundException : Exception
    {
        public RoadNotFoundException(): base()
        {
            
        }
    }
}