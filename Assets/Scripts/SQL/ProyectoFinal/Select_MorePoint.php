<?php
header("Content-Type: application/json");

$mysqli = new mysqli("localhost", "root", "", "juegoPuntaje");

if ($mysqli->connect_error) {
    echo json_encode(["error" => "Error de conexión"]);
    exit();
}

if ($_SERVER["REQUEST_METHOD"] == "POST") 
{
    $Usuarios_id = $_POST["Usuarios_id"];

    $sql = "SELECT SUM (puntaje) AS MayorPuntaje
        FROM PuntajesFinales
        WHERE Usuarios_id = ?";
    $query = $mysqli->prepare($sql);
    $query->bind_param("i", $Usuarios_id);
    $query->execute();
    $result = $query->get_result();

    if ($result->num_rows > 0) {
        $row = $result->fetch_assoc();
        echo json_encode(["message" => "Mayor puntuación obtenida con éxito", "data" => $row]);
    } else {
        echo json_encode(["message" => "No se encontraron puntuaciones para el usuario especificado", "data" => null]);
    }

    $query->close();
}

$mysqli->close();
?>