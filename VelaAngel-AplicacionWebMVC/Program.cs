using Microsoft.EntityFrameworkCore;
using VelaAngel_AplicacionWebMVC.Data; // Aseg�rate de que este es el espacio de nombres correcto

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexi�n a PostgreSQL (aseg�rate de que la cadena de conexi�n est� en appsettings.json)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios para controladores con vistas (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build(); // Solo una llamada a Build()

// Configurar el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Jugador}/{action=Index}/{id?}");

app.Run();
