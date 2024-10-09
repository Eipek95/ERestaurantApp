﻿namespace SignalR.WEB_Food.ViewModels.MessageViewModels
{
	public class ResultMessageViewModel
	{
		public int Id { get; set; }
		public string NameSurname { get; set; }
		public string Mail { get; set; }
		public string Phone { get; set; }
		public string Subject { get; set; }
		public string MessageContent { get; set; }
		public DateTime MessageSendDate { get; set; }
		public bool Status { get; set; }
	}
}
