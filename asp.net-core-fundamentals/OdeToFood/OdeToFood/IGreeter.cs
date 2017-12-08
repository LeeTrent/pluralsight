using Microsoft.Extensions.Configuration;

namespace OdeToFood
{
    public interface IGreeter
    {
        string getMessageOfTheDay();
    }

    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration config)
        {
            _configuration = config;
        }

        string IGreeter.getMessageOfTheDay()
        {
            return _configuration["Greeting"];
        }
    }
}