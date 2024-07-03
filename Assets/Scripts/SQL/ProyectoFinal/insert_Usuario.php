<?php
header("Content-Type: application/json");

$mysqli = new mysqli("localhost", "root", "", "juegoPuntaje");

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $nombre = $_POST["nombre"];
    //Inserta Usuario
    $sql = "SELECT * FROM Usuarios WHERE nombre = ?";
    $checkQuery = $mysqli->prepare($sql);
    $checkQuery->bind_param("s", $nombre);
    $checkQuery->execute();
    $checkResult = $checkQuery->get_result();

    if ($checkResult->num_rows > 0) {
        echo json_encode(["message" => "El usuario ya existe", "data" => null]);
    } else {
        $insertSql = "INSERT INTO Usuarios (nombre) VALUES (?)";
        $insertQuery = $mysqli->prepare($insertSql);
        $insertQuery->bind_param("s", $nombre);
        $insertQuery->execute();

        $userId = $insertQuery->insert_id;

        $user = ["user_id" => $userId, "username" => $nombre];

        echo json_encode(["message" => "Usuario insertado con éxito", "data" => ["user" => $user]]);
    }

    $checkQuery->close();
    $insertQuery->close();
}

$mysqli->close();
?>