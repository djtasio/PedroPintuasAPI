using Serilog;
using Serilog.Events;
using Serilog.AspNetCore;

public class Startup
{
    private readonly IWebHostEnvironment _env;

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        _env = env;
    }

    public IConfiguration Configuration { get; }

    public void Configure(IApplicationBuilder app)
    {
        // Otras configuraciones de la aplicación

        // Obtener la ruta raíz del proyecto
        string logsPath = Path.Combine(_env.ContentRootPath, "LogErrores", "logs.txt");

        // Configurar Serilog
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File(logsPath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

        app.UseSerilogRequestLogging(); // Registrar solicitudes HTTP

        // Resto de la configuración de la aplicación
    }
}
