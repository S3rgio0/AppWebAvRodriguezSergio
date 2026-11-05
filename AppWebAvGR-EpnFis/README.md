# AppWebAvGR-EpnFis

Solución ASP.NET Web Forms sobre .NET Framework 4.8, organizada en Entity, DAL, BLL y Web.

## Compilar desde la terminal

En Windows se necesita el Developer Pack de .NET Framework 4.8 y MSBuild con los targets de Web Application. No hace falta abrir Visual Studio. Desde esta carpeta:

```powershell
msbuild .\SlnAppPoliMusic.sln /m /p:Configuration=Debug
```

Para ejecutar el sitio se necesita IIS Express o IIS. Con IIS Express en el `PATH`, desde esta carpeta:

```powershell
iisexpress /path:"$PWD\WebAppPoliMusicV3" /port:8080
```

Después abre `http://localhost:8080/`. La aplicación usa la conexión `BDD_PoliMusicConnectionString` definida en `WebAppPoliMusicV3\Web.config`; el servidor SQL debe tener disponible la base `BDD_PoliMusic` y las tablas `TBL_USER` y `TBL_SONG`.
