using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using System;
using OngProject.Core.Helper;


namespace OngProject.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {


            //Add Sedd Data Testimomios
            modelBuilder.Entity<Testimony>()
                .HasData(
                new Testimony
                { Id=1,Name="Juan Perez",Content= "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Image="urlconimagenpersona", SoftDelete = false, TimeStamps= DateTime.Now },
                new Testimony
                {
                    Id = 2, Name = "Micaela Suarez", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Image = "urlconimagenpersona", SoftDelete = false, TimeStamps = DateTime.Now
                },
                new Testimony
                {
                    Id = 3, Name = "Hernan Gomez", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Image = "urlconimagenpersona", SoftDelete = false, TimeStamps = DateTime.Now
                }
                );


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

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, SoftDelete = false, Name = "Administrador", Description = "Role Administrator", TimeStamps = DateTime.UtcNow },
                new Role { Id = 2, SoftDelete = false, Name = "Comun", Description = "Role Common", TimeStamps = DateTime.UtcNow }
                );

            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 1,
                    FirstName = "Milton",
                    LastName = "Casco",
                    Email = "miltoncasco20@seed.com",
                    Password = EncryptHelper.GetSHA256("milton123"),
                    Photo = "foto.jpg",
                    RoleId = 1,
                },
                new Users
                {
                    Id = 2,
                    FirstName = "Enzo",
                    LastName = "Perez",
                    Email = "enzopere24@seed.com",
                    Password = EncryptHelper.GetSHA256("enzo123"),
                    Photo = "foto.jpg",
                    RoleId = 1,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 3,
                    FirstName = "Juan Fernando",
                    LastName = "Quintero",
                    Email = "juanfer10@seed.com",
                    Password = EncryptHelper.GetSHA256("juanfer123"),
                    Photo = "foto.jpg",
                    RoleId = 1,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 4,
                    FirstName = "Marcelo",
                    LastName = "Gallardo",
                    Email = "muñeco@seed.com",
                    Password = EncryptHelper.GetSHA256("muñeco123"),
                    Photo = "foto.jpg",
                    RoleId = 1,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 5,
                    FirstName = "Lucas",
                    LastName = "Beltran",
                    Email = "lucasbeltran@seed.com",
                    Password = EncryptHelper.GetSHA256("lucas123"),
                    Photo = "foto.jpg",
                    RoleId = 1,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 6,
                    FirstName = "Ignacio",
                    LastName = "Fernandez",
                    Email = "nacho26@seed.com",
                    Password = EncryptHelper.GetSHA256("nacho123"),
                    Photo = "foto.jpg",
                    RoleId = 1,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 7,
                    FirstName = "Leonardo",
                    LastName = "Ponzio",
                    Email = "leon23@seed.com",
                    Password = EncryptHelper.GetSHA256("ponzio123"),
                    Photo = "foto.jpg",
                    RoleId = 1,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 8,
                    FirstName = "Bruno",
                    LastName = "Zuculini",
                    Email = "zuculini@seed.com",
                    Password = EncryptHelper.GetSHA256("zucu123"),
                    Photo = "foto.jpg",
                    RoleId = 1,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 9,
                    FirstName = "Gonzalo",
                    LastName = "Montiel",
                    Email = "montiel29@seed.com",
                    Password = EncryptHelper.GetSHA256("gonza123"),
                    Photo = "foto.jpg",
                    RoleId = 1,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 10,
                    FirstName = "Javier",
                    LastName = "Pinola",
                    Email = "javipinola@seed.com",
                    Password = EncryptHelper.GetSHA256("pinola123"),
                    Photo = "foto.jpg",
                    RoleId = 1,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 11,
                    FirstName = "Franco",
                    LastName = "Armani",
                    Email = "armani1@seed.com",
                    Password = EncryptHelper.GetSHA256("armani123"),
                    Photo = "foto.jpg",
                    RoleId = 2,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 12,
                    FirstName = "Julian",
                    LastName = "Alvarez",
                    Email = "julian9@seed.com",
                    Password = EncryptHelper.GetSHA256("julian123"),
                    Photo = "foto.jpg",
                    RoleId = 2,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 13,
                    FirstName = "Ariel",
                    LastName = "Ortega",
                    Email = "ariel14@seed.com",
                    Password = EncryptHelper.GetSHA256("ariel123"),
                    Photo = "foto.jpg",
                    RoleId = 2,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 14,
                    FirstName = "Matias",
                    LastName = "Biscay",
                    Email = "matiasdt@seed.com",
                    Password = EncryptHelper.GetSHA256("matias123"),
                    Photo = "foto.jpg",
                    RoleId = 2,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 15,
                    FirstName = "Jose",
                    LastName = "Paradela",
                    Email = "paradela@seed.com",
                    Password = EncryptHelper.GetSHA256("jose123"),
                    Photo = "foto.jpg",
                    RoleId = 2,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 16,
                    FirstName = "Elias",
                    LastName = "Gomez",
                    Email = "eliasgomez@seed.com",
                    Password = EncryptHelper.GetSHA256("elias123"),
                    Photo = "foto.jpg",
                    RoleId = 2,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 17,
                    FirstName = "Esequiel",
                    LastName = "Barco",
                    Email = "barco21@seed.com",
                    Password = EncryptHelper.GetSHA256("barco123"),
                    Photo = "foto.jpg",
                    RoleId = 2,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 18,
                    FirstName = "Agustin",
                    LastName = "Palavecino",
                    Email = "aguspala@seed.com",
                    Password = EncryptHelper.GetSHA256("agus123"),
                    Photo = "foto.jpg",
                    RoleId = 2,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 19,
                    FirstName = "Rodrigo",
                    LastName = "Aliendro",
                    Email = "aliendro@seed.com",
                    Password = EncryptHelper.GetSHA256("rodri123"),
                    Photo = "foto.jpg",
                    RoleId = 2,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                },
                new Users
                {
                    Id = 20,
                    FirstName = "Bruno",
                    LastName = "Zuculini",
                    Email = "zuculini@seed.com",
                    Password = EncryptHelper.GetSHA256("zucu123"),
                    Photo = "foto.jpg",
                    RoleId = 2,
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                }
                );

            modelBuilder.Entity<Organization>().HasData(
                new Organization
                {
                    Id = 1,
                    Name = "Somos Mas",
                    Image = "somosmas.jpg",
                    Address = "Direccion Falsa 123",
                    Email = "somosfundacionmas@gmail.com",
                    Phone = "1160112988",
                    WelcomeText = "Bienvenidos nosotros somos Somos Mas",
                    AboutUsText = "Somos una asociacion civil sin fines de lucro",
                    FacebookUrl = "facebook.com/Somos_Mas",
                    InstagramUrl = "instragram.com/SomosMas",
                    LinkedinUrl = "linkedin.com/SomosMas",
                    SoftDelete = false,
                    TimeStamps = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Slide>().HasData(
                    new Slide
                    {
                        Id = 1,
                        ImageUrl = "primerslide.jpg",
                        Text = "Este es el primer slide",
                        Order = 1,
                        OrganizationId = 1,
                        SoftDelete = false,
                        TimeStamps = DateTime.UtcNow
                    },
                      new Slide
                      {
                          Id = 2,
                          ImageUrl = "segundoslide.jpg",
                          Text = "Este es el segundo slide",
                          Order = 2,
                          OrganizationId = 1,
                          SoftDelete = false,
                          TimeStamps = DateTime.UtcNow
                      },
                        new Slide
                        {
                            Id = 3,
                            ImageUrl = "tercerslide.jpg",
                            Text = "Este es el tercer slide",
                            Order = 3,
                            OrganizationId = 1,
                            SoftDelete = false,
                            TimeStamps = DateTime.UtcNow
                        }
                );

            modelBuilder.Entity<News>()
                .HasData(
                    new News
                    {
                        Id = 1, Name = "Clases de Refuerzo Escolar", 
                        Content = "Gracias a la colaboracion de Docentes vecinos del barrio es que " +
                        "logramos lanzar un proyecto para brindar apoyo escolar a los chicos " +
                        "del barrio y barrios aledaños que lo necesiten.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 2, TimeStamps = DateTime.Now, SoftDelete = false

                    },
                    new News
                    {
                        Id = 2,
                        Name = "Futbol y Danza Juvenil",
                        Content = "Con la Ayuda del Club 25 de Mayo, lanzamos las clases de Futbol " +
                        "y Danza para los jovenes del barrio, las mismas se impartiran " +
                        "los dias sabados por la mañana o la tarde dependiendo de la edad del chico.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 4,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false

                    },
                    new News
                    {
                        Id = 3,
                        Name = "Subsidio Nacional",
                        Content = "Ahora contamos con un nuevo aporte " +
                        "economico que nos permitira brinadar 2 raciones alimentarias diarias a 200 " +
                        "personas, pudiendo alcanzar tambien a barrios aledños.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 3,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false

                    },
                    new News
                    {
                        Id = 4,
                        Name = "Donación Supermercado El Juanito",
                        Content = "El Señor Pascual Perez, dueño del Juanito comenzo a donarnos a partir de hoy 50 Kgs " +
                        "de pan por dia, podemos reforzar nuestras" +
                        " raciones que hoy alimentan a 342 familias del barrio de La Cava y barrios aledaños.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 4,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false

                    },
                    new News
                    {
                        Id = 5,
                        Name = "Donación Supermercado El Juanito",
                        Content = "El Señor Pascual Perez, dueño del Juanito comenzo a donarnos a partir de hoy 50 Kgs " +
                        "de pan por dia, podemos reforzar nuestras" +
                        " raciones que hoy alimentan a 342 familias del barrio de La Cava y barrios aledaños.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 4,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false

                    },
                    new News
                    {
                        Id = 6,
                        Name = "Donación Supermercado El Juanito",
                        Content = "El Señor Pascual Perez, dueño del Juanito comenzo a donarnos a partir de hoy 50 Kgs " +
                        "de pan por dia, podemos reforzar nuestras" +
                        " raciones que hoy alimentan a 342 familias del barrio de La Cava y barrios aledaños.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 4,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false

                    },
                    new News
                    {
                        Id = 7,
                        Name = "Donación Supermercado El Juanito",
                        Content = "El Señor Pascual Perez, dueño del Juanito comenzo a donarnos a partir de hoy 50 Kgs " +
                        "de pan por dia, podemos reforzar nuestras" +
                        " raciones que hoy alimentan a 342 familias del barrio de La Cava y barrios aledaños.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 4,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false

                    },
                    new News
                    {
                        Id = 8,
                        Name = "Donación Supermercado El Juanito",
                        Content = "El Señor Pascual Perez, dueño del Juanito comenzo a donarnos a partir de hoy 50 Kgs " +
                        "de pan por dia, podemos reforzar nuestras" +
                        " raciones que hoy alimentan a 342 familias del barrio de La Cava y barrios aledaños.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 4,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false

                    },
                    new News
                    {
                        Id = 9,
                        Name = "Donación Supermercado El Juanito",
                        Content = "El Señor Pascual Perez, dueño del Juanito comenzo a donarnos a partir de hoy 50 Kgs " +
                        "de pan por dia, podemos reforzar nuestras" +
                        " raciones que hoy alimentan a 342 familias del barrio de La Cava y barrios aledaños.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 4,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false

                    },
                    new News
                    {
                        Id = 10,
                        Name = "Donación Supermercado El Juanito",
                        Content = "El Señor Pascual Perez, dueño del Juanito comenzo a donarnos a partir de hoy 50 Kgs " +
                        "de pan por dia, podemos reforzar nuestras" +
                        " raciones que hoy alimentan a 342 familias del barrio de La Cava y barrios aledaños.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 4,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false

                    },
                    new News
                    {
                        Id = 11,
                        Name = "Donación Supermercado El Juanito",
                        Content = "El Señor Pascual Perez, dueño del Juanito comenzo a donarnos a partir de hoy 50 Kgs " +
                        "de pan por dia, podemos reforzar nuestras" +
                        " raciones que hoy alimentan a 342 familias del barrio de La Cava y barrios aledaños.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 4,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false

                    },
                    new News
                    {
                        Id = 12,
                        Name = "Donación Supermercado El Juanito",
                        Content = "El Señor Pascual Perez, dueño del Juanito comenzo a donarnos a partir de hoy 50 Kgs " +
                        "de pan por dia, podemos reforzar nuestras" +
                        " raciones que hoy alimentan a 342 familias del barrio de La Cava y barrios aledaños.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 4,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false

                    },
                    new News
                    {
                        Id = 13,
                        Name = "Donación Supermercado El Juanito",
                        Content = "El Señor Pascual Perez, dueño del Juanito comenzo a donarnos a partir de hoy 50 Kgs " +
                        "de pan por dia, podemos reforzar nuestras" +
                        " raciones que hoy alimentan a 342 familias del barrio de La Cava y barrios aledaños.",
                        Image = "Agregar ruta de la imagen",
                        CategoryId = 4,
                        TimeStamps = DateTime.Now,
                        SoftDelete = false

                    }

                );

            //Add Seed Data Comment
            modelBuilder.Entity<Comment>()
                .HasData(
                    new Comment
                    {
                        Id=1, User_Id = 7, 
                        Body = "Con esto se siguen expandiendo nuestros diferentes refuerzos educativos para niños, niñas " +
                        "y jóvenes", News_Id = 1, TimeStamps = DateTime.Now, SoftDelete = false
                    },
                    new Comment
                    {
                        Id=2, User_Id = 1, 
                        Body = "Estos talleres ayudan a que los participantes también puedan divertirse y practica " +
                        "deportes, socializando con sus pares", News_Id = 2, TimeStamps = DateTime.Now, SoftDelete = false
                    },
                    new Comment
                    {
                        Id=3, User_Id = 4, 
                        Body = "Esta ayuda del gobierno llega en un buen momento y es perfecto para apoyar a las familias " +
                        "y llevar alimento a las diferentes personas que lo necesiten ", 
                        News_Id = 3, TimeStamps = DateTime.Now, SoftDelete = false 
                    },
                    new Comment
                    {
                        Id=4, User_Id = 5, 
                        Body = "Me parece bien que mas actores se esten sumando a esta iniciativa apoyandola con " +
                        "diferentes aportes", News_Id = 4, TimeStamps = DateTime.Now, SoftDelete = false
                    }
                );

            //Add Seed Data Contact
            modelBuilder.Entity<Contact>()
                .HasData(
                    new Contact
                    {
                        Id = 1, Name = "Juan Perez", Phone = 984576543, Email = "juan.perez@correo.com",
                        Message = "Este es un mensaje", TimeStamps = DateTime.Now, SoftDelete = false
                    },
                    new Contact
                    {
                        Id = 2, Name = "Maria Gomez", Phone = 115433764, Email = "maria.gomez@correo.com",
                        Message = "Este es otro mensaje", TimeStamps = DateTime.Now, SoftDelete = false
                    }
                );

        }

    }
}
