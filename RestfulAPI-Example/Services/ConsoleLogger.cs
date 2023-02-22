namespace RestfulAPI_Example.Services
{
    public class ConsoleLogger : ILoggerServices
    {
        public void Write(string Message)
        {
            Console.WriteLine("[ConsoleLogger] - " + Message);
        }
    }
}
