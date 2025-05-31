//constructor de la aplicación ASP.NET Core
var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de contorladores MVC al contenedor de inyección de dependencias para manejar peticiones HTTP.

builder.Services.AddControllers();

// Configuración de Swagger para probar api 
    // Configurar explorador de endpoints de la API 
builder.Services.AddEndpointsApiExplorer();
    //Agregar generador de Swagger para especificación y UI 
builder.Services.AddSwaggerGen();

//contruir aplicacion web a partir del builder, con configuraciones y servicios
var app = builder.Build();

//Configurción de Swagger   
    //habila la generación del JSON OpenAPI
        app.UseSwagger();
    //habilita la interfaz gráfica en el navegador
        app.UseSwaggerUI();

//Mapea los controladores a las rutas de la aplicación.
    /// Esto permite que las peticiones HTTP sean dirigidas a los métodos correspondientes en los controladores.
app.MapControllers();

//Ejecuta aplicacion y pone el servidor a la escucha de peticiones HTTP.
app.Run();
