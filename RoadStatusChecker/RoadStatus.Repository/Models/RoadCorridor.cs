﻿namespace RoadStatus.Repository.Models
{
    public class RoadCorridor
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string StatusSeverity { get; set; }
        public string StatusSeverityDescription { get; set; }
    }
}