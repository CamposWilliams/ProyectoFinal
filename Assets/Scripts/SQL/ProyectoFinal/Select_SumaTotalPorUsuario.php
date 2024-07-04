<?php
header("Content-Type: application/json");
//get
$mysqli = new mysqli("localhost", "root", "", "juegoPuntaje");

if ($mysqli->connect_error) {
    echo json_encode(["error" => "Error de conexión"]);
    exit();
}

if ($_SERVER["REQUEST_METHOD"] == "GET") {
    $sql = "SELECT Usuarios.nombre, SUM(PuntajesFinales.puntaje) AS total_puntaje
            FROM Usuarios
            JOIN PuntajesFinales ON Usuarios.Usuarios_id = PuntajesFinales.Usuarios_id
            GROUP BY Usuarios.nombre";
    $result = $mysqli->query($sql);

    if ($result->num_rows > 0) {
        $totales_puntajes = [];
        while ($row = $result->fetch_assoc()) {
            $totales_puntajes[] = $row;
        }
        echo json_encode(["message" => "Consulta realizada con éxito", "data" => $totales_puntajes]);
    } else {
        echo json_encode(["message" => "No se encontraron datos", "data" => null]);
    }
}

$mysqli->close();
?>