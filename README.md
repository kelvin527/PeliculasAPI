# 🎬 PeliculasAPI

API REST para la gestión de películas, construida con **ASP.NET Core 8** y **Entity Framework Core**. Permite administrar géneros y actores como base para un sistema de catálogo de películas.

---

## 🚀 Tecnologías

- [.NET 8](https://dotnet.microsoft.com/)
- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core 8](https://learn.microsoft.com/en-us/ef/core/) con SQL Server
- [AutoMapper 12](https://automapper.org/)

---

## 🧠 Decisiones técnicas

**DTOs con AutoMapper**  
Se separaron las entidades de base de datos de los modelos expuestos en la API usando DTOs (`GenerosDTO`, `ActorDTO`, etc.). AutoMapper gestiona la conversión automáticamente, evitando exponer la estructura interna de la base de datos y facilitando la evolución independiente de ambas capas.

**Patrón `CreatedAtRouteResult`**  
Los endpoints `POST` devuelven `201 Created` con la URL del recurso recién creado en el header `Location`, siguiendo las convenciones REST correctamente.

**Migraciones con EF Core**  
El esquema de la base de datos se gestiona íntegramente con migraciones de EF Core, lo que permite reproducir el entorno en cualquier máquina con un solo comando.

**`EntityState.Modified` en PUT**  
En lugar de hacer un `SELECT` para actualizar, se mapea el DTO directamente a la entidad y se marca su estado como `Modified`, reduciendo una consulta innecesaria a la base de datos.

---

## 📁 Estructura del proyecto

```
PeliculasAPI/
├── Controllers/
│   ├── GenerosController.cs   # CRUD completo de géneros
│   └── ActoresController.cs   # GET y POST de actores
├── Entidades/
│   ├── Genero.cs              # Entidad de base de datos
│   ├── Actor.cs               # Entidad de base de datos
│   └── ContextDb.cs           # DbContext de EF Core
├── DTOS/
│   ├── GenerosDTO.cs          # DTO de lectura
│   ├── GeneroCreacionDTO.cs   # DTO de escritura
│   ├── ActorDTO.cs            # DTO de lectura
│   └── ActorCreacionDTO.cs    # DTO de escritura (incluye foto)
├── Helperd/
│   └── AutoMapperProfile.cs   # Configuración de mapeos
├── Migrations/                # Migraciones de EF Core
├── Program.cs                 # Configuración de servicios y pipeline
├── appsettings.json
└── appsettings.Development.json
```

---

## ⚙️ Instalación y uso

### Requisitos previos
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local o remoto)

### Pasos

```bash
# 1. Clonar el repositorio
git clone https://github.com/tu-usuario/PeliculasAPI.git
cd PeliculasAPI
```

Configura la cadena de conexión en `appsettings.Development.json`:
```json
"ConnectionStrings": {
  "connection": "Server=TU_SERVIDOR; Database=PeliculasAPI; Trusted_Connection=true; TrustServerCertificate=true;"
}
```

```bash
# 2. Aplicar las migraciones
dotnet ef database update

# 3. Ejecutar el proyecto
dotnet run
```

La API estará disponible en `https://localhost:7034`.

---

## 📡 Endpoints

### Géneros `/api/generos`

| Método | Ruta | Descripción |
|---|---|---|
| `GET` | `/api/generos` | Obtiene todos los géneros |
| `GET` | `/api/generos/{id}` | Obtiene un género por ID |
| `POST` | `/api/generos` | Crea un nuevo género |
| `PUT` | `/api/generos/{id}` | Actualiza un género existente |
| `DELETE` | `/api/generos/{id}` | Elimina un género |

### Actores `/api/actores`

| Método | Ruta | Descripción |
|---|---|---|
| `GET` | `/api/actores` | Obtiene todos los actores |
| `GET` | `/api/actores/{id}` | Obtiene un actor por ID |
| `POST` | `/api/actores` | Crea un nuevo actor |

### Ejemplos de body

**POST** `/api/generos`
```json
{
  "nombre": "Acción"
}
```

**POST** `/api/actores`
```json
{
  "nombre": "Keanu Reeves",
  "fechaNacimiento": "1964-09-02T00:00:00"
}
```

---

## 📝 Notas

- La connection string en `appsettings.Development.json` apunta a un servidor local — recuerda actualizarla antes de ejecutar el proyecto.
- El campo `Foto` en `ActorCreacionDTO` recibe un `IFormFile`, por lo que el endpoint de creación de actores espera `multipart/form-data`.
- Este proyecto está en desarrollo activo — próximamente se agregarán películas, relaciones entre entidades y autenticación.
