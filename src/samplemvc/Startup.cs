using System;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.FileSystems;
using Microsoft.AspNet.StaticFiles;

public class Startup
{
    public void Configure(IApplicationBuilder app)
    {
        app.UseServices(services =>
        {
            services.AddMvc();
        });

	app.UseFileServer(new FileServerOptions()
            {
                EnableDirectoryBrowsing = false,
            });
        app.Use(async (context, next) => 
        {
            Console.WriteLine(context.Request.Path);

            try
            {
                await next();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        });

        app.UseMvc();
    }
}

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}
