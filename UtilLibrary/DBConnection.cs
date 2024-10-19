using Microsoft.Extensions.Configuration;

namespace UtilLibrary
{
    public class DBConnection
    {
        private static IConfigurationRoot _configuration;
        static string cnstring = null;
        static DBConnection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("C:\\Users\\Ayush Tripathi\\OneDrive\\Desktop\\Technical Training\\CARS\\UtilLibrary\\appsettings.json",
                optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }


        public static string ReturnCn(string key)
        {
            cnstring = _configuration.GetConnectionString(key);
            return cnstring;

        }
    }
}
