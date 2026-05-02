using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerce.Helper;

public class WorkingHoursAttribute : ActionFilterAttribute
{
    private readonly int _startHour;
    private readonly int _endHour;

    public WorkingHoursAttribute(int startHour , int endHour ,string message)
    {
        _startHour = startHour;
        _endHour = endHour;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var cuurentHour = DateTime.Now.Hour;
        
        if(cuurentHour < _startHour || cuurentHour >= _endHour)
        {
            context.Result = new ContentResult
            {
                Content = "الخدمة متاحة فقط ضمن اوقات الدوام",
                StatusCode = 403
            };
        }

        base.OnActionExecuting(context);
    }
}

public class AuditAttribute : ActionFilterAttribute
{
    private readonly string _message;

    public AuditAttribute(string message)
    {
        _message = message;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Add Message To Database Audit Log

        base.OnActionExecuting(context);
    }
}