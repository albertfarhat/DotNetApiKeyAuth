using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiKeyAuth
{
    public class ApiKeyRequirementHandler : AuthorizationHandler<ApiKeyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiKeyRequirement requirement)
        {
            ValidateApiKey(context, requirement);
            return Task.CompletedTask;
        }

        private void ValidateApiKey(AuthorizationHandlerContext context, ApiKeyRequirement requirement)
        {
            if (context.Resource is AuthorizationFilterContext authorizationFilterContext)
            {
                var apiKey = authorizationFilterContext.
                    HttpContext
                    .Request
                    .Headers[GlobalSettings.HeaderKey]
                    .FirstOrDefault();
                if (apiKey == null)
                {
                    var authFilterContext = context.Resource as AuthorizationFilterContext;
                    authFilterContext.Result = new RedirectToActionResult(
                        GlobalSettings.NoApiKeyAction, 
                        GlobalSettings.AuthController, null);
                    context.Succeed(requirement);
                }
                else
                if (requirement.ApiKeys.Any(requiredApiKey => apiKey == requiredApiKey))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    var authFilterContext = context.Resource as AuthorizationFilterContext;
                    authFilterContext.Result = new RedirectToActionResult(
                        GlobalSettings.NotAuthorizedAction,
                        GlobalSettings.AuthController, null);
                    context.Succeed(requirement);
                }
            }
        }
    }
}
