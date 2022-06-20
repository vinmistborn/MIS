using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.Telegram;
using MIS.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    public class TelegramController : BaseController
    {
        private readonly ITelegramService _telegramService;

        public TelegramController(ITelegramService telegramService)
        {
            _telegramService = telegramService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTelegramChats()
        {
            var chats = await _telegramService.GetTelegramChatsAsync();
            return Ok(chats);
        }

        [HttpPost("send-message")]
        public async Task<IActionResult> SendTelegramMessage(TelegramMessageDTO messageDTO)
        {
            await _telegramService.SendMessageAsync(messageDTO);
            return NoContent();
        }
    }
}
