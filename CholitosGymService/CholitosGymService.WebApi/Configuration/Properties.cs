using CholitosGymService.Core.Interfaces.Configuration;

namespace CholitosGymService.WebApi.Configuration
{
    public class Properties : IProperties
    {
        private readonly IConfiguration _configuration;

        public Properties(IConfiguration configuration) {
            this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            // Obtener datos para conectarse al servidor de base de datos.
            this.Server = configuration["Gimnasio.Configuration.Database:Host"] ?? "";
            this.Database = configuration["Gimnasio.Configuration.Database:Database"] ?? "";
            this.UserName = configuration["Gimnasio.Configuration.Database:UserDb"] ?? "";
            this.Password = configuration["Gimnasio.Configuration.Database:Password"] ?? "";
            this.IntegratedSecurity = configuration["Gimnasio.Configuration.Database:IntegratedSecurity"] ?? "";

            if (Convert.ToBoolean(IntegratedSecurity))
            {
                this.ConnectionString = $"Server = {this.Server}; Database = {this.Database}; Integrated Security = {this.IntegratedSecurity}";
            }
            else {
                this.ConnectionString = $"Server = {this.Server}; Initial Catalog = {this.Database}; User ID = {this.UserName}; Password = {this.Password}";
            }
        }

        // Propiedades que se implementan a traves de la interfaz IProperties.
        public string Server { get; }
        public string Database { get; }
        public string UserName { get; }
        public string Password { get; }
        public string IntegratedSecurity { get; }


        // Propiedades no implementadas por IProperties
        public string ConnectionString { get; set; }
    }
}
