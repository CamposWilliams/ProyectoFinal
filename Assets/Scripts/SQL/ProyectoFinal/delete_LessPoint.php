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
    $sql = " SELECT id_PuntajesFinales
        FROM PuntajesFinales
        WHERE Usuarios_id = ?
        ORDER BY puntaje ASC";
    $query = $mysqli->prepare($sql);
    $query->bind_param("i", $Usuarios_id);
    $query->execute();
    $result = $query->get_result();

    if ($result->num_rows > 0)
     {
        $row = $result->fetch_assoc();
        $id_PuntajesFinales = $row["id_PuntajesFinales"];

        $deleteSql = "DELETE FROM PuntajesFinales WHERE id_PuntajesFinales = ?";
        $deleteQuery = $mysqli->prepare($deleteSql);
        $deleteQuery->bind_param("i", $id_PuntajesFinales);
        $deleteQuery->execute();

        if ($deleteQuery->affected_rows > 0) {
            echo json_encode(["message" => "Menor puntuación eliminada con éxito", "data" => null]);
        } else {
            echo json_encode(["message" => "Error al eliminar la menor puntuación", "data" => null]);
        }

        $deleteQuery->close();
    } else {
        echo json_encode(["message" => "No se encontraron puntuaciones para el usuario especificado", "data" => null]);
    }

    $query->close();
}

$mysqli->close();
?>