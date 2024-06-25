using CapitoleSantander.Domain.Logic;

namespace CapitoleSantander;

public class Startup
{
      public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddEndpointsApiExplorer();

        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
        });

        services.AddControllers();
        services.AddSwaggerGen();

        services.AddHttpClient<IHackerNewsService, HackerNewsService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UsePathBase("/");

        if (!env.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production
            // scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        else
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseResponseCompression();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
