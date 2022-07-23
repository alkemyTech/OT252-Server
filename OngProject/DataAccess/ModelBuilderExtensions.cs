using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Add Seed Data Category
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Organización", Description = "Noticias propias sobre la organización", 
                        Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false},
                    new Category { Id = 2, Name = "Educación", Description = "Noticias sobre educación y relacionadas con los programas educativos",
                        Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false},
                    new Category { Id = 3, Name = "Finanzas", Description = "Noticias sobre las finanzas de la organización", 
                        Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false },
                    new Category { Id = 4, Name = "Social", Description = "Noticias del ámbito social", 
                        Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false }
                );

            //Add Seed Data Activity
            modelBuilder.Entity<Activity>()
                .HasData(
                    new Activity {Id = 1, Name = "Programas Escucativos", 
                        Content = "Mediantes nuestros programas educativos, buscamos incrementar la capacidad intelectual, " +
                        "moral y afectiva de las personas de acuerdo con la cultura y las normas de convivencia de la sociedad " +
                        "a la que pertenecen.", Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false},
                    new Activity {Id = 2, Name = "Apoyo Escolar para el nivel Primario", 
                        Content = "Es el corazón del área educativa. Se realizan los talleres de lunes a jueves " +
                        "de 10 a 12 horas y de 14 a 16 horas en el contraturno, los sabados también se realiza el taller " +
                        "para niños y niñas que asisten a la escuela doble turno. Tenemos un espacio especial para los " +
                        "de 1er grado 2 veces por semana ya que ellos necesitan atención especial! Se encuentran inscriptos " +
                        "a este programa 150 niños y niñas de 6 a 15 años. Este taller está pensado para ayudar a los " +
                        "alumnos con el material que traen de la escuela, también tenemos una docente que les da clases " +
                        "de lengua y matemática con una planificación propia que armamos en Manos para nivelar a los niños " +
                        "y que vayan con más herramientas a la escuela.", Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false},
                    new Activity {Id = 3, Name = "Apoyo Escolar nivel Secundaria", 
                        Content = "Este taller es el corazón del área secundaria. Se realizan talleres de lunes a " +
                        "viernes de 10 a 12 horas y y de 16 a 18 horas en el contraturno. Actualmente se encuentran " +
                        "inscriptos en el taller 50 adolescentes entre 13 y 20 años. Aquí los jóvenes se presentan " +
                        "con el material que traen del colegio y una docente de la institución y un grupo de voluntarios " +
                        "los recibe para ayudarlos a estudiar o hacer la tarea. Este espacio también es utilizado por " +
                        "los jóvenes como un punto de encuentro y relación entre ellos y la institución.", 
                        Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false},
                    new Activity {Id = 4, Name = "Tutorías", Content = "Es un programa destinado a jóvenes a partir del " +
                    "tercer año de secundaria, cuyo objetivo es garantizar su permanencia en la escuela y constuir un " +
                    "proyecto de vida que da sentido al colegio. El objetivo de esta propuesta es lograr la integración " +
                    "escolar de niños y jóvenes del barrio promoviendo el soporte socioeducativo y emocional apropiado " +
                    ",desarrollando los recursos institucionales necesarios a tráves de la articulación de nuestras " +
                    "intervenciones con las escuelas que los alojan, con las familias de los alumnos y con las instancias " +
                    "municipales, provinciales y nacionales que correspondan, Este programa contempla diferentes talleres.", 
                        Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false},
                    new Activity {Id = 5, Name = "Encuentro semanal con tutores", 
                        Content = "Los participantes participan en reuniones individual o grupales con los tutores.", 
                        Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false},
                    new Activity {Id = 6, Name = "Actividad proyecto", Content = "Los participantes deben pensar una " +
                    "actividad relacionada a lo que quieren hacer una vez terminada la escuela y su tutor los " +
                    "acomapaña en el proceso.", Image = "Agregar ruta de la imagen",
                        TimeStamps = DateTime.Now, SoftDelete = false},
                    new Activity {Id = 7, Name = "Ayudantías", Content = "Los que comienzan el 2do años del programa " +
                    "deben elegir una de las actividades que se realizan en la institución para acompañarla e ir " +
                    "conociendo como es el mundo laboral que les espera.", Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false},
                    new Activity {Id = 8, Name = "Acompañamiento escolar y familiar", 
                        Content = "Los tutores son encargados de articular con la familia y con las escuelas de los " +
                        "jóvenes para monitorear el estado de los tutorados.", Image = "Agregar ruta de la imagen", 
                        TimeStamps = DateTime.Now, SoftDelete = false},
                    new Activity {Id = 9, Name = "Beca estímulo", Content = "Los jóvenes reciben una beca estímulo que es " +
                    "supervisada por los tutores. Se encuentran inscriptos en el programa 30 aodlescentes.", 
                        Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false},
                    new Activity {Id = 10, Name = "Taller de Arte y Cuentos", Content = "Taller literario " +
                    "y de manualidades que se realiza semanalmente.", Image = "Agregar ruta de la imagen", TimeStamps = DateTime.Now, SoftDelete = false},
                    new Activity {Id = 11, Name = "Paseos recreativos y educativos", 
                        Content = "Estos paseos están pensados para promover la participación y sentido de pertenencia " +
                        "de los niños, niñas y adolescentes al área educativa.", Image = "Agregar ruta de la imagen",
                        TimeStamps = DateTime.Now, SoftDelete = false}
                );


            //Add Seed Data Members
            modelBuilder.Entity<Member>()
                        .HasData(
                    new Member { Id = 1, Name = "María Iraola", FacebookUrl= "https://www.facebook.com/", InstragramUrl= "https://www.instagram.com/", LinkedinUrl= "https://www.linkedin.com/feed/", Image="Ruta a la magen", TimeStamps = DateTime.Now, SoftDelete = false },
                    new Member { Id = 2, Name = "Marita Gomez", FacebookUrl = "https://www.facebook.com/", InstragramUrl = "https://www.instagram.com/", LinkedinUrl = "https://www.linkedin.com/feed/", Image = "Ruta a la magen", TimeStamps = DateTime.Now, SoftDelete = false },
                    new Member { Id = 3, Name = "Miriam Rodriguez", FacebookUrl = "https://www.facebook.com/", InstragramUrl = "https://www.instagram.com/", LinkedinUrl = "https://www.linkedin.com/feed/", Image = "Ruta a la magen", TimeStamps = DateTime.Now, SoftDelete = false },
                    new Member { Id = 4, Name = "Cecilia Mendez", FacebookUrl = "https://www.facebook.com/", InstragramUrl = "https://www.instagram.com/", LinkedinUrl = "https://www.linkedin.com/feed/", Image = "Ruta a la magen", TimeStamps = DateTime.Now, SoftDelete = false },
                    new Member { Id = 5, Name = "Rodrigo Fuentes", FacebookUrl = "https://www.facebook.com/", InstragramUrl = "https://www.instagram.com/", LinkedinUrl = "https://www.linkedin.com/feed/", Image = "Ruta a la magen", TimeStamps = DateTime.Now, SoftDelete = false },
                    new Member { Id = 6, Name = "María Garcia", FacebookUrl = "https://www.facebook.com/", InstragramUrl = "https://www.instagram.com/", LinkedinUrl = "https://www.linkedin.com/feed/", Image = "Ruta a la magen", TimeStamps = DateTime.Now, SoftDelete = false },
                    new Member { Id = 7, Name = "Marco Fernandez", FacebookUrl = "https://www.facebook.com/", InstragramUrl = "https://www.instagram.com/", LinkedinUrl = "https://www.linkedin.com/feed/", Image = "Ruta a la magen", TimeStamps = DateTime.Now, SoftDelete = false }
                    );

        }
    }
}
