using Microsoft.EntityFrameworkCore;
using NotesApp.Data;

// Reference using https://stackoverflow.com/a/75218950/13150631

namespace NotesApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration) {
            this.Configuration = configuration;
        }

        /* This method gets called by the runtime(Program.cs).
           Use this method to add services to the container. 
        */
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // MySQL connection setup
            var connectionStrings = this.Configuration.GetConnectionString("DefaultConnection");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings));
            });
        }


        /* This method gets called by the runtime(Program.cs)
           Use this method to configure the HTTP request pipeline.
        */
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

        }

    }
}
