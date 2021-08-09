using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModernStreaming.Models
{
    public class Status
    {
        public Status()
        {

        }
        public int status { get; set; }
        public bool status_bool { get; set; }
        public string status_name { get; set; }
        public int status_count { get; set; }
        public int total_count { get; set; }
    }
}