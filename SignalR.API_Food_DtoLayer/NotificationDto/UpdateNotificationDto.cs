namespace SignalR.API_Food_DtoLayer.NotificationDto
{
    public class UpdateNotificationDto
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
