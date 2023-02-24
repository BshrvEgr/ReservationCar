using System.Text.Json.Serialization;

namespace WpfApp1.Models.MySql
{
    public class ConnectionStringMySql
    {
        [JsonPropertyName("ConnectionString")]
        public string ConnectionString { get; set; }
    }
}
