var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSpaStaticFiles(configuration => {
  configuration.RootPath = "client/dist";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSpaStaticFiles(); // SPA 拡張機能の適用
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
  endpoints.MapControllers();
});

// SPA拡張機能の適用
app.UseSpa(spa =>
{
  spa.Options.SourcePath = "client";
  if (app.Environment.IsDevelopment())
  {
    // 開発環境では yarn serve をして 8080 ポートへ自動的にリダイレクトしてくれるようにする。
    spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
  }
});

app.Run();
