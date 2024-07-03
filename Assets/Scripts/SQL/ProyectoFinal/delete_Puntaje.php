<?php
header("Content-Type: application/json");

$mysqli = new mysqli("localhost", "root", "", "juegoPuntaje");

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    if (isset($_POST["id_PuntajesFinales"])) {
        $idPuntajeFinal = $_POST["id_PuntajesFinales"];

        $checkSql = "SELECT * FROM PuntajesFinales WHERE id_PuntajesFinales = ?";
        $checkQuery = $mysqli->prepare($checkSql);
        $checkQuery->bind_param("i", $idPuntajeFinal);
        $checkQuery->execute();
        $checkResult = $checkQuery->get_result();

        if ($checkResult->num_rows > 0) {
            $deleteSql = "DELETE FROM PuntajesFinales WHERE id_PuntajesFinales = ?";
            $deleteQuery = $mysqli->prepare($deleteSql);
            $deleteQuery->bind_param("i", $idPuntajeFinal);
            $deleteQuery->execute();

            echo json_encode(["message" => "Registro de puntaje eliminado con éxito", "data" => null]);

            $deleteQuery->close();
        } else {
            echo json_encode(["message" => "El registro de puntaje no existe", "data" => null]);
        }

        $checkQuery->close();
    } else {
        echo json_encode(["message" => "ID de puntaje no proporcionado", "data" => null]);
    }
}

$mysqli->close();
?>