﻿using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;

		public OrderManager(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public int BActiveOrderCount() => _orderDal.ActiveOrderCount();
		public void BAdd(Order entity)
		{
			throw new NotImplementedException();
		}

		public void BDelete(Order entity)
		{
			throw new NotImplementedException();
		}

		public List<Order> BGetAll()
		{
			throw new NotImplementedException();
		}

		public Order BGetById(int id)
		{
			throw new NotImplementedException();
		}

		public decimal BLastOrderPrice() => _orderDal.LastOrderPrice();

		public int BPassiveOrderCount() => _orderDal.PassiveOrderCount();

		public decimal BTodayTotalPrice() => _orderDal.TodayTotalPrice();

		public int BTotalOrderCount() => _orderDal.TotalOrderCount();

		public void BUpdate(Order entity)
		{
			throw new NotImplementedException();
		}
	}
}
