﻿namespace RemAcademy.WebApi.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMaintenanceMode(this IApplicationBuilder app)
        {
           return app.UseMiddleware<MaintenanceMiddliware>();
        }
    }
}
