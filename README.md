# MasterCrud
Proyecto de realizado con metodología _Api Full-rest_ junto con las tecnologías de desarrollo DotNetCore y Angular, en el cual consiste en realizar un crud para crear una ciudad y vendedores por cada ciudad creada.

## Comenzando 🚀
Para ejecutar el proyecto necesitará lo siguiente para inicializarlo.

### Pre-requisitos 📋

Se debe crear una base de datos e insertarlo en el archivo _appsettings.Development.json_ una vez dentro, reemplazar la cadena de conexión, dentro del _ConnectionStrings_

```
"DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MasterCrud;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
```

### Instalación 🔧

El proyecto ejecutará de manera automática las migraciones, pero si es necesario que realice un cambio para agregar de manera automática algunas ciudades que servirán como ejemplo para la ejecución del proyecto:

* Ingresa a la librería _Infrastructure_, luego a la carpeta _Data_ e ingrese al archivo _Seed.cs_ y reemplazar la siguiente línea string dentro del código:

```
var citiesData = await File.ReadAllTextAsync(
                            @"C:/[YourPC]/[USER]/[CarpetaDondeSeAloja]/MasterCrud/Infrastructure/Data/File/cities.json");
```

una vez reemplazado la cadena, podrá iniciar el proyecto.

## Construido con 🛠️

Este proyecto Web fue desarrollado con:

* [.Net Core](https://dotnet.microsoft.com/) - El principal framework utilizado para Back-end
* [Angular](https://angular.io/) - Framework para el lado del cliente
* [NPM](https://www.npmjs.com/) - Manejador de dependencias

## Contribuyendo 🖇️
Por favor el feedback para mí es importante, así que no dudes en comentar, con esto me harás ver los errores cometidos y a su vez, la manera para solucionarlo y hará en mí un mejor developer.

## Autores ✒️
* **Leonardo Fabián Hernández Peña** - Software Developer

también puedes revisar todos mis trabajos realizados [aquí](https://github.com/leo7962).

## Licencia 📄
Este proyecto está bajo la Licencia GPL-3.0.
