﻿using System;
using System.Threading.Tasks;
using BPS.Core.Constants;
using BPS.Core.Contracts.Repository;
using BPS.Core.Contracts.Services.Data;
using BPS.Core.Models;

namespace BPS.Core.Services.Data
{
    public class OrderDataService : IOrderDataService
    {
        private readonly IGenericRepository _genericRepository;

        public OrderDataService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Order> PlaceOrder(Order order)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.PlaceOrderEndpoint
            };

            var result =
                await _genericRepository.PostAsync<Order>(builder.ToString(), order);

            return order;
        }
    }
}
