using System.Web.Mvc;

namespace GYPSEA.Controllers.SessionActionFilter
{
    public class SessionFilter : ActionFilterAttribute
    {

        private readonly int[] _validRoles;
        public SessionFilter(params int[] validRoles)
        {
            _validRoles = validRoles;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ActionResult result = filterContext.Result;
            filterContext.Result = new RedirectResult("~/Home/Index");
            int? sessionRole = (int?)filterContext.HttpContext.Session["RoleID"];
            if (sessionRole != null)
            {

                foreach (int currentRole in _validRoles)
                {
                    if (currentRole == sessionRole)
                    {
                        filterContext.Result = result;
                    }
                    else
                    { }
                }
            }
            else
            {

            }
            base.OnActionExecuting(filterContext);
        }
    }
}