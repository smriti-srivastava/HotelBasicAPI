using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FirstASP.NETWebAPIApplication.Models
{
    public class Hotel
    {
        public int Id{ get; set;}
        public String Name { get; set; }
        public int NumberOfAvailableRooms { get; set; }
        public string Address { get; set; }
        public int LocationCode { get; set; }

    }
}