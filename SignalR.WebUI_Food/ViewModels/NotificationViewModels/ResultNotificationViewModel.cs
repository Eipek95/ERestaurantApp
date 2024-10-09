namespace SignalR.WEB_Food.ViewModels.NotificationViewModels
{
    public class ResultNotificationViewModel
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
