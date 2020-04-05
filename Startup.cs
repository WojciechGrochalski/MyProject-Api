using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyProject.Services;
using MyProject.Tools;
using Newtonsoft.Json;

namespace MyProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.WriteIndented = true);

            services.AddCronJob<MyCronJob>(c =>
            {
                c.TimeZoneInfo = TimeZoneInfo.Local;
                c.CronExpression = @" 20 8 * * *  ";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           
            app.UseWebSockets();

            app.Use(async (http, next) =>
            {
                if (http.WebSockets.IsWebSocketRequest &&
                    http.Request.Path=="/ws")
                {
                    Program.wb = await http.WebSockets.AcceptWebSocketAsync();
                    await Task.Run(async () =>
                    {
                        
                        while(Program.wb.State== System.Net.WebSockets.WebSocketState.Open)
                        {
                            byte[] bt = new byte[1024];
                            System.Net.WebSockets.WebSocketReceiveResult rc = 
                            await Program.wb.ReceiveAsync(bt, CancellationToken.None);

                            string txt = System.Text.Encoding.UTF8.GetString(bt);
                            await Program.wb.SendAsync(System.Text.Encoding.UTF8.GetBytes(txt),
                                System.Net.WebSockets.WebSocketMessageType.Text,true,CancellationToken.None);
                        }
                    });
                }
                else
                {
                    await next();
                }
            });
        }
    }
}
