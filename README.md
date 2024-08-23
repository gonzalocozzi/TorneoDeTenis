TorneoDeTenis WebAPI
====================

Este proyecto es una aplicación WebAPI en .NET para gestionar un sistema de torneos de tenis. Incluye pruebas unitarias con xUnit y está contenedorizado utilizando Docker. La API permite la crear torneos, obteniendo el resultado de los partidos y el ganador del torneo.

Tabla de Contenidos
-------------------

- [TorneoDeTenis WebAPI](#torneodetenis-webapi)
  - [Tabla de Contenidos](#tabla-de-contenidos)
  - [Requisitos Previos](#requisitos-previos)
  - [Configuración](#configuración)
    - [Clonar el Repositorio](#clonar-el-repositorio)
    - [Variables de Entorno](#variables-de-entorno)
  - [Ejecutar la Aplicación con Docker Compose](#ejecutar-la-aplicación-con-docker-compose)
  - [Ejecutar Pruebas](#ejecutar-pruebas)
  - [Conectarse a la Base de Datos](#conectarse-a-la-base-de-datos)
  - [Uso](#uso)
    - [Jugar un torneo](#jugar-un-torneo)
      - [Obtener solamente el ganador](#obtener-solamente-el-ganador)
  - [Licencia](#licencia)

Requisitos Previos
------------------

*   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
*   [Docker](https://www.docker.com/get-started)
*   [Azure Data Studio](https://azure.microsoft.com/en-us/services/data-studio/) (opcional, para conectarse a la base de datos)

Configuración
-------------

### Clonar el Repositorio

Clona el repositorio en tu máquina local:

    git clone https://github.com/gonzalocozzi/TorneoDeTenis.git
    cd TorneoDeTenis


### Variables de Entorno

Configura las variables de entorno en tu archivo Docker Compose para configurar la conexión a la base de datos:

    services:
      torneo-de-tenis-webapi:
        environment:
          - ASPNETCORE_ENVIRONMENT=Development


Adicionalmente, debe incluir en el archivo `appsettings.Development.json` el ConnectionString de la base de datos:

      "ConnectionStrings": {
        "DefaultConnection": "Server=torneo-de-tenis-db,1433;Database=TorneoDeTenis;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=true;"
      }

Ejecutar la Aplicación con Docker Compose
-----------------------------------------

Para ejecutar la aplicación localmente, asegúrate de que Docker esté en funcionamiento y ejecuta:

    docker-compose -f docker-compose.debug.yml up


Navega a `http://localhost:5292/swagger` para explorar los endpoints de la API a través de Swagger UI.

Ejecutar Pruebas
----------------

El proyecto incluye pruebas unitarias escritas en xUnit. Para ejecutar las pruebas, ejecuta el siguiente comando:

    dotnet test


Si ejecutas las pruebas en un contenedor Docker, asegúrate de que el contenedor de la webapi y de la base de datos estén en funcionamiento:

    docker-compose -f docker-compose.debug.yml up


Conectarse a la Base de Datos
-----------------------------

Puedes conectarte al servidor SQL que se ejecuta dentro del contenedor Docker usando Azure Data Studio:

*   **Servidor:** `localhost,1433`
*   **Base de Datos:** `TorneoDeTenis`
*   **Usuario:** `sa`
*   **Contraseña:** `YourStrong!Passw0rd`

Uso
---

### Jugar un torneo

Para obtener un nuevo torneo, junto a su ganador, envía un objeto JSON `TorneoRequest` a:

    POST http://localhost:5292/api/Torneo/ObtenerTorneo


#### Obtener solamente el ganador

Para jugar un nuevo torneo obteniendo solamente su ganador, envía la misma solicitud a:

    POST http://localhost:5292/api/Torneo/ObtenerGanador


Licencia
--------

Este proyecto está licenciado bajo la Licencia Pública General GNU v3 (GPLv3). Consulta el archivo [LICENSE](LICENSE)