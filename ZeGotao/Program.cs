using Microsoft.EntityFrameworkCore;

using ZeGotao.Core.Data;

var builder = WebApplication.CreateBuilder(args);

// =========================================================
// CONFIGURAÇÃO DE SESSÃO
// =========================================================
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddDbContext<ZeGotaoContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ZeGotaoContext")
        ?? throw new InvalidOperationException("Connection string 'ZeGotaoContext' not found.")
    )
);

// =========================================================
// MVC
// =========================================================
builder.Services.AddControllersWithViews();

var app = builder.Build();

// =========================================================
// PIPELINE
// =========================================================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Sessão deve vir ANTES de autenticação/autorização
app.UseSession();

// Se tiver autenticação, manter essas linhas (não remove):
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.Run();