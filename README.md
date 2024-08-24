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
    - [TorneoRequest](#torneorequest)
    - [Jugar un torneo](#jugar-un-torneo)
      - [Obtener solamente el ganador](#obtener-solamente-el-ganador)
  - [Próximos pasos](#próximos-pasos)
  - [Licencia](#licencia)

Requisitos Previos
------------------

*   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
*   [Docker](https://www.docker.com/get-started) junto a [Docker Compose](https://docs.docker.com/compose/)
*   [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
*   [Azure Data Studio](https://azure.microsoft.com/es-es/products/data-studio/) (opcional, para conectarse a la base de datos)

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

Puedes conectarte al servidor de SQL Server que se ejecuta dentro del contenedor Docker usando Azure Data Studio:

*   **Servidor:** `localhost,1433`
*   **Base de Datos:** `TorneoDeTenis`
*   **Usuario:** `sa`
*   **Contraseña:** `YourStrong!Passw0rd` (ejemplo)

Uso
---

### TorneoRequest

A fin de indicarle los jugadores del torneo a la API, debe enviar un objeto JSON como el del siguiente ejemplo:

    {
      "tipoTorneo": 1, (0: torneo masculino, 1: torneo femenino)
      "jugadores": [
        {
          "nombre": "Jugador 1",
          "habilidad": 85,
          "fuerza": 90,
          "velocidad": 75,
          "tiempoReaccion": 80
        },
        {
          "nombre": "Jugador 2",
          "habilidad": 78,
          "fuerza": 88,
          "velocidad": 85,
          "tiempoReaccion": 82
        },
        {
          "nombre": "Jugador 3",
          "habilidad": 95,
          "fuerza": 80,
          "velocidad": 90,
          "tiempoReaccion": 85
        },
        {
          "nombre": "Jugador 4",
          "habilidad": 80,
          "fuerza": 85,
          "velocidad": 88,
          "tiempoReaccion": 79
        }
      ]
    }

El número de de jugadores debe ser una potencia de 2, de otra forma recibirá una excepción y un HTTP 400 (Bad Request).

### Jugar un torneo

Para obtener un nuevo torneo, junto a su ganador, envía un objeto JSON `TorneoRequest` a:

    POST http://localhost:5292/api/Torneo/ObtenerTorneo


#### Obtener solamente el ganador

Para jugar un nuevo torneo obteniendo solamente su ganador, envía la misma solicitud a:

    POST http://localhost:5292/api/Torneo/ObtenerGanador

Próximos pasos
--------
- Recurso de API para obtener partidos o torneos por fecha.
- Recurso de API para obtener torneos por tipo.
- Configuración de coverlet para excluir de las cobertura de pruebas algunas clases y directorios, como Migrations y Exceptions.

Licencia
--------

Este proyecto está licenciado bajo la Licencia Pública General GNU v3 (GPLv3). Consulta el archivo [LICENSE](LICENSE)