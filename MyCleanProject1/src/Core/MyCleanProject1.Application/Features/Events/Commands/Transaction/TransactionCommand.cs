﻿using MyCleanProject1.Application.Responses;
using MediatR;
using System;

namespace MyCleanProject1.Application.Features.Events.Commands.Transaction
{
    public class TransactionCommand: IRequest<Response<Guid>>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public override string ToString()
        {
            return $"Event name: {Name}; Price: {Price}; By: {Artist}; On: {Date.ToShortDateString()}; Description: {Description}";
        }
    }
}
