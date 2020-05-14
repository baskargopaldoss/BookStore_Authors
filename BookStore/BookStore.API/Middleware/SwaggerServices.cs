using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BookStore.API.Middleware
{
  public static class SwaggerServices
  {

      public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, bool enableAuthorizeButton)
      {
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "BookStore API",
          Version = "v1",
          Description = "Full documentation to BookStore API",
          //Contact = new OpenApiContact
          //{
          //  Name = "Baskar Gopaldoss",
          //  Email = "ping2baskar@gmail.com",
          //  Url = new Uri("https://www.baskarg.cloud/")
          //},
        });

        if (enableAuthorizeButton)
        {
          c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
          {
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\nExample: \"Bearer 12345abcdef\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
          });

          c.AddSecurityRequirement(new OpenApiSecurityRequirement()
          {
              {
                  new OpenApiSecurityScheme
                  {
                      Reference = new OpenApiReference
                      {
                          Type = ReferenceType.SecurityScheme,
                          Id = "Bearer"
                      },
                      Scheme = "oauth2",
                      Name = "Bearer",
                      In = ParameterLocation.Header,

                  },
                  new List<string>()
              }
          });
        }

      });
      return services;
      }

      public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
      {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API V1");
          c.DocumentTitle = "BookStore API Documentation";
          c.DocExpansion(DocExpansion.None);
        });

      return app;
      }

  }

  public static class JWTServices
  {

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration _configuration, bool enableJWTToken)
    {
        if (enableJWTToken)
        {
            string securityKey = _configuration["Jwt:Key"];
            //string securityKey = "security_key_for_bookstore$2020";
            var symmetricSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(securityKey));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],
                IssuerSigningKey = symmetricSecurityKey
              };
            });
      }
      return services;
    }

  }


}
