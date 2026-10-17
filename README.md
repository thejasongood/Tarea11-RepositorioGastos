# Repositorio de Gastos

Tarea de la Clase 11 - Curso de Algoritmos  
Universidad Mariano Gálvez - Centro Universitario de Chiquimulilla

VIDEO:
https://drive.google.com/file/d/1lNoEdfLibOMM7_cPKxKVAvbzKgfH2FUG/view?usp=drive_link

Autor: Jeison Hair Donis Martinez


## ¿Qué hace este programa?

Es un programa de consola para registrar y listar gastos.  
Usa una base de datos llamada `GastosDB` y el patrón Repositorio que vimos en clase.

Tiene dos funciones principales:
- Registrar un gasto nuevo
- Listar todos los gastos y mostrar el total

Todas las consultas a la base de datos van con parámetros para evitar problemas con comillas o inyección SQL.

## Cómo correrlo

1. Abre Visual Studio y ve al Explorador de objetos de SQL Server.
2. Conéctate a `(localdb)\ProjectModels`.
3. Ejecuta el script `CrearGastosDB.sql` para crear la base y los 3 gastos iniciales.
4. Abre el proyecto y presiona F5.

## Estructura

- `Gasto.cs` → la clase del gasto
- `GastoRepositorio.cs` → aquí está el Insertar y el ListarTodos
- `Program.cs` → el menú y las validaciones
- `CrearGastosDB.sql` → script para crear la base de datos

## Menú

1. Registrar gasto  
2. Listar gastos  
3. Salir

## Validaciones

- La descripción y la categoría no pueden ir vacías
- El monto tiene que ser un número mayor a 0
- Si algo está mal muestra un mensaje de error y no guarda nada

## Pruebas que hice

| Prueba | Resultado |
|--------|-----------|
| Listar al inicio | Salen los 3 gastos y el total Q 370.50 |
| Registrar Café de 12 | Se guarda y el total pasa a Q 382.50 |
| Poner monto inválido (abc o -5) | Muestra error y no guarda |
| Registrar "Tacos 'al pastor'" | Se guarda bien con la comilla y el total queda en Q 417.50 |

## Cadena de conexión

```csharp
Server=(localdb)\ProjectModels;Database=GastosDB;Trusted_Connection=True;TrustServerCertificate=True;




