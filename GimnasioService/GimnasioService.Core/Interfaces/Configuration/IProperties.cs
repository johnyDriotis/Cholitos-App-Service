namespace GimnasioService.Core.Interfaces.Configuration
{
    public interface IProperties
    {
        // Propiedades solo de lectura
        string Server { get; }
        string Database { get; }
        string UserName { get; }
        string Password { get; }
        string IntegratedSecurity { get; }

        // Propiedades de lectura y escritura.
        string ConnectionString { get; set; }

    }
}
