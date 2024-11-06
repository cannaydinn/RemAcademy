using RemAcademy.Business.Operations.Setting;

namespace RemAcademy.WebApi.Middlewares
{
    public class MaintenanceMiddliware
    {
        private readonly RequestDelegate _next;


        public MaintenanceMiddliware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var settingService = context.RequestServices.GetRequiredService<ISettingService>();
            bool maintenanceMode = settingService.GetMaintenanceState();

            if(context.Request.Path.StartsWithSegments("/api/auth/login") || context.Request.Path.StartsWithSegments("/api/settings"))
            {
                await _next(context);
            }

            if (maintenanceMode) 
            {
                await context.Response.WriteAsync("Şu anda hizmet verememekteyiz");
            }
            else
            {
                await _next(context);    
            }
        }
    }

}
