## Test

### El objetivo es crear un host de aplicación por defecto, para ser reutilizado de una forma fácil y rápida.

* Se puede ejecutar 3 tipos de host: 

![Execute Host](img/execute_host.png)


* Iniciar la api con el perfil "Tests.Api.Host.Simple":

_Host simple utilizado mayormente para pruebas_

![Host Simple](img/host_simple_result.png)


* Iniciar la api con el perfil "Tests.Api.Host.Error":

_Host con logeo de errores, si ocurre un error en el inicio del host lo muestra en consola y lo guarda en un registro "Logs/start_host/{Date}.log", si ocurre un error en la ejecucción de la app lo muestra en consola y/o en archivo y/o en una base de datos según la configuración de la librería "Kitpymes.Core.Logger", este host es el mas utilizado para producción_

![Host Error](img/host_error_result.png)


* Iniciar la api con el perfil "Tests.Api.Host.Custom":

_Host Custom para ser configurado según necesidades_

![Host Custom](img/host_custom_result.png)
