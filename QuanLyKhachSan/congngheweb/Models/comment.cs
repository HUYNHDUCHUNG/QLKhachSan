﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace congngheweb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class comment
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string message { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string GetTimeElapsed(DateTime createdDateTime)
        {
            TimeSpan timeElapsed = DateTime.Now - createdDateTime;

            // Logic để tính toán thời gian theo ngày, giờ, phút, giây
            string timeElapsedString = string.Empty;
            if (timeElapsed.TotalDays >= 1)
            {
                timeElapsedString = $"{(int)timeElapsed.TotalDays} day(s) ago";
            }
            else if (timeElapsed.TotalHours >= 1)
            {
                timeElapsedString = $"{(int)timeElapsed.TotalHours} hour(s) ago";
            }
            else if (timeElapsed.TotalMinutes >= 1)
            {
                timeElapsedString = $"{(int)timeElapsed.TotalMinutes} minute(s) ago";
            }
            else
            {
                timeElapsedString = $"{(int)timeElapsed.TotalSeconds} second(s) ago";
            }

            return timeElapsedString;
        }
    }
}
