using ELearningPlatform.BLL.Dtos.StudentDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ELearningPlatform.API.Filters
{
    public class CheckAgeIfLessThan6Attribute : ActionFilterAttribute
    {
        //ActionFilterAttribute has 2 important methods for applying filtering
        //OnActionExecuting
        //OnActionExecuted
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var model = context.ActionArguments["studentAddDto"] as StudentAddDto;
            
            if(model.Age < 6)
            {
                context.ModelState.AddModelError("", "Sorry, student's age is less 6 years");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
