using Hangfire;
using MIS.Application.Interfaces.Services;

namespace MIS.API.Extensions
{
    public static class TelegramRecurrentJobs
    {
        public static void AddTelegramRecurrentJobs()
        {
            RecurringJob.AddOrUpdate<ITelegramService>(recurringJobId: "addTelegramChats", x => x.AddChatsAsync(), Cron.Hourly);
            RecurringJob.AddOrUpdate<ITelegramService>(recurringJobId: "updateTelegramChatsStatus", x => x.UpdateChatsStatusAsync(), Cron.Hourly);
            RecurringJob.AddOrUpdate<ITelegramService>(recurringJobId: "deleteTelegramChats", x => x.DeleteChatsAsync(), Cron.Daily);
        }
    }
}
