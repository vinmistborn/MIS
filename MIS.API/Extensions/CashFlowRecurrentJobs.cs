using Hangfire;
using MIS.Application.Interfaces.Services;

namespace MIS.API.Extensions
{
    public static class CashFlowRecurrentJobs
    {
        public static void AddCashFlowRecurrentJobs()
        {
            RecurringJob.AddOrUpdate<ICashFlowService>(recurringJobId: "dailyCashFlow", x => x.CalculateDailyCashFlowAsync(), Cron.Daily);
            RecurringJob.AddOrUpdate<ICashFlowService>(recurringJobId: "dailyCashFlowIncomeOnly", x => x.AddDailyIncomeToCashFlow(), Cron.Daily);
            RecurringJob.AddOrUpdate<ICashFlowService>(recurringJobId: "dailyCashFlowExpensesOnly", x => x.AddDailyExpensesToCashFlow(), Cron.Daily);
        }
    }
}
