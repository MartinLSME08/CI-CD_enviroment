using Microsoft.EntityFrameworkCore;
using Modelo;

namespace TestModelo
{
    public class AlumnoServiceTEST
    {
        //private readonly DbContextOptionsBuilder<Context> _context;
        private readonly Context _context;
        private readonly IAlumno _alumnoService;

        public AlumnoServiceTEST()
        {
            //Configurar Base de Datos en Memoria para Pruebas Unitarias

            //_context = new DbContextOptionsBuilder<Context>()
            //                                                  .UseInMemoryDatabase("ServicesTesting");

             _context = new Context();

            _context.Database.EnsureDeleted();  
            _context.Database.EnsureCreated();

            for (int i = 1; i <= 10; i++)
                {
                    _context.Alumnos.Add(new Alumno
                    {
                        Legajo = i,
                        Nombre = "Martin" + i.ToString(),
                        Apellido = "Lopez Soto" + i.ToString(),
                        Email = "martinls0" + i.ToString() + "@gmail.com",
                        Telefono = "3777-" + i.ToString()

                    });   
                }

                _context.SaveChanges();

              

                _alumnoService = new AlumnoService(_context);
        }

        [Fact]
        public async Task GetAllAlumnos_ReturnsAllAlumnos()
        {
            // Act
            var result = await _alumnoService.GetAllAlumnos();

            // Assert
            Assert.Equal(10, result.Count());
        }

        [Fact]
        public async Task GetAlumno_WithExistingLegajo_ReturnsAlumno()
        {
            // Arrange
            int legajo = 1;

            // Act
            var result = await _alumnoService.GetAlumno(legajo);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(legajo, result.Legajo);
        }

        [Fact]
        public async Task CreateAlumno_ReturnsCreatedAlumno()
        {
            // Arrange
            var newAlumno = new Alumno
            {
                Legajo = 11,
                Nombre = "New",
                Apellido = "Alumno",
                Email = "newalumno@gmail.com",
                Telefono = "1234-5678"
            };

            // Act
            var result = await _alumnoService.CreateAlumno(newAlumno);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newAlumno.Legajo, result.Legajo);
        }

        [Fact]
        public async Task UpdateAlumno_ReturnsUpdatedAlumno()
        {
            // Arrange
            var existingAlumno = await _alumnoService.GetAlumno(1);
            existingAlumno.Nombre = "UpdatedName";

            // Act
            var result = await _alumnoService.Update(existingAlumno);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(existingAlumno.Nombre, result.Nombre);
        }

        [Fact]
        public async Task DeleteAlumno_ReturnsDeletedAlumno()
        {
            // Arrange
            int legajo = 1;

            // Act
            var result = await _alumnoService.Delete(legajo);

            // Assert
            Assert.Equal(legajo, result.Legajo);
            Assert.NotNull(result);
            
        }
    }


    }
