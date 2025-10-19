/* =========================
   Ejemplo 1
   Seleccionar todos los campos de Products
   ========================= */
SELECT * FROM Products

/* =========================
   Ejemplo 2
   Seleccionar columnas específicas
   ========================= */
SELECT ProductID, ProductName, UnitPrice
FROM Products

/* =========================
   Ejemplo 3
   WHERE con operador >
   ========================= */
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice > 15

/* =========================
   Ejemplo 4
   WHERE con >= y <=
   ========================= */
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice >= 15 AND UnitPrice <= 50

/* =========================
   Ejemplo 5
   BETWEEN (equivale a >= y <=)
   ========================= */
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice BETWEEN 15 AND 50

/* =========================
   Ejemplo 6
   NOT (niega la condición)
   ========================= */
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE NOT UnitPrice > 15

/* =========================
   Ejemplo 7
   OR (una u otra condición verdadera)
   ========================= */
SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE ProductID > 15 OR UnitPrice < 10

/* =========================
   Ejemplo 8
   LIKE - comienza con 'D'
   ========================= */
SELECT EmployeeID, LastName
FROM Employees
WHERE LastName LIKE 'D%'

/* =========================
   Ejemplo 9
   LIKE - termina con 'N'
   ========================= */
SELECT EmployeeID, LastName
FROM Employees
WHERE LastName LIKE '%N'

/* =========================
   Ejemplo 10
   LIKE - contiene 'SALES' en cualquier posición
   ========================= */
SELECT EmployeeID, LastName, Title
FROM Employees
WHERE Title LIKE '%SALES%'

/* =========================
   Ejemplo 11
   NOT LIKE - no comienza con 'D'
   ========================= */
SELECT EmployeeID, LastName
FROM Employees
WHERE LastName NOT LIKE 'D%'

/* =========================
   Ejemplo 12
   ORDER BY ASC (ascendente)
   ========================= */
SELECT ProductID, ProductName, UnitPrice
FROM Products
ORDER BY ProductID ASC

/* =========================
   Ejemplo 13
   ORDER BY DESC (descendente)
   ========================= */
SELECT ProductID, ProductName, UnitPrice
FROM Products
ORDER BY ProductID DESC

/* =========================
   Ejemplo 14
   DISTINCT - elimina duplicados
   ========================= */
SELECT DISTINCT OrderID
FROM [Order Details]

/* =========================
   Ejemplo 15
   TOP n - primeros 5 registros
   ========================= */
SELECT TOP 5 OrderID, ProductID, Quantity
FROM [Order Details]

/* =========================
   Ejemplo 16
   TOP n PERCENT - 10% de los registros
   ========================= */
SELECT TOP 10 PERCENT OrderID, ProductID, Quantity
FROM [Order Details]

/* =========================
   Ejemplo 17
   AS - alias para renombrar columna
   ========================= */
SELECT CategoryName AS [Nombre de Categoría]
FROM Categories

/* =========================
   Ejemplo 18
   Cálculo de fecha con retraso de 5 días
   ========================= */
SELECT OrderID, OrderDate, ShippedDate, ShippedDate + 5 AS RetrasoEnvio
FROM Orders

/* =========================
   Ejemplo 19
   INNER JOIN: Products con Order Details
   ========================= */
SELECT OD.OrderID, P.ProductID, P.ProductName
FROM Products AS P
INNER JOIN [Order Details] AS OD
  ON P.ProductID = OD.ProductID

/* =========================
   Ejemplo 20
   FULL JOIN: Products y Suppliers (muestra todo aunque no haga match)
   ========================= */
SELECT P.ProductName, S.CompanyName, S.ContactName
FROM Products AS P
FULL JOIN Suppliers AS S
  ON P.SupplierID = S.SupplierID
