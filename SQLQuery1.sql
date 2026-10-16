-- Script para crear GastosDB (Clase 10 / Tarea Repositorio de Gastos)
-- Ejecutar en SQL Server Object Explorer o en una consulta nueva de LocalDB

-- 1. Crear la base de datos (si no existe)
IF DB_ID('GastosDB') IS NULL
BEGIN
    CREATE DATABASE GastosDB;
END
GO

USE GastosDB;
GO

-- 2. Crear la tabla (si no existe)
IF OBJECT_ID('dbo.Gastos', 'U') IS NULL
BEGIN
    CREATE TABLE Gastos (
        Id          INT IDENTITY(1,1) PRIMARY KEY,
        Descripcion NVARCHAR(100) NOT NULL,
        Monto       DECIMAL(10,2) NOT NULL,
        Categoria   NVARCHAR(50)  NOT NULL
    );
END
GO

-- 3. Limpiar e insertar los 3 gastos iniciales (total exacto: Q 370.50)
DELETE FROM Gastos;
GO

INSERT INTO Gastos (Descripcion, Monto, Categoria) VALUES
    (N'Almuerzo ejecutivo', 120.00, N'Comida'),
    (N'Gasolina',           200.00, N'Transporte'),
    (N'Internet residencial', 50.50, N'Servicios');
GO

-- Verificación
SELECT * FROM Gastos;
SELECT SUM(Monto) AS TotalEsperado FROM Gastos;  -- debe ser 370.50
GO