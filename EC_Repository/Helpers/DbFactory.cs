using Microsoft.Extensions.Configuration;

namespace EC_Repository.Helpers
{
    public static class DbFactory
    {
        public static string dbconnection { get; set; }
        public static void SetProperties(IConfiguration conf)
        {
            dbconnection = conf.GetConnectionString("DefaultConnection");

        }

        public static string GetConnectionString
        {
            get { return "Server=.\\SQLExpress;Database=ec_db;Trusted_Connection=True;MultipleActiveResultSets=true"; }
        }
    }
}
