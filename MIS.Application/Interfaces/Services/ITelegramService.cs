using MIS.Application.DTOs.Telegram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Services
{
    public interface ITelegramService
    {
        Task AddChatsAsync();
        Task UpdateChatsStatusAsync();
        Task DeleteChatsAsync();
        Task SendMessageAsync(TelegramMessageDTO messageDTO);
        Task<IEnumerable<TelegramInfoDTO>> GetTelegramChatsAsync();
    }
}
