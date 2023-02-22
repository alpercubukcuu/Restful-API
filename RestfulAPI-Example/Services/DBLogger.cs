namespace RestfulAPI_Example.Services
{
    public class DBLogger : ILoggerServices
    {
        public void Write(string Message)
        {
            Console.WriteLine("[DBLogger] - " + Message);
        }
    }
}
