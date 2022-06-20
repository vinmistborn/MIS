using AutoMapper;
using MIS.Application.DTOs.Telegram;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications.TelegramSpec;
using MIS.Domain.Entities;
using MIS.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace MIS.Infrastructure.Services
{
    public class TelegramService : ITelegramService
    {
        private readonly TelegramBotClient _telegramBotClient;
        private readonly IRepository<TelegramChat> _telegramRepo;
        private readonly IMapper _mapper;

        public TelegramService(IRepository<TelegramChat> telegramRepo,
                               IMapper mapper)
        {
            _telegramBotClient = new TelegramBotClient("5137226234:AAHCKUSOMUgFkGRvNspwHBh7RFaOH1Jq8Bc");
            _telegramRepo = telegramRepo;
            _mapper = mapper;
        }

        public async Task AddChatsAsync()
        {
            var updates = await _telegramBotClient.GetUpdatesAsync();
            var telegramGroupChats = updates.Where(x => x.Message != null && x.Message.GroupChatCreated == true)                                                
                                                    .Select(x => x.Message.Chat);
            
            var groupChats = await _telegramRepo.ListAsync();
            var newGroupChats = new List<TelegramChat>();

            foreach (var telegramChat in telegramGroupChats)
            {
                var chat = await _telegramRepo.GetBySpecAsync(new TelegramFilterSpec(telegramChat.Id));
                
                if(chat == null)
                {
                    var groupChat = new TelegramChat
                    {
                        BotId = telegramChat.Id,
                        ChatTitle = telegramChat.Title,
                        IsActive = true
                    };
                    newGroupChats.Add(groupChat);
                }
            }

            await _telegramRepo.AddRangeAsync(newGroupChats);
        }

        public async Task DeleteChatsAsync()
        {
            var groupChats = await _telegramRepo.ListAsync(new TelegramStatusSpec());
            await _telegramRepo.DeleteRangeAsync(groupChats);
        }

        public async Task SendMessageAsync(TelegramMessageDTO messageDTO)
        {
            foreach (var id in messageDTO.Id)
            {
                var chat = await _telegramRepo.GetByIdAsync(id);
                var text = await _telegramBotClient.SendTextMessageAsync(chat.BotId, messageDTO.Message);
                await _telegramBotClient.PinChatMessageAsync(chat.BotId, text.MessageId);
            }
        }

        public async Task UpdateChatsStatusAsync()
        {
            var updates = await _telegramBotClient.GetUpdatesAsync();
            var telegramGroupChats = updates
                                           .Where(x => x.MyChatMember != null && x.MyChatMember
                                                                                      .NewChatMember
                                                                                          .Status == ChatMemberStatus.Left)
                                                                                            .Select(x => x.MyChatMember.Chat);
            foreach (var telegramChat in telegramGroupChats)
            {
                var chat = await _telegramRepo.GetBySpecAsync(new TelegramFilterSpec(telegramChat.Id));
                
                if(chat != null)
                {
                    chat.IsActive = false;
                    await _telegramRepo.SaveChangesAsync();
                }
            }
        }
        
        public async Task<IEnumerable<TelegramInfoDTO>> GetTelegramChatsAsync()
        {
            var chats = await _telegramRepo.ListAsync();
            return _mapper.Map<IEnumerable<TelegramInfoDTO>>(chats);
        }
    }
}
