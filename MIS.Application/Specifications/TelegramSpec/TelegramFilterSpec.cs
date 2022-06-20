using Ardalis.Specification;
using MIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.Specifications.TelegramSpec
{
    public class TelegramFilterSpec : Specification<TelegramChat>, ISingleResultSpecification
    {
        public TelegramFilterSpec(long botId)
        {
            Query
                .Where(x => x.BotId == botId);
        }
    }

    public class TelegramStatusSpec : Specification<TelegramChat>, ISingleResultSpecification
    {
        public TelegramStatusSpec()
        {
            Query
                .Where(x => x.IsActive == false);
        }
    }
}
