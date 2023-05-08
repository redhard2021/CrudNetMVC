using System.Data.SqlClient;


namespace CRUDCORE.Datos
{
    public class Connection
    {
        private string chainSQL = string.Empty;

        public Connection()
        {
            var builder =
                new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            #pragma warning disable CS8601 // Possible null reference assignment.
            chainSQL = builder.GetSection("ConnectionStrings:ChainSQL").Value;
        }

        public string ChainSQL()
        {
            return chainSQL;
        }
    }
}
