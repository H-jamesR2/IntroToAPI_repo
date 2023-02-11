using System;
using System.Threading;
/* 
    Create a console app with a class that has an interface and push it to a git repo!
    Send me the link to the repository when done. 
    your class should have at least one interface and
        three different types of properties.
    the interface (and therefore, your class) should have at least three out of these four things:
    instance methods, properties, events, indexers.
    Make sure you have an instance of this class in main!

*/
namespace MyConsoleApplication
{
    interface MyDate
    {
        // Properties:
        string Month { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
    class Date : MyDate
    {
        public Date(String month, int x, int y)
        {
            Month = month;
            X = x;
            Y = y;
        }
        public string Month { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Order
    {
        public string Item;
    }
    public class PackageOrderingService
    {
        // Define delegate
        public delegate void PackageEnrouteEventHandler(object source, EventArgs args);
        // Declare event
        public event PackageEnrouteEventHandler PackageEnroute;

        public void PrepareOrder(Order order)
        {
            Console.WriteLine($"Preparing your package '{order.Item}', please wait...");
            Thread.Sleep(5000);

            OnPackageEnroute();
        }
        protected virtual void OnPackageEnroute()
        {
            if (PackageEnroute != null)
                PackageEnroute(this, null);
        }
    }

    public class AppService
    {
        public void OnPackageEnroute(object source, EventArgs eventArgs)
        {
            Console.WriteLine("AppService: your package is enroute..");
        }
    }

    class Program
    {
        static void PrintDateForDelivery(MyDate date)
        {
            Console.WriteLine($"{date.Month} {date.X}, {date.Y}.");//, date.Month, date.X, date.Y);
        }
        static void Main(string[] args)
        {
            var order = new Order { Item = "Vitamin Supplements 50mg" };
            var orderingService = new PackageOrderingService();
            var appService = new AppService();
            orderingService.PackageEnroute += appService.OnPackageEnroute;
            orderingService.PrepareOrder(order);
            Console.ReadKey();

            MyDate d = new Date("February", 1, 2023);
            Console.Write("Shipment will be delivered by ");
            PrintDateForDelivery(d);
        }
    }
}