using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace API {
	public class Startup {
		public Startup(IConfiguration configuration) => Configuration = configuration;

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

			services.AddControllers();

			services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" }));

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options => {
						options.SaveToken = true;
						options.TokenValidationParameters = new TokenValidationParameters {
							ValidateLifetime = true,
							ValidateAudience = true,
							ValidateIssuer = true,
							ValidateIssuerSigningKey = true,
							ValidAudience = Configuration["JWT:Audience"],
							ValidIssuer = Configuration["JWT:Issuer"],
							IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])),
							ClockSkew = TimeSpan.Zero
						};
						options.Events = new JwtBearerEvents {
							OnAuthenticationFailed = context =>
							{
								if (context.Exception.GetType() == typeof(SecurityTokenExpiredException)) {
									context.Response.ContentType = "application/json; charset=utf-8";
									context.Response.StatusCode = 401;
									context.Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes($"{{\"message\":\"Token expired.\"}}"));
								}
								return Task.CompletedTask;
							}
						};
					});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => endpoints.MapControllers());
		}
	}
}
