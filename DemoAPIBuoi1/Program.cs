using DemoAPIBuoi1.Repository;
using DemoAPIBuoi1.Repository.IRepository;

namespace DemoAPIBuoi1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IReservationRepository,ReservationRepository>();
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
