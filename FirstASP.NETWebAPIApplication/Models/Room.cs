using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstASP.NETWebAPIApplication.Models
{
    public class Room
    {
        int RoomId { get; set; }
        RoomType TypeOfRoom { get; set; }
        int NumberOfRoomsPresnet { get; set; }
        
        int NumberOfRoomsBooked { get;set }
    }

    public enum RoomType
    {
        Single,
        Double,
        Triple,
        Quad,
        Queen,
        King,
        Twin,
        Studio
    }
}