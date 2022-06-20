using AutoMapper;
using MIS.Application.DTOs.Telegram;
using MIS.Domain.Entities;

namespace MIS.Application.Mappings
{
    public class TelegramProfile : Profile
    {
        public TelegramProfile()
        {
            CreateMap<TelegramChat, TelegramInfoDTO>();
        }
    }
}
