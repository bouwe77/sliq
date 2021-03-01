using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Api.Queries;
using HotChocolate.AspNetCore;
using Microsoft.Extensions.Hosting;
using HotChocolate.AspNetCore.Playground;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Api.Mutations;

namespace Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();

            services.AddRouting();

            services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=sliq.db"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UsePlayground(new PlaygroundOptions
            {
                QueryPath = "/graphql",
                Path = "/playground"
            });
        }
    }
}
