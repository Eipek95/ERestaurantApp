﻿namespace SignalR.WEB_Food.ViewModels.ProductViewModels
{
	public class UpdateProductViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public bool Status { get; set; }
		public int CategoryID { get; set; }
	}
}
