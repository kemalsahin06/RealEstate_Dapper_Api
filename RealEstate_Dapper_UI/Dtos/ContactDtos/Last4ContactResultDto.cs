﻿namespace RealEstate_Dapper_UI.Dtos.ContactDtos
{
    public class Last4ContactResultDto
    {
        public int ContacID { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
