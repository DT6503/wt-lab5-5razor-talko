var builder = WebApplication.CreateBuilder(args);

// 1. Читаем порт, который передает Render (если его нет, используем 10000)
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";

// 2. Говорим приложению слушать этот порт на всех интерфейсах
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// 3. Запускаем приложение
app.Run();