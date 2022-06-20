using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MIS.API.Middleware;
using MIS.API.Extensions;
using MIS.Infrastructure;
using FluentValidation.AspNetCore;
using Hangfire;

namespace MIS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext(Configuration.GetConnectionString("DefaultConnection"));
            services.AddIdentityServices(Configuration);
            services.AddApplicationServices();
            services.AddBranchServices();
            services.AddRoomServices();
            services.AddCourseServices();
            services.AddGroupTimeServices();
            services.AddLessonDayServices();
            services.AddStudentServices();
            services.AddGroupServices();
            services.AddGroupTypeServices();
            services.AddUserServices();
            services.AddRoleServices();
            services.AddTeacherServices();
            services.AddTimetableServices();
            services.AddAttendanceServices();
            services.AddStudentGroupHistoryServices();
            services.AddCashFlowServices();
            services.AddAuditLoggingServices();
            services.AddExcelFileExportServices();
            services.AddTelegramServices();

            services.AddControllers().AddFluentValidation();
            services.AddCors(policy =>
            {
                policy.AddPolicy("OpenCorsPolicy", opt =>
                opt.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
            services.AddValidationResponse();

            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MIS.API", Version = "v1" });

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Auth Bearer Scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        securitySchema, new [] {"Bearer"}                        
                    }
                };
                c.AddSecurityRequirement(securityRequirement);
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MIS.API v1"));
            }

            app.UseHangfireDashboard("/dashboard");

            StudentGroupHistoryRecurrentJob.AddStudentGroupHistoryRecurrentJob();
            TelegramRecurrentJobs.AddTelegramRecurrentJobs();
            CashFlowRecurrentJobs.AddCashFlowRecurrentJobs();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();
            app.UseCors("OpenCorsPolicy");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
