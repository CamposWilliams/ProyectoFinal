<?php
header("Content-Type: application/json");

$mysqli = new mysqli("localhost", "root", "", "juegoPuntaje");

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $idPuntajeFinal = $_POST["id_PuntajesFinales"];
    $enemigosAsesinados = $_POST["enemigosAsesinados"];
    $puntaje = $_POST["puntaje"];

    $checkSql = "SELECT * FROM PuntajesFinales WHERE id_PuntajesFinales = ?";
    $checkQuery = $mysqli->prepare($checkSql);
    $checkQuery->bind_param("i", $idPuntajeFinal);
    $checkQuery->execute();
    $checkResult = $checkQuery->get_result();

    if ($checkResult->num_rows > 0) {
        $updateSql = "UPDATE PuntajesFinales SET enemigosAsesinados = ?, puntaje = ? WHERE id_PuntajesFinales = ?";
        $updateQuery = $mysqli->prepare($updateSql);
        $updateQuery->bind_param("iii", $enemigosAsesinados, $puntaje, $idPuntajeFinal);
        $updateQuery->execute();

        echo json_encode(["message" => "Puntaje final actualizado con éxito", "data" => null]);
        
        $updateQuery->close();
    } else {
        echo json_encode(["message" => "El registro de puntaje no existe", "data" => null]);
    }

    $checkQuery->close();
}

$mysqli->close();
?>