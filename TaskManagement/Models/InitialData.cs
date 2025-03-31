using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Models
{
    public class InitialData
    {
        public static void EnsurePopulated(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ManagerDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Missions.Any())
            {
                context.Missions.AddRange(
                    new Mission
                    {
                        //TaskID = 1,
                        Name = "Встреча",
                        Description = "Поговорить с клиентом",
                        Category = "Meeting",
                        Status = "Scheduled",
                        Priority = 1,
                        AssignedTo = "Имя1",
                        Duration = 120,
                        CreatedDate = new DateTime(2025, 03, 25, 9, 0 ,0)
                    },
                    new Mission
                    { 
                        //TaskID = 2,
                        Name = "Звонок",
                        Description = "Уточнить детали",
                        Category = "Call",
                        Status = "Scheduled", 
                        Priority = 2,
                        AssignedTo = "Имя2",
                        Duration = 120,
                        CreatedDate = new DateTime(2025, 03, 25, 9, 0, 0)
                    },
                    new Mission 
                    { 
                       // TaskID = 3, 
                        Name = "Отчет ",
                        Description = "Подготовить отчет",
                        Category = "Report", 
                        Status = "Scheduled",
                        Priority = 3,
                        AssignedTo = "Имя3",
                        Duration = 120,
                        CreatedDate = new DateTime(2025, 03, 25, 9, 0, 0)
                    },
                    new Mission 
                    { 
                       // TaskID = 4,
                        Name = "Планирование",
                        Description = "Запланировать встречу",
                        Category = "Planning", 
                        Status = "Scheduled",
                        Priority = 4,
                        AssignedTo = "Имя4",
                        Duration = 120,
                        CreatedDate = new DateTime(2025, 03, 25, 9, 0, 0)
                    },
                    new Mission 
                    { 
                        //TaskID = 5,
                        Name = "Собеседование",
                        Description = "Провести собеседование",
                        Category = "HR",
                        Status = "Scheduled",
                        Priority = 5,
                        AssignedTo = "Имя5",
                        Duration = 120,
                        CreatedDate = new DateTime(2025, 03, 25, 9, 0, 0)
                    },
                    new Mission 
                    { 
                        //TaskID = 6, 
                        Name = "Встреча", 
                        Description = "Обсудить проект",
                        Category = "Meeting",
                        Status = "Scheduled",
                        Priority = 6,
                        AssignedTo = "Имя6",
                        Duration = 120,
                        CreatedDate = new DateTime(2025, 03, 25, 9, 0, 0)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
