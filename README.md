<div align="center">

# Data Shelf Master
</div>

### Descripción
Este proyecto es una aplicación desarrollada en `C#` con una interfaz gráfica (GUI) que ofrece diversas funcionalidades relacionadas con la gestión de datos. El proyecto está orientado a servir como una herramienta educativa o de gestión, aplicando conceptos avanzados de desarrollo de software en un entorno práctico.

## Objetivo
El objetivo de este proyecto es crear una aplicación funcional que integre varios elementos del desarrollo de software moderno, incluyendo el uso de interfaces gráficas, manejo de datos y la implementación de lógica de negocio en `C#`. Este proyecto busca mejorar las habilidades de los desarrolladores en la creación de aplicaciones robustas y bien estructuradas.

## Características
- Interfaz de usuario desarrollada en `WPF` para una experiencia interactiva.
- Gestión de datos con opciones de visualización y manipulación.
- Integración de recursos visuales como iconos y gráficos.
- Código modular para facilitar el mantenimiento y la expansión de funcionalidades.

## Requisitos
- **.NET SDK** compatible con la versión especificada en el archivo del proyecto (`.csproj`).
- **Visual Studio** o cualquier otro **IDE** compatible con **WPF** y **C#**.
- **Git** para la clonación del repositorio y gestión del código.
> [!Important]
> Es importante asegurarse de que todos los requisitos estén instalados y configurados correctamente antes de ejecutar este proyecto para evitar problemas y asegurar un funcionamiento óptimo.

## Guía de Instalación
1. Clona este repositorio en tu máquina local utilizando Git:
   
   ```bash
   git clone https://github.com/Miguel-Antonio-Martinez-Jimenez/Data_Shelf_Master.git
3. Abre el archivo de solución o proyecto en Visual Studio (`DataShelfMaster.csproj`).
4. Asegúrate de tener todos los paquetes NuGet restaurados si no se hace automáticamente.
5. Compila y ejecuta la aplicación desde el entorno de desarrollo.

## Conexión con la Base de Datos
Este proyecto utiliza MySQL como sistema de gestión de bases de datos para manejar y almacenar la información.

### Configuración de la Conexión
- La configuración de la conexión a la base de datos se encuentra en el archivo `Context/ApplicationDBContext.cs`. A continuación, se muestra un ejemplo del código de configuración:

  ```bash
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       string connection = "Server=localhost; Database=datashelfmaster; User=root; Password=tu_contraseña;";
       optionsBuilder.UseMySQL(connection);
   }
### Personalización de la Conexión
Para que la conexión funcione correctamente, es esencial que ajustes los parámetros de conexión según tu entorno local:
- **Servidor (Server)**: `localhost` o `dominio`.
- **Nombre de la Base de Datos (Database)**: Cambia `datashelfmaster` al nombre de tu base de datos personalizada.
- **Usuario (User)**: Ajusta el usuario (`root` por defecto) a tu configuración de acceso.
- **Contraseña (Password)**: Sustituye `tu_contraseña` con la contraseña correspondiente para tu base de datos.

> [!Important]
> **Solución de Problemas Comunes**:
> - **Errores de Conexión**: Asegúrate de que MySQL esté en ejecución y que los parámetros de conexión sean correctos.
> - **Permisos Denegados**: Verifica que el usuario configurado tenga los permisos necesarios para la base de datos especificada.
> - **Problemas de Red**: Revisa las configuraciones de red y firewall para asegurar que no bloqueen las conexiones a MySQL.

## Accesos o Credenciales
- **Usuario de prueba**: prueba@devdarksonic.com
- **Contraseña de prueba**: devdarksonic123

## Guía de Uso del Proyecto
1. Ejecuta la aplicación desde **Visual Studio** o tu entorno de desarrollo preferido.
2. Utiliza la interfaz gráfica para interactuar con las funcionalidades disponibles.
3. Sigue las instrucciones y mensajes en pantalla para operar correctamente las opciones del programa.

## Estructura del Proyecto
- `App.xaml` / `App.xaml.cs`: Archivos de configuración y lógica inicial de la aplicación.
- `AssemblyInfo.cs`: Información de ensamblado del proyecto.
- `MainWindow.xaml` / `MainWindow.xaml.cs`: Ventana principal de la aplicación con la interfaz gráfica y su correspondiente lógica.
- `Entities/`: Esta carpeta generalmente contiene las clases que representan las entidades del modelo de datos.
- `Icon/`: Recursos visuales utilizados dentro de la aplicación.
- `Migrations/`: Esta carpeta almacena los archivos de migraciones que son generados por Entity Framework o cualquier otro sistema de migración de bases de datos.
- `Services/`: La carpeta contiene las clases que implementan la lógica de negocio de la aplicación.
- `ViewWindows/`: Esta carpeta contiene las ventanas o vistas de la aplicación, generalmente en aplicaciones de escritorio o proyectos que utilizan interfaces gráficas (como WinForms o WPF en C#). 

  ```bash
   Data_Shelf_Master/
   ├── .gitattributes
   ├── .gitignore
   ├── App.xaml
   ├── App.xaml.cs
   ├── AssemblyInfo.cs
   ├── DataShelfMaster.csproj
   ├── Logo.png
   ├── MainWindow.xaml
   ├── MainWindow.xaml.cs
   ├── Padlock.png
   ├── User.png
   ├── Context/
   │   └── ApplicationDBContext.cs
   ├── Entities/
   │   ├── Book.cs
   │   ├── Personnel.cs
   │   ├── Role.cs
   │   ├── Solicitude.cs
   │   ├── Student.cs
   │   └── ValidateRole.cs
   ├── Icon/
   │   ├── Delete.png
   │   ├── Edit.png
   │   ├── Headuser.png
   │   ├── Icon-Logo.png
   │   ├── Logo.png
   │   ├── Padlock.png
   │   ├── Search.png
   │   ├── User.png
   │   └── UserLogo.png
   ├── Migrations/
   │   ├── 20230726194836_Tables.Designer.cs
   │   ├── 20230726194836_Tables.cs
   │   └── ApplicationDBContextModelSnapshot.cs
   ├── Services/
   │   ├── BookService.cs
   │   ├── PersonnelService.cs
   │   └── StudentService.cs
   ├──ViewWindows/
   │   ├── AddBooks.xaml
   │   ├── AddBooks.xaml.cs
   │   ├── AddSolicitudes.xaml
   │   ├── AddSolicitudes.xaml.cs
   │   ├── AddStudent.xaml
   │   ├── AddStudent.xaml.cs
   │   ├── AddUsers.xaml
   │   ├── AddUsers.xaml.cs
   │   ├── CreateAccount.xaml
   │   ├── CreateAccount.xaml.cs
   │   ├── DataShelfMasterSistem.xaml
   │   ├── DataShelfMasterSistem.xaml.cs
   │   ├── Delete.png
   │   ├── Edit.png
   │   ├── EditBooks.xaml
   │   ├── EditBooks.xaml.cs
   │   ├── EditSolicitudes.xaml
   │   ├── EditSolicitudes.xaml.cs
   │   ├── EditStudents.xaml
   │   ├── EditStudents.xaml.cs
   │   ├── EditUsers.xaml
   │   ├── EditUsers.xaml.cs
   │   ├── Headuser.png
   │   ├── Icon-Logo.png
   │   ├── Logo.png
   │   ├── Padlock.png
   │   ├── User.png
   │   └── UserLogo.png
   ├── LICENSE
   └── README.md
  
## Estado del Proyecto
**Estado Actual:** `Finalizado.`
> [!Note]
> Este proyecto se encuentra en estado **Finalizado**, lo que significa que todas las funcionalidades planeadas han sido implementadas y probadas satisfactoriamente. El código está disponible para su uso y estudio, y se aceptan contribuciones para mejoras o nuevas características.
<!--### Posibles Estados del Proyecto
- **Inicios:** El proyecto está en sus etapas iniciales de planificación y desarrollo. Apenas se están definiendo los requisitos y comenzando la implementación básica.
- **En Desarrollo:** El proyecto está en plena fase de desarrollo, con funcionalidades siendo añadidas y pruebas en curso. Puede contener errores o estar sujeto a cambios importantes.
- **Finalizado:** El proyecto ha alcanzado sus objetivos iniciales, con todas las funcionalidades implementadas y probadas. Puede recibir mantenimiento o mejoras menores.
- **Mantenimiento:** El proyecto está completo, pero sigue recibiendo actualizaciones menores, corrección de errores o mejoras en la documentación y el rendimiento.
- **Abandonado:** El desarrollo ha sido detenido y no se planean futuras actualizaciones ni mantenimiento. -->

## Contribuciónes
> [!Tip]
> Si deseas contribuir al proyecto, reportar errores o proponer mejoras, te invitamos a abrir un pull request o issue en el repositorio. También puedes contactarme directamente para compartir tus ideas o sugerencias a través de mi correo electrónico miguelantoniomartinezjimenez00@gmail.com. ¡Toda colaboración es bienvenida!

## Autores
[MiguelMartinez30 - @DevDarkSonic](https://github.com/Miguel-Antonio-Martinez-Jimenez)

## Licencia
Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo LICENSE para más detalles.
