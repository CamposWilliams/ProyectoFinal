DROP DATABASE IF EXISTS juegoPuntaje;
CREATE DATABASE juegoPuntaje;
USE juegoPuntaje;

CREATE TABLE Usuarios
(
    Usuarios_id INT NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(45) NOT NULL,
    PRIMARY KEY (Usuarios_id)
);

CREATE TABLE Niveles
(
    Niveles_id INT NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(45) NOT NULL,
    tiempo VARCHAR(45) NULL,
    PRIMARY KEY (Niveles_id)
);

CREATE TABLE PuntajesFinales
(
    id_PuntajesFinales INT NOT NULL AUTO_INCREMENT,
    Usuarios_id INT NOT NULL,
    Niveles_id INT NOT NULL,
    enemigosAsesinados INT NOT NULL,
    puntaje INT NOT NULL,
    CONSTRAINT fk_PuntajesFinales_Usuarios
    FOREIGN KEY (Usuarios_id)
    REFERENCES Usuarios(Usuarios_id),
    CONSTRAINT fk_PuntajesFinales_Niveles
    FOREIGN KEY (Niveles_id)
    REFERENCES Niveles(Niveles_id),
    PRIMARY KEY (id_PuntajesFinales)
);

INSERT INTO Niveles (Niveles_id, nombre, tiempo) 
VALUES (NULL, "Nivel 1", "01:00");
INSERT INTO Niveles (Niveles_id, nombre, tiempo) 
VALUES (NULL, "Nivel 2", "02:00");

/*LIKE,ORDY BY,GROUP BY,JOIN,SUM,AVG,COUNT*/

/*Encontrar a todos los usuarios con el nombre "Maria" usando LIKE*/
SELECT * FROM Usuarios WHERE nombre LIKE "%Maria%";

/*Ordenar puntajes finales de los usuarios por PromedioFinal usando ORDER BY de forma Descendente*/ 
SELECT * FROM PuntajesFinales ORDER BY puntaje DESC;

/*Obtener el Nombre del Usuario, Nombre del Nivel y Promedio Final usando INNER JOIN*/
SELECT Usuarios.nombre, Niveles.nombre, PuntajesFinales.puntaje
FROM Usuarios
INNER JOIN PuntajesFinales ON Usuarios.Usuarios_id = PuntajesFinales.Usuarios_id
INNER JOIN Niveles ON PuntajesFinales.Niveles_id = Niveles.Niveles_id;

/*Contar la Cantidad de Usuarios que jugaron por Nivel usando GROUP BY y COUNT*/
SELECT Niveles.nombre, COUNT(DISTINCT PuntajesFinales.Usuarios_id) AS CantidadUsuarios
FROM PuntajesFinales
INNER JOIN Niveles ON PuntajesFinales.Niveles_id = Niveles.Niveles_id
GROUP BY Niveles.nombre;

/*Calcular la suma d epuntajes finales por Usuario usando SUM*/
SELECT Usuarios_id, SUM(puntaje) AS TotalPuntaje
FROM PuntajesFinales
GROUP BY Usuarios_id;

/*Promedio de promedio final por nivel usando AVG*/
SELECT Niveles_id, AVG(puntaje) AS PromedioPuntaje
FROM PuntajesFinales
GROUP BY Niveles_id;

/*Contar la Cantidad de Usuarios que han Jugado en Ambos Niveles usando COUNT*/
SELECT COUNT(DISTINCT Usuarios_id) AS CantidadUsuarios
FROM PuntajesFinales
WHERE Niveles_id IN (1, 2);