Hola buenos dias señor Gustavo.
Adjunto Repositorio donde se encuentra alojado el proyecto:
	
Adjunto link del proyecto desplegado en azure:
	https://testidlsg.azurewebsites.net/


El proyecto fue desarrollado en ASP.NET Core MVC(.NET 5), como entorno de desarrollo se usó visual studio community 2019.
A nivel de persistencia se utilizó sql-server y el ORM de .net, EntityFramework Core.
La documentación se encuentra en formato xml y tambien en el código del proyecto.
Librerias descargadas:
	Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
	Microsoft.EntityFrameworkCore.SqlServer
	Microsoft.EntityFrameworkCore.Tools
	Microsoft.VisualStudio.Web.CodeGeneration.Desing

Además de las 2 tablas(departamento y ciudad), decidi agregar otra entidad Pais, ya que en la tabla departamento se encontraba el dato CodigoPais, al final decidi complementarlo agregando esa entidad.
No se puede   cambiar referencia de pais a un departamento, o referencia de departamento a una ciudad
la identificacion de todas las entidades se genera automaticamente(identity 1,1). 

Muchas gracias.




