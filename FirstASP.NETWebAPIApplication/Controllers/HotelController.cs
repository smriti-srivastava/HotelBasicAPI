using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstASP.NETWebAPIApplication.Models;

namespace FirstASP.NETWebAPIApplication.Controllers
{
    public class HotelController : ApiController
    {
        private static List<Hotel> _hotels = new List<Hotel>()
        {new Hotel { Id = 1, Name = "Caesars Hotel", NumberOfAvailableRooms = 100, Address = "Pune", LocationCode = 100 },
         new Hotel { Id = 2, Name = "Hotel 2", NumberOfAvailableRooms = 100, Address = "Pune", LocationCode = 100 },
         new Hotel { Id = 3, Name = "Hotel 3", NumberOfAvailableRooms = 100, Address = "Pune", LocationCode = 100 }
        };


        [HttpGet]
        public APIResponse FindAllHotels()
        {
            try
            {
                return new APIResponse
                {
                    Hotels = _hotels,
                    Status = Status.Success,
                    StatusCode = 200,
                    StatusMessage = "List Of Hotels Successfully Sent"
                };
            }
            catch (Exception e)
            {
                return new APIResponse
                {
                    Hotels = null,
                    Status = Status.Failed,
                    StatusCode = 500,
                    StatusMessage = "Exception : " + e.Message
                };

            }
        }

        [HttpGet]
        public APIResponse FindHotel(int Id)
        {

            try
            {
                Hotel requiredHotel = null;
                //Hotel requiredHotel = _hotels.Find(hotel => hotel.Id == Id);
                foreach (Hotel hotel in _hotels)
                {
                    if (hotel.Id == Id)
                        requiredHotel = hotel;
                }
                if (requiredHotel != null)
                {
                    List<Hotel> desiredHotel = new List<Hotel>();
                    desiredHotel.Add(requiredHotel);
                    return new APIResponse
                    {
                        Hotels = desiredHotel,
                        //Hotels = new List<Hotel>() { requiredHotel },
                        Status = Status.Success,
                        StatusCode = 200,
                        StatusMessage = "Hotel Found!"

                    };
                }
                else
                {
                    return new APIResponse
                    {
                        Hotels = null,
                        Status = Status.Failed,
                        StatusCode = 404,
                        StatusMessage = "Hotel Not Found!"

                    };

                }
            }
            catch (Exception e)
            {
                return new APIResponse
                {
                    Hotels = null,
                    Status = Status.Failed,
                    StatusCode = 500,
                    StatusMessage = "Exception Occurred :" + e.Message
                };
            }

        }


        [HttpPost]
        public APIResponse CreateHotel(Hotel newHotel)
        {
            try
            {
                if (newHotel == null)
                {
                    return new APIResponse
                    {
                        Hotels = null,
                        Status = Status.Failed,
                        StatusCode = 400,
                        StatusMessage = "Empty Hotel Details Sent"
                    };

                }

                if (_hotels != null && _hotels.Any(hotel => hotel.Id == newHotel.Id))
                {
                    return new APIResponse
                    {
                        Hotels = null,
                        Status = Status.Failed,
                        StatusCode = 400,
                        StatusMessage = "Duplicate ID - A Hotel with the same ID is already Present"
                    };
                }
                else
                {
                    _hotels.Add(newHotel);
                    return new APIResponse
                    {
                        Hotels = _hotels,
                        Status = Status.Success,
                        StatusCode = 201,
                        StatusMessage = "New Hotel Successfully Added"
                    };
                }
            }
            catch (Exception e)
            {
                return new APIResponse
                {
                    Hotels = null,
                    Status = Status.Failed,
                    StatusCode = 500,
                    StatusMessage = "Exception Occurred :" + e.Message
                };
            }
        }

        [HttpDelete]
        public APIResponse RemoveHotel(int Id)
        {
            try
            {
                var hotelToBeDeleted = _hotels.Find(x => x.Id == Id);
                if (hotelToBeDeleted != null)
                {
                    _hotels.Remove(hotelToBeDeleted);
                    return new APIResponse
                    {
                        Hotels = _hotels,
                        Status = Status.Success,
                        StatusCode = 200,
                        StatusMessage = "Hotel Successfully Deleted"
                    };
                }
                else
                {
                    return new APIResponse
                    {
                        Hotels = _hotels,
                        Status = Status.Failed,
                        StatusCode = 404,
                        StatusMessage = "Hotel Not Found!"
                    };
                }
            }
            catch (Exception e)
            {
                return new APIResponse
                {
                    Hotels = null,
                    Status = Status.Failed,
                    StatusCode = 500,
                    StatusMessage = "Exception Occurred :" + e.Message
                };
            }
        }


        [HttpPut]
        public APIResponse BookHotel(int Id, [FromBody] int NumberOfRoomsToBeBooked)
        {
            try {
                var hotelToBeBooked = _hotels.Find(x => x.Id == Id);
                if (hotelToBeBooked != null && NumberOfRoomsToBeBooked > 0)
                {
                    
                    if (hotelToBeBooked.NumberOfAvailableRooms >= NumberOfRoomsToBeBooked)
                    {
                        hotelToBeBooked.NumberOfAvailableRooms -= NumberOfRoomsToBeBooked;
                        return new APIResponse
                        {
                            Hotels = _hotels,
                            Status = Status.Success,
                            StatusCode = 200,
                            StatusMessage = "Room Booked Successfully"
                        };

                    }
                    else
                    {
                        return new APIResponse
                        {
                            Hotels = null,
                            Status = Status.Failed,
                            StatusCode = 404,
                            StatusMessage = "Rooms Not Available"
                        };
                    }
                }
                else
                {
                    return new APIResponse
                    {
                        Hotels = null,
                        Status = Status.Failed,
                        StatusCode = 404,
                        StatusMessage = "Invalid Data Sent"
                    };
                }

            }
            catch (Exception e)
            {
                return new APIResponse
                {
                    Hotels = null,
                    Status = Status.Failed,
                    StatusCode = 500,
                    StatusMessage = "Exception Occurred :" + e.Message
                };
            }
        }

    }
}
