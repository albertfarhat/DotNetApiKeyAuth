using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ApiKeyAuth
{
    public static class ServicesConfiguration
    {/// <summary>
    /// 
    /// </summary>
    /// <param name="policy">Defines the policy key used on Api Actions</param>
    /// <param name="keys">array of allowed keys for authorization</param>
    /// <param name="headerKey">header key used for authorization</param>
        public static void AddApiKeyAuth(this IServiceCollection services,string policy,string[] keys,string headerKey)
        {
            GlobalSettings.HeaderKey = headerKey;
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
