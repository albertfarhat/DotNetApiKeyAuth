using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiKeyAuth
{
    public static class ServicesConfiguration
    {
        public static void AddApiKeyAuth(this IServiceCollection services,string policy,string[] keys)
        {
            services.AddAuthorization(authConfig =>
            {
                authConfig.AddPolicy(policy,
                  policyBuilder => policyBuilder
                      .AddRequirements(new ApiKeyRequirement(keys)));            
            });
            services.AddTransient<IAuthorizationHandler, ApiKeyRequirementHandler>();
        }
    }
}
