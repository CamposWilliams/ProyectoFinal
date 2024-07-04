<?php
header("Content-Type: application/json");
//GET
$mysqli = new mysqli("localhost", "root", "", "juegoPuntaje");

if ($mysqli->connect_error) {
    echo json_encode(["error" => "Error de conexión"]);
    exit();
}

if ($_SERVER["REQUEST_METHOD"] == "GET") {
    $sql = "SELECT Usuarios.nombre, PuntajesFinales.puntaje
            FROM Usuarios
            JOIN PuntajesFinales ON Usuarios.Usuarios_id = PuntajesFinales.Usuarios_id
            ORDER BY PuntajesFinales.puntaje DESC";
    $result = $mysqli->query($sql);

    if ($result->num_rows > 0) {
        $puntuaciones = [];
        while ($row = $result->fetch_assoc()) {
            $puntuaciones[] = $row;
        }
        echo json_encode(["message" => "Consulta realizada con éxito", "data" => $puntuaciones]);
    } else {
        echo json_encode(["message" => "No se encontraron datos", "data" => null]);
    }
}

$mysqli->close();
?>