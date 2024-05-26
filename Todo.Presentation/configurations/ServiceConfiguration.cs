using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Todo.Application.Handlers;
using Todo.Application.Handlers.Contracts;
using Todo.Application.Handlers.Contracts.UseCase.Task;
using Todo.Application.Handlers.Contracts.UseCase.User;
using Todo.Domain.RequestModel;
using Todo.Domain.RequestModel.Task;
using Todo.Domain.ResponseModel;
using Todo.Infrastructure;
using Todo.Infrastructure.Contracts;
using Todo.Infrastructure.Database;

namespace Todo.Presentation.configurations
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddConfigureServices(this IServiceCollection services){
            services.AddScoped<DatabaseContext>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskHandler, TaskHandler>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserHandler, UserHandler>();
            services.AddScoped<IHandler<LoginDto, CommonResponse>, LoginHandler>();
            services.AddScoped<IHandler<RegisterDto, CommonResponse>, RegistrationHandler>();
            services.AddScoped<IHandler<AddTaskRequest,CommonResponse>, CreateTaskHandler>();
            services.AddScoped<IHandler<GetTaskRequest,CommonResponse>, GetTaskHandler>();
            services.AddScoped<IHandler<GetAllTaskRequest, CommonResponse>, GetAllTaskHandler>();
            services.AddScoped<IHandler<UpdateTaskRequest, CommonResponse>, UpdateTaskHandler>();
            services.AddScoped<IHandler<DeleteTaskRequest, CommonResponse>, DeleteTaskHandler>();
            services.AddScoped<IHandler<BulkDeleteRequest, CommonResponse>, BulkDeleteHandler>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "shanto",
                        ValidAudience = "company",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hcuegcuegcuc"))
                    };
                });
            return services;
        }
        
    }
}