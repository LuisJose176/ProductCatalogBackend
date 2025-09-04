1. Proyecto en .NET 8.0

Este es un proyecto desarrollado con **.NET 8.0**.

2. Requisitos previos

Asegúrate de tener instalados:

- [SDK de .NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022 (v17.8 o superior)](https://visualstudio.microsoft.com/) con la carga de trabajo **ASP.NET y desarrollo web**
- (Opcional) [Visual Studio Code](https://code.visualstudio.com/) con la extensión **C# Dev Kit**

3. Verifica que tienes .NET 8 instalado:

```bash
dotnet --version


4.Ejecutar las migraciones
update-database



5.Recompilar la solución
dotnet clean
dotnet build

6.Escoger el perfil de desarrollo
En Visual Studio, selecciona en la barra superior el perfil de ejecución:

IIS Express

<NombreDelProyecto>

Si prefieres la terminal, puedes correr con un perfil específico definido en launchSettings.json:
dotnet run --launch-profile "Development"


7.Compilar y ejecutar el proyecto
