
using EmployeesWeb;

public class Program
{
    private static void Main(string[] args)
    {
      var app = Startup.InitializeApp(args);
      app.Run();
    }
}
