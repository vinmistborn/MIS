using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MIS.Application.DTOs.Branch;
using MIS.Application.DTOs.Course;
using MIS.Application.DTOs.Group;
using MIS.Application.DTOs.GroupTime;
using MIS.Application.DTOs.GroupType;
using MIS.Application.DTOs.LessonDays;
using MIS.Application.DTOs.Room;
using MIS.Application.DTOs.Student;
using MIS.Application.DTOsValidators;
using MIS.Domain.Entities;
using MIS.Domain.Entities.Identity;
using MIS.Application.Interfaces.Services;
using MIS.Application.Interfaces.Repositories;
using MIS.Application.Services;
using MIS.Infrastructure;
using MIS.Infrastructure.Data.Repositories;
using MIS.Shared.Errors;
using MIS.Shared.Interfaces;
using System;
using System.Linq;
using System.Text;
using MIS.Shared.Interfaces.Services;
using MIS.Shared.Interfaces.Repositories;
using MIS.Infrastructure.Services;
using MIS.Application.Interfaces.Services.ExcelFileServices;
using MIS.Infrastructure.Services.ExcelFileServices;

namespace MIS.API.Extensions
{
   public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());            
            return services;
        }

        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddSignInManager<SignInManager<User>>()                  
                    .AddDefaultTokenProviders();
            services.AddIdentityCore<Teacher>()
                    .AddRoles<Role>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddSignInManager<SignInManager<Teacher>>()                                                          
                    .AddDefaultTokenProviders();
           
            services.AddScoped<ITokenClaimsService, TokenClaimsService>();
            services.AddScoped(typeof(IAccountService<,>), typeof(AccountService<,>));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"])),
                        ValidIssuer = config["JWT:Issuer"],
                        ValidAudience = config["JWT:Audience"],
                        ValidateIssuer = true,
                        ValidateAudience = true

                    };
                });

            return services;
        }

        public static IServiceCollection AddBranchServices(this IServiceCollection services)
        {
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IValidator<BranchDTO>, BranchValidator>();  
            return services;
        }

        public static IServiceCollection AddRoomServices(this IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomService>();                  
            services.AddScoped<IValidator<RoomDTO>, RoomValidator>();
            return services;
        }

        public static IServiceCollection AddCourseServices(this IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IValidator<CourseDTO>, CourseValidator>();
            return services;
        }

        public static IServiceCollection AddGroupTimeServices(this IServiceCollection services)
        {
            services.AddScoped<IGroupTimeService, GroupTimeService>();
            services.AddScoped<IValidator<GroupTimeDTO>, GroupTimeValidator>();
            return services;
        }

        public static IServiceCollection AddLessonDayServices(this IServiceCollection services)
        {
            services.AddScoped<ILessonDayService, LessonDayService>();
            services.AddScoped<IValidator<LessonDayDTO>, LessonDayValidator>();
            return services;
        }

        public static IServiceCollection AddGroupTypeServices(this IServiceCollection services)
        {
            services.AddScoped<IGroupTypeService, GroupTypeService>();
            services.AddScoped<IValidator<GroupTypeDTO>, GroupTypeValidator>();
            return services;
        }

        public static IServiceCollection AddStudentServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();            
            services.AddScoped<IValidator<StudentDTO>, StudentValidator>();
            return services;
        }

        public static IServiceCollection AddGroupServices(this IServiceCollection services)
        {
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IValidator<AddGroupDTO>, GroupValidator>();
            return services;
        }

        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(IGenericUserRepository<>), typeof(GenericUserRepository<>));
            services.AddScoped(typeof(IGenericUserService<,>), typeof(GenericUserService<,>));
            return services;
        }

        public static IServiceCollection AddRoleServices(this IServiceCollection services)
        {
            services.AddScoped<IRoleService, RoleService>();
            return services;
        }

        public static IServiceCollection AddTeacherServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();
            return services;
        }

        public static IServiceCollection AddTimetableServices(this IServiceCollection services)
        {
            services.AddScoped<ITimetableService, TimetableService>();
            services.AddScoped<ITimetableRepository, TimetableRepository>();
            return services;
        }

        public static IServiceCollection AddAttendanceServices(this IServiceCollection services)
        {
            services.AddScoped<IAttendanceService, AttendanceService>();
            return services;
        }

        public static IServiceCollection AddStudentGroupHistoryServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentGroupHistoryService, StudentGroupHistoryService>();
            services.AddScoped<IStudentGroupHistoryRepository, StudentGroupHistoryRepository>();
            return services;
        }

        public static IServiceCollection AddCashFlowServices(this IServiceCollection services)
        {
            services.AddScoped<IIncomeService, IncomeService>();
            services.AddScoped<IExpensesService, ExpensesService>();
            services.AddScoped<ICashFlowService, CashFlowService>();
            return services;
        }

        public static IServiceCollection AddAuditLoggingServices(this IServiceCollection services)
        {
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IIncomeLogService, IncomeLogService>();
            services.AddScoped<IExpensesLogService, ExpensesLogService>();
            return services;
        }

        public static IServiceCollection AddExcelFileExportServices(this IServiceCollection services)
        {
            services.AddScoped<IIncomeExcelFileService, IncomeExcelFileService>();
            services.AddScoped<IExpensesExcelFileService, ExpensesExcelFileService>();
            services.AddScoped<ICashFlowExcelFileService, CashFlowExcelFileService>();
            return services;
        }

        public static IServiceCollection AddTelegramServices(this IServiceCollection services)
        {
            services.AddScoped<ITelegramService, TelegramService>();
            return services;
        }

        public static IServiceCollection AddValidationResponse(this IServiceCollection services)
        {
            //Configure Validation Responses
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState.Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ValidationErrorResponse
                    {
                        Errors = errors                        
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }
}
