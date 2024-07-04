<?php
header("Content-Type: application/json");

$mysqli = new mysqli("localhost", "root", "", "juegoPuntaje");

if ($mysqli->connect_error) {
    echo json_encode(["error" => "Error de conexión"]);
    exit();
}

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $Usuarios_id = $_POST["Usuarios_id"];
    $nuevo_nombre = $_POST["nuevo_nombre"];
    $sql = "UPDATE Usuarios
        SET nombre = ?
        WHERE Usuarios_id = ?
    ";
    $query = $mysqli->prepare($sql);
    $query->bind_param("si", $nuevo_nombre, $Usuarios_id);

    if ($query->execute()) {
        $selectSql = "SELECT PuntajesFinales.*
            FROM PuntajesFinales
            WHERE Usuarios_id = ?
            ORDER BY puntaje DESC";
        $selectQuery = $mysqli->prepare($selectSql);
        $selectQuery->bind_param("i", $Usuarios_id);
        $selectQuery->execute();
        $result = $selectQuery->get_result();

        if ($result->num_rows > 0) {
            $puntuaciones = [];
            while ($row = $result->fetch_assoc()) {
                $puntuaciones[] = $row;
            }
            echo json_encode(["message" => "Usuario actualizado con éxito", "data" => $puntuaciones]);
        } else {
            echo json_encode(["message" => "No se encontraron puntuaciones para el usuario especificado", "data" => null]);
        }

        $selectQuery->close();
    } else {
        echo json_encode(["message" => "Error al actualizar el usuario", "data" => null]);
    }

    $query->close();
}

$mysqli->close();
?>