using Hangfire;
using MIS.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIS.API.Extensions
{
    public static class StudentGroupHistoryRecurrentJob
    {
        public static void AddStudentGroupHistoryRecurrentJob()
        {
            RecurringJob.AddOrUpdate<IStudentGroupHistoryService>(recurringJobId: "studentFirstLesson", x => x.UpdateFirstLessonAsync(), Cron.Daily);
        }
    }
}
