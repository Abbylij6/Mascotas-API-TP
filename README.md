# 🐾 API de Mascotas

Trabajo práctico de **Programación II** desarrollado con **C# y ASP.NET Core 8**.

La aplicación expone una API REST sencilla para administrar mascotas y aplica conceptos de Programación Orientada a Objetos como **abstracción, herencia y polimorfismo**.

---

## 📌 Funcionalidades

- Listar todas las mascotas.
- Buscar una mascota por su identificador.
- Registrar perros.
- Registrar gatos.
- Actualizar los datos de una mascota.
- Eliminar una mascota.
- Filtrar mascotas por edad.
- Filtrar mascotas por tipo.
- Explorar y probar la API mediante Swagger.

Los datos se almacenan en una **lista en memoria**. Por este motivo, los cambios realizados se pierden cuando se detiene o reinicia la aplicación.

---

## 🛠️ Tecnologías utilizadas

- **C#**
- **.NET 8**
- **ASP.NET Core Web API**
- **Swagger / OpenAPI**
- **Swashbuckle**
- **Git**
- **GitHub**

---

## 🧩 Modelo de dominio

La clase abstracta `Mascota` contiene las propiedades comunes de todas las mascotas:

- `Id`
- `Nombre`
- `Edad`
- `Tipo`

De ella heredan las siguientes clases:

- `Perro`, que agrega la propiedad `Raza`.
- `Gato`, que agrega la propiedad `Color`.

### Diagrama de herencia

```text
              Mascota
             (abstracta)
              /      \
             /        \
          Perro      Gato
            |          |
          Raza       Color
```

La clase `Mascota` es abstracta, por lo que no se pueden crear objetos directamente a partir de ella. En su lugar, se crean objetos de tipo `Perro` o `Gato`.

---

## 📋 Datos iniciales

La aplicación comienza con cuatro mascotas cargadas en memoria:

| ID | Nombre | Tipo | Edad | Dato particular |
|---:|--------|------|-----:|-----------------|
| 1 | Firulais | Perro | 5 | Labrador |
| 2 | Luna | Gato | 3 | Negro |
| 3 | Rocky | Perro | 8 | Caniche |
| 4 | Michi | Gato | 10 | Naranja |

---

## 📦 Requisitos

Para ejecutar el proyecto se necesita:

- **.NET SDK 8.0** o superior compatible.
- Visual Studio, Visual Studio Code o JetBrains Rider.
- Git, en caso de clonar el repositorio.

---

## ▶️ Ejecución

Desde la carpeta raíz del repositorio, ejecutar:

```bash
dotnet restore
```

Luego:

```bash
dotnet run
```

La terminal mostrará las direcciones en las que se encuentra disponible la aplicación.

### Swagger

Swagger permite explorar y probar todos los endpoints de la API.

Ejemplo:

```text
https://localhost:xxxx/swagger
```

> El puerto puede variar según la configuración local del proyecto.

---

## 🌐 Endpoints

| Método | Ruta | Descripción |
|--------|------|-------------|
| `GET` | `/Mascota` | Obtiene todas las mascotas. |
| `GET` | `/Mascota/{id}` | Obtiene una mascota por su ID. |
| `POST` | `/Mascota/perro` | Registra un nuevo perro. |
| `POST` | `/Mascota/gato` | Registra un nuevo gato. |
| `PUT` | `/Mascota/{id}` | Modifica una mascota existente. |
| `DELETE` | `/Mascota/{id}` | Elimina una mascota. |
| `GET` | `/Mascota/mayores-a/{edad}` | Lista las mascotas cuya edad es mayor a la indicada. |
| `GET` | `/Mascota/tipo/{tipo}` | Filtra las mascotas por tipo: `perro` o `gato`. |

---

## 🧪 Ejemplos de solicitudes

### 🐶 Crear un perro

**Endpoint:**

```http
POST /Mascota/perro
```

**Content-Type:**

```text
application/json
```

**Body:**

```json
{
  "nombre": "Toby",
  "edad": 4,
  "raza": "Labrador"
}
```

La API asignará automáticamente un nuevo ID al perro.

---

### 🐱 Crear un gato

**Endpoint:**

```http
POST /Mascota/gato
```

**Content-Type:**

```text
application/json
```

**Body:**

```json
{
  "nombre": "Nina",
  "edad": 2,
  "color": "Gris"
}
```

La API asignará automáticamente un nuevo ID al gato.

---

### 🔎 Buscar una mascota por ID

**Endpoint:**

```http
GET /Mascota/3
```

Este ejemplo devuelve la mascota con ID `3`, correspondiente a **Rocky**.

Si el ID no existe, la API devuelve:

```text
404 Not Found
```

---

### ✏️ Modificar una mascota

**Endpoint:**

```http
PUT /Mascota/1
```

**Content-Type:**

```text
application/json
```

**Body:**

```json
{
  "nombre": "Firulais Modificado",
  "edad": 6,
  "datoParticular": "Bulldog"
}
```

En caso de tratarse de un perro, `datoParticular` corresponde a su raza.

En caso de tratarse de un gato, `datoParticular` corresponde a su color.

---

### 🗑️ Eliminar una mascota

**Endpoint:**

```http
DELETE /Mascota/1
```

Si la mascota existe, será eliminada de la lista en memoria.

La API devuelve:

```text
204 No Content
```

---

## 👴 Mascotas mayores a una edad

**Endpoint:**

```http
GET /Mascota/mayores-a/{edad}
```

Por ejemplo:

```http
GET /Mascota/mayores-a/5
```

Devuelve todas las mascotas cuya edad sea **mayor** al valor indicado.

Con los datos iniciales, el resultado incluye:

- Rocky — 8 años
- Michi — 10 años

Firulais no se incluye porque tiene exactamente 5 años.

---

## 🐶🐱 Mascotas por tipo

**Endpoint:**

```http
GET /Mascota/tipo/{tipo}
```

### Obtener perros

```http
GET /Mascota/tipo/perro
```

Devuelve solamente las mascotas que pertenecen a la clase `Perro`.

### Obtener gatos

```http
GET /Mascota/tipo/gato
```

Devuelve solamente las mascotas que pertenecen a la clase `Gato`.

Si se ingresa un tipo diferente de `perro` o `gato`, la API devuelve:

```text
400 Bad Request
```

---

## 📊 Códigos de respuesta HTTP

La API utiliza diferentes códigos de estado según el resultado de cada operación:

| Código | Descripción |
|--------|-------------|
| `200 OK` | La operación se realizó correctamente. |
| `201 Created` | El recurso fue creado correctamente. |
| `204 No Content` | El recurso fue eliminado correctamente. |
| `400 Bad Request` | La solicitud contiene datos incorrectos. |
| `404 Not Found` | No se encontró la mascota solicitada. |

---

## 🧪 Pruebas

Los endpoints fueron probados utilizando **Swagger**, verificando las operaciones solicitadas en el trabajo práctico:

- [x] Obtener la lista completa de mascotas.
- [x] Buscar una mascota existente.
- [x] Buscar una mascota inexistente.
- [x] Registrar un nuevo perro.
- [x] Registrar un nuevo gato.
- [x] Modificar una mascota.
- [x] Eliminar una mascota.
- [x] Consultar mascotas mayores a una edad determinada.
- [x] Consultar mascotas según su tipo.

---

## 🗂️ Estructura del proyecto

```text
MascotasAPI/
│
├── Controllers/
│   └── MascotaController.cs
│
├── Models/
│   ├── Mascota.cs
│   ├── Perro.cs
│   └── Gato.cs
│
├── DTOs/
│   └── MascotaActualizarDto.cs
│
├── Properties/
│   └── launchSettings.json
│
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── MascotasAPI.csproj
├── .gitignore
└── README.md
```

---

## 🧠 Conceptos de Programación Orientada a Objetos

### Abstracción

La clase `Mascota` se define como una clase abstracta, ya que representa las características comunes de los diferentes tipos de mascotas.

```csharp
public abstract class Mascota
```

### Herencia

Las clases `Perro` y `Gato` heredan de la clase `Mascota`.

```csharp
public class Perro : Mascota
```

```csharp
public class Gato : Mascota
```

Cada clase agrega sus propias propiedades particulares:

- `Perro` → `Raza`
- `Gato` → `Color`

### Polimorfismo

La aplicación utiliza una lista de tipo `Mascota` que permite almacenar objetos de diferentes clases derivadas:

```csharp
List<Mascota> mascotas
```

De esta manera, la misma lista puede contener objetos `Perro` y `Gato`.

---

## 💾 Almacenamiento

El proyecto **no utiliza una base de datos**.

Todas las mascotas se almacenan temporalmente en una lista en memoria:

```csharp
private static List<Mascota> mascotas
```

Esto significa que los datos agregados, modificados o eliminados durante la ejecución se pierden cuando la aplicación se detiene.

---

## 👩‍💻 Autor

**Abby Lijtenstein**

Trabajo práctico realizado para la materia **Programación II**.

**Tecnología:** C# / ASP.NET Core Web API
