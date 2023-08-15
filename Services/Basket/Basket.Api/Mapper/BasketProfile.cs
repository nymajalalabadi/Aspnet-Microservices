using AutoMapper;
using Basket.Api.Entites;
using EventBus.Messages.Events;

namespace Basket.Api.Mapper
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
        }
    }
} 
