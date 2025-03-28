# ✅ TodoTask - Gestor de Tareas en Consola 

TodoTask es una aplicación de consola desarrollada en **C#** que permite gestionar tareas de forma eficiente. Fue construida aplicando **principios SOLID** y una **arquitectura limpia (Clean Architecture)** para garantizar una estructura escalable, mantenible y fácilmente testeable.

## 🧠 ¿Qué es TodoTask?

Es una app tipo ToDo donde podés:

- 📌 Crear tareas nuevas
- 📋 Ver tareas pendientes, en progreso o finalizadas
- ✏️ Modificar estados de tareas
- 🧹 Almacenar tareas en archivos JSON para persistencia de datos

Todo esto desde una interfaz de consola intuitiva.

## ⚙️ ¿Cómo funciona?

1. Al ejecutar la app, se despliega un **menú interactivo**.
2. El usuario puede crear tareas nuevas o ver las existentes.
3. Cada tarea tiene un `Id`, `Título`, `Descripción`, `Fecha de creación`, y `Estado` (`Pending`, `InProgress`, `Done`).
4. Las tareas se guardan en un archivo JSON, lo que permite conservar los datos entre ejecuciones.
5. La lógica está separada por capas y responsabilidades específicas, aplicando principios de diseño profesionales.


## 🧠 Principios SOLID aplicados

1. Single Responsibility Principle (SRP):
Cada clase tiene una única razón para cambiar. Por ejemplo, TaskHandler solo gestiona acciones sobre tareas, y TaskReader solo se encarga de leer/escribir tareas.

2. Open/Closed Principle (OCP):
Las clases están abiertas a extensión pero cerradas a modificación. Podés agregar nuevos tipos de almacenamiento sin tocar el código existente (por ejemplo, guardar en DB o XML).

3. Liskov Substitution Principle (LSP):
Las interfaces ITaskService, ITaskReader permiten que nuevas implementaciones puedan ser intercambiadas sin romper el sistema.

4. Interface Segregation Principle (ISP):
Se crean interfaces específicas para funcionalidades concretas (por ejemplo, una interfaz que solo lee tareas, otra que las guarda).

5. Dependency Inversion Principle (DIP):
La lógica de negocio depende de abstracciones, no de implementaciones concretas. Esto se ve reflejado en cómo se inyectan las dependencias (ITaskReader, ITaskService).

---

## 🧱 ¿Por qué Clean Architecture?

Clean Architecture divide el sistema en capas con dependencias que van de afuera hacia adentro, protegiendo la lógica de negocio del resto de las preocupaciones (interfaz, infraestructura, etc.).

- ✅ Separación clara de responsabilidades
- 🔁 Fácil de testear e intercambiar dependencias
- 🧩 Escalable para migrar a API REST, GUI o microservicios en el futuro
- 🧪 Adaptable para aplicar pruebas unitarias o de integración

---

## 🚀 Próximas mejoras (ideas futuras)

- 🗂️ Implementar una base de datos (SQL Server o SQLite)
- 🌐 Crear una versión con ASP.NET Core MVC o Blazor
- 🔍 Buscar tareas por título o palabra clave


https://roadmap.sh/projects/task-tracker
- 🛠️ Agregar validaciones más complejas
- 📅 Notificaciones o recordatorios por fecha límite




