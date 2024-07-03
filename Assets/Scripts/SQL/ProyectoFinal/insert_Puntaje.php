<?php
header("Content-Type: application/json");

$mysqli = new mysqli("localhost", "root", "", "juegoPuntaje");

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $Usuarios_id = $_POST["Usuarios_id"];
    $Niveles_id = $_POST["Niveles_id"];
    $enemigosAsesinados = $_POST["enemigosAsesinados"];
    $puntaje = $_POST["puntaje"];

    // Verificar la existencia del nivel
    $checkNivelQuery = $mysqli->prepare("SELECT * FROM Niveles WHERE Niveles_id = ?");
    $checkNivelQuery->bind_param("i", $Niveles_id);
    $checkNivelQuery->execute();
    $checkNivelResult = $checkNivelQuery->get_result();

    if ($checkNivelResult->num_rows > 0) {
        // Insertar puntaje
        $insertSql = "INSERT INTO PuntajesFinales (Usuarios_id, Niveles_id, enemigosAsesinados, puntaje) VALUES (?, ?, ?, ?)";
        $insertQuery = $mysqli->prepare($insertSql);
        $insertQuery->bind_param("iiii", $Usuarios_id, $Niveles_id, $enemigosAsesinados, $puntaje);
        $insertQuery->execute();

        echo json_encode(["message" => "Puntaje insertado con Ã©xito", "data" => null]);

        $insertQuery->close();
    } else {
        echo json_encode(["message" => "El nivel especificado no existe", "data" => null]);
    }

    $checkNivelQuery->close();
}

$mysqli->close();
?>