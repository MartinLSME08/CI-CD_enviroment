//constructor de la aplicaci�n ASP.NET Core
var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de contorladores MVC al contenedor de inyecci�n de dependencias para manejar peticiones HTTP.

builder.Services.AddControllers();

// Configuraci�n de Swagger para probar api 
    // Configurar explorador de endpoints de la API 
builder.Services.AddEndpointsApiExplorer();
    //Agregar generador de Swagger para especificaci�n y UI 
builder.Services.AddSwaggerGen();

//contruir aplicacion web a partir del builder, con configuraciones y servicios
var app = builder.Build();

//Configurci�n de Swagger   
    //habila la generaci�n del JSON OpenAPI
        app.UseSwagger();
    //habilita la interfaz gr�fica en el navegador
        app.UseSwaggerUI();

//Mapea los controladores a las rutas de la aplicaci�n.
    /// Esto permite que las peticiones HTTP sean dirigidas a los m�todos correspondientes en los controladores.
app.MapControllers();

//Ejecuta aplicacion y pone el servidor a la escucha de peticiones HTTP.
app.Run();
