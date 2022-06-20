using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MIS.Domain.Entities;
using MIS.Domain.Entities.AuditLogging;
using MIS.Domain.Entities.Identity;
using System.Reflection;

namespace MIS.Infrastructure
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupTime> GroupTime { get; set; }
        public DbSet<GroupType> GroupType { get; set; }
        public DbSet<LessonDay> LessonDays { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }        
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGroupHistory> StudentGroupHistory { get; set; }
        public DbSet<GroupTeacher> GroupTeacher { get; set; } 
        public DbSet<Income> Income { get; set; }
        public DbSet<IncomeLog> IncomeLogs { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<ExpensesLog> ExpensesLogs { get; set; }
        public DbSet<TotalCashFlow> TotalCashFlow { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<TelegramChat> TelegramChats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.Entity<User>().ToTable("Users");
            modelbuilder.Entity<Role>().ToTable("Roles");
            modelbuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
