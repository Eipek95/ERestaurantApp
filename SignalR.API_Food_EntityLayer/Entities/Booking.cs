﻿namespace SignalR.API_Food_EntityLayer.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Status { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
