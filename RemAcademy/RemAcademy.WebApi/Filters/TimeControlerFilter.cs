using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RemAcademy.WebApi.Filters
{
    public class TimeControlerFilter : ActionFilterAttribute
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var now = DateTime.Now.TimeOfDay;

            StartTime = "22:00";
            EndTime = "23:00";

            if (now >= TimeSpan.Parse(StartTime) && now <= TimeSpan.Parse(EndTime)) 
            {
                base.OnActionExecuting(context);
            }
            else
            {
                context.Result = new ContentResult
                {
                    Content = "Bu saatler arasında end-point'e istek atılamaz!!!!!",
                    StatusCode = 403
                };
            }
            
        }
    }
}
