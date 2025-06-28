using CholitosGymService.Core.Interfaces;

namespace CholitosGymService.WebApi.Configuration
{
    public class Properties : IProperties
    {
        private readonly IConfiguration _configuration;

        public Properties(IConfiguration configuration) {
            this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            // Obtener datos para conectarse al servidor de base de datos.
            this.Server = configuration["CholitosAppFront.Configuration.Database:Host"] ?? "";
            this.Database = configuration["CholitosAppFront.Configuration.Database:Database"] ?? "";
            this.UserName = configuration["CholitosAppFront.Configuration.Database:UserDb"] ?? "";
            this.Password = configuration["CholitosAppFront.Configuration.Database:Password"] ?? "";
            this.IntegratedSecurity = configuration["CholitosAppFront.Configuration.Database:IntegratedSecurity"] ?? "";

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


        // Propiedades que no se necesita sean inyectadas por un servicio
        public string ConnectionString { get; set; }
    }
}
