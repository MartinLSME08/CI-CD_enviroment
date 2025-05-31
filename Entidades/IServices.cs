namespace Modelo
{
    public interface IAlumno
        {
            Task<Alumno>? CreateAlumno(Alumno alumno);
            Task<IEnumerable<Alumno>> GetAllAlumnos();
            Task<Alumno>? GetAlumno(int legajo);
            Task<Alumno> Update(Alumno alumno);
            Task<Alumno>? Delete(int legajo);

        }
}
