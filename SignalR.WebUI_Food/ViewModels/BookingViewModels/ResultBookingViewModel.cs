using SignalR.API_Common;

namespace SignalR.WEB_Food.ViewModels.BookingViewModels
{
    public class ResultBookingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public ReservationStatus Status { get; set; }

        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
