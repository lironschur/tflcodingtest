using System;

namespace RoadStatus.Service
{
    public class RoadNotFoundException : Exception
    {
        public RoadNotFoundException(): base()
        {
            
        }
    }
}