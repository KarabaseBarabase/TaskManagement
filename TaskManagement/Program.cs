using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using TaskManagement.Models;

var builder = WebApplication.CreateBuilder(args);

// ��������� ��������� ������
builder.Services.AddControllersWithViews(); // ����������� ��������� ������������ �������, ����������� � �����������, ������� ������������� MVC frw �������� ������������ Razor
builder.Services.AddDbContext<ManagerDbContext>(options => // ������������ EFR
	options.UseSqlServer(builder.Configuration.GetConnectionString("TaskManagementConnection")));
builder.Services.AddScoped<IManagerRepository, EFManagerRepository>(); // C����� ���������, � ������� ������ HTTP-������ �������� ����������� ������ ���������
var app = builder.Build();

if (!app.Environment.IsDevelopment()) // ��� ��������� ������ � ��������� ������������, ����������� �������, ���� ���������� �� � ������ ����������.
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseDeveloperExceptionPage();  // ����������� �� ������ middleware, ����� ������������� ���������� � ���������� ������, ���� � ������ ����������.

app.UseStatusCodePages(); // ��������� ��������� ����� ���������.

app.UseStaticFiles(); // ��������� ��� ������������ ������������ ����������� �� ����� wwwroot

app.UseRouting();// ������� ����� ������������� �� ������ �������� �������� � ����������, ����� ���������� � �������� ������ ���� �������.

// ����� ���������� ������������� ��������� � ���������� ������������ � ��������� ������ �� ������ ������������� � �����������;
//��� �������� ����� ��������� ���� middleware, ��������� � ���������� ��������.
app.MapDefaultControllerRoute(); // ��������� asp � ���, ��� ������������ URL � �������� ������������

InitialData.EnsurePopulated(app);

app.Run(); // ��������� ���������� � �������� ������������� �������� HTTP-��������.