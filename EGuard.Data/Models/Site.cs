﻿namespace EGuard.Data.Models
{
    public class Site
    {
        public string Url { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return Url;
        }
    }
}
