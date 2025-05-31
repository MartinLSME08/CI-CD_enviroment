using Microsoft.EntityFrameworkCore;
using Modelo;

namespace TestModelo
{
    public class AlumnoServiceTEST
    {
        private readonly DbContextOptions<Context> _context;
        private readonly IAlumno _alumnoService;

        public AlumnoServiceTEST()
        {
            _context = new DbContextOptions<Context>();

            using var context = new Context();

                for (int i = 1; i <= 10; i++)
                {
                    context.Alumnos.Add(new Alumno
                    {
                        Legajo = i,
                        Nombre = "Martin" + i,
                        Apellido = "Lopez Soto" + i,
                        Email = "martinls0" + i + "@gmail.com",
                        Telefono = "3777-" + i.ToString()
                    });
                
                    context.SaveChanges();
                }
                context.Database.EnsureDeleted();  
                context.Database.EnsureCreated();


            _alumnoService = new AlumnoService(context);
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
            int legajo = 2;

            // Act
            var result = await _alumnoService.Delete(legajo);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(legajo, result.Legajo);
        }
    }


    }
