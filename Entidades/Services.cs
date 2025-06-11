using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    
        public class AlumnoService : IAlumno
        {
            private readonly Context _context;

            public AlumnoService(Context context)
            {
                _context = context;
            }

            public async Task<Alumno>? CreateAlumno(Alumno alumno)
            {
                _context.Alumnos.Add(alumno);
                await _context.SaveChangesAsync();
                return (alumnos);
            }

            public async Task<IEnumerable<Alumno>>? GetAllAlumnos()
            {
                // no deja asincrono, revisar
                var usuarios = _context.Alumnos.ToList();

                return(usuarios);
            }

            public async Task<Alumno>? GetAlumno(int legajo)
            {
                var alumno = await _context.Alumnos.FindAsync(legajo);

                return (alumno);
            }

            public async Task<Alumno> Update(Alumno alumno)
            {
                _context.Alumnos.Update(alumno);
                await _context.SaveChangesAsync();
                return alumno;
            }

            public async Task<Alumno>? Delete(int legajo)
            {
                var alumno = await GetAlumno(legajo);

                if (alumno != null)
                {
                    _context.Alumnos.Remove(alumno);
                    await _context.SaveChangesAsync();
                }
               
                return alumno;
            }
        }
    }