using MIS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Domain.Entities
{
    public class TelegramChat : BaseEntity
    {
        public long BotId { get; set; }
        public string ChatTitle { get; set; }
        public bool IsActive { get; set; }
    }
}
