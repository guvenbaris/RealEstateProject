﻿using System.Web;

namespace RealEstateWebApp.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePicUrl { get; set; }
        public HttpPostedFileBase ProfilePic { get; set; }
        public Address Address { get; set; }

    }
}