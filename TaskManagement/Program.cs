using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using TaskManagement.Models;

var builder = WebApplication.CreateBuilder(args);

// Настройка контекста данных
builder.Services.AddControllersWithViews(); // настраивает совместно используемые объекты, требующиеся в приложениях, которые эксплуатируют MVC frw механизм визуализации Razor
builder.Services.AddDbContext<ManagerDbContext>(options => // Конфигурация EFR
	options.UseSqlServer(builder.Configuration.GetConnectionString("TaskManagementConnection")));
builder.Services.AddScoped<IManagerRepository, EFManagerRepository>(); // Cлужба хранилища, в которой каждый HTTP-запрос получает собственный объект хранилища
var app = builder.Build();

if (!app.Environment.IsDevelopment()) // Для обработки ошибок и настройки безопасности, выполняются первыми, если приложение не в режиме разработки.
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseDeveloperExceptionPage();  // Добавляется до других middleware, чтобы перехватывать исключения и показывать детали, если в режиме разработки.

app.UseStatusCodePages(); // Добавляет обработку кодов состояний.

app.UseStaticFiles(); // Поддержка для обслуживания статического содержимого из папки wwwroot

app.UseRouting();// Создает точки маршрутизации на основе входящих запросов и определяет, какой контроллер и действие должны быть вызваны.

// Здесь происходит сопоставление маршрутов с действиями контроллеров и генерация ответа на основе маршрутизации и авторизации;
//это делается после настройки всех middleware, связанных с обработкой запросов.
app.MapDefaultControllerRoute(); // указывает asp о том, как сопоставлять URL с классами контроллеров

InitialData.EnsurePopulated(app);

app.Run(); // запускает приложение и начинает прослушивание входящих HTTP-запросов.