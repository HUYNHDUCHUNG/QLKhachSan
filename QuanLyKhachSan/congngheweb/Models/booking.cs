//------------------------------------------------------------------------------
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
    
    public partial class booking
    {
        public int id { get; set; }
        public string code { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public Nullable<int> guest { get; set; }
        public Nullable<System.DateTime> checkin { get; set; }
        public Nullable<System.DateTime> checkout { get; set; }
        public Nullable<int> room { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public Nullable<int> status { get; set; }
    }
}