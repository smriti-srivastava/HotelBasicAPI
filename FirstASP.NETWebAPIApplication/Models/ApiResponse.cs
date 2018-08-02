using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstASP.NETWebAPIApplication.Models
{
    public class APIResponse
    {
        public List<Hotel> Hotels;
        public Status Status;
        public int StatusCode;
        public string StatusMessage;


    }

    public enum Status
    {
        Failed,
        Success
    }
}