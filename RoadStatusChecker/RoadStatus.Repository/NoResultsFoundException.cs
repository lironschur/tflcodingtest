using System;

namespace RoadStatus.Repository
{
    public class NoResultsFoundException : Exception
    {
        public NoResultsFoundException(): base()
        {
            
        }
    }
}