
using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;

namespace HotelProject.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<Context>();
            builder.Services.AddScoped<IStaffDal, EfStaffDal>();
            builder.Services.AddScoped<IStaffService, StaffManager>();

            builder.Services.AddScoped<IRoomDal, EfRoomDal>();
            builder.Services.AddScoped<IRoomService, RoomManager>();

            builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
            builder.Services.AddScoped<ISubscribesService, SubscribesManager>();

            builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

            builder.Services.AddScoped<IServiceDal, EfServiceDal>();
            builder.Services.AddScoped<IServiceService, ServiceManager>();

            builder.Services.AddScoped<IAboutDal, EfAboutDal>();
            builder.Services.AddScoped<IAboutService, AboutManager>();

            builder.Services.AddScoped<IBookingDal, EfBookingDal>();
            builder.Services.AddScoped<IBookingService, BookingManager>();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);



            builder.Services.AddCors(options =>
            {
                options.AddPolicy("OtelApiCors",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();

            }


            app.UseCors("OtelApiCors");

            //app useauthorization hemen üstüne

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
