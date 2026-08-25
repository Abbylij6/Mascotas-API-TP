API Mascotas

Descripción:
Este proyecto consiste en el desarrollo de una API REST utilizando **C# y ASP.NET Core Web API**.

La aplicación permite gestionar mascotas mediante operaciones CRUD, utilizando conceptos de Programación Orientada a Objetos como:

- Herencia
- Polimorfismo
- Clases abstractas
- Encapsulamiento

La información se almacena en memoria mediante una lista, por lo tanto no se utiliza base de datos.

Estructura del proyecto

```text
ApiMascotas
│
├── Controllers
│   └── MascotaController.cs
│
├── Models
│   ├── Mascota.cs
│   ├── Perro.cs
│   └── Gato.cs
│
├── DTOs
│   └── MascotaActualizarDto.cs
│
├── Program.cs
└── README.md
