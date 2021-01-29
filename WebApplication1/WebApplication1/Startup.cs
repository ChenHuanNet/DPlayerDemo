using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace WebApplication1
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
            services.AddControllersWithViews();

            #region 跨域设置  core3.1    4个不能同时打开
            services.AddCors(options =>
            {
                options.AddPolicy("allow_all",
                builder => builder.AllowAnyOrigin()//.WithOrigins("http://127.0.0.1:8081", "http://127.0.0.1:8080", "http://120.25.152.180:8002", "http://120.25.152.180:8003")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                //.AllowCredentials()//指定处理cookie
                );
            });

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            //允许跨域 必须写在UseMvc之前
            app.UseCors("allow_all");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            string path = AppContext.BaseDirectory;
            path = Path.Combine(path, "Files");
            //通过url访问文件
            app.UseStaticFiles(new StaticFileOptions()//自定义自己的文件路径
            {
                RequestPath = new PathString("/api/WebSocketT"),//对外的访问路径
                FileProvider = new PhysicalFileProvider(path)//指定实际物理路径
            });
        }
    }
}
