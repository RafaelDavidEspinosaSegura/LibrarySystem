LibrarySystem API
API RESTful para la gestión de una biblioteca. Permite administrar categorías, libros, autores, copias, usuarios, préstamos y reservas, cubriendo el ciclo completo de un sistema bibliotecario.

🚀 Tecnologías utilizadas
.NET 8 (ASP.NET Core Web API)

Entity Framework Core

PostgreSQL

Swagger / Swashbuckle

xUnit + Moq (pruebas unitarias)

🏗️ Arquitectura
El proyecto sigue el patrón Onion Architecture, con separación de capas:

Domain (LibrarySystem.Domain): Entidades del negocio.

Application (LibrarySystem.Application): Interfaces y lógica de aplicación.

Infrastructure (LibrarySystem.Infrastructure): Persistencia con EF Core, repositorios y migraciones.

Api (LibrarySystem.Api): Controladores REST, configuración de Swagger y DI.



📋 Requisitos previos
.NET 8 SDK (dotnet.microsoft.com in Bing)

PostgreSQL

DBeaver o pgAdmin (opcional, para administrar la base de datos)

⚙️ Configuración
Clonar el repositorio:

bash
git clone https://github.com/RafaelDavidEspinosaSegura/LibrarySystem.git
Crear una base de datos en PostgreSQL llamada librarysystemdb.

Editar el archivo LibrarySystem.Api/appsettings.json con tu cadena de conexión:

json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=librarysystemdb;Username=postgres;Password=********"
  }
}
▶️ Ejecución
Desde la raíz de la solución:

Restaurar paquetes:

bash
dotnet restore
Aplicar migraciones:

bash
dotnet ef database update -p LibrarySystem.Infrastructure -s LibrarySystem.Api
Ejecutar la API:

bash
dotnet run --project LibrarySystem.Api
Abrir Swagger en:

Código
http://localhost:5065/swagger


🔑 Endpoints principales
POST /api/Categories → Crear categoría

POST /api/Books → Crear libro

POST /api/Authors → Crear autor

POST /api/Copies → Crear copia

POST /api/Users → Crear usuario

POST /api/Loans → Crear préstamo

PUT /api/Loans/{id}/return → Devolver préstamo

POST /api/Reservations → Crear reserva

PUT /api/Reservations/{id}/cancel → Cancelar reserva



📊 Diagrama Entidad-Relación
El modelo de datos incluye las entidades:

Categories, Books, Authors, AuthorBook, Copies, Users, Loans, Reservations.



✅ Conclusiones
La API implementa el ciclo completo de gestión de biblioteca.

Se garantiza integridad referencial con llaves foráneas.

Swagger facilita pruebas y documentación automática.

La arquitectura modular asegura mantenibilidad y escalabilidad.

Futuras mejoras: autenticación JWT y roles avanzados.

Autor [Rafael Espinosa]